using eBalance.src_2.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.controllers
{
    interface IParrentEntityController:IEntityController
    {
        void updateSub(string name, IEntity updated);
        void deleteSub(string name);
        void renameSub(string oldName, string newGradeName);

        double getSubWeight(string name);

        void rename(string newName);
        
    }
}
