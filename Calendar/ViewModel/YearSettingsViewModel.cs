using Calendar.Model.Settings;
using JM.General;
using System;

namespace Calendar.ViewModel
{
    class YearSettingsViewModel : ObservableObject
    {
        #region constructors


        public YearSettingsViewModel(YearSettings yearSettings)
        {
            settings = yearSettings ?? throw new ArgumentNullException(nameof(yearSettings) + " can not be null");
            OnPropertyChanged("");
        }
        #endregion

        #region properties
        private readonly YearSettings settings;

        public int StartYear
        {
            get { return settings.StartYear; }
            set { settings.StartYear = value; OnPropertyChanged(nameof(StartYear)); }
        }

        public int EndYear
        {
            get { return settings.EndYear; }
            set { settings.EndYear = value; OnPropertyChanged(nameof(EndYear)); }
        }
        #endregion

        #region commands
        #endregion

        #region methods
        #endregion

        #region events
        #endregion

        #region event handlers
        #endregion


    }
}
