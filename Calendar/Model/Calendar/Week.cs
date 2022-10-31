using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace Calendar.Model.Calendar
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
            Days = new Dictionary<int, Day>();
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

        /// <summary>
        /// Key is <see cref="Day.WeekDayNumber"/> and value is <see cref="Day"/>.
        /// </summary>
        public Dictionary<int, Day> Days { get; private set; }

        //public bool MonthChangesDuringWeek()
        //{
        //    if (Days.Count < 7)
        //    {
        //        return true;
        //    }

        //    bool result = false;
        //    foreach (Day d in Days)
        //    {
        //    }
        //    return result;
        //}
        #endregion properties

        #region methods
        internal void AddDay(Day d)
        {
            if (!Days.ContainsValue(d))
            {
                Days.Add(d.WeekDayNumber, d);
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
