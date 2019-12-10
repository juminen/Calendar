using Calendar.Enums;
using Calendar.Model.Calendar;
using Calendar.Model.Geometry;
using System;

namespace Calendar.Model.Cells
{
    class YearCell : CalendarCell
    {
        public YearCell(Year year, Coordinate location, double height, double width)
            : base(location, height, width)
        {
            this.year = year ?? throw new ArgumentNullException(nameof(year) + " can not be null");
        }

        private readonly Year year;
        public override string Value => year.Number.ToString();
        public override double ValueTextHeight => Grids.GridCalculator.CalculateYearTextHeight(Height);
        public override CellType Type => CellType.Year;
        public override string HelpText1 => string.Empty;
        public override string HelpText2 => string.Empty;

        public override string Layer
        {
            get
            {
                return CellConstants.LayerNames.Year;
            }
        }

        public override string TextStyle
        {
            get
            {
                return CellConstants.TexStyleNames.Year;
            }
        }
    }
}
