using Terminal_3D.SceneManagement;
using Terminal_3D.Geometry;
using Terminal_3D.Core;

namespace Terminal_3D.Rendering
{
    public class Camera : Entity
    {
        private float MoveSpeed = 20f;
        private float RotateSpeed = 0.01f;

        public int screenDistance = 70;

        public Camera(Vector3 position, Vector3 rotation) : base(position, rotation)
        {
            InputManager.Instance.KeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    Move(Forward * MoveSpeed);
                    break;
                case ConsoleKey.A:
                    Rotate(new Vector3(0, -RotateSpeed, 0));
                    break;
                case ConsoleKey.S:
                    Move(Forward * -MoveSpeed);
                    break;
                case ConsoleKey.D:
                    Rotate(new Vector3(0, RotateSpeed, 0));
                    break;
                default:
                    break;

            }

        }

    }
}
