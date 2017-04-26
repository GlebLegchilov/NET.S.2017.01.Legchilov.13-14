using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Supports visiting objects by visitor.
    /// </summary>
    public interface IVisitable<T>
    {
        #region Methods

        /// <summary>
        /// Accepts specified visitor.
        /// </summary>
        /// <param name="visitor">Visitor to accept.</param>
        void Accept(IMatrixVisitor<T> visitor);

        #endregion
    }
}
