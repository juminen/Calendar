using JM.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Shapes
{
    class Rectangle : ObservableObject, IRectangle
    {
        #region constructors
        public Rectangle()
        {
            location = new Coordinate();
            Height = 0;
            Widht = 0;
        }
        #endregion constructors

        #region properties
        private Coordinate location;
        public Coordinate Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        private double height;
        public virtual double Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }

        private double widht;
        public virtual double Widht
        {
            get { return widht; }
            set { SetProperty(ref widht, value); }
        }
        #endregion properties

        #region methods
        #endregion methods

    }
}
