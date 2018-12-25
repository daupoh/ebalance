using eBalance.src_2.models.Entities.Criterion;
using eBalance.src_2.models.Entities.PriorityKeeper;
using System;
using System.Collections;
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
            initilizeSubGoalsLists();
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
            int indexInCrtrns = hasNameInCriterions(name),
                indexInGoals = hasNameInSubGoals(name);
            if (indexInCrtrns>=0 && indexInGoals<0)
            {
                weight = m_lsCriterions[indexInCrtrns].Weight;
            }
            else if (indexInGoals >= 0 && indexInCrtrns<0)
            {
                weight = m_lsSubGoals[indexInGoals].Weight;
            }
            else if (indexInGoals >= 0 && indexInCrtrns >= 0)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("subGoalsNamesMatches"));
            }
            else
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("subGoalsNameNotFound"));
            }            
            return weight;
        }
        public void addSubGoal(IGoal goal)
        {
            int indexInCrtrns = hasNameInCriterions(goal.Name),
               indexInGoals = hasNameInSubGoals(goal.Name);
            if (Name!=goal.Name && indexInGoals<0 && indexInCrtrns<0)
            {
                m_lsSubGoals.Add(goal);
            }
            else
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("subGoalAlreadyExist")); 
            }
        }
        public void addSubGoal(ICriterion criterion)
        {
            int indexInCrtrns = hasNameInCriterions(criterion.Name),
               indexInGoals = hasNameInSubGoals(criterion.Name);
            if (Name != criterion.Name && indexInGoals < 0 && indexInCrtrns < 0)
            {
                m_lsCriterions.Add(criterion);
            }
            else
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("subGoalAlreadyExist"));
            }
        }
        
        public void setPrioritySubGoal(string subGoalDominantName, string subGoalRecesiveName, uint priority)
        {
            SCPriorityKeeper.addPriority(subGoalDominantName, subGoalRecesiveName, priority);
        }
        
        public IGoal getSubGoalByName(string subGoalName)
        {
            IGoal goal = null;
            int indexInGoals = hasNameInSubGoals(subGoalName);
            if (indexInGoals >= 0)
            {
                goal = m_lsSubGoals[indexInGoals];
            }
            else 
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("subGoalsNameNotFound"));
            }
           
            return goal;
        }
        public ICriterion getCriterionByName(string subGoalName)
        {
            ICriterion criterion= null;
            int indexInCrtrns = hasNameInCriterions(subGoalName);
            if (indexInCrtrns >= 0)
            {
                criterion = m_lsCriterions[indexInCrtrns];
            }
            else
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("subGoalsNameNotFound"));
            }
            return criterion;
        }
        public IList<string> getSubGoalsNames() {
            IList<string> subGoalsNames = new List<string>();
            if (m_lsSubGoals==null || m_lsCriterions==null)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("subGoalListsAreNull"));
            }
            
            foreach(IGoal subGoal in m_lsSubGoals)
            {
                subGoalsNames.Add(subGoal.Name);
            }
            foreach (ICriterion subGoal in m_lsCriterions)
            {
                subGoalsNames.Add(subGoal.Name);
            }
            return subGoalsNames;
        }
        private void initilizeSubGoalsLists()
        {
            m_lsCriterions = new List<ICriterion>();
            m_lsSubGoals = new List<IGoal>();
        }
        private int hasNameInCriterions(string criterionName)
        {
            int index = -1;
            int i = 0;
            foreach (ICriterion criterion in m_lsCriterions)
            {
                if (criterion.Name==criterionName)
                {
                    index = i;                   
                    break;
                }
                i++;
            }
            return index;
        }
        private int hasNameInSubGoals(string subGoalName)
        {
            int index = -1;
            int i = 0;
            foreach (IGoal subGoal in m_lsSubGoals)
            {
                if (subGoal.Name == subGoalName)
                {
                    index = i;                   
                    break;
                }
                i++;
            }
            return index;
        }
    }
}
