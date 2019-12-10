using Calendar.Shapes;
using System;

namespace Calendar.Grid
{
    class YearGridSettings
    {
        #region constructors
        public YearGridSettings(
            double squareSize,
            int columnCount,
            int rowCount)//,
            //double topLeftX,
            //double topLeftY)
        {
            if (squareSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(squareSize) + " must be positive");
            }

            if (ColumnCount * RowCount != 12)
            {
                throw new ArgumentOutOfRangeException($"There must be 12 months. Check {nameof(rowCount)} and/or {nameof(columnCount)}.");
            }

            SquareSize = squareSize;
            ColumnCount = columnCount;
            RowCount = rowCount;

            //TopLeftLocation = new Coordinate(topLeftX, topLeftY, 0);
        }
        #endregion

        #region properties
        public double SquareSize { get; }
        public int ColumnCount { get; }
        public int RowCount { get; }

        //public Coordinate TopLeftLocation { get; }

        public double DayTextHeight { get { return 3 / 10 * SquareSize; } }
        public double MonthTextHeight { get { return 3.5 / 10 * SquareSize; } }
        public double YearTextHeight { get { return 0.5 * SquareSize; } }
        #endregion

        #region methods
        public double CalculateWidth()
        {
            double X = ColumnCount * 8 * SquareSize;
            if (ColumnCount > 1)
            {
                double gapWidth = SquareSize * ColumnCount - 1;
                X = X + gapWidth;
            }
            return X;
        }

        private double CalculateHeight()
        {
            double Y = 2 * SquareSize + RowCount * 8 * SquareSize;
            if (RowCount > 1)
            {
                double gapHeight = SquareSize * RowCount - 1;
                Y = Y + gapHeight;
            }
            return Y;
        }
        #endregion

        #region events
        #endregion

        #region event handlers
        #endregion

    }
}
