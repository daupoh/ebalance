using eBalance.src_2.models.Entities.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities.Goals
{
    class CGoal:IGoal
    {
        public CGoal()
        {

        }
        public double Weight { get; }
        public string Name { get; set; }
        public void updateSub(string name, IEntity updated) { }
        public void deleteSub(string name) { }
        public void renameSub(string oldName, string newGradeName) { }
       
        public double getSubWeight(string name)
        {
            double weight = 0;
            return weight;
        }
        public void addSubGoal(IGoal goal) { }
        public void addSubGoal(ICriterion criterion) { }
        
        public void setPrioritySubGoal(string subGoulDominantName, string subGoalRecesiveName, uint priority) { }
        
        public IGoal getSubGoalByName(string subGoalName)
        {
            IGoal goal = new CGoal();

            return goal;
        }
        public ICriterion getCriterionByName(string subGoalName)
        {
            ICriterion criterion=new CCriterion();

            return criterion;
        }
        public IList<string> getSubGoalsNames() {
            IList<string> subGoalsNames = new List<string>();

            return subGoalsNames;
        }
    }
}
