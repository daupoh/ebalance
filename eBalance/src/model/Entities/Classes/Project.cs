using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBalance.src.controller.Holders;
using eBalance.src.controller.NamesHolder;
using eBalance.src.model.Interfaces;

namespace eBalance.src.model.Classes
{
    class Project:IProject
    {
        string projectName="";
        IList<IStandart> projectStandarts;

        public Project()
        {
            projectName = NamesValuesHolder.defaultProjectName;
            projectStandarts = new List<IStandart>();    
        }
        public Project(string name)
        {
            if (name != "" && name!=null)
            {
                projectName = name;

                projectStandarts = new List<IStandart>();
            }
            else
            {
                throw new FormatException(ErrorHolder.projectCantBeCreatedWithoutName);
            }
        }
        public Project(IList<IStandart> standarts, string name)
        {
            if (name != "" && name != null)
            {
                projectName = name;

                projectStandarts = new List<IStandart>();
            }
            else
            {
                throw new FormatException(ErrorHolder.projectCantBeCreatedWithoutName);
            }
            if (standarts != null)
            {
                projectStandarts = standarts;
            }
            else
            {
                throw new FormatException(ErrorHolder.projectCantHaveNullStandartList);
            }
        }

        public string getName()
        {
            return projectName;
        }
        public IList<string> getParentName()
        {
            return null;
        }
        public void addStandart(IStandart standart)
        {
            if (standart != null)
            {
                if (!isThatNameAlreadyUsedForAnotherStandart(standart))
                {
                    
                    projectStandarts.Add(standart);
                }
                else
                {
                    throw new FormatException(ErrorHolder.projectCantAddTwoStandartWithSameNames);
                }
            }
            else
            {
                throw new FormatException(ErrorHolder.projectCantAddNullStandart);
            }
        }
        public IList<IStandart> getProjectStandarts()
        {
            return projectStandarts;
        }

        private bool isThatNameAlreadyUsedForAnotherStandart(IStandart standart)
        {
            bool isIt = false;
            foreach(IStandart stndrt in projectStandarts)
            {
                if (standart.getName()==stndrt.getName())
                {
                    isIt = true;
                    break;
                }
            }
            return isIt;
        }
    }
}
