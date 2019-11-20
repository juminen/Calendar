namespace Calendar
{
    interface IMonthGridSquare
    {
        int Column { get; set; }
        bool RedLabel { get; }
        double Size { get; set; }
        string Text { get; }
    }
}