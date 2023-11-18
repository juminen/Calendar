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
			//return ConstructSring();
			return ConstructSringCadex();
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

		private string ConstructSringCadex()
		{
			StringBuilder sb = new();

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

			sb.Append($"\t"); //FileStatus
			sb.Append($"\t"); //TextStatus
			sb.Append($"\t"); //DrawingDirectory
			sb.Append($"{fileName}\t"); //DrawingFileName
			sb.Append($"\t"); //Handle
			sb.Append($"Model\t"); //Layout
			sb.Append($"ByLayer\t");  //Color
			sb.Append($"{cell.Layer}\t");  //Layer
			sb.Append($"ByLayer\t"); //Linetype
			sb.Append($"ByLayer\t"); //Lineweight
			sb.Append($"{cell.ValueLocation.X}\t"); //PositionX
			sb.Append($"{cell.ValueLocation.Y}\t"); //PositionZ
			sb.Append($"{cell.ValueLocation.Z}\t"); //PositionY
			sb.Append($"0\t"); //AlignmentX
			sb.Append($"0\t"); //AlignmentZ
			sb.Append($"0\t"); //AlignmentY
			sb.Append($"0\t"); //Rotation
			sb.Append($"{cell.ValueTextHeight}\t"); //Height
			sb.Append($"1\t"); //WidthFactor
			sb.Append($"0\t"); //Obliquing
			sb.Append($"{cell.TextStyle}\t");  //Style
			sb.Append($"MiddleCenter\t"); //Justification
			sb.Append($"{cell.Value}\t"); //Contents
			sb.Append($"{type}\t"); //TYYPPI
			sb.Append($"{cell.HelpText1}\t"); //APUTEKSTI
			sb.Append($"{cell.HelpText2}\t"); //APUTEKST2
			return sb.ToString();
		}

		public static string GetHeaders()
        {
			//StringBuilder sb = new();
			//sb.Append("TYYPPI\t");
			//sb.Append("APUTEKSTI 1\t");
			//sb.Append("APUTEKSTI 2\t");
			//sb.Append("FILENAME\t");
			//sb.Append("TEKSTI VANHA\t");
			//sb.Append("TEKSTI UUSI\t");
			//sb.Append("X-KOORD\t");
			//sb.Append("Y-KOORD\t");
			//sb.Append("Z-KOORD\t");
			//sb.Append("KORKEUS\t");
			//sb.Append("KULMA\t");
			//sb.Append("TEKSTITYYLI\t");
			//sb.Append("KESKITYS\t");
			//sb.Append("VÄRI\t");
			//sb.Append("TASO\t");
			//return sb.ToString();
			return GetHeadersCadex();
        }

		private static string GetHeadersCadex()
		{
			StringBuilder sb = new();
			sb.Append("FileStatus\t");
			sb.Append("TextStatus\t");
			sb.Append("DrawingDirectory\t");
			sb.Append("DrawingFileName\t");
			sb.Append("Handle\t");
			sb.Append("Layout\t");
			sb.Append("Color\t");
			sb.Append("Layer\t");
			sb.Append("Linetype\t");
			sb.Append("Lineweight\t");
			sb.Append("PositionX\t");
			sb.Append("PositionY\t");
			sb.Append("PositionZ\t");
			sb.Append("AlignmentX\t");
			sb.Append("AlignmentY\t");
			sb.Append("AlignmentZ\t");
			sb.Append("Rotation\t");
			sb.Append("Height\t");
			sb.Append("WidthFactor\t");
			sb.Append("Obliquing\t");
			sb.Append("Style\t");
			sb.Append("Justification\t");
			sb.Append("Contents\t");
    		sb.Append("TYYPPI\t");
			sb.Append("APUTEKSTI 1\t");
			sb.Append("APUTEKSTI 2\t");
			return sb.ToString();
		}
	}
}
