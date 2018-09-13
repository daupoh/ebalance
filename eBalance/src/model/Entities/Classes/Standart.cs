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
        IList<IProject> projectParents = null;
        
        //------public------------------

        public Standart()
        {
            standartName = NameHolder.defaultStandartName;
            listEntitiesInitialize();
             projectParents = new List<IProject>();
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
                generateGrades(countGrades);
            }
            else
            {
                throw new FormatException(ErrorHolder.standartCantBeWithLesserThanTwoGrades);
            }

        }
        public Standart(IProject parent)
        {
            
            standartName = NameHolder.defaultStandartName;
            listEntitiesInitialize();
            if (parent != null)
            {
                addParrent(parent);
            }
            else
            {
                throw new FormatException(ErrorHolder.standartAlreadyHaveThisParent);
            }
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
            if (parent != null)
            {
                addParrent(parent);
            }
            else
            {
                throw new FormatException(ErrorHolder.standartAlreadyHaveThisParent);
            }

        }
        public int CountGrades
        {
            get { return grades.Count; }
        }
        public string getName()
        {
            
            return standartName;
        }
        public void addGrade(IGrade grade)
        {
            if (grade != null)
            {
                if (CountGrades < NameHolder.maximumGradesInStandart)
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
            if (isProjectNotParentYet(project))
            {
                projectParents.Add(project);
            }
            else
            {
                throw new FormatException(ErrorHolder.standartAlreadyHaveThisParent);
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
            projectParents = new List<IProject>();
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
            foreach (IProject proj in projectParents)
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
                string nameGrade = NameHolder.defaultGradeName + Convert.ToString(i);
                grades.Add(new Grade(nameGrade));
            }
            
        }

    }
}
