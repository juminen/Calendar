using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace Calendar.Model.Calendar
{
    class Year : ObservableObject
    {
        #region constructors
        public Year(int yearNumber)
        {
            Number = yearNumber;
            Months = new Dictionary<int, Month>();
            CreateMonths();
            Weeks = new Dictionary<string, Week>();
            CreateWeeks();
        }
        #endregion constructors

        #region properties
        private int number;
        public int Number
        {
            get { return number; }
            private set { SetProperty(ref number, value); }
        }

        /// <summary>
        /// Key is <see cref="Month.Number"/> and value is <see cref="Month"/>.
        /// </summary>
        public Dictionary<int, Month> Months { get; private set; }

        /// <summary>
        /// Key is <see cref="Week.Identifier"/> and value is <see cref="Week"/>.
        /// </summary>
        public Dictionary<string, Week> Weeks { get; private set; }
        #endregion properties

        #region methods
        private void CreateMonths()
        {
            for (int i = 1; i < 13; i++)
            {
                Months.Add(i, new Month(this, i));
            }
        }

        public IEnumerable<Month> GetMonthsInOrder()
        {
            return Months.Values.OrderBy(x => x.Number).ToList();
        }

        public IEnumerable<Day> GetDaysInOrder()
        {
            List<Day> days = new List<Day>();
            foreach (Month m in GetMonthsInOrder())
            {
                days.AddRange(m.GetDaysInOrder());
            }
            return days.OrderBy(x => x.Date).ToList();
        }

        private void CreateWeeks()
        {
            foreach (Day d in GetDaysInOrder())
            {
                Week w;
                if (!Weeks.ContainsKey(d.Iso8601WeekOfYearWithYear))
                {
                    w = new Week(d.Iso8601WeekNumberWithYear.Item1, d.Iso8601WeekNumberWithYear.Item2);
                    Weeks.Add(w.Identifier, w);
                }
                else
                {
                    w = Weeks[d.Iso8601WeekOfYearWithYear];
                }
                w.AddDay(d);
            }
            #endregion methods
        }

        public IEnumerable<Week> GetWeeksInOrder()
        {
            return Weeks.Values.OrderBy(x => x.Identifier).ToList();
        }
    }
}