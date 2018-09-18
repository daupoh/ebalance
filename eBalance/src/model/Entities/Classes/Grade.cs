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
    class Grade:IGrade
    {
        string gradeName = "";
        IList<IStandart> gradeParents; 

        public Grade()
        {
            gradeName = NamesValuesHolder.defaultGradeName;
            gradeParents = new List<IStandart>();
        }
        public Grade(string name)
        {
            if (name != null && name != "")
            {
                gradeName = name;
            }
            else
            {
                throw new FormatException(ErrorHolder.gradeCantBeCreatedWithoutName);
            }
            gradeParents = new List<IStandart>();
        }
        public Grade(IStandart parent, string name)
        {
            if (name != null && name != "")
            {
                gradeName = name;
            }
            else
            {
                throw new FormatException(ErrorHolder.gradeCantBeCreatedWithoutName);
            }
            gradeParents = new List<IStandart>();
            addParentStandart(parent);
           
        }
        public Grade(IStandart parent)
        {
            gradeName = NamesValuesHolder.defaultGradeName;
            gradeParents = new List<IStandart>();
            addParentStandart(parent);
            
        }

        public string getName() { return gradeName; }
        public IList<string> getParentName()
        {
            IList<string> parentsNames = new List<string>();
            foreach(IStandart std in gradeParents)
            {
                parentsNames.Add(std.getName());
            }
            return parentsNames;
        }
        public void addParentStandart(IStandart standart)
        {
            if (standart != null)
            {
                if (isStandartNotParentYet(standart))
                {
                    gradeParents.Add(standart);
                }
                else
                {
                    throw new FormatException(ErrorHolder.standartIsAlreadyParentToGrade);
                }
            }
            else
            {
                throw new FormatException(ErrorHolder.gradeCantHaveNullStandartParent);
            }
            
        }
        public bool Equal(IGrade grade)
        {
            if (grade != null)
            {
                bool isEqual = false;
                if (grade.getName() == getName())
                {
                    isEqual = true;
                }
                return isEqual;
            }
            else
            {
                throw new FormatException(ErrorHolder.gradeCantCompareWithNull);
            }
        }
        //---private-----------------------------

        private bool isStandartNotParentYet(IStandart standart)
        {
            bool isStandartNotParentYet = true;
            foreach (IStandart stdrt in gradeParents)
            {
                if (stdrt.Equals(standart))
                {
                    isStandartNotParentYet = false;
                    break;
                }
            }
            return isStandartNotParentYet;
        }
    }
}
