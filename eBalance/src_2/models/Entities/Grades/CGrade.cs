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
        public double Weight { get; }
        public string Name { get; set; }
       
    }
}
