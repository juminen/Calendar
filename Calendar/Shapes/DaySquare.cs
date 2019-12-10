using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Shapes
{
    class DaySquare : Square
    {
        #region constructors
        public DaySquare(Coordinate location, double size) : base(location, size)
        {
            CalculateTextLocation();
        }
        #endregion

        #region properties
        public Coordinate TextLocation { get; private set; }
        #endregion

        #region methods
        private void CalculateTextLocation()
        {
            double x = TopLeftLocation.X + Width / 2;
            double y = TopLeftLocation.Y - Width / 2;
            TextLocation = new Coordinate(x, y, 0);
        }
        #endregion

        #region events
        #endregion

        #region event handlers
        #endregion

    }
}
