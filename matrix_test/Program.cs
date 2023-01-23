using System;
using System.Numerics;

namespace matrix_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix4x4 matrix = new Matrix4x4();

            Vector3 t = new Vector3(1.0f, 2.0f, 3.0f);
            Quaternion r = new Quaternion(7.0f, 8.0f, 9.0f,10.0f); ;
            Vector3 s = new Vector3(4.0f, 5.0f, 6.0f);


            matrix.TRS(t, r, s);


            Console.WriteLine("/t/");
            Console.WriteLine(matrix.m00);
            Console.WriteLine(matrix.m10);
            Console.WriteLine(matrix.m20);
            Console.WriteLine(matrix.m30);

            Console.WriteLine("/r/");
            Console.WriteLine(matrix.m01);
            Console.WriteLine(matrix.m11);
            Console.WriteLine(matrix.m21);
            Console.WriteLine(matrix.m31);

            Console.WriteLine("/s/");
            Console.WriteLine(matrix.m02);
            Console.WriteLine(matrix.m12);
            Console.WriteLine(matrix.m22);
            Console.WriteLine(matrix.m32);


            Console.WriteLine("/なんもないはず/");
            Console.WriteLine(matrix.m03);
            Console.WriteLine(matrix.m13);
            Console.WriteLine(matrix.m13);
            Console.WriteLine(matrix.m13);

            matrix.Inverse();

            Console.WriteLine("/逆行列/");

            Console.WriteLine("/t/");
            Console.WriteLine(matrix.m00);
            Console.WriteLine(matrix.m10);
            Console.WriteLine(matrix.m20);
            Console.WriteLine(matrix.m30);

            Console.WriteLine("/r/");
            Console.WriteLine(matrix.m01);
            Console.WriteLine(matrix.m11);
            Console.WriteLine(matrix.m21);
            Console.WriteLine(matrix.m31);

            Console.WriteLine("/s/");
            Console.WriteLine(matrix.m02);
            Console.WriteLine(matrix.m12);
            Console.WriteLine(matrix.m22);
            Console.WriteLine(matrix.m32);


            Console.WriteLine("/なんもないはず/");
            Console.WriteLine(matrix.m03);
            Console.WriteLine(matrix.m13);
            Console.WriteLine(matrix.m13);
            Console.WriteLine(matrix.m13);


        }
    }
}
