using JM.General;

namespace Calendar.Shapes
{
    class Coordinate : ObservableObject
    {
        #region constructors
        public Coordinate()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Coordinate(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #endregion constructors

        #region properties
        private double x;
        public double X
        {
            get { return x; }
            set { SetProperty(ref x, value); }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { SetProperty(ref y, value); }
        }

        private double z;
        public double Z
        {
            get { return z; }
            set { SetProperty(ref z, value); }
        }
        #endregion properties

        #region methods
        #endregion methods

    }
}
