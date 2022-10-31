using Calendar.Interfaces;
using Calendar.Model.Calendar;
using Calendar.Model.Geometry;
using Calendar.Model.Grids;
using Calendar.Model.Settings;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Calendar.Model
{
    class CalendarBuilder
    {
        #region constructors
        public CalendarBuilder()
        {
            years = new List<Year>();
            Years = new ReadOnlyCollection<Year>(years);
            YearSettings = new YearSettings();
            YearCalendarSettings = new YearCalendarSettings();
            IndividualMonthSettings = new IndividualMonthSettings();
        }
        #endregion

        #region properties
        List<Year> years;
        public IReadOnlyCollection<Year> Years { get; private set; }
        public string DatabaseValues { get; private set; } = string.Empty;
        public string YearCalendarValues { get; private set; } = string.Empty;
		public string IndividualMonthValues { get; private set; } = string.Empty;

		public YearSettings YearSettings { get; private set; }
        public YearCalendarSettings YearCalendarSettings { get; private set; }
        public IndividualMonthSettings IndividualMonthSettings { get; private set; }
        #endregion

        #region methods
        public void CreateCalendar(
            bool createDatabaseValues,
            bool createYearCalendarValues,
            bool createIndividualMonthValues)
        {
            ClearValues();
            CreateYears();

            if (createDatabaseValues)
            {
                CreateDatabaseValues();
            }

            if (createYearCalendarValues)
            {
                CreateYearCalendarValues();
            }

            if (createIndividualMonthValues)
            {
                CreateIndividualMonthValues();
            }
        }

        private void ClearValues()
        {
            DatabaseValues = string.Empty;
            YearCalendarValues = string.Empty;
            IndividualMonthValues = string.Empty;
        }

        private void CreateYears()
        {
            years.Clear();
            for (int i = YearSettings.StartYear; i < YearSettings.EndYear + 1; i++)
            {
                Year y = new Year(i);
                years.Add(y);
            }
        }

        private void CreateDatabaseValues()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DatabaseValueDetails.GetHeaders());
            foreach (Year year in years)
            {
                foreach (Day day in year.GetDaysInOrder())
                {
                    DatabaseValueDetails details = new DatabaseValueDetails(day);
                    sb.AppendLine(details.ToString());
                }
            }
            DatabaseValues = sb.ToString();
        }

        private void CreateYearCalendarValues()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CellValueDetails.GetHeaders());
            foreach (Year year in years)
            {
                YearGrid yg =
                    new YearGrid(
                        year,
                        new Coordinate(YearCalendarSettings.TopLeftX, YearCalendarSettings.TopLeftY, 0),
                        YearCalendarSettings.ColumnCount,
                        YearCalendarSettings.RowCount,
                        YearCalendarSettings.CellSize);

                string filename = YearCalendarSettings.FilenameTemplate.Replace("[YEAR]", yg.YearCell.Value);
                CellValueDetails cvdYear = new CellValueDetails(yg.YearCell, filename);
                sb.AppendLine(cvdYear.ToString());
                foreach (MonthGrid mg in yg.MonthGrids)
                {
                    foreach (ICalendarCell cell in mg.Cells)
                    {
                        CellValueDetails cvd = new CellValueDetails(cell, filename);
                        sb.AppendLine(cvd.ToString());
                    }
                }
            }
            YearCalendarValues = sb.ToString();
        }

        private void CreateIndividualMonthValues()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CellValueDetails.GetHeaders());
            foreach (Year year in years)
            {
                foreach (Month month in year.GetMonthsInOrder().ToList())
                {
                    string filename = 
                        IndividualMonthSettings.FilenameTemplate.Replace("[YEAR]", year.Number.ToString())
                            .Replace("[MONTH]",month.Number.ToString("00"));
                    MonthGrid mg = new MonthGrid(
                        month,
                        new Coordinate(IndividualMonthSettings.TopLeftX, IndividualMonthSettings.TopLeftY, 0),
                        GridCalculator.CalculateMonthGridSize(IndividualMonthSettings.CellSize));
                    foreach (ICalendarCell cell in mg.Cells)
                    {
                        CellValueDetails cvd = new CellValueDetails(cell, filename);
                        sb.AppendLine(cvd.ToString());
                    }
                }
            }
            IndividualMonthValues = sb.ToString();
        }
        #endregion

        #region events
        #endregion

        #region event handlers
        #endregion
    }
}
