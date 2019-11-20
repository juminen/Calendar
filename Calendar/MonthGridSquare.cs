using JM.General;

namespace Calendar
{
    abstract class MonthGridSquare : ObservableObject, IMonthGridSquare
    {
        #region constructors
        #endregion constructors

        #region properties
        private double size;
        public double Size
        {
            get { return size; }
            set { SetProperty(ref size, value); }
        }

        private int column;
        public int Column
        {
            get { return column; }
            set { SetProperty(ref column, value); }
        }

        public abstract bool RedLabel { get; }
        public abstract string Text { get; }
        #endregion properties

        #region methods
        #endregion methods

    }
}
