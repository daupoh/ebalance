using eBalance.src_2.models.Entities.Standarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities.Criterion
{
    interface ICriterion:IWeightEntity
    {
        
        void tieToStandart(IStandart standart);
        
        IStandart getStandart();  
    }
}
