using OpenTK;
using OpenTK.Graphics.ES10;
using OpenTK.Graphics.ES11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OpenTK
{
    public class Cube
    {

        public static Vector3 CubePos = Vector3.Zero;

        public void CubesetPos(float X,float Y, float Z)
        {
            CubePos.X = X;
            CubePos.Y = Y;
            CubePos.Z = Z;
        }

        public Vector3 GetCubePos()
        {
            return new Vector3(CubePos.X, CubePos.Y, CubePos.Z);
        }

        public Vector3[] cube = new Vector3[24]
        {
            new Vector3(1.0f + CubePos.X, 1.0f + CubePos.Y, -1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, 1.0f + CubePos.Y, -1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, 1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(1.0f + CubePos.X, 1.0f + CubePos.Y, 1.0f + CubePos.Z),

            new Vector3(1.0f + CubePos.X, -1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, -1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, -1.0f + CubePos.Y, -1.0f + CubePos.Z),
            new Vector3(1.0f + CubePos.X, -1.0f + CubePos.Y, -1.0f + CubePos.Z),

            new Vector3(1.0f + CubePos.X, 1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, 1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, -1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(1.0f + CubePos.X, -1.0f + CubePos.Y, 1.0f + CubePos.Z),

            // Back face (z = -1.0f)
            new Vector3(1.0f  + CubePos.X, -1.0f + CubePos.Y, -1.0f +  CubePos.Z),
            new Vector3(-1.0f + CubePos.X, -1.0f + CubePos.Y, -1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, 1.0f + CubePos.Y, -1.0f + CubePos.Z),
            new Vector3(1.0f + CubePos.X, 1.0f + CubePos.Y, -1.0f + CubePos.Z),

            // Left face (x = -1.0f)
            new Vector3(-1.0f + CubePos.X, 1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, 1.0f + CubePos.Y, -1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, -1.0f + CubePos.Y, -1.0f + CubePos.Z),
            new Vector3(-1.0f + CubePos.X, -1.0f + CubePos.Y, 1.0f + CubePos.Z),
    
            // Right face (x = 1.0f)
            new Vector3(1.0f + CubePos.X, 1.0f + CubePos.Y, -1.0f + CubePos.Z),
            new Vector3(1.0f + CubePos.X, 1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(1.0f + CubePos.X, -1.0f + CubePos.Y, 1.0f + CubePos.Z),
            new Vector3(1.0f + CubePos.X, -1.0f + CubePos.Y, -1.0f + CubePos.Z),
        };

        public Vector3[] Triangle = new Vector3[3]
        {
            new Vector3(5.0f, 1.0f, 1.0f),
            new Vector3(6.0f, 0.0f, 1.0f),
            new Vector3(6.0f, 1.0f, 1.0f)
        };

    }
}
