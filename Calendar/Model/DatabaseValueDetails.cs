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
                    return "7,5";
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
            StringBuilder sb = new();
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
            StringBuilder sb = new();
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
    }
}
