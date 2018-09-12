using eBalance.src.controller.ProjectController.Interfaces;
using eBalance.src.model.Classes;
using eBalance.src.model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src.controller.ProjectController.Classes
{
    public class ProjectController:IProjectController
    {
        IProject project;
        IList<IStandart> projectStandarts;
        IStandart currentStandart;
        IList<IGrade> standartGrades;

        public string createProject(string name)
        {
            project = new Project(name);
            
        }
        public string addStandart(string name)
        {

        }
    }
}
