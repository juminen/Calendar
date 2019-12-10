using Calendar.Model;
using JM.General;

namespace Calendar.ViewModel
{
    class ApplicationMainViewModel : ObservableObject
    {
        #region constructors
        public ApplicationMainViewModel()
        {
            builder = new CalendarBuilder();
            YearSettings = new YearSettingsViewModel(builder.YearSettings);
            YearCalendarSettings = new YearCalendarSettingsViewModel(builder.YearCalendarSettings);
            IndividualMonthSettings = new IndividualMonthSettingsViewModel(builder.IndividualMonthSettings);
            DatabaseValues = string.Empty;
            YearCalendarValues = string.Empty;
            individualMonthValues = string.Empty;
        }
        #endregion

        #region properties
        private readonly CalendarBuilder builder;

        private YearSettingsViewModel yearSettings;
        public YearSettingsViewModel YearSettings
        {
            get { return yearSettings; }
            private set { SetProperty(ref yearSettings, value); }
        }

        private YearCalendarSettingsViewModel yearCalendarSettings;
        public YearCalendarSettingsViewModel YearCalendarSettings
        {
            get { return yearCalendarSettings; }
            private set { SetProperty(ref yearCalendarSettings, value); }
        }

        private IndividualMonthSettingsViewModel individualMonthSettings;
        public IndividualMonthSettingsViewModel IndividualMonthSettings
        {
            get { return individualMonthSettings; }
            private set { SetProperty(ref individualMonthSettings, value); }
        }

        private bool databaseValuesChecked;
        public bool DatabaseValuesChecked
        {
            get { return databaseValuesChecked; }
            set { SetProperty(ref databaseValuesChecked, value); }
        }

        private bool yearCalendarValuesChecked;
        public bool YearCalendarValuesChecked
        {
            get { return yearCalendarValuesChecked; }
            set { SetProperty(ref yearCalendarValuesChecked, value); }
        }

        private bool individualMonthValuesChecked;
        public bool IndividualMonthValuesChecked
        {
            get { return individualMonthValuesChecked; }
            set { SetProperty(ref individualMonthValuesChecked, value); }
        }

        private string databaseValues;
        public string DatabaseValues
        {
            get { return databaseValues; }
            private set { SetProperty(ref databaseValues, value); }
        }

        private string yearCalendarValues;
        public string YearCalendarValues
        {
            get { return yearCalendarValues; }
            private set { SetProperty(ref yearCalendarValues, value); }
        }

        private string individualMonthValues;
        public string IndividualMonthValues
        {
            get { return individualMonthValues; }
            private set { SetProperty(ref individualMonthValues, value); }
        }
        #endregion

        #region commands
        private RelayCommand createValuesCommand;
        public RelayCommand CreateValuesCommand
        {
            get
            {
                if (createValuesCommand == null)
                {
                    createValuesCommand =
                        new RelayCommand(
                            param => CreateValues(),
                            param => DatabaseValuesChecked ||
                            YearCalendarValuesChecked ||
                            IndividualMonthValuesChecked);
                }
                return createValuesCommand;
            }
        }

        private RelayCommand clearValuesCommand;
        public RelayCommand ClearValuesCommand
        {
            get
            {
                if (clearValuesCommand == null)
                {
                    clearValuesCommand =
                        new RelayCommand(
                            param => ClearValues(),
                            param => !string.IsNullOrWhiteSpace(DatabaseValues) ||
                            !string.IsNullOrWhiteSpace(YearCalendarValues) ||
                            !string.IsNullOrWhiteSpace(IndividualMonthValues));
                }
                return clearValuesCommand;
            }
        }

        private RelayCommand copyDatabaseValuesCommand;
        public RelayCommand CopyDatabaseValuesCommand
        {
            get
            {
                if (copyDatabaseValuesCommand == null)
                {
                    copyDatabaseValuesCommand =
                      new RelayCommand(
                          param => CopyToClipboard(CopyFrom.Database),
                          param => !string.IsNullOrWhiteSpace(DatabaseValues));
                }
                return copyDatabaseValuesCommand;
            }
        }

        private RelayCommand copyYearCalendarValuesCommand;
        public RelayCommand CopyYearCalendarValuesCommand
        {
            get
            {
                if (copyYearCalendarValuesCommand == null)
                {
                    copyYearCalendarValuesCommand =
                      new RelayCommand(
                          param => CopyToClipboard(CopyFrom.YearCalendar),
                          param => !string.IsNullOrWhiteSpace(YearCalendarValues));
                }
                return copyYearCalendarValuesCommand;
            }
        }

        private RelayCommand copyIndividualMothValuesCommand;
        public RelayCommand CopyIndividualMothValuesCommand
        {
            get
            {
                if (copyIndividualMothValuesCommand == null)
                {
                    copyIndividualMothValuesCommand =
                      new RelayCommand(
                          param => CopyToClipboard(CopyFrom.IndividualMonths),
                          param => !string.IsNullOrWhiteSpace(IndividualMonthValues));
                }
                return copyIndividualMothValuesCommand;
            }
        }
        #endregion

        #region methods
        private void CreateValues()
        {
            ClearValues();

            builder.CreateCalendar(
                DatabaseValuesChecked,
                YearCalendarValuesChecked,
                IndividualMonthValuesChecked);

            DatabaseValues = builder.DatabaseValues;
            YearCalendarValues = builder.YearCalendarValues;
            IndividualMonthValues = builder.IndividualMonthValues;
        }

        private void ClearValues()
        {
            DatabaseValues = string.Empty;
            YearCalendarValues = string.Empty;
            IndividualMonthValues = string.Empty;
        }

        private void CopyToClipboard(CopyFrom from)
        {
            switch (from)
            {
                case CopyFrom.Database:
                    System.Windows.Clipboard.SetText(DatabaseValues);
                    break;
                case CopyFrom.YearCalendar:
                    System.Windows.Clipboard.SetText(YearCalendarValues);
                    break;
                case CopyFrom.IndividualMonths:
                    System.Windows.Clipboard.SetText(IndividualMonthValues);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region events
        #endregion

        #region event handlers
        #endregion

        private enum CopyFrom
        {
            Database,
            YearCalendar,
            IndividualMonths
        }
    }
}
