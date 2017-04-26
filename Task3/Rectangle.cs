using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class represent rectangle
    /// </summary>
    public class Rectangle :IFigure
    {
        #region Fields
        /// <summary>
        /// Rectangle's side
        /// </summary>
        private double sideOne;

        /// <summary>
        /// Rectangle's second side
        /// </summary>
        private  double sideTwo;
        #endregion

        #region Properties
        /// <summary>
        ///  Rectangle's side
        /// </summary>
        public virtual double SideOne
        {
            get
            {
                return sideOne;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Side must be positiv");
                sideOne = value;
            }
        }

        /// <summary>
        /// Rectangle's second side
        /// </summary>
        public virtual double SideTwo
        {
            get
            {
                return sideTwo;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Side must be positiv");
                sideTwo = value;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Rectangle() : this(0, 0)
        { }

        /// <summary>
        /// The constructor with spesified sides.
        /// </summary>
        /// <param name="a">First side of a rectangle.</param>
        /// <param name="b">Second side of a rectangle.</param>
        public Rectangle(int a, int b)
        {
            if((a<0)||(b<0)) throw new ArgumentException("Sides must be positiv");
            SideOne = a;
            sideTwo = b;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return figure perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        public virtual double GetPerimeter()
        {
            return (SideOne + SideTwo)*2;
        }

        /// <summary>
        /// Return figure area
        /// </summary>
        /// <returns>Area</returns>
        public virtual double GetArea()
        {
            return (SideTwo * SideOne);
        }
        #endregion
    }
}
