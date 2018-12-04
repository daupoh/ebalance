using eBalance.src_2.models.Entities.Standarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities.Criterion
{
    class CCriterion:ICriterion
    {
        public CCriterion()
        {

        }
        public string Name { get; set; }
        public double Weight { get; }

        public void addStandart(IStandart standart) { }

       
        public IStandart getStandartByName(string standartName)
        {
            IStandart standart=new CStandart();

            return standart;
        }
        public IList<string> getStandartsNames()
        {
            IList<string> standartsNames = new List<string>();

            return standartsNames;
        }
    }
}
