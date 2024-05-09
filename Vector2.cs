
namespace Terminal_3D.Geometry
{
    public class Vector2
    {
        public float X;
        public float Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 Zero
        {
            get { return new Vector2(0, 0); }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
