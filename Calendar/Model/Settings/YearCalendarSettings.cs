namespace Calendar.Model.Settings
{
    class YearCalendarSettings
    {
        public YearCalendarSettings()
        {
            RowCount = 4;
            ColumnCount = 3;
            TopLeftX = 18.5;
            TopLeftY = 410;
            CellSize = 10;
            FilenameTemplate = "kalenteri_[YEAR].dwg";
        }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public double TopLeftX { get; set; }
        public double TopLeftY { get; set; }
        public double CellSize { get; set; }
        public string FilenameTemplate { get; set; }
    }
}
