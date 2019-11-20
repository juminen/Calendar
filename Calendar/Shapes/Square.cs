using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Shapes
{
    class Square : Rectangle
    {
        #region constructors
        #endregion constructors

        #region properties
        public override double Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.Widht = value;
            }
        }

        public override double Widht 
        {
            get
            {
                return base.Widht;
            }
            set
            {
                base.Height = value;
                base.Widht = value;
            }
        }
        #endregion properties

        #region methods
        #endregion methods

    }
}
