using Calendar.Model.Calendar;
using System;
using System.Globalization;
using System.Text;

namespace Calendar.Model
{
    class DatabaseValueDetails
    {
        public DatabaseValueDetails(Day day)
        {
            d = day ?? throw new ArgumentNullException(nameof(day) + " can not be null");
        }

        private readonly Day d;

        //[Description("Päivämäärä")]
        public string Date => d.Date.ToString("dd.MM.yyyy");
        //[Description("Viikonpäivän numero")]
        public string WeekDayNumber => d.WeekDayNumber.ToString();
        //[Description("Viikonpäivä")]
        public string DayLocalName => d.LocalName;
        //[Description("Päivä")]
        public string Day => d.Date.Day.ToString();
        //[Description("Kuukausi")]
        public string Month => d.Date.Month.ToString();
        //[Description("Kuukausi (teksti)")]
        public string MonthName => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Date.Month);
        //[Description("Vuosi")]
        public string Year => d.Date.Year.ToString();
        //[Description("Viikkonumero")]
        public string Iso8601WeekOfYear => d.Iso8601WeekOfYear.ToString();
        //[Description("Tuntilapun viikkonumero (viikko)")]
        public string HourSlipIso8601WeekOfYear => d.Iso8601WeekOfYearWithYear;
        //[Description("Tuntilapun viikkonumero (kuukausivaihde)")]
        public string HourSlipIso8601WeekOfYearWithMonthChange => d.Iso8601WeekOfYearWithYear + d.GetWeekNumberPart();
        //[Description("Päivämäärän huomautus")]
        public string DayDescription => d.WorkingDayDescription;
        //[Description("Arki/viikonloppu")]
        public string WeekdayOrWeekend
        {
            get
            {
                if (d.WeekDay)
                {
                    return "arki";
                }
                else
                {
                    return "viikonloppu";
                }
            }
        }
        //[Description("Työ-/vapaapäivä")]
        public string WorkdayOrDayOff
        {
            get
            {
                if (d.IsWorkingDay)
                {
                    return "työpäivä";
                }
                else
                {
                    return "vapaapäivä";
                }
            }
        }
        //[Description("Normaalit työtunnit päivässä")]
        public string NormalWorkHoursInDay
        {
            get
            {
                if (d.IsWorkingDay)
                {
                    return "8,0";
                }
                else
                {
                    return "0,0";
                }
            }
        }

        public override string ToString()
        {
            return ConstructSring();
        }

        private string ConstructSring()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{ Date }\t");
            sb.Append($"{ WeekDayNumber }\t");
            sb.Append($"{ DayLocalName }\t");
            sb.Append($"{ Day }\t");
            sb.Append($"{ Month }\t");
            sb.Append($"{ MonthName }\t");
            sb.Append($"{ Year }\t");
            sb.Append($"{ Iso8601WeekOfYear }\t");
            sb.Append($"{ HourSlipIso8601WeekOfYear }\t");
            sb.Append($"{ HourSlipIso8601WeekOfYearWithMonthChange }\t");
            sb.Append($"{ DayDescription }\t");
            sb.Append($"{ WeekdayOrWeekend }\t");
            sb.Append($"{ WorkdayOrDayOff }\t");
            sb.Append($"{ NormalWorkHoursInDay }");
            return sb.ToString();
        }

        public static string GetHeaders()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Päivämäärä\t");
            sb.Append("Viikonpäivän numero\t");
            sb.Append("Viikonpäivä\t");
            sb.Append("Päivä\t");
            sb.Append("Kuukausi\t");
            sb.Append("Kuukausi (teksti)\t");
            sb.Append("Vuosi\t");
            sb.Append("Viikkonumero\t");
            sb.Append("Tuntilapun viikkonumero (viikko)\t");
            sb.Append("Tuntilapun viikkonumero (kuukausivaihde)\t");
            sb.Append("Päivämäärän huomautus\t");
            sb.Append("Arki/viikonloppu\t");
            sb.Append("Työ-/vapaapäivä\t");
            sb.Append("Normaalit työtunnit päivässä");
            return sb.ToString();
        }

        //private string CreateCalendar(int startYear, int endYear)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("Päivämäärä");
        //    sb.Append("\tViikonpäivän numero");
        //    sb.Append("\tViikonpäivä");
        //    sb.Append("\tPäivä");
        //    sb.Append("\tKuukausi");
        //    sb.Append("\tKuukausi (teksti)");
        //    sb.Append("\tVuosi");
        //    sb.Append("\tViikkonumero");
        //    sb.Append("\tTuntilapun viikkonumero (viikko)");
        //    sb.Append("\tTuntilapun viikkonumero (kuukausivaihde)");
        //    sb.Append("\tPäivämäärän huomautus");
        //    sb.Append("\tArki/viikonloppu");
        //    sb.Append("\tTyö-/vapaapäivä");
        //    sb.AppendLine("\tNormaalit työtunnit päivässä");

        //    for (int i = startYear; i < endYear + 1; i++)
        //    {
        //        Year y = new Year(i);
        //        foreach (Day d in y.GetDaysInOrder())
        //        {
        //            sb.Append(d.Date.ToString("dd.MM.yyyy"));
        //            sb.Append("\t" + d.WeekDayNumber);
        //            sb.Append("\t" + d.LocalName);
        //            sb.Append("\t" + d.Date.Day);
        //            sb.Append("\t" + d.Date.Month);
        //            sb.Append("\t" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Date.Month));
        //            sb.Append("\t" + d.Date.Year);
        //            sb.Append("\t" + d.Iso8601WeekOfYear);
        //            sb.Append("\t" + d.Iso8601WeekOfYearWithYear);
        //            sb.Append("\t" + d.Iso8601WeekOfYearWithYear + d.GetWeekNumberPart());
        //            sb.Append("\t" + d.WorkingDayDescription);
        //            if (d.WeekDay)
        //            {
        //                sb.Append("\tarki");
        //            }
        //            else
        //            {
        //                sb.Append("\tviikonloppu");
        //            }
        //            if (d.IsWorkingDay)
        //            {
        //                sb.Append("\ttyöpäivä");
        //                sb.AppendLine("\t8,0");
        //            }
        //            else
        //            {
        //                sb.Append("\tvapaapäivä");
        //                sb.AppendLine("\t0,0");
        //            }

        //        }
        //    }
        //    return sb.ToString();
        //}
    }
}
