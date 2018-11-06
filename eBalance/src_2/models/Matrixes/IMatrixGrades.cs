using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Matrixes
{
    public interface IMatrixGrades
    {
        uint CountOfAlternatives { get; }
        uint CountOfCriterions { get; }

        void normalizeMatrix();
        double[] getRelativeWeight(double[] criterionWeight);

        double getElement(uint rowNumber, uint columnNumber);
        void setElement(uint rowNumber, uint columnNumber, double value);
    }
}
