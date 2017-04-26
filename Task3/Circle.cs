using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class represent circle
    /// </summary>
    public class Circle : IFigure
    {
        #region Fields
        /// <summary>
        /// Circle's radius
        /// </summary>
        private double radius;
        #endregion

        #region Properties
        /// <summary>
        /// Circle's radius
        /// </summary>
        public virtual double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Radius must be positiv");
                radius = value;
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Circle():this(0)
        { }

        /// <summary>
        /// The constructor with spesified radius.
        /// </summary>
        /// <param name="r">Circle's radius.</param>
        public Circle(double r)
        {
            if(r<0) throw new ArgumentException("Radius must be positiv");
            Radius = r;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return figure perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        public virtual double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Return figure area
        /// </summary>
        /// <returns>Area</returns>
        public virtual double GetArea()
        {
            return (Math.PI * Radius * Radius) / 2;
        }
        #endregion
    }
}
