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
        string m_strName;
        double m_dbWeight;
        IList<IGoal> m_lsSubGoals;
        IList<ICriterion> m_lsCriterions;

        public CGoal(string name)
        {
            m_strName = name;
            m_dbWeight = 1.0;
        }
        public double Weight
        {
            get
            {
                return m_dbWeight;
            }
        }
        public string Name { get { return m_strName; }
            set
            {
                SCChecker.isStringNotEmpty(value);
                m_strName = value;
            }
        }
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
            IGoal goal = new CGoal(subGoalName);

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

        private bool hasNameInCriterions(string criterionName, ICriterion findedCriterion)
        {
            bool itHas = false;
            foreach (ICriterion criterion in m_lsCriterions)
            {
                if (criterion.Name==criterionName)
                {
                    itHas = true;
                    findedCriterion = criterion;
                    break;
                }
            }
            return itHas;
        }
        private bool hasNameInSubGoals(string subGoalName, IGoal findedSybGoal)
        {
            bool itHas = false;
            foreach (IGoal subGoal in m_lsSubGoals)
            {
                if (subGoal.Name == subGoalName)
                {
                    itHas = true;
                    findedSybGoal = subGoal;
                    break;
                }
            }
            return itHas;
        }
    }
}
