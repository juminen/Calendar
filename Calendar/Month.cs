﻿using JM.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Month : ObservableObject
    {
        #region constructors
        public Month(Year monthYear, int monthNumber)
        {
            Year = monthYear ?? throw new ArgumentNullException(nameof(monthYear));

            if (monthNumber < 1 || monthNumber > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(monthNumber), "Number has to be between 1-12.");
            }
            Number = monthNumber;
            days = new Dictionary<int, Day>();
            Days = new Dictionary<int, Day>(days);
            CreateDays();
        }
        #endregion constructors

        #region properties
        private int number;
        public int Number
        {
            get { return number; }
            private set { SetProperty(ref number, value); }
        }

        private Year year;
        public Year Year
        {
            get { return year; }
            private set { SetProperty(ref year, value); }
        }

        private Dictionary<int, Day> days;
        public readonly Dictionary<int, Day> Days;

        public string LocalName
        {
            get
            {
                return DateTimeFormatInfo.CurrentInfo.GetMonthName(number);
            }
        }
        #endregion properties

        #region methods
        private void CreateDays()
        {
            int numberOfDaysInMonth = DateTime.DaysInMonth(Year.Number, Number);

            for (int i = 1; i < numberOfDaysInMonth + 1; i++)
            {
                Day d = new Day(new DateTime(Year.Number, Number, i));
                days.Add(i, d);
            }
        }

        public IEnumerable<Day> GetDaysInOrder()
        {
            return days.Values.OrderBy(x => x.Date).ToList();
        }

        public IEnumerable<Week> GetWeeksInOrder()
        {
            List<Week> list = new List<Week>();
            foreach (Week w in Year.GetWeeksInOrder())
            {
                if (w.BelongsToMonth(this))
                {
                    list.Add(w);
                }
            }
            return list;
        }

        #endregion methods

    }
}
