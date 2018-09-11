using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src.model.Interfaces
{
    interface IProject:IEntity
    {
        void addStandart(IStandart standart);
        IList<IStandart> getProjectStandarts();
    }
}
