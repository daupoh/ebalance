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
        string createProject(string name);
        string addStandart(string name);
        
    }
}
