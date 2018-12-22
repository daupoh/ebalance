using eBalance.src_2.models.Entities.Criterion;
using eBalance.src_2.models.Entities.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.controllers
{
    class CGoalController:IGoalController
    {
        IGoal m_pMainGoal;
        IList<IGoal> m_lsSubGoals;
        IList<ICriterion> m_lsCriterions;

        public CGoalController ()
        {
            
        }

        void setPrioritySubEntity(string subDominantName, string subRecesiveName, uint priority);
        IList<double> getSameNumbers();
        void addSubGoal(string subGoalName);
        void addCriterion(string criterionName);
        IGoal getGoal();
        IGoal getSubGoalByName(string subGoalName);
        ICriterion getCriterionByName(string subGoalName);
        IList<string> getSubGoalsNames();

        void updateSub(string name, IEntity updated);
        void deleteSub(string name);
        void renameSub(string oldName, string newGradeName);

        double getSubWeight(string name);

        void rename(string newName);
    }
}
