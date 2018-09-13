using eBalance.src.controller.ProjectController.Interfaces;
using eBalance.src.model.Classes;
using eBalance.src.model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBalance.src.controller.ProjectController.Classes
{
    public class ProjectController:IProjectController
    {
        IProject project;
        IList<IStandart> projectStandarts;
        IStandart currentStandart;
        IList<IGrade> standartGrades;

        public ProjectController()
        {
            initializeProjectList();
        }
        public void Dispose()
        {
            project = null;
            standartGrades.Clear();
            standartGrades = null;
            projectStandarts.Clear();
            projectStandarts = null;
            currentStandart = null;            
        }

        public void createProject(string name)
        {
            project = new Project(name);    
        }
        public void addStandart(string name, int count)
        {
            IStandart standart;
            standart = new Standart(name,count);
            standart.addParrent(project);           
            projectStandarts.Add(standart);
            standartGrades = standart.getGrades();
            currentStandart = standart;

        }

        public string getProjectName()
        {
            return project.getName();
        }
        public string getCurrentStandartName()
        {
            return currentStandart.getName();
        }
        public IList<string> getProjectStandartsNames()
        {
            IList<string> standartNames = new List<string>();

            foreach(IStandart standart in projectStandarts)
            {
                standartNames.Add(standart.getName());
            }

            return standartNames;
        }
        public IList<string> getStandartGradesNames(string standartName)
        {
            IList<string> gradeOfCurrentStandartNames = new List<string>();
            foreach(IGrade grade in standartGrades)
            {
                gradeOfCurrentStandartNames.Add(grade.getName());
            }
            return gradeOfCurrentStandartNames;
        }

        //---private----------------------

        private void initializeProjectList()
        {
            projectStandarts = new List<IStandart>();
            standartGrades = new List<IGrade>();
        }
        
    }
}
