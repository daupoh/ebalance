using eBalance.src_2.models.Entities;
using eBalance.src_2.models.Entities.Criterion;
using eBalance.src_2.models.Entities.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.controllers
{
    interface IGoalController:IParrentEntityController
    {
        void addSubGoal(string subGoalName);
        void addCriterion(string criterionName);
        IGoal getGoal();
        IGoal getSubGoalByName(string subGoalName);
        ICriterion getCriterionByName(string subGoalName);
        IList<string> getSubGoalsNames();

        
    }
}
