namespace Calendar.Model.Settings
{
    class IndividualMonthSettings
    {
        public IndividualMonthSettings()
        {
            TopLeftX = 0;
            TopLeftY = 0;
            CellSize = 2.6250;
            FilenameTemplate = "kuukausi_[YEAR]-[MONTH].dwg";
        }
        public double TopLeftX { get; set; }
        public double TopLeftY { get; set; }
        public double CellSize { get; set; }
        public string FilenameTemplate { get; set; }
    }
}
