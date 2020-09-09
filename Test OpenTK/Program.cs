// C# example program to demonstrate OpenTK
//
// Steps:
// 1. Create an empty C# console application project in Visual Studio
// 2. Place OpenTK.dll in the directory of the C# source file
// 3. Add System.Drawing and OpenTK as References to the project
// 4. Paste this source code into the C# source file
// 5. Run. You should see a colored triangle. Press ESC to quit.
//
// Copyright (c) 2013 Ashwin Nanjappa
// Released under the MIT License

using System;
using System.Reflection;
using LearnOpenTK.Common;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Test_OpenTK;

namespace StarterKit
{
    class Game : GameWindow
    {
        Cube cube = new Cube();
        Player player = new Player();
        Camera cam;

        private bool _firstMove = true;
        private Vector2 _lastPos;

        const float cameraSpeed = 1.5f;
        const float sensitivity = 0.2f;

        public Game()
            : base(800, 600, GraphicsMode.Default, "OpenTK Quick Start Sample")
        {
            VSync = VSyncMode.Off;
        }

        protected override void OnLoad(EventArgs e)
        {

            cam = new Camera(Vector3.UnitZ * 3, Width / (float)Height);

            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {


            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            cam.AspectRatio = Width / (float)Height;

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            base.OnResize(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            #region Mov
            var input = Keyboard.GetState();

            //Console.WriteLine("Camera Position: " + cam.Position + " " + "projection matrix mode: " + cam.GetProjectionMatrix());

            if (input.IsKeyDown(Key.W))
            {
                cam.Position += cam.Front * cameraSpeed * (float)e.Time; // Forward
            }
            if (input.IsKeyDown(Key.S))
            {
                cam.Position -= cam.Front * cameraSpeed * (float)e.Time; // Backwards
            }
            if (input.IsKeyDown(Key.A))
            {
                cam.Position -= cam.Right * cameraSpeed * (float)e.Time; // Left
            }
            if (input.IsKeyDown(Key.D))
            {
                cam.Position += cam.Right * cameraSpeed * (float)e.Time; // Right
            }
            if (input.IsKeyDown(Key.Space))
            {
                cam.Position += cam.Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Key.LShift))
            {
                cam.Position -= cam.Up * cameraSpeed * (float)e.Time; // Down
            }
            #endregion


            #region CamRot
            //get the mouse state
            var mouse = Mouse.GetState();

            if (_firstMove) // this bool variable is initially set to true
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                // Calculate the offset of the mouse position
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);

                // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                cam.Yaw += deltaX * sensitivity;
                cam.Pitch -= deltaY * sensitivity; // reversed since y-coordinates range from bottom to top
            }
            #endregion

            if (Keyboard.GetState().IsKeyDown(Key.Escape))
                Exit();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 _model = Matrix4.Identity;
            Matrix4 _projection = Matrix4.CreatePerspectiveFieldOfView(1.0f, 4.0f / 3.0f, 0.1f, 100.0f);
            Matrix4 modelview = _model * cam.GetViewMatrix() * _projection;

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref modelview);

            CreateObjects();

            SwapBuffers();
        }
        float cubeY;
        void CreateObjects()
        {
            cubeY = cubeY - 0.01f;
            //cube.CubesetPos(5, cubeY, 5);
            //Console.WriteLine("Cube Pos: " + cube.GetCubePos());
            GL.Begin(PrimitiveType.Quads);
            for (int i = cube.cube.Length - 1; i >= 0; i--)
            {
                GL.Color3(1.0f, 1.0f, 1.0f); GL.Vertex3(cube.cube[i]);
            }
            GL.End();

            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(5.0f, 1.0f + cubeY, 1.0f);
            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(6.0f, 0.0f + cubeY, 1.0f);
            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(6.0f, 1.0f + cubeY, 1.0f);
            GL.End();

            /*GL.Begin(PrimitiveType.Triangles);
            for (int i = cube.Triangle.Length - 1; i >= 0; i--)
            {
                GL.Color3(0.0f, 1.0f, 1.0f); GL.Vertex3(cube.Triangle[i]);
            }
            GL.End();*;*/
        }

        [STAThread]
        static void Main()
        {
            // The 'using' idiom guarantees proper resource cleanup.
            // We request 30 UpdateFrame events per second, and unlimited
            // RenderFrame events (as fast as the computer can handle).
            using (Game game = new Game())
            {
                game.Run(30.0);
            }
        }
    }
}
