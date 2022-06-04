using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lw7.Mathematics;

namespace Lw7.Model
{
    public class RenderContext
    {
        private Mat4d _projectionMatrix = Mat4d.Identity;
        private Mat4d _modelViewMatrix = Mat4d.Identity;
        private Mat4d _inverseModelViewProjMatrix = Mat4d.Identity;
        private Vec3d _cameraPos = Vec3d.Zero;
        private ViewPort _viewPort = new();

        public RenderContext()
        { 
        }

        public Vec3d GetCameraPos()
        {
            return _cameraPos;
        }

        public UInt32 CalculatePixelColor(Scene scene, int x, int y)
        {
            if (!_viewPort.TestPoint(x, y))
            {
                return 0x000000;
            }

            Vec2d pixelCenter = GetNormalizedViewportCoord(x + 0.5, y + 0.5);

            Vec3d rayStart = UnProject(pixelCenter.X, pixelCenter.Y, 0);
            Vec3d rayEnd = UnProject(pixelCenter.X, pixelCenter.Y, 1);

            Vec3d rayDirection = rayEnd - rayStart;

            Vec4d color = scene.Shade(new Ray(rayStart, rayDirection));

            Vec4d clampedColor = MathHelper.Clamp(color, 0.0, 1.0);

            UInt32 r = (UInt32)(clampedColor.X * 255);
            UInt32 g = (UInt32)(clampedColor.Y * 255);
            UInt32 b = (UInt32)(clampedColor.Z * 255);
            UInt32 a = (UInt32)(clampedColor.W * 255);

            return (a << 24) | (r << 16) | (g << 8) | b;
        }

        public void SetViewPort(ViewPort viewPort)
        {
            _viewPort = viewPort;
        }

        public void SetProjectionMatrix(Mat4d projectionMatrix)
        {
            _projectionMatrix = projectionMatrix;
            UpdateInverseModelViewProjectionMatrix();
        }

        public void SetModelViewMatrix(Mat4d modelViewMatrix)
        {
            _modelViewMatrix = modelViewMatrix;
            UpdateInverseModelViewProjectionMatrix();
        }

        private Vec2d GetNormalizedViewportCoord(double x, double y)
        {
            double viewportCenterX = (_viewPort.Left + _viewPort.Right) * 0.5;
            double viewportCenterY = (_viewPort.Top + _viewPort.Bottom) * 0.5;

            double xNormalized = 2 * (x - viewportCenterX) / _viewPort.Width;
            double yNormalized = -2 * (y - viewportCenterY) / _viewPort.Height;

            return new(xNormalized, yNormalized);
        }

        private Mat4d GetInverseModelViewProjectionMatrix()
        {
            return _inverseModelViewProjMatrix;   
        }

        private Vec3d UnProject(double normalizedX, double normalizedY, double depth)
        {
            Mat4d invModelViewProj = GetInverseModelViewProjectionMatrix();

            double normalizedZ = depth * 2 - 1;

            Vec4d pos = new Vec4d(normalizedX, normalizedY, normalizedZ, 1) * invModelViewProj;

            return pos.Project();
        }

        private void UpdateInverseModelViewProjectionMatrix()
        {
            _inverseModelViewProjMatrix = (_modelViewMatrix * _projectionMatrix).GetInverseMatrix();
        }

    }
}
