using Calendar.Enums;
using Calendar.Model.Calendar;
using Calendar.Model.Geometry;
using System;

namespace Calendar.Model.Cells
{
    class WeekNumberCell : CalendarCell
    {
        public WeekNumberCell(Week week, Coordinate location, double size)
            : base(location, size, size)
        {
            this.week = week ?? throw new ArgumentNullException(nameof(week) + " can not be null");
        }

        private readonly Week week;
        public override string Value => week.Number.ToString();
        public override double ValueTextHeight => Grids.GridCalculator.CalculateDayTextHeight(Height);
        public override CellType Type => CellType.WeekNumber;
        public override string HelpText1 => week.Identifier;
        public override string HelpText2 => string.Empty;

        public override string Layer
        {
            get
            {
                return CellConstants.LayerNames.WeekNumber;
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
