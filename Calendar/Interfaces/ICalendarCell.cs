using Calendar.Enums;
using Calendar.Model.Geometry;

namespace Calendar.Interfaces
{
    interface ICalendarCell
    {
        Coordinate ValueLocation { get; }
        string Value { get; }
        double ValueTextHeight { get; }
        CellType Type { get; }
        string HelpText1 { get; }
        string HelpText2 { get; }
        string Layer { get; }
        string TextStyle { get; }
    }
}
