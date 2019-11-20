using JM.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Week : ObservableObject
    {
        #region constructors
        public Week(int weekYear, int weekNumber)
        {
            year = weekYear;
            if (weekNumber < 1 || weekNumber > 53)
            {
                throw new ArgumentOutOfRangeException(nameof(weekYear), "number has to be between 1-53.");
            }
            Number = weekNumber;
            days = new Dictionary<int, Day>();
            Days = new Dictionary<int, Day>(days);
        }
        #endregion constructors

        #region properties
        private int year;

        private int number;
        public int Number
        {
            get { return number; }
            private set { SetProperty(ref number, value); }
        }

        /// <summary>
        /// returns week number and year in ISO8601 format (year in four digits, character 'W' and week number in two digits.)
        /// </summary>
        /// <example>1987W09</example>
        public string Identifier
        {
            get
            {
                return string.Format("{0}W{1}", year.ToString("D4"), number.ToString("D2"));
            }
        }

        private Dictionary<int, Day> days;
        public readonly Dictionary<int, Day> Days;

        public bool MonthChangesDuringWeek()
        {
            if (Days.Count < 7)
            {
                return true;
            }

            bool result = false;
            foreach (Day d in Days.Values)
            {

            }
            return result;
        }
        #endregion properties

        #region methods
        internal void AddDay(Day d)
        {
            if (d == null)
            {
                return;
            }

            //int weekDayNumber = 0;
            //switch (d.Date.DayOfWeek)
            //{
            //    case DayOfWeek.Sunday:
            //        weekDayNumber = 7;
            //        break;
            //    case DayOfWeek.Monday:
            //        weekDayNumber = 1;
            //        break;
            //    case DayOfWeek.Tuesday:
            //        weekDayNumber = 2;
            //        break;
            //    case DayOfWeek.Wednesday:
            //        weekDayNumber = 3;
            //        break;
            //    case DayOfWeek.Thursday:
            //        weekDayNumber = 4;
            //        break;
            //    case DayOfWeek.Friday:
            //        weekDayNumber = 5;
            //        break;
            //    case DayOfWeek.Saturday:
            //        weekDayNumber = 6;
            //        break;
            //}

            if (days.ContainsKey(d.WeekDayNumber))
            {
                days[d.WeekDayNumber] = d;
            }
            else
            {
                days.Add(d.WeekDayNumber, d);
            }
        }

        public bool BelongsToMonth(Month month)
        {
            bool answer = false;
            foreach (Day d in Days.Values)
            {
                if (d.Date.Month == month.Number)
                {
                    answer = true;
                    break;
                }
            }
            return answer;
        }
        #endregion methods

    }
}
