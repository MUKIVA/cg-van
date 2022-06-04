using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lw7.Mathematics;

namespace Lw7.Model
{
    public class GeometryObjectImpl : IGeometryObject
    {
        private Mat4d _transform = Mat4d.Identity;
        private Mat3d _normalMatrix = Mat3d.Identity;
        private Mat4d _invTransform = Mat4d.Identity;

        public GeometryObjectImpl()
        {
            SetTransform(Mat4d.Identity);
        }

        public GeometryObjectImpl(Mat4d transform)
        {
            SetTransform(transform);
        }

        public Mat4d GetTransform()
        {
            return _transform;
        }

        public void SetTransform(Mat4d transform)
        {
            _transform = transform;
            _invTransform = transform.GetInverseMatrix();

            _normalMatrix.SetRow(0, _transform.GetRow(0).XYZ);
            _normalMatrix.SetRow(1, _transform.GetRow(1).XYZ);
            _normalMatrix.SetRow(2, _transform.GetRow(2).XYZ);

            OnUpdateTransform();
        }

        public virtual Mat4d GetInverseTransform()
        {
            return _invTransform;
        }

        public Mat3d GetNormalMatrix()
        {
            return _normalMatrix;
        }

        public virtual bool Hit(Ray ray, Intersection intersection)
        {
            return false; 
        }

        protected virtual void OnUpdateTransform()
        {
            
        }
    }
}
