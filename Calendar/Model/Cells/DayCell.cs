using Calendar.Enums;
using Calendar.Model.Calendar;
using Calendar.Model.Geometry;
using System;

namespace Calendar.Model.Cells
{
    class DayCell : CalendarCell
    {
        public DayCell(Day day, Coordinate location, double size)
            : base(location, size, size)
        {
            this.day = day ?? throw new ArgumentNullException(nameof(day) + " can not be null");
        }

        private readonly Day day;
        public override string Value => day.Date.Day.ToString();
        public override double ValueTextHeight => Grids.GridCalculator.CalculateDayTextHeight(Height);
        public override CellType Type => CellType.Day;
        public override string HelpText1 => day.Date.ToString("dd.MM.yyyy");
        public override string HelpText2 => day.LocalName;

        public override string Layer
        {
            get
            {
                if (day.IsHoliday || day.WeekDayNumber == 7)
                {
                    return CellConstants.LayerNames.SaintDay;
                }
                return CellConstants.LayerNames.Day;
            }
        }


        public override string TextStyle
        {
            get
            {
                return CellConstants.TexStyleNames.Number;
            }
        }
    }
}