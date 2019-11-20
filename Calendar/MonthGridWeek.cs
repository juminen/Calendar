using JM.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class MonthGridWeek : MonthGridRow
    {
        #region constructors	
        public MonthGridWeek(Week week, Month monthOfWeek)
        {
            squares = new ObservableCollection<IMonthGridSquare>();
            this.week = week;
            month = monthOfWeek;
        }
        #endregion constructors

        #region properties
        private Week week;
        private Month month;

        private ObservableCollection<IMonthGridSquare> squares;
        public ObservableCollection<IMonthGridSquare> Squares
        {
            get { return squares; }
            set { SetProperty(ref squares, value); }
        }

        public override double Widht
        {
            get
            {
                if (squares.Count > 0)
                {
                    double sum = squares.Sum(x => x.Size);
                    return sum;
                }
                return 0;
            }
        }

        public override double Height
        {
            get
            {
                if (squares.Count > 0)
                {
                    return squares[0].Size;
                }
                return 0;
            }
        }
        #endregion properties

        #region methods
        private void CreateSquares()
        {
            //create square for week number
            Squares.Add(new MonthGridWeekSquare(week) { Column = 0 });

            //create seven squares for days
            for (int i = 1; i < 7; i++)
            {
                IMonthGridSquare square;
                if (week.Days.ContainsKey(i))
                {
                    square = new MonthGridDay(week.Days[i]);
                }
                else
                {
                    square = new MonthGridEmptySquare();
                }
                square.Column = i;
                Squares.Add(square);
            }
        }
        #endregion methods
    }
}
