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

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator *(Vector2 vector, float scalar)
        {
            return new Vector2(vector.X * scalar, vector.Y * scalar);
        }

        public static Vector2 operator *(float scalar, Vector2 vector)
        {
            return vector * scalar;
        }

        public static float Dot(Vector2 a, Vector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public Vector2 Normalize()
        {
            float magnitude = Magnitude();
            if (magnitude == 0)
                return new Vector2(0, 0);
            return new Vector2(X / magnitude, Y / magnitude);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            return (a - b).Magnitude();
        }
    }
}
