using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src.model.Interfaces
{
    interface IGrade:IEntity
    {
        void addParentStandart(IStandart standart);
    }
}
