using Calendar.Interfaces;
using Calendar.Model.Calendar;
using Calendar.Model.Geometry;
using Calendar.Model.Cells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Calendar.Model.Grids
{
    class YearGrid : Rectangle
    {
        #region constructors
        public YearGrid(Year year,
            Coordinate location,
            int columnCount,
            int rowCount,
            double cellSize)
            : base(location,
                  GridCalculator.CalculateYearGridHeight(cellSize, rowCount),
                  GridCalculator.CalculateYearGridWidth(cellSize, columnCount))
        {
            this.year = year ?? throw new ArgumentNullException(nameof(year));
            if (cellSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cellSize) + " must be positive.");
            }
            this.cellSize = cellSize;

            if (columnCount * rowCount != 12)
            {
                throw new ArgumentOutOfRangeException($"Multiplication of {nameof(rowCount)} and {nameof(columnCount)} must be 12. Check values.");
            }
            this.rowCount = rowCount;
            this.columnCount = columnCount;

            monthGrids = new List<MonthGrid>();
            MonthGrids = new ReadOnlyCollection<MonthGrid>(monthGrids);

            CreateYearCellAndMonthGrids();
        }
        #endregion

        #region properties
        private readonly Year year;
        private readonly double cellSize;
        private readonly int columnCount;
        private readonly int rowCount;

        public ICalendarCell YearCell { get; private set; } = null!;

        private List<MonthGrid> monthGrids;
        public IReadOnlyCollection<MonthGrid> MonthGrids { get; private set; }
        #endregion

        #region methods
        private void CreateYearCellAndMonthGrids()
        {
            YearCell = new YearCell(year, TopLeftLocation, cellSize, Width);

            double monthSize = cellSize * 8;
            double currentY = TopLeftLocation.Y - 2 * cellSize;
            List<Month> months = year.GetMonthsInOrder().ToList();

            int monthIndex = 0;

            for (int row = 0; row < rowCount; row++)
            {
                double currentX = TopLeftLocation.X;

                for (int columns = 0; columns < columnCount; columns++)
                {
                    MonthGrid mg = new MonthGrid(
                        months[monthIndex],
                        new Coordinate(currentX, currentY, 0),
                        monthSize);
                    monthGrids.Add(mg);
                    currentX = currentX + monthSize + cellSize;
                    monthIndex++;
                }

                currentY = currentY - monthSize - cellSize;
            }
        }
        #endregion

        #region events
        #endregion

        #region event handlers
        #endregion
    }
}
