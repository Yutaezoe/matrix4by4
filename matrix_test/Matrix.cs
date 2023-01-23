using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Numerics;

namespace matrix_test
{
    public partial struct Matrix4x4
    {
        // memory layout:
        //
        //                row no (=vertical)
        //               |  0   1   2   3
        //            ---+----------------
        //            0  | m00 m10 m20 m30
        // column no  1  | m01 m11 m21 m31
        // (=horiz)   2  | m02 m12 m22 m32
        //            3  | m03 m13 m23 m33


        public float m00;
        public float m10;
        public float m20;
        public float m30;


        public float m01;
        public float m11;
        public float m21;
        public float m31;

        
        public float m02;
        public float m12;
        public float m22;
        public float m32;

        
        public float m03;
        public float m13;
        public float m23;
        public float m33;

        public Matrix4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            this.m00 = column0.X; this.m01 = column1.X; this.m02 = column2.X; this.m03 = column3.X;
            this.m10 = column0.Y; this.m11 = column1.Y; this.m12 = column2.Y; this.m13 = column3.Y;
            this.m20 = column0.Z; this.m21 = column1.Z; this.m22 = column2.Z; this.m23 = column3.Z;
            this.m30 = column0.W; this.m31 = column1.W; this.m32 = column2.W; this.m33 = column3.W;
        }

        public void TRS(Vector3 t , Quaternion r , Vector3 s)
        {

            System.Numerics.Matrix4x4 matrix = new System.Numerics.Matrix4x4();

            matrix.M11 = (1.0f - 2.0f * (r.Y * r.Y + r.Z * r.Z)) * s.X;
            matrix.M12 = (r.X * r.Y + r.Z * r.W) * s.X * 2.0f;
            matrix.M13 = (r.X * r.Z - r.Y * r.W) * s.X * 2.0f;
            matrix.M14 = 0.0f;
            matrix.M21 = (r.X * r.Y - r.Z * r.W) * s.Y * 2.0f;
            matrix.M22 = (1.0f - 2.0f * (r.X * r.X + r.Z * r.Z)) * s.Y;
            matrix.M23 = (r.Y * r.Z + r.X * r.W) * s.Y * 2.0f;
            matrix.M24 = 0.0f;
            matrix.M31 = (r.X * r.Z + r.Y * r.W) * s.Z * 2.0f;
            matrix.M32 = (r.Y * r.Z - r.X * r.W) * s.Z * 2.0f;
            matrix.M33 = (1.0f - 2.0f * (r.X * r.X + r.Y * r.Y)) * s.Z;
            matrix.M34 = 0.0f;
            matrix.M41 = t.X;
            matrix.M42 = t.Y;
            matrix.M43 = t.Z;
            matrix.M44 = 1.0f;

            this.ChangeMatrix4x4(matrix);

        }

        public void Inverse()
        {

            System.Numerics.Matrix4x4 matrix4X4 = new System.Numerics.Matrix4x4(m00,m10,m20,m30,m01,m11,m21,m31,m02,m12,m22,m32,m03,m13,m23,m33);

            System.Numerics.Matrix4x4 result = new System.Numerics.Matrix4x4();

            System.Numerics.Matrix4x4.Invert(matrix4X4, out result);

            ChangeMatrix4x4(result);

        }

        private void ChangeMatrix4x4(System.Numerics.Matrix4x4 matrix4x4)
        {
            this.m00 = matrix4x4.M11; this.m01 = matrix4x4.M21; this.m02 = matrix4x4.M31; this.m03 = matrix4x4.M41;
            this.m10 = matrix4x4.M12; this.m11 = matrix4x4.M22; this.m12 = matrix4x4.M32; this.m13 = matrix4x4.M41;
            this.m20 = matrix4x4.M13; this.m21 = matrix4x4.M23; this.m22 = matrix4x4.M33; this.m23 = matrix4x4.M41;
            this.m30 = matrix4x4.M14; this.m31 = matrix4x4.M24; this.m32 = matrix4x4.M34; this.m33 = matrix4x4.M41;

        }


    }

   


}
