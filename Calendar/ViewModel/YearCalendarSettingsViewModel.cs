using Calendar.Model.Grids;
using Calendar.Model.Settings;
using JM.General;
using System;

namespace Calendar.ViewModel
{
    class YearCalendarSettingsViewModel : ObservableObject
    {
        #region constructors
        public YearCalendarSettingsViewModel(YearCalendarSettings yearCalendarSettings)
        {
            settings = yearCalendarSettings ?? throw new ArgumentNullException(nameof(yearCalendarSettings) + " can not be null");
            CalculateYearGridValues();
            CalculateMonthSize();
        }
        #endregion

        #region properties
        private readonly YearCalendarSettings settings;

        public double TopLeftX
        {
            get { return settings.TopLeftX; }
            set { settings.TopLeftX = value; OnPropertyChanged(nameof(TopLeftX)); }
        }

        public double TopLeftY
        {
            get { return settings.TopLeftY; }
            set { settings.TopLeftY = value; OnPropertyChanged(nameof(TopLeftY)); }
        }

        public int RowCount
        {
            get { return settings.RowCount; }
            set
            {
                settings.RowCount = value;
                OnPropertyChanged(nameof(RowCount));
                CalculateYearGridValues();
            }
        }

        public int ColumnCount
        {
            get { return settings.ColumnCount; }
            set
            {
                settings.ColumnCount = value;
                OnPropertyChanged(nameof(ColumnCount));
                CalculateYearGridValues();
            }
        }

        public double CellSize
        {
            get { return settings.CellSize; }
            set
            {
                settings.CellSize = value;
                OnPropertyChanged(nameof(CellSize));
                CalculateYearGridValues();
                CalculateMonthSize();
            }
        }

        private double monthGridSize;
        public double MonthGridSize
        {
            get { return monthGridSize; }
            private set { SetProperty(ref monthGridSize, value); }
        }

        private double yearGridHeight;
        public double YearGridHeight
        {
            get { return yearGridHeight; }
            private set { SetProperty(ref yearGridHeight, value); }
        }

        private double yearGridWidth;
        public double YearGridWidth
        {
            get { return yearGridWidth; }
            private set { SetProperty(ref yearGridWidth, value); }
        }

        public string FilenameTemplate
        {
            get { return settings.FilenameTemplate; }
            set
            {
                settings.FilenameTemplate = value;
                OnPropertyChanged(nameof(FilenameTemplate));
            }
        }
        #endregion

        #region commands
        #endregion

        #region methods
        private void CalculateYearGridValues()
        {
            YearGridHeight = GridCalculator.CalculateYearGridHeight(CellSize, RowCount);
            YearGridWidth = GridCalculator.CalculateYearGridWidth(CellSize, ColumnCount);
        }

        private void CalculateMonthSize()
        {
            MonthGridSize = GridCalculator.CalculateMonthGridSize(CellSize);
        }
        #endregion

        #region events
        #endregion

        #region event handlers
        #endregion

    }
}
