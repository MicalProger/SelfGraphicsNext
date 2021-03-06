using SelfGraphicsNext.BaseGraphics;
using SFML.Graphics;

namespace SelfGraphicsNext.RayGraphics.Graphics3D.Geometry
{
    public class Point3
    {
        public static Point3 Zero = new Point3(0, 0, 0);
        public static Point3 One = new Point3(1, 1, 1);
        public double Lenght => (X.Pow() + Y.Pow() + Z.Pow()).Sqrt();
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Distance { get; set; }
        public Color Color { get; set; } = Color.White;
        public Point3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }


        public Point3(Point xy)
        {
            X = xy.X;
            Y = xy.Y;
            Z = 0;
        }
        public Point3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3(double x, double y, double z, Color color) : this(x, y, z)
        {
            Color = color;
        }
        public Point3 Rounded(int k = 4)
        {
            return new Point3(X.Round(k), Y.Round(k), Z.Round(k), Color);
        }

        public void Round(int k = 4)
        {
            X.Round(k);
            Y.Round(k);
            Z.Round(k);
        }
        public static Point3 operator +(Point3 point1, Point3 point2) => new Point3(point1.X + point2.X, point1.Y + point2.Y, point1.Z + point2.Z, point1.Color);

        public static Point3 operator -(Point3 point1, Point3 point2) => new Point3(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z, point1.Color);

        public static Point3 operator *(Point3 point1, double k) => new Point3(point1.X * k, point1.Y * k, point1.Z * k, point1.Color);

        public static bool operator ==(Point3 point1, Point3 point2) => point1.Equals(point2);

        public static bool operator !=(Point3 point1, Point3 point2) => !point1.Equals(point2);

        public void SetDistanceTo(Point3 p) => Distance = (this - p).Lenght;

        public double GetDistanceTo(Point3 p) => (this - p).Lenght;

        public override string ToString()
        {
            return $"[{X.Round()}:{Y.Round()}:{Z.Round()}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null && this is null)
                return true;
            if (obj == null)
                return false;
            if (!(obj is Point3))
                return false;
            Point3 p = (Point3)obj;
            return p.X == X && p.Y == Y && p.Z == Z;
        }
        public Point3 Normalised()
        {
            var len = this.GetDistanceTo(Point3.Zero);
            return this * (1 / len);
        }

        public double ScalarMul(Point3 vec)
        {
            return X * vec.X + Y * vec.Y + Z * vec.Z;
        }
    }
}
