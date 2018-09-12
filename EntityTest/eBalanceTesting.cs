using System;
using eBalance.src.controller.NamesHolder;
using eBalance.src.model.Classes;
using eBalance.src.model.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace eBalanceTesting
{
    [TestClass]
    public class TestEntity
    {
       

        [TestMethod]
        public void testCreateNewProjectWithoutName()
        {

            IProject project = new Project();
            Assert.AreEqual(NameHolder.defaultProjectName, project.getName());
        }
    }
}
