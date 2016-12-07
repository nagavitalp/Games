using System;

namespace Vital.Games
{
    public class Coordinate : IEquatable<Coordinate>,ICloneable
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
        
        
        public bool Equals(Coordinate other)
        {
            if (other == null)
            {
                return false;
            }

            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
