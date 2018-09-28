using eBalance.src.model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src.controller.ProjectController.Interfaces
{
    public interface IProjectController
    {
       

        void createProject(string name);
        void addStandart(string name, int count);

        string getProjectName();
        string getCurrentStandartName();
        IList<string> getProjectStandartsNames();
        IList<string> getStandartGradesNames(string standartName);
        void Dispose();
    }
}
