using Calendar.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calendar.ViewModel
{
	class ApplicationMainViewModel : ObservableObject
	{
		#region constructors
		public ApplicationMainViewModel()
		{
			builder = new CalendarBuilder();
			yearSettings = new YearSettingsViewModel(builder.YearSettings);
			yearCalendarSettings = new YearCalendarSettingsViewModel(builder.YearCalendarSettings);
			individualMonthSettings = new IndividualMonthSettingsViewModel(builder.IndividualMonthSettings);
			databaseValues = string.Empty;
			yearCalendarValues = string.Empty;
			individualMonthValues = string.Empty;

			CreateValuesCommand = new RelayCommand(() => CreateValues(),
							() => DatabaseValuesChecked ||
							YearCalendarValuesChecked ||
							IndividualMonthValuesChecked);

			ClearValuesCommand = new RelayCommand(() => ClearValues(),
							() => !string.IsNullOrWhiteSpace(DatabaseValues) ||
							!string.IsNullOrWhiteSpace(YearCalendarValues) ||
							!string.IsNullOrWhiteSpace(IndividualMonthValues));

			CopyDatabaseValuesCommand = new RelayCommand(() => CopyToClipboard(CopyFrom.Database),
				() => !string.IsNullOrWhiteSpace(DatabaseValues));

			CopyYearCalendarValuesCommand = new RelayCommand(() => CopyToClipboard(CopyFrom.YearCalendar),
				() => !string.IsNullOrWhiteSpace(YearCalendarValues));

			CopyIndividualMonthValuesCommand = new RelayCommand(() => CopyToClipboard(CopyFrom.IndividualMonths),
				() => !string.IsNullOrWhiteSpace(IndividualMonthValues));

			DatabaseValuesChecked = true;
			YearCalendarValuesChecked = true;
			IndividualMonthValuesChecked = true;
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
			set
			{
				SetProperty(ref databaseValuesChecked, value);
				CreateValuesCommand.NotifyCanExecuteChanged();
			}
		}

		private bool yearCalendarValuesChecked;
		public bool YearCalendarValuesChecked
		{
			get { return yearCalendarValuesChecked; }
			set
			{
				SetProperty(ref yearCalendarValuesChecked, value);
				CreateValuesCommand.NotifyCanExecuteChanged();
			}
		}

		private bool individualMonthValuesChecked;
		public bool IndividualMonthValuesChecked
		{
			get { return individualMonthValuesChecked; }
			set
			{
				SetProperty(ref individualMonthValuesChecked, value);
				CreateValuesCommand.NotifyCanExecuteChanged();
			}
		}

		private string databaseValues;
		public string DatabaseValues
		{
			get { return databaseValues; }
			private set
			{
				SetProperty(ref databaseValues, value);
				ClearValuesCommand.NotifyCanExecuteChanged();
				CopyDatabaseValuesCommand.NotifyCanExecuteChanged();
			}
		}

		private string yearCalendarValues;
		public string YearCalendarValues
		{
			get { return yearCalendarValues; }
			private set
			{
				SetProperty(ref yearCalendarValues, value);
				ClearValuesCommand.NotifyCanExecuteChanged();
				CopyYearCalendarValuesCommand.NotifyCanExecuteChanged();
			}
		}

		private string individualMonthValues;
		public string IndividualMonthValues
		{
			get { return individualMonthValues; }
			private set
			{
				SetProperty(ref individualMonthValues, value);
				ClearValuesCommand.NotifyCanExecuteChanged();
				CopyIndividualMonthValuesCommand.NotifyCanExecuteChanged();
			}
		}
		#endregion

		#region commands
		public IRelayCommand CreateValuesCommand { get; }
		public IRelayCommand ClearValuesCommand { get; }
		public IRelayCommand CopyDatabaseValuesCommand { get; }
		public IRelayCommand CopyYearCalendarValuesCommand { get; }
		public IRelayCommand CopyIndividualMonthValuesCommand { get; }
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
