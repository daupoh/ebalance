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
        //------positive tests

                
        [TestCategory("positive test"),TestMethod()]      
        public void canCreateProjectWithCorrectName()
        {
            pc.createProject(TestDataHolder.correctProjectName);
            Assert.AreEqual(TestDataHolder.correctProjectName, pc.getProjectName(), TestMessageHolder.projectExpectedNameNotEqualActualName);
        }


        [DataRow(0)]
        [DataRow(1)]
        [DataRow(10)]
        [TestCategory("positive test"), DataTestMethod]        
        public void canAddStandartsWithCorrectNameAndCountOfGradesInQuantity(int countOfStandarts)
        {
            createProjectForStandarts(TestDataHolder.correctProjectName);
            addStandartsToProject(countOfStandarts, TestDataHolder.defaultCountOfGrades);

            pc.addStandart(TestDataHolder.correctStandartName,TestDataHolder.defaultCountOfGrades);
            Assert.AreEqual(TestDataHolder.correctStandartName, pc.getCurrentStandartName(),TestMessageHolder.standartAddedNotBeenCurrentForProject);
            Assert.AreEqual(TestDataHolder.defaultCountOfGrades, pc.getStandartGradesNames(TestDataHolder.correctStandartName).Count, 
                TestMessageHolder.standartAddedNotHasRequireCountOfGrades);
            Assert.AreEqual(countOfStandarts + 1, pc.getProjectStandartsNames().Count, TestMessageHolder.standartAddedCountIsWrong);

            IList<string> standartNames = pc.getProjectStandartsNames();
            for (int i=0;i<countOfStandarts;i++) {
                string standartName = standartNames[i];
                string requireName = TestDataHolder.correctStandartName + Convert.ToString(i);
                Assert.AreEqual(requireName, standartName, TestMessageHolder.standartAddedNamesIsWrong);
            }
            Assert.AreEqual(TestDataHolder.correctStandartName, standartNames[countOfStandarts], TestMessageHolder.standartAddedNamesIsWrong);
        } 


        private void createProjectForStandarts(string name)
        {
            pc.createProject(name);
        }
        private void addStandartsToProject(int countOfStandarts, int countOfGrades)
        {
            for(int i=0;i<countOfStandarts;i++)
            {

                pc.addStandart(TestDataHolder.correctStandartName + Convert.ToString(i),countOfGrades);
            }

        }
        
        //------negative tests
        
        
        [DynamicData(nameof(testDataIncorrectProjectNames),DynamicDataSourceType.Method)]
        [TestCategory("negative test"),DataTestMethod]
        public void cantCreateProjectWithInCorrectName(string name,string message)
        {
            try
            {
                pc.createProject(name);
            }
            catch(FormatException fe)
            {
                Assert.AreEqual(message, fe.Message, TestMessageHolder.projectExceptionDsntThrow);                
                return;
            }
            Assert.Fail(TestMessageHolder.projectExceptionDsntThrow);
        }

        [TestCategory("negative test"), DataTestMethod]
        public void cantAddStandartsWithEqualNames()
        {
            createProjectForStandarts(TestDataHolder.correctProjectName);

            pc.addStandart(TestDataHolder.correctStandartName, TestDataHolder.defaultCountOfGrades);
            try
            {
                pc.addStandart(TestDataHolder.correctStandartName, TestDataHolder.defaultCountOfGrades);
            }
            catch (FormatException fe)
            {
                Assert.AreEqual(ErrorHolder.projectCantAddTwoStandartWithSameNames, fe.Message, TestMessageHolder.standartAddedWithSameNames);
                return;
            }
            Assert.Fail(TestMessageHolder.standartAddExpectedExceptionDsntThrow);

        }
        [DynamicData(nameof(testDataIncorrectStandartNamesAndCountsOfGrades), DynamicDataSourceType.Method)]
        [TestCategory("negative test"), DataTestMethod]
        public void cantAddStandartsWithIncorrectNamesOrCount(string standartName, int countOfGrades, string errorMessage)
        {          
            createProjectForStandarts(TestDataHolder.correctProjectName);
            try
            {
                pc.addStandart(standartName, countOfGrades);
            }
            catch (FormatException fe)
            {
                Assert.AreEqual(errorMessage, fe.Message, TestMessageHolder.standartAddedWithIncorrectData);                
                return;
            }
            Assert.Fail(TestMessageHolder.standartAddExpectedExceptionDsntThrow);
        }

        [TestMethod]
        public void cantAddStandartWithoutProject()
        {
            try
            {
                pc.addStandart(TestDataHolder.correctStandartName, TestDataHolder.defaultCountOfGrades);
            }
            catch (FormatException fe)
            {
                Assert.AreEqual(ErrorHolder.standartCantHaveNullProjectParent, fe.Message, TestMessageHolder.standartAddWithoutProjectParent);
                return;
            }
            Assert.Fail(TestMessageHolder.standartAddExpectedExceptionDsntThrow);
        }

        private static IEnumerable<object[]> testDataIncorrectProjectNames()
        {
            yield return new object[] { TestDataHolder.EmptyName,ErrorHolder.projectCantBeCreatedWithoutName};
            yield return new object[] {  TestDataHolder.NullName,ErrorHolder.projectCantBeCreatedWithoutName};

        }
        private static IEnumerable<object[]> testDataIncorrectStandartNamesAndCountsOfGrades()
        {
            yield return new object[] { TestDataHolder.EmptyName, TestDataHolder.defaultCountOfGrades,ErrorHolder.standartCantBeCreatedWithoutName };
            yield return new object[] { TestDataHolder.NullName, TestDataHolder.defaultCountOfGrades, ErrorHolder.standartCantBeCreatedWithoutName };
            yield return new object[] { TestDataHolder.correctStandartName, TestDataHolder.zeroCount, ErrorHolder.standartCantBeWithLesserThanTwoGrades };
            yield return new object[] { TestDataHolder.correctStandartName, TestDataHolder.oneCount, ErrorHolder.standartCantBeWithLesserThanTwoGrades };
            yield return new object[] { TestDataHolder.correctStandartName, TestDataHolder.lessThanZeroCount, ErrorHolder.standartCantBeWithLesserThanTwoGrades };
            yield return new object[] { TestDataHolder.correctStandartName, TestDataHolder.toManyGradesCount, ErrorHolder.standartCantHaveToMuchGrades };
        }


    }
}
