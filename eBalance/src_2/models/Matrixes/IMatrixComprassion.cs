using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Matrixes
{
    public interface IMatrixComprassion
    {
        double[] getSameNumbers { get; }
        
        double getRelativeConsistency { get; }

        double getElement(uint rowNumber, uint columnNumber);
        void setElement(uint rowNumber, uint columnNumber, double value);
    }
}
