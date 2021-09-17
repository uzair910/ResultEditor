using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResultStudio.Common
{
    public struct Vector
    {
        // naming fromat : memeber_TypeAxis
        private double m_dX;

        private double m_dY;

        private double m_dZ;

        public double X
        {
            get { return this.m_dX; }
            set { this.m_dX = value; }
        }

        public double Y
        {
            get { return this.m_dY; }
            set { this.m_dY = value; }
        }

        public double Z
        {
            get { return this.m_dZ; }
            set { this.m_dZ = value; }
        }

        public Vector(double x, double y, double z)
        {
            this.m_dX = x;
            this.m_dY = y;
            this.m_dZ = z;
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
            get { return new double[] { m_dX, m_dY, m_dZ }; }
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
