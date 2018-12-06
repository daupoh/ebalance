
using eBalance.src_2.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.controllers
{
    interface IEntityController
    {
        void setPrioritySubEntity(string subDominantName, string subRecesiveName, uint priority);
        IList<double> getSameNumbers();
        
    }
}
