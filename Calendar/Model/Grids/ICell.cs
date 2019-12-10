namespace Calendar.Model.Grids
{
    interface ICell
    {
        int Row { get; }
        int Column { get; }
        string Value { get; }
    }
}