using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class represent triangle
    /// </summary>
    public class Triangle:IFigure
    {

        #region Properties
        /// <summary>
        /// Triangle's side
        /// </summary>
        public virtual double SideOne { get; }

        /// <summary>
        /// Triangle's side
        /// </summary>
        public virtual double SideTwo { get; }

        /// <summary>
        /// Triangle's side
        /// </summary>
        public virtual double SideThree { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Triangle() : this(0, 0, 0)
        {}

        /// <summary>
        /// The constructor with spesified sides.
        /// </summary>
        /// <param name="a">First side of a triangle.</param>
        /// <param name="b">Second side of a triangle.</param>
        /// <param name="c">Third side of a triangle.</param>
        public Triangle(int a, int b, int c)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentOutOfRangeException();
            if (!((a < (b+c)) ||  (a > (b-c)) || (b < (a+c)) || ( b > (a-c)) || (c < (a+b)) ||  (c > (a-b) )))
                throw new ArgumentOutOfRangeException();
            SideOne = a;
            SideTwo = b;
            SideThree = c;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return figure perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        public virtual double GetPerimeter()
        {
            return (SideOne + SideTwo + SideThree);
        }

        /// <summary>
        /// Return figure area
        /// </summary>
        /// <returns>Area</returns>
        public virtual double GetArea()
        {
            double p = GetPerimeter();
            return Math.Sqrt(p * (p - SideOne) * (p - SideTwo) * (p - SideThree));
        }
        #endregion
    }
}
