using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResultStudio.Common
{
    public struct Vector
    {
        private readonly double x;

        private readonly double y;

        private readonly double z;

        public double X
        {
            get { return this.x; }
        }

        public double Y
        {
            get { return this.y; }
        }

        public double Z
        {
            get { return this.z; }
        }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            return new Vector(
               v1.X + v2.X,
               v1.Y + v2.Y,
               v1.Z + v2.Z);
        }

        public static Vector Subtract(Vector v1, Vector v2)
        {
            return new Vector(
               v1.X - v2.X,
               v1.Y - v2.Y,
               v1.Z - v2.Z);
        }

        // Not sure if i need these. TBD. Uzair
        public double[] Array
        {
            get { return new double[] { x, y, z }; }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: { return X; }
                    case 1: { return Y; }
                    case 2: { return Z; }
                    default: throw new ArgumentException(Properties.Resources.sErrTextInvalidVector, "index");
                }
            }
        }
    }
}
