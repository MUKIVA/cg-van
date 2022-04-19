using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace Lw4
{
    public class DeltoidalHexecontahedron
    {
        private static readonly float _fi = (1f + MathF.Sqrt(5))/ 2f;
        private Random _rnd = new(0);

        private float _size = 2.5f;

        private float[] _vertexBuffer;
        private float[] _colorBuffer;
        private float[] _normalBuffer;
        private Vector4 _specularColor = new(0, 0, 0, 1);
        private float _shininess = 1f;

        private Vector4[] _colors = new Vector4[5]
            {
                new(0, 0, 1, 1),
                new(0, 1, 0, 1),
                new(0, 1, 1, 1),
                new(1, 0, 0, 1),
                new(1, 0, 1, 1),
            };

        // Правильный додекаэдр
        private List<Vector3> _points = new()
        {
            new(-1, -1, -1),          // 0
            new(+1, -1, -1),          // 1
            new(+1, +1, -1),          // 2
            new(-1, +1, -1),          // 3
            new(-1, -1, +1),          // 4
            new(+1, -1, +1),          // 5
            new(+1, +1, +1),          // 6
            new(-1, +1, +1),          // 7
            new(0, +_fi, +(1 / _fi)), // 8 
            new(0, +_fi, -(1 / _fi)), // 9
            new(0, -_fi, +(1 / _fi)), // 10
            new(0, -_fi, -(1 / _fi)), // 11
            new(+(1 / _fi), 0, +_fi), // 12 
            new(+(1 / _fi), 0, -_fi), // 13
            new(-(1 / _fi), 0, +_fi), // 14
            new(-(1 / _fi), 0, -_fi), // 15
            new(+_fi, +(1 / _fi), 0), // 16
            new(+_fi, -(1 / _fi), 0), // 17
            new(-_fi, +(1 / _fi), 0), // 18
            new(-_fi, -(1 / _fi), 0)  // 19
        };

        // Обход граней додекаэдра
        private List<int[]> _sides = new()
        {
            new int[5] { 0, 15, 13, 1, 11 }, // 0
            new int[5] { 0, 11, 10, 4, 19 }, // 1
            new int[5] { 0, 19, 18, 3, 15 }, // 2
            new int[5] { 1, 17, 5, 10, 11 }, // 3
            new int[5] { 1, 13, 2, 16, 17 }, // 4
            new int[5] { 2, 9,  8,  6, 16 }, // 7
            new int[5] { 2, 13, 15, 3, 9  }, // 8
            new int[5] { 3, 18, 7,  8, 9  }, // 11
            new int[5] { 4, 14, 7, 18, 19 }, // 13
            new int[5] { 4, 10, 5, 12, 14 }, // 14
            new int[5] { 5, 17, 16, 6, 12 }, // 16
            new int[5] { 6, 8, 7, 14, 12  }, // 20 
        };

        private Dictionary<Vector3, int[]> _flowerCenters = new();

        public DeltoidalHexecontahedron()
        {
            // Находим центры граней, для построения дельтоид
            foreach (var side in _sides)
            {
                Vector3 center = Vector3.Zero;
                foreach (var point in side)
                    center += _points[point];
                center.Normalize();
                _flowerCenters.Add(center, side);
            }
            List<float> vertexBuffer = new();
            List<float> colorBuffrer = new();
            List<float> normalBuffer = new();
            // Обходим каждый цветок
            foreach (var flower in _flowerCenters)
            {
                // Строим точки дельтоид
                for (int i = 0; i < flower.Value.Length; i++)
                {
                    int j = (i + 1) % flower.Value.Length;
                    int l = (i + 2) % flower.Value.Length;
                    //Добавляем точки
                    AddVector3(vertexBuffer, flower.Key * _size);
                    AddVector3(vertexBuffer, Vector3.Lerp(_points[flower.Value[i]], _points[flower.Value[j]], 0.5f).Normalized() * _size);
                    AddVector3(vertexBuffer, _points[flower.Value[j]].Normalized() * _size);
                    AddVector3(vertexBuffer, Vector3.Lerp(_points[flower.Value[j]], _points[flower.Value[l]], 0.5f).Normalized() * _size);
                    //Добавляем цвета
                    Vector4 color = new(
                        (float)_rnd.NextDouble(),
                        (float)_rnd.NextDouble(),
                        (float)_rnd.NextDouble(), 1f);
                    AddVector4(colorBuffrer, color);
                    AddVector4(colorBuffrer, color);
                    AddVector4(colorBuffrer, color);
                    AddVector4(colorBuffrer, color);
                    //Расчет нормалей
                    var v01 = _points[flower.Value[0]] - flower.Key;
                    var v02 = _points[flower.Value[1]] - flower.Key;
                    var normal = Vector3.Normalize(Vector3.Cross(v01, v02));
                    AddVector3(normalBuffer, normal);
                    AddVector3(normalBuffer, normal);
                    AddVector3(normalBuffer, normal);
                    AddVector3(normalBuffer, normal);
                }
            }
            // Сохранение даннных
            _vertexBuffer = vertexBuffer.ToArray();           
            _colorBuffer = colorBuffrer.ToArray();
            _normalBuffer = normalBuffer.ToArray();
        }

        public void Draw()
        {
            GL.Enable(EnableCap.ColorMaterial);
            GL.ColorMaterial(MaterialFace.FrontAndBack, ColorMaterialParameter.AmbientAndDiffuse);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, _specularColor);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, _shininess);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(3, VertexPointerType.Float, 0, _vertexBuffer);
            GL.EnableClientState(ArrayCap.ColorArray);
            GL.ColorPointer(4, ColorPointerType.Float, 0, _colorBuffer);
            GL.EnableClientState(ArrayCap.NormalArray);
            GL.NormalPointer(NormalPointerType.Float, 0, _normalBuffer);
            {
                GL.DrawArrays(PrimitiveType.Quads, 0, _vertexBuffer.Length / 3);
            }
            GL.DisableClientState(ArrayCap.ColorArray);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.NormalArray);
        }

        public void SetSpecularColor(Vector4 color) => _specularColor = color;
        public void SetShininess(float shininess) => _shininess = shininess;

        private void AddVector3(List<float> buffer, Vector3 v)
        {
            buffer.Add(v.X); buffer.Add(v.Y); buffer.Add(v.Z);
        }

        private void AddVector4(List<float> buffer, Vector4 v)
        {
            buffer.Add(v.X); buffer.Add(v.Y); buffer.Add(v.Z); buffer.Add(v.W);
        }
    }
}
