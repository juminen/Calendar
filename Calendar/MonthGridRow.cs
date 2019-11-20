using JM.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    abstract class MonthGridRow : ObservableObject
    {
        #region constructors
        #endregion constructors

        #region properties
        private int number;
        public int Number
        {
            get { return number; }
            set { SetProperty(ref number, value); }
        }

        public abstract double Height { get; }
        public abstract double Widht { get; }
        #endregion properties

        #region methods
        #endregion methods
    }
}
