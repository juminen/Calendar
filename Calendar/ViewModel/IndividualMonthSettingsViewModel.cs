using Calendar.Model.Grids;
using Calendar.Model.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Calendar.ViewModel
{
    class IndividualMonthSettingsViewModel : ObservableObject
    {
        #region constructors      
        public IndividualMonthSettingsViewModel(IndividualMonthSettings individualMonthSettings)
        {
            settings = individualMonthSettings ?? throw new ArgumentNullException(nameof(individualMonthSettings) + " can not be null");
            CalculateMonthSize();
        }
        #endregion

        #region properties
        private readonly IndividualMonthSettings settings;

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

        public double CellSize
        {
            get { return settings.CellSize; }
            set
            {
                settings.CellSize = value;
                OnPropertyChanged(nameof(CellSize));
                CalculateMonthSize();
            }
        }

        private double monthGridSize;
        public double MonthGridSize
        {
            get { return monthGridSize; }
            private set { SetProperty(ref monthGridSize, value); }
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
