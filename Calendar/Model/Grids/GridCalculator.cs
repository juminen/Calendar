namespace Calendar.Model.Grids
{
    static class GridCalculator
    {
        public static double CalculateYearGridHeight(double cellSize, int rows)
        {
            double monthHeight = CalculateMonthGridSize(cellSize);
            return  cellSize + //year cell
                    cellSize + //gap between year and months
                    monthHeight * rows + //months
                    (rows - 1) * cellSize; //gaps between months
        }

        public static double CalculateYearGridWidth(double cellSize, int columns)
        {
            double monthWidth = CalculateMonthGridSize(cellSize);
            return monthWidth * columns + (columns - 1) * cellSize;
        }

        public static double CalculateMonthGridSize(double cellSize)
        {
            return 8.0 * cellSize;
        }

        public static double CalculateYearTextHeight(double cellSize)
        {
            return 0.5 * cellSize;
        }

        public static double CalculateMonthTextHeight(double cellSize)
        {
            return 3.5 / 10 * cellSize;
        }

        public static double CalculateDayTextHeight(double cellSize)
        {
            return 3.0 / 10 * cellSize;
        }
    }
}
