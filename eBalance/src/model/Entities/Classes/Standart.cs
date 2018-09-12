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
            standartName = name;
            listEntitiesInitialize();
        }
        public Standart(string name, int countGrades)
        {
            standartName = name;
            listEntitiesInitialize();
            generateGrades(countGrades);

        }
        public Standart(IProject parent)
        {
            
            standartName = NameHolder.defaultStandartName;
            listEntitiesInitialize();
            addParrent(parent);
        }
        public Standart(IProject parent, string name)
        {            
            standartName = name;
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
        public void addGrade(IGrade grade)
        {
            if (CountGrades < NameHolder.maximumGradesInStandart)
            {
                if (isGradeHaveUniqueName(grade))
                {
                    grades.Add(grade);
                }
                else
                {
                    throw new FormatException(ErrorHolder.notUniqueGradeAddedToStandartError);
                }
            }
            else
            {
                throw new FormatException(ErrorHolder.toManyGradesForStandart);
            }
        }
        public void addGrades(IList<IGrade> grades)
        {            
            foreach(IGrade grade in grades)
            {
                addGrade(grade);
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
                throw new FormatException(ErrorHolder.projectIsAlreadyParentToStandart);
            }
        }

        public bool Equal(IStandart standart)
        {
            bool isEqual = false;
            if (standart.getName() == getName())
            {
                isEqual = true;
            }
            return isEqual;
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
