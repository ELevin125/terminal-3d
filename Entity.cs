using Terminal_3D.Geometry;

namespace Terminal_3D.SceneManagement
{
    public class Entity
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }

        public Entity(Vector3 position, Vector3 rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public void Move(Vector3 delta)
        {
            Position += delta;
        }

        public void Rotate(Vector3 eulerRotation)
        {
            Rotation += eulerRotation;
        }
    }
}
