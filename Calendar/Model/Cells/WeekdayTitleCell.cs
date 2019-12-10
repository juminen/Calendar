using Calendar.Enums;
using Calendar.Model.Geometry;

namespace Calendar.Model.Cells
{
    class WeekdayTitleCell : CalendarCell
    {
        public WeekdayTitleCell(string value, Coordinate location, double size)
            : base(location, size, size)
        {
            this.value = value;
        }

        private readonly string value;
        public override string Value => value;
        public override double ValueTextHeight => Grids.GridCalculator.CalculateDayTextHeight(Height);
        public override CellType Type => CellType.WeekDayTitle;
        public override string HelpText1 => string.Empty;
        public override string HelpText2 => string.Empty;

        public override string Layer
        {
            get
            {
                if (value.Equals("VKO"))
                {
                    return CellConstants.LayerNames.WeekTitleWeek;
                }
                else if (value.Equals("SU"))
                {
                    return CellConstants.LayerNames.WeekTitleSunday;
                }
                else
                {
                    return CellConstants.LayerNames.WeekTitleMondaySaturday;
                }                
            }
        }


        public override string TextStyle
        {
            get
            {
                return CellConstants.TexStyleNames.WeekTitle;
            }
        }
    }
}
