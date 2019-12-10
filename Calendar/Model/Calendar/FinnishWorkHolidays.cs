using System;
using System.Collections.Generic;

namespace Calendar.Model.Calendar
{
    class FinnishWorkHolidays
    {
        public static Dictionary<DateTime, string> Holidays(int year)
        {
            Dictionary<DateTime, string> holidays = FinnishHolidays.Holidays(year);
            holidays.Add(FinnishHolidays.Juhannus(year).AddDays(-1), "juhannusaatto");
            holidays.Add(new DateTime(year, 12, 24), "jouluaatto");
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
    }
}
