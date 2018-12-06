using eBalance.src_2.models.Entities.Goals;
using eBalance.src_2.models.Entities.Standarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.controllers
{
    interface ICriterionController
    {        
        void selectCriterion(string criterionName);
        string getStandartName(string criterionName);
        
        void tieToStandart(string standartName);
    }
}
