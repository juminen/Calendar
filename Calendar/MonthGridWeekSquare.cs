using System;

namespace Calendar
{
    class MonthGridWeekSquare : MonthGridSquare
    {
        #region constructors
        public MonthGridWeekSquare(Week week)
        {
            this.week = week ?? throw new ArgumentNullException(nameof(week));
        }
        #endregion constructors

        #region properties
        private Week week;

        public override bool RedLabel
        {
            get
            {
                return false;
            }
        }

        public override string Text
        {
            get
            {
                return week.Number.ToString();
            }
        }
        #endregion properties

        #region methods
        #endregion methods
    }
}
