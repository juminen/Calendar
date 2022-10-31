using Calendar.Interfaces;
using Calendar.Model.Calendar;
using Calendar.Model.Geometry;
using Calendar.Model.Cells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Calendar.Model.Grids
{
	class MonthGrid : Square
	{
		#region constructors	
		public MonthGrid(Month month, Coordinate location, double size)
			: base(location, size)
		{
			this.month = month ?? throw new ArgumentNullException(nameof(month));
			CreateSquares();
		}
		#endregion constructors

		#region properties
		private readonly Month month;
		List<ICalendarCell> cells = new();
		public IReadOnlyCollection<ICalendarCell> Cells { get; private set; } = null!;
		#endregion properties

		#region methods
		private void CreateSquares()
		{
			double rowHeight = Height / 8;
			double cellSize = rowHeight;
			double currentY = TopLeftLocation.Y;

			//Month title
			MonthNameCell title = new(month, TopLeftLocation, rowHeight, Width);
			cells.Add(title);

			//Day titles
			currentY -= rowHeight;
			CreateDayTitles(currentY, cellSize);

			foreach (Week week in month.GetWeeksInOrder())
			{
				currentY -= rowHeight;
				//Week number
				WeekNumberCell ws = new(
					week,
					new Coordinate(TopLeftLocation.X, currentY, 0),
					cellSize);
				cells.Add(ws);

				//Day number
				foreach (KeyValuePair<int, Day> kvp in week.Days)
				{
					if (kvp.Value.Date.Month == month.Number)
					{
						Coordinate loc = new(
							TopLeftLocation.X + kvp.Key * cellSize,
							currentY, 0);
						DayCell ds = new DayCell(kvp.Value, loc, cellSize);
						cells.Add(ds);
					}
				}
			}

			Cells = new ReadOnlyCollection<ICalendarCell>(cells);
		}
		private void CreateDayTitles(double Y, double cellSize)
		{
			Dictionary<int, string> list = new Dictionary<int, string>()
			{
				{ 0, "VKO" },
				{ 1, "MA" },
				{ 2, "TI" },
				{ 3, "KE" },
				{ 4, "TO" },
				{ 5, "PE" },
				{ 6, "LA" },
				{ 7, "SU" }
			};

			double currentX = TopLeftLocation.X;
			for (int i = 0; i < 8; i++)
			{
				WeekdayTitleCell square =
					new WeekdayTitleCell(
						list[i],
						new Coordinate(currentX, Y, 0),
						cellSize);
				cells.Add(square);
				currentX += cellSize;
			}
		}
		#endregion methods


	}
}
