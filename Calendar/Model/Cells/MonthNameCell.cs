using Calendar.Enums;
using Calendar.Model.Calendar;
using Calendar.Model.Geometry;
using System;

namespace Calendar.Model.Cells
{
    class MonthNameCell : CalendarCell
    {
        public MonthNameCell(Month month, Coordinate location, double height, double width)
            : base(location, height, width)
        {
            this.month = month ?? throw new ArgumentNullException(nameof(month) + " can not be null");
        }

        private readonly Month month;
        public override string Value => month.LocalName.ToUpper();
        public override double ValueTextHeight => Grids.GridCalculator.CalculateMonthTextHeight(Height);
        public override CellType Type => CellType.MonthName;
        public override string HelpText1 => month.Year.Number.ToString();
        public override string HelpText2 => month.Number.ToString();

        public override string Layer
        {
            get
            {
                return CellConstants.LayerNames.Month;
            }
        }

        public override string TextStyle
        {
            get
            {
                return CellConstants.TexStyleNames.Month;
            }
        }
    }
}
