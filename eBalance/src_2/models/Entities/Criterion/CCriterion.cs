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
        public void updateSub(string name, IEntity updated) { }
        public void deleteSub(string name) { }
        public void renameSub(string oldName, string newGradeName) { }

        public void addStandart(IStandart standart) { }

        public double getSubWeight(string name)
        {
            double weight = 0;
            return weight;
        }
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
