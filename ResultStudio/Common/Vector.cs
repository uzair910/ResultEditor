namespace ResultStudio.Common
{
    public struct Vector
    {
        private double _dX;
        private double _dY;
        private double _dZ;

        public double X
        {
            get { return this._dX; }
            set { this._dX = value; }
        }

        public double Y
        {
            get { return this._dY; }
            set { this._dY = value; }
        }

        public double Z
        {
            get { return this._dZ; }
            set { this._dZ = value; }
        }
    }
}
