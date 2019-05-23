using System;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Matrices
{
    public class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Matrix(Point p)
        {
            return new Matrix
            {
                {p.X },
                {p.Y },
                {1 }
            };
        }

        public static implicit operator Point(Matrix m)
        {
            return new Point((int)m[0,0],(int)m[1,0]);
        }

        public override string ToString()
        {
            return $"({X},{Y}";
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
