using eBalance.src_2.models.Entities.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities.Goals
{
    interface IGoal:IEntity
    {
        void addSubGoal(IGoal goal);
        void addSubGoal(ICriterion criterion);

      
        void setPrioritySubGoal(string subGoulDominantName, string subGoalRecesiveName, uint priority);


        IGoal getSubGoalByName(string subGoalName);
        ICriterion getCriterionByName(string subGoalName);
        IList<string> getSubGoalsNames();
        //IList<double> getSameNumbersOfSubGoal();

    }
}
