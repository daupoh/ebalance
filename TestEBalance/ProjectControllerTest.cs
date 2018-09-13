using System;
using System.Collections.Generic;
using eBalance.src.controller.Holders;
using eBalance.src.controller.ProjectController.Classes;
using eBalance.src.controller.ProjectController.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEBalance
{
    [TestClass]
    public class ProjectControllerTest
    {
        IProjectController pc;
     

        [TestInitialize]
        public void prepareProjectController()
        {
            pc = new ProjectController();             
        }

        [TestCleanup]
        public void clearProjectController()
        {
            pc.Dispose();
            pc = null;
        }


        [TestMethod()]      
        public void createProjectWithCorrectName()
        {
            pc.createProject(TestDataHolder.correctProjectName);
            Assert.AreEqual(TestDataHolder.correctProjectName, pc.getProjectName(), TestMessageHolder.projectExpectedNameNotEqualActualName);
        }

        
        [DataRow(null)]
        [DataRow("")]      
        [DataTestMethod]
        public void createProjectWithInCorrectName(string name)
        {
            try
            {
                pc.createProject(name);
            }
            catch(FormatException fe)
            {
                Assert.AreEqual(ErrorHolder.projectCantBeCreatedWithoutName, fe.Message, TestMessageHolder.projectExceptionDsntThrow);
                // Assert.AreEqual(ErrorHolder.projectCantBeCreatedWithoutName, " dsdds", TestMessageHolder.projectExceptionDsntThrow);
                return;
            }
            Assert.Fail(TestMessageHolder.projectExceptionDsntThrow);
        }
    }
}
