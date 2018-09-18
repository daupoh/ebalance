using eBalance.src.controller.Holders;
using eBalance.src.controller.NamesHolder;
using eBalance.src.model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src.model.Classes
{
    class Standart : IStandart
    {
        string standartName = "";
        IList<IGrade> grades = null;
        IList<IProject> standartParents = null;
        
        //------public------------------

        public Standart()
        {
            standartName = NamesValuesHolder.defaultStandartName;
            listEntitiesInitialize();
             standartParents = new List<IProject>();
        }
        public Standart(string name)
        {
            if (name!=null && name!="")
            {
                standartName = name;
            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantBeCreatedWithoutName);
            }
            
            listEntitiesInitialize();
        }
        public Standart(string name, int countGrades)
        {
            if (name != null && name != "")
            {
                standartName = name;
            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantBeCreatedWithoutName);
            }
            listEntitiesInitialize();
            
            if (countGrades > 1)
            {
                if (countGrades < NamesValuesHolder.maximumGradesInStandart)
                {
                    generateGrades(countGrades);
                }
                else
                {
                    throw new FormatException(ErrorHolder.standartCantHaveToMuchGrades);
                }
            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantBeWithLesserThanTwoGrades);
            }

        }
        public Standart(IProject parent)
        {
            
            standartName = NamesValuesHolder.defaultStandartName;
            listEntitiesInitialize();
            addParrent(parent);
          
        }
        public Standart(IProject parent, string name)
        {
            if (name != null && name != "")
            {
                standartName = name;
            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantBeCreatedWithoutName);
            }
            listEntitiesInitialize();
            addParrent(parent);

        }
        public int CountGrades
        {
            get { return grades.Count; }
        }
        public string getName()
        {
            
            return standartName;
        }
        public IList<string> getParentName()
        {
            IList<string> parentsNames = new List<string>();
            foreach(IProject proj in standartParents)
            {
                parentsNames.Add(proj.getName());
            }
            return parentsNames;
        }
        public void addGrade(IGrade grade)
        {
            if (grade != null)
            {
                if (CountGrades < NamesValuesHolder.maximumGradesInStandart)
                {
                    if (isGradeHaveUniqueName(grade))
                    {                        
                        grades.Add(grade);
                    }
                    else
                    {
                        throw new FormatException(ErrorHolder.standartCantAddNotUniqueGrade);
                    }
                }
                else
                {
                    throw new FormatException(ErrorHolder.standartCantHaveToMuchGrades);
                }
            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantAddNullGrade);
            }
        }
        public void addGrades(IList<IGrade> grades)
        {
            if (grades != null && grades.Count>0)
            {
                foreach (IGrade grade in grades)
                {
                    addGrade(grade);
                }
            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantAddNullListGrades);
            }
        }

        public IList<IGrade> getGrades()
        {
            return grades;
        }

        public void addParrent(IProject project)
        {
            if (project != null)
            {
                if (isProjectNotParentYet(project))
                {
                    standartParents.Add(project);
                }
                else
                {
                    throw new FormatException(ErrorHolder.standartAlreadyHaveThisParent);
                }

            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantHaveNullProjectParent);
            }
        }

        public bool Equal(IStandart standart)
        {
            bool isEqual = false;
            if (standart != null)
            {
                if (standart.getName() == getName())
                {
                    isEqual = true;
                }
                return isEqual;
            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantCompareWithNull);
            }
        }

        //------private------------------

        private void listEntitiesInitialize()
        {
            standartParents = new List<IProject>();
            grades = new List<IGrade>();
        }
        private bool isGradeHaveUniqueName(IGrade grade)
        {
            bool isGradeHaveUniqueName = true;
            foreach(IGrade grd in grades)
            {
                if (grd.Equals(grade))
                {
                    isGradeHaveUniqueName = false;
                    break;
                }
            }
            return isGradeHaveUniqueName;
        }
        private bool isProjectNotParentYet(IProject project)
        {
            bool isProjectNotParentYet = true;
            foreach (IProject proj in standartParents)
            {
                if (proj.Equals(project))
                {
                    isProjectNotParentYet = false;
                    break;
                }
            }
            return isProjectNotParentYet;
        }
        private void generateGrades(int countGrades)
        {
            for (int i=0;i<countGrades;i++)
            {
                string nameGrade = NamesValuesHolder.defaultGradeName + Convert.ToString(i);
                IGrade grade = new Grade(nameGrade);
                grade.addParentStandart(this);
                grades.Add(grade);
            }
            
        }

    }
}
