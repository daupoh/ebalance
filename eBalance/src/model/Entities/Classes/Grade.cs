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
        IList<IStandart> standartParents; 

        public Grade()
        {
            gradeName = NameHolder.defaultGradeName;
            standartParents = new List<IStandart>();
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
            standartParents = new List<IStandart>();
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
            if (parent != null)
            {
                standartParents = new List<IStandart>();
                addParentStandart(parent);
            }
            else
            {
                throw new FormatException(ErrorHolder.gradeCantHaveNullStandartParent);
            }
        }
        public Grade(IStandart parent)
        {
            gradeName = NameHolder.defaultGradeName;
            if (parent != null)
            {
                standartParents = new List<IStandart>();
                addParentStandart(parent);
            }
            else
            {
                throw new FormatException(ErrorHolder.gradeCantHaveNullStandartParent);
            }
        }

        public string getName() { return gradeName; }
        public void addParentStandart(IStandart standart)
        {
            if (standart != null)
            {
                if (isStandartNotParentYet(standart))
                {
                    standartParents.Add(standart);
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
            foreach (IStandart stdrt in standartParents)
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
