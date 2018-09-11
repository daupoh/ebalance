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
            gradeName = name;
            standartParents = new List<IStandart>();
        }
        public Grade(IStandart parent, string name)
        {
            gradeName = name;
            standartParents = new List<IStandart>();
            addParentStandart(parent);
        }
        public Grade(IStandart parent)
        {
            gradeName = NameHolder.defaultGradeName;
            standartParents = new List<IStandart>();
            addParentStandart(parent);
        }

        public string getName() { return gradeName; }
        public void addParentStandart(IStandart standart)
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
        public bool Equal(IGrade grade)
        {
            bool isEqual = false;
            if (grade.getName()==getName())
            {
                isEqual=true;
            }
            return isEqual;
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
