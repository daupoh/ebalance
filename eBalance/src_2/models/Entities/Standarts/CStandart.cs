using eBalance.src_2.models.Entities.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities.Standarts
{
    class CStandart:IStandart
    {
        public CStandart()
        {

        }

        public string Name { get; set; }
        public void updateSub(string name, IEntity updated) { }
        public void deleteSub(string name) { }
        public void renameSub(string oldName, string newGradeName) { }
               
        public double getSubWeight(string name)
        {
            double weight = 0;
            return weight;
        }
        public void setPriorityGrades(string dominantGrade, string recesiveGrade, uint priority) { }
       
        public IGrade getGradeByName(string gradeName)
        {
            IGrade grade=new CGrade();

            return grade;
        }
        public IList<string> getGradesNames()
        {
            IList<string> gradesNames = new List<string>();

            return gradesNames;
        }
    }
}
