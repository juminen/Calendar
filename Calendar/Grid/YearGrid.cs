using Calendar.Shapes;
using JM.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Grid
{
    class YearGrid : Rectangle
    {
        #region constructors
        public YearGrid(Coordinate topLeftLocation, double height, double width)
            : base(topLeftLocation, height, width)
        {

        }
        //public YearGrid(YearGridSettings yearGridSettings)
        //{
        //    Settings = yearGridSettings ?? throw new ArgumentNullException(nameof(yearGridSettings) + " can not be null");
        //    CalculateGridSize();
        //    CalculateYearTextLocation();
        //}
        #endregion

        #region properties
        //private readonly YearGridSettings settings;
        //public YearGridSettings Settings { get; private set; }
        public Coordinate YearTextLocation { get; private set; }

        #endregion

        #region methods
        //private void CalculateGridSize()
        //{
        //    double X = Settings.ColumnCount * 8 * Settings.SquareSize;
        //    if (Settings.ColumnCount > 1)
        //    {
        //        double gapWidth = Settings.SquareSize * Settings.ColumnCount - 1;
        //        X = X + gapWidth;
        //    }
        //    Width = X;

        //    double Y = 2 * Settings.SquareSize + Settings.RowCount * 8 * Settings.SquareSize;
        //    if (Settings.RowCount > 1)
        //    {
        //        double gapHeight = Settings.SquareSize * Settings.RowCount - 1;
        //        Y = Y + gapHeight;
        //    }
        //    Height = Y;
        //}

        private void CalculateYearTextLocation()
        {
            double X = TopLeftLocation.X + (Width / 2);
            double Y = TopLeftLocation.Y - (Settings.SquareSize / 2);
            YearTextLocation = new Coordinate(X, Y, 0);
        }
        #endregion

        #region events
        #endregion

        #region event handlers
        #endregion
    }
}
