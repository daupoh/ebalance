using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            projectName = NameHolder.defaultProjectName;
            projectStandarts = new List<IStandart>();    
        }
        public Project(string name)
        {
            projectName = name;
            projectStandarts = new List<IStandart>();
        }
        public Project(IList<IStandart> standarts, string name)
        {
            projectName = name;
            projectStandarts = standarts;
        }

        public string getName()
        {
            return projectName;
        }
        public void addStandart(IStandart standart)
        {
            standart.addParrent(this);
            projectStandarts.Add(standart);
        }
        public IList<IStandart> getProjectStandarts()
        {
            return projectStandarts;
        }
    }
}
