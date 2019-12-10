using System.Windows.Shapes;

namespace Calendar.Model.Grids
{
    class Cell : ICell
    {
        #region constructors
        public Cell(int row, int column, string value)
        {
            Row = row;
            Column = column;
            Value = value;
        }
        #endregion constructors

        #region properties
        public int Row { get; }
        public int Column { get; }
        public string Value { get; }
        #endregion properties

        #region methods
        #endregion methods
    }
}
