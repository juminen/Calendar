using System;
using System.Collections.Generic;

namespace Calendar.Model.Calendar
{
    class FinnishHolidays
    {
        #region kiinteät juhlapyhät
        public static DateTime Uudenvuodenpäivä(int year)
        {
            return new DateTime(year, 1, 1);
        }

        public static DateTime Loppiainen(int year)
        {
            return new DateTime(year, 1, 6);
        }

        public static DateTime Vappu(int year)
        {
            return new DateTime(year, 5, 1);
        }

        public static DateTime Itsenäisyyspäivä(int year)
        {
            return new DateTime(year, 12, 6);
        }

        public static DateTime Joulupäivä(int year)
        {
            return new DateTime(year, 12, 25);
        }

        public static DateTime Tapaninpäivä(int year)
        {
            return new DateTime(year, 12, 26);
        }
        #endregion kiinteät juhlapyhät
        #region muuttuvat juhlapyhät
        public static DateTime Pitkäperjantai(int year)
        {
            return ChristianHolidays.GoodFriday(year);
        }

        public static DateTime Pääsiäispäivä(int year)
        {
            return ChristianHolidays.EasterSunday(year);
        }

        public static DateTime ToinenPääsiäispäivä(int year)
        {
            return ChristianHolidays.EasterSunday(year).AddDays(1);
        }

        public static DateTime Helatorstai(int year)
        {
            return ChristianHolidays.AscensionDay(year);
        }

        public static DateTime Helluntai(int year)
        {
            return ChristianHolidays.WhitSunday(year);
        }

