using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities.Grades
{
    class CGrade:IGrade
    {
        public CGrade()
        {

        }

        public string Name { get; set; }
        public void updateSub(string name, IEntity updated) { }
        public void deleteSub(string name) { }
        public void renameSub(string oldName, string newGradeName) { }
    }
}
