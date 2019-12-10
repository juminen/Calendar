using Calendar.Enums;
using Calendar.Interfaces;
using Calendar.Model.Geometry;

namespace Calendar.Model.Cells
{
    abstract class CalendarCell : Rectangle, ICalendarCell
    {
        public CalendarCell(Coordinate location, double height, double width)
            : base(location, height, width)
        {
            CalculateValueLocation();
        }
        public Coordinate ValueLocation { get; private set; }
        public abstract string Value { get; }
        public abstract double ValueTextHeight { get; }
        public abstract CellType Type { get; }
        public abstract string HelpText1 { get; }
        public abstract string HelpText2 { get; }
        public abstract string Layer { get; }
        public abstract string TextStyle { get; }

        private void CalculateValueLocation()
        {
            double X = TopLeftLocation.X + Width / 2;
            double Y = TopLeftLocation.Y - Height / 2;
            ValueLocation = new Coordinate(X, Y, 0);
        }
    }
}
