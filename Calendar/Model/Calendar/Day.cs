using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Globalization;

namespace Calendar.Model.Calendar
{
    class Day : ObservableObject
    {
        #region constructors
        public Day(DateTime day)
        {
            Date = day;
        }
        #endregion constructors

        #region properties
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            private set { SetProperty(ref date, value); }
        }

        public string LocalName
        {
            get
            {
                return DateTimeFormatInfo.CurrentInfo.GetDayName(date.DayOfWeek);
            }
        }

        /// <summary>
        /// Returns true if day is not saturday or sunday
        /// </summary>
        public bool WeekDay
        {
            get
            {
                return !WeekEndDay;
            }
        }

        /// <summary>
        /// Returns true if day is saturday or sunday
        /// </summary>
        public bool WeekEndDay
        {
            get
            {
                if (Date.DayOfWeek == DayOfWeek.Saturday ||
                    Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsHoliday
        {
            get { return FinnishHolidays.IsHoliday(Date); }
        }

        public string HolidayName
        {
            get { return FinnishHolidays.HolidayDescription(Date); }
        }

        public bool IsWorkingDay
        {
            get
            {
                if (FinnishWorkHolidays.IsHoliday(Date) || WeekEndDay)
                {
                    return false;
                }
                return true;
            }
        }

        public string WorkingDayDescription { get { return FinnishWorkHolidays.HolidayDescription(Date); } }

        /// <summary>
        /// Day's week information 
        /// </summary>
        /// <returns>Tuple containing year (item 1) and week (item 2)</returns>
        public Tuple<int, int> Iso8601WeekNumberWithYear
        {
            get
            {
                int distanceToSunday = 7 - WeekDayNumber;
                DateTime sunday = date.AddDays(distanceToSunday);
                int weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(sunday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                int year = Date.Year;

                if (Date.Month == 12 && weekNumber == 1)
                {
                    year++;
                }

                if (Date.Month == 1 && weekNumber >= 52)
                {
                    year--;
                }

                return new Tuple<int, int>(year, weekNumber);
            }
        }

        public int Iso8601WeekOfYear { get { return Iso8601WeekNumberWithYear.Item2; } }

        /// <summary>
        /// Returns value in format YYYYWWW, e.g 2000W01
        /// </summary>
        public string Iso8601WeekOfYearWithYear
        {
            get
            {
                return string.Format("{0}W{1}",
                    Iso8601WeekNumberWithYear.Item1.ToString("D4"),
                    Iso8601WeekNumberWithYear.Item2.ToString("D2"));
            }
        }

        /// <summary>
        /// Week day number (1 = monday, 7 = sunday)
        /// </summary>
        public int WeekDayNumber
        {
            get
            {
                int weekDayNumber = 0;
                switch (date.Date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        weekDayNumber = 7;
                        break;
                    case DayOfWeek.Monday:
                        weekDayNumber = 1;
                        break;
                    case DayOfWeek.Tuesday:
                        weekDayNumber = 2;
                        break;
                    case DayOfWeek.Wednesday:
                        weekDayNumber = 3;
                        break;
                    case DayOfWeek.Thursday:
                        weekDayNumber = 4;
                        break;
                    case DayOfWeek.Friday:
                        weekDayNumber = 5;
                        break;
                    case DayOfWeek.Saturday:
                        weekDayNumber = 6;
                        break;
                }
                return weekDayNumber;
            }
        }

        public int Ordinal { get { return Date.DayOfYear; } }

        #endregion properties

        #region methods
        /// <summary>
        /// If week days belong in the same month -> returns empty string. <br>
        /// If month changes during week:<br>
        /// -> returns A when day belongs to "first" month. <br>
        /// -> returns B when day belongs to "second" month. <br>
        /// </summary>
        /// <returns>empty string, A or B</returns>
        public string GetWeekNumberPart()
        {
            int distanceToMonday = 1 - WeekDayNumber;
            int distanceToSunday = 7 - WeekDayNumber;

            DateTime monday = date.AddDays(distanceToMonday);
            DateTime sunday = date.AddDays(distanceToSunday);

            if (monday.Month == sunday.Month)
            {
                return "";
            }

            if (monday.Month == date.Month)
            {
                return "A";
            }

            return "B";
        }
        #endregion methods
    }
}
