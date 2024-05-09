using Terminal_3D.SceneManagement;
using Terminal_3D.Geometry;
using Terminal_3D.Core;
using System.Diagnostics;

namespace Terminal_3D.Rendering
{
    public class Camera : Entity
    {
        private float MoveSpeed = 20f;
        private float RotateSpeed = 0.005f;

        public Camera(Vector3 position, Vector3 rotation) : base(position, rotation)
        {
            InputManager.Instance.KeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    Position += Forward * MoveSpeed;
                    break;
                case ConsoleKey.A:
                    Rotation.Y -= RotateSpeed;
                    break;
                case ConsoleKey.S:
                    Position += Forward * -MoveSpeed;
                    break;
                case ConsoleKey.D:
                    Rotation.Y += RotateSpeed;
                    break;
                default:
                    break;
            }

        }

    }
}
