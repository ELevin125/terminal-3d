namespace Terminal_3D.Geometry
{
    public class Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 Add(Vector3 other)
        {
            return new Vector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        public Vector3 Subtract(Vector3 other)
        {
            return new Vector3(X - other.X, Y - other.Y, Z - other.Z);
        }

        public Vector3 Multiply(float scalar)
        {
            return new Vector3(X * scalar, Y * scalar, Z * scalar);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector3 Normalize()
        {
            float magnitude = Magnitude();
            if (magnitude == 0)
                return new Vector3(0, 0, 0);
            return new Vector3(X / magnitude, Y / magnitude, Z / magnitude);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
