using JM.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class MonthGrid : ObservableObject
    {
        #region constructors	
        public MonthGrid(Month month)
        {
            this.month = month ?? throw new ArgumentNullException(nameof(month));
            CreateWeeks();
        }
        #endregion constructors

        #region properties
        private Month month;
        //private IMonthGridSquare squares;
        //private ReadOnlyObservableCollection<IMonthGridSquare>



        #endregion properties

        #region methods
        private void CreateWeeks()
        {
            Day d = new Day(DateTime.Now);
            string str = d.LocalName.Substring(0, 2).ToUpper();
            //d.Date.DayOfWeek
            int i = 1;
            foreach (Week w in month.GetWeeksInOrder())
            {
                MonthGridWeek mgw = new MonthGridWeek(w, month);
                mgw.Number = i;
                //TODO: mitäs viikoille tehdään?
                i++;
            }
        }
        #endregion methods


    }
}
