using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Classes.Game
{
    public struct Coordinate: IEquatable<Coordinate>
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            if (!Coordinate.ExistingCoordinate(x, y))
                throw new ArgumentOutOfRangeException("Invalid coordinate values");

            X = x;
            Y = y;
        }

        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public static bool ExistingCoordinate(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7) return false;
            return true;
        }
    }
}
