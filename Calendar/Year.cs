using JM.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Year : ObservableObject
    {
        #region constructors
        public Year(int yearNumber)
        {
            Number = yearNumber;
            months = new Dictionary<int, Month>();
            Months = new Dictionary<int, Month>(months);
            CreateMonths();
            weeks = new Dictionary<string, Week>();
            Weeks = new Dictionary<string, Week>(weeks);
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

        private Dictionary<int, Month> months;
        public readonly Dictionary<int, Month> Months;

        private Dictionary<string, Week> weeks;
        /// <summary>
        /// Key is <see cref="Week.Identifier"/> and value is <see cref="Week"/>,
        /// </summary>
        public readonly Dictionary<string, Week> Weeks;
        #endregion properties

        #region methods
        private void CreateMonths()
        {
            for (int i = 1; i < 13; i++)
            {
                months.Add(i, new Month(this, i));
            }
        }

        public IEnumerable<Month> GetMonthsInOrder()
        {
            return months.Values.OrderBy(x => x.Number).ToList();
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
                if (!weeks.ContainsKey(d.Iso8601WeekOfYearWithYear))
                {
                    w = new Week(d.Iso8601WeekNumberWithYear.Item1, d.Iso8601WeekNumberWithYear.Item2);
                    weeks.Add(w.Identifier, w);
                }
                else
                {
                    w = weeks[d.Iso8601WeekOfYearWithYear];
                }
                w.AddDay(d);
            }
            #endregion methods
        }

        public IEnumerable<Week> GetWeeksInOrder()
        {
            return weeks.Values.OrderBy(x => x.Identifier).ToList();
        }
    }
}