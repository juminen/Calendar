using System;

namespace Calendar
{
    class MonthGridDay : MonthGridSquare
    {
        #region constructors
        public MonthGridDay(Day day)
        {
            this.day = day ?? throw new ArgumentNullException(nameof(day));
        }
        #endregion constructors

        #region properties
        private Day day;

        public override bool RedLabel
        {
            get
            {
                if (day.IsHoliday)
                {
                    return true;
                }
                return false;
            }
        }

        public override string Text
        {
            get
            {
                return day.Date.Day.ToString();
            }
        }
        #endregion properties

        #region methods
        #endregion methods

    }
}
