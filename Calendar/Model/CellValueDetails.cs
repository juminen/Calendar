using Calendar.Interfaces;
using System;
using System.Text;

namespace Calendar.Model
{
    class CellValueDetails
    {
        public CellValueDetails(ICalendarCell calendarCell, string nameOfFile)
        {
            cell = calendarCell ?? throw new ArgumentNullException(nameof(calendarCell) + " can not be null");
            fileName = nameOfFile;
        }

        private readonly ICalendarCell cell;
        private readonly string fileName;

        public override string ToString()
        {
            return ConstructSring();
        }

        private string ConstructSring()
        {
            StringBuilder sb = new StringBuilder();

            string type = string.Empty;

            switch (cell.Type)
            {
                case Enums.CellType.Day:
                    type = "päivä";
                    break;
                case Enums.CellType.WeekNumber:
                    type = "viikkonumero";
                    break;
                case Enums.CellType.WeekDayTitle:
                    type = "viikko-otsikko";
                    break;
                case Enums.CellType.MonthName:
                    type = "kuukausi";
                    break;
                case Enums.CellType.Year:
                    type = "vuosi";
                    break;
                default:
                    break;
            }
            sb.Append($"{ type }\t");
            sb.Append($"{ cell.HelpText1 }\t");
            sb.Append($"{ cell.HelpText2 }\t");
            sb.Append($"{ fileName }\t"); //filename
            sb.Append($"{ cell.Value }\t"); //teksti vanha
            sb.Append($"\t"); //teksti uusi
            sb.Append($"{ cell.ValueLocation.X }\t");
            sb.Append($"{ cell.ValueLocation.Y }\t");
            sb.Append($"{ cell.ValueLocation.Z }\t");
            sb.Append($"{ cell.ValueTextHeight }\t");
            sb.Append($"0\t");  //kulma
            sb.Append($"{ cell.TextStyle }\t");  //tekstityyli
            sb.Append($"MiddleCenter\t");  //keskitys
            sb.Append($"ByLayer\t");  //väri
            sb.Append($"{ cell.Layer }\t");  //taso

            return sb.ToString();
        }

        public static string GetHeaders()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TYYPPI\t");
            sb.Append("APUTEKSTI 1\t");
            sb.Append("APUTEKSTI 2\t");
            sb.Append("FILENAME\t");
            sb.Append("TEKSTI VANHA\t");
            sb.Append("TEKSTI UUSI\t");
            sb.Append("X-KOORD\t");
            sb.Append("Y-KOORD\t");
            sb.Append("Z-KOORD\t");
            sb.Append("KORKEUS\t");
            sb.Append("KULMA\t");
            sb.Append("TEKSTITYYLI\t");
            sb.Append("KESKITYS\t");
            sb.Append("VÄRI\t");
            sb.Append("TASO\t");
            return sb.ToString();
        }
    }
}