        public static DateTime Juhannus(int year)
        {
            //is saturday between 20.06.-26.06.
            DateTime date = new DateTime(year, 6, 20);
            for (int i = 0; i < 7; i++)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    break;
                }
                date = date.AddDays(1);
            }
            return date;
        }

        public static DateTime Pyhäinpäivä(int year)
        {
            //is saturday between 31.10.-6.11.
            DateTime date = new DateTime(year, 10, 31);
            for (int i = 0; i < 7; i++)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    break;
                }
                date = date.AddDays(1);
            }
            return date;
        }
        #endregion muuttuvat juhlapyhät

        public static Dictionary<DateTime, string> Holidays(int year)
        {
            Dictionary<DateTime, string> holidays = new Dictionary<DateTime, string>()
            {
                { Uudenvuodenpäivä(year), "uudenvuodenpäivä" },
                { Loppiainen(year), "loppiainen" },
                { Pitkäperjantai(year), "pitkäperjantai" },
                { Pääsiäispäivä(year), "pääsiäispäivä" },
                { ToinenPääsiäispäivä(year), "2. pääsiäispäivä" },
                { Vappu(year), "vappu" },
                { Helatorstai(year), "helatorstai" },
                { Helluntai(year), "helluntaipäivä" },
                { Juhannus(year), "juhannuspäivä" },
                { Pyhäinpäivä(year), "pyhäinpäivä" },
                { Itsenäisyyspäivä(year), "itsenäisyyspäivä" },
                { Joulupäivä(year), "joulupäivä" },
                { Tapaninpäivä(year), "tapaninpäivä" }
            };
            return holidays;
        }

        public static bool IsHoliday(DateTime date)
        {
            if (Holidays(date.Year).ContainsKey(date))
            {
                return true;
            }
            return false;
        }

        public static string HolidayDescription(DateTime date)
        {
            Dictionary<DateTime, string> dic = Holidays(date.Year);
            if (dic.ContainsKey(date))
            {
                return dic[date];
            }
            return string.Empty;
        }

        /// <summary>
        /// ChristianHolidays calculates the dates for christian holidays that are either based on Easter or Christmas. It was
        /// based on the EasterSunday method described by Oskar Wieland at code project: http://www.codeproject.com/datetime/easter.asp.
        /// 
        /// The dates calculated here is not a complete list of all calculated christian holidays. Dates that are not calculated here
        /// are related to dates that are, so they should be easily added should you need them.
        /// </summary>
        private class ChristianHolidays
        {
            private ChristianHolidays()
            {
                // Private constructor to prevent instantiating
            }

            /// <summary>
            /// Calculate Easter Sunday month and day
            /// </summary>
            /// <remarks>This method was ported from C++. The original C++ code, by Oskar Wieland, can be found here:
            /// http://www.codeproject.com/datetime/easter.asp </remarks>
            /// <param name="year">4 digit year (but not before 1583)</param>
            /// <param name="month">Out - integer month</param>
            /// <param name="day">Out - integer day</param>
            public static void EasterSunday(int year, ref int month, ref int day)
            {
                int g = year % 19;
                int c = year / 100;
                int h = h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
                int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

                day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
                month = 3;

                if (day > 31)
                {
                    month++;
                    day -= 31;
                }
            }

            /// <summary>
            /// Calculate Easter Sunday
            /// </summary>
            /// <param name="year">4 digit year (but not before 1583)</param>
            /// <returns>DateTime</returns>
            public static DateTime EasterSunday(int year)
            {
                int month = 0;
                int day = 0;
                EasterSunday(year, ref month, ref day);

                return new DateTime(year, month, day);
            }

            /// <summary>
            /// Calculate Good Friday
            /// </summary>
            /// <remarks>
            /// Good Friday is the Friday before easter.
            /// </remarks>
            /// <param name="year">4 digit year (but not before 1583)</param>
            /// <returns>DateTime</returns>
            public static DateTime GoodFriday(int year)
            {
                return EasterSunday(year).AddDays(-2);
            }

            /// <summary>
            /// Calculate Palm Sunday
            /// </summary>
            /// <remarks>
            /// Palm Sunday is the sunday one week before easter.
            /// </remarks>
            /// <param name="year">4 digit year (but not before 1583)</param>
            /// <returns>DateTime</returns>
            public static DateTime PalmSunday(int year)
            {
                return EasterSunday(year).AddDays(-7);
            }

            /// <summary>
            /// Calculate Ascencion day
            /// </summary>
            /// <remarks>Ascencion day is always 10 days before Whit Sunday.</remarks>
            /// <param name="year">4 digit year (but not before 1583)</param>
            /// <returns>DateTime</returns>
            public static DateTime AscensionDay(int year)
            {
                return EasterSunday(year).AddDays(39);
            }

            /// <summary>
            /// Calculate Whit Sunday
            /// </summary>
            /// <remarks>Whit Sunday is always 7 weeks after Easter</remarks>
            /// <param name="year">4 digit year (but not before 1583)</param>
            /// <returns>DateTime</returns>
            public static DateTime WhitSunday(int year)
            {
                return EasterSunday(year).AddDays(49);
            }

            /// <summary>
            /// Calculate Ash Wednesday
            /// </summary>
            /// <remarks>
            /// Ash Wednesday marks the start of Lent. This is the 40 day period between before Easter
            /// </remarks>
            /// <param name="year">4 digit year (but not before 1583)</param>
            /// <returns>DateTime</returns>
            public static DateTime AshWednesday(int year)
            {
                return EasterSunday(year).AddDays(-46);
            }

            /// <summary>
            /// Calculate the first Sunday of Advent
            /// </summary>
            /// <remarks>
            /// The first sunday of advent is the first sunday at least 4 weeks before christmas
            /// </remarks>
            /// <param name="year">4 digit year (but not before 1583)</param>
            /// <returns>DateTime</returns>
            public static DateTime FirstSundayOfAdvent(int year)
            {
                int weeks = 4;
                int correction = 0;
                DateTime christmas = ChristmasDay(year);

                if (christmas.DayOfWeek != DayOfWeek.Sunday)
                {
                    weeks--;
                    correction = ((int)christmas.DayOfWeek - (int)DayOfWeek.Sunday);
                }

                return christmas.AddDays(-1 * ((weeks * 7) + correction));
            }

            /// <summary>
            /// Get the first day of christmas
            /// </summary>
            /// <remarks>
            /// Is always on December 25.
            /// </remarks>
            /// <param name="year">4 digit year</param>
            /// <returns>DateTime</returns>
            public static DateTime ChristmasDay(int year)
            {
                return new DateTime(year, 12, 25);
            }
        }
    }
}
