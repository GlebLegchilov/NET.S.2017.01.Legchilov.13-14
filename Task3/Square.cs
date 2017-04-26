using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class represent square
    /// </summary>
    public sealed class Square : Rectangle
    {
        #region Fields
        /// <summary>
        /// Rectangle's side
        /// </summary>
        private readonly double side;
        #endregion

        #region Properties
        /// <summary>
        ///  Rectangle's side
        /// </summary>
        public override double SideOne { get { return side; } }
        public override double SideTwo { get { return side; } }
        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Square():this(0,0)
        { }

        /// <summary>
        /// The constructor with spesified sides.
        /// </summary>
        /// <param name="a">First side of a square.</param>
        /// <param name="b">Second side of a square.</param>
        public Square(int a, int b)
        {
            if ((a < 0) || (b < 0)||(a!=b)) throw new ArgumentException("Sides must be positiv and equal");
            side = a;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return figure perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        public override double GetPerimeter()
        {
            return SideOne * 4;
        }

        /// <summary>
        /// Return figure area
        /// </summary>
        /// <returns>Area</returns>
        public override double GetArea()
        {
            return SideOne * SideTwo;
        }
        #endregion
    }
}
