using Calendar.Interfaces;
using System;

namespace Calendar.Model.Geometry
{
    class Rectangle : IRectangle
    {
        #region constructors
        public Rectangle(Coordinate location, double height, double width)
        {
            TopLeftLocation = location ?? throw new ArgumentNullException(nameof(location) + " can not be null");
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height) + "must be positive");
            }
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width) + "must be positive");
            }
            Height = height;
            Width = width;
        }
        #endregion constructors

        #region properties
        public Coordinate TopLeftLocation { get; }
        public virtual double Height { get; }
        public virtual double Width { get; }
        #endregion properties

        #region methods
        #endregion methods
    }
}
