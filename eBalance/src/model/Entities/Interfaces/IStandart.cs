using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src.model.Interfaces
{
     interface IStandart:IEntity
    {
        void addGrade(IGrade grade);
        void addGrades(IList<IGrade> grades);
        IList<IGrade> getGrades();
        void addParrent(IProject project);
    }
}
