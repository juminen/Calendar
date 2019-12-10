using System;

namespace Calendar.Model.Settings
{
    class YearSettings
    {
        public YearSettings()
        {
            StartYear = DateTime.Today.Year + 1;
            EndYear = StartYear;
        }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
}
