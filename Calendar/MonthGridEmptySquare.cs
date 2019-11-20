namespace Calendar
{
    class MonthGridEmptySquare : MonthGridSquare
    {
        public override bool RedLabel
        {
            get { return false; }
        }

        public override string Text
        {
            get { return string.Empty; }
        }

    }
}
