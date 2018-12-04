using eBalance.src_2.models.Entities.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities.Standarts
{
    interface IStandart:IParrentEntity
    {
        void addGrade(IGrade grade);

        
        void setPriorityGrades(string dominantGrade, string recesiveGrade, uint priority);

        IGrade getGradeByName(string gradeName);
        double getGradesWeight(string gradeName);
        IList<string> getGradesNames();
    }
}
