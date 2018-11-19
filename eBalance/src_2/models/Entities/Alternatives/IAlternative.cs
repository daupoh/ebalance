using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities.Alternatives
{
    interface IAlternative
    {
        void setGradeForCriterion(string gradeName, string criterionName);
        double getWeightByCriterion(string criterionName);
    }
}
