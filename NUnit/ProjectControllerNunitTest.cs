using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBalance.src.controller.Holders;
using eBalance.src.controller.ProjectController.Classes;
using eBalance.src.controller.ProjectController.Interfaces;
using NUnit.Framework;
using TestEBalance;

namespace NUnit
{
    [TestFixture]
    public class ProjectControllerNunitTest
    {
        IProjectController pc;
      
        [SetUp]
        public void prepareProjectController()
        {
            pc = new ProjectController();
        }

        [TearDown]
        public void clearProjectController()
        {
            pc.Dispose();
            pc = null;
        }
        //------positive tests


        [Test]
        public void canCreateProjectWithCorrectName()
        {
            pc.createProject(TestDataHolder.correctProjectName);
            Assert.AreEqual(TestDataHolder.correctProjectName, pc.getProjectName(), TestMessageHolder.projectExpectedNameNotEqualActualName);
        }

        [TestCaseSource("addStandartWithCorrectDataTestCases")]
        public void canAddStandartsWithCorrectNameAndCountOfGradesInQuantity(int countOfStandarts)
        {
            createProjectForStandarts(TestDataHolder.correctProjectName);
            addStandartsToProject(countOfStandarts, TestDataHolder.defaultCountOfGrades);

            pc.addStandart(TestDataHolder.correctStandartName, TestDataHolder.defaultCountOfGrades);
            Assert.AreEqual(TestDataHolder.correctStandartName, pc.getCurrentStandartName(), TestMessageHolder.standartAddedNotBeenCurrentForProject);
            Assert.AreEqual(TestDataHolder.defaultCountOfGrades, pc.getStandartGradesNames(TestDataHolder.correctStandartName).Count,
                TestMessageHolder.standartAddedNotHasRequireCountOfGrades);
            Assert.AreEqual(countOfStandarts + 1, pc.getProjectStandartsNames().Count, TestMessageHolder.standartAddedCountIsWrong);

            IList<string> standartNames = pc.getProjectStandartsNames();
            for (int i = 0; i < countOfStandarts; i++)
            {
                string standartName = standartNames[i];
                string requireName = TestDataHolder.correctStandartName + Convert.ToString(i);
                Assert.AreEqual(requireName, standartName, TestMessageHolder.standartAddedNamesIsWrong);
            }
            Assert.AreEqual(TestDataHolder.correctStandartName, standartNames[countOfStandarts], TestMessageHolder.standartAddedNamesIsWrong);
        }
        public static List<TestCaseData> addStandartWithCorrectDataTestCases()
        {
            List<TestCaseData> list = new List<TestCaseData>();
            list.Add(new TestCaseData(TestDataHolder.zeroCount));
            list.Add(new TestCaseData(TestDataHolder.oneCount));
            list.Add(new TestCaseData(TestDataHolder.moreThanZeroCount));
            return list;
        }

        private void createProjectForStandarts(string name)
        {
            pc.createProject(name);
        }
        private void addStandartsToProject(int countOfStandarts, int countOfGrades)
        {
            for (int i = 0; i < countOfStandarts; i++)
            {

                pc.addStandart(TestDataHolder.correctStandartName + Convert.ToString(i), countOfGrades);
            }

        }

        //------negative tests

        [TestCaseSource("createProjectIncorrectNameTestCases")]
        public void cantCreateProjectWithInCorrectName(string name, string message)
        {
            try
            {
                pc.createProject(name);
            }
            catch (FormatException fe)
            {
                Assert.AreEqual(message, fe.Message, TestMessageHolder.projectExceptionDsntThrow);
                return;
            }
            Assert.Fail(TestMessageHolder.projectExceptionDsntThrow);
        }

        [Test]
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

        [Test]
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

        [TestCaseSource("addStandartWithIncorrectDataTestCases")]
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
        public static List<TestCaseData> addStandartWithIncorrectDataTestCases()
        {
            List<TestCaseData> list = new List<TestCaseData>();
            list.Add(new TestCaseData(TestDataHolder.EmptyName, TestDataHolder.defaultCountOfGrades, ErrorHolder.standartCantBeCreatedWithoutName));
            list.Add(new TestCaseData(TestDataHolder.NullName, TestDataHolder.defaultCountOfGrades, ErrorHolder.standartCantBeCreatedWithoutName));
            list.Add(new TestCaseData(TestDataHolder.correctStandartName, TestDataHolder.zeroCount, ErrorHolder.standartCantBeWithLesserThanTwoGrades));
            list.Add(new TestCaseData(TestDataHolder.correctStandartName, TestDataHolder.oneCount, ErrorHolder.standartCantBeWithLesserThanTwoGrades));
            list.Add(new TestCaseData(TestDataHolder.correctStandartName, TestDataHolder.lessThanZeroCount, ErrorHolder.standartCantBeWithLesserThanTwoGrades));
            list.Add(new TestCaseData(TestDataHolder.correctStandartName, TestDataHolder.toManyGradesCount, ErrorHolder.standartCantHaveToMuchGrades));
            return list;         
        }

        public static List<TestCaseData> createProjectIncorrectNameTestCases()
        {
            List<TestCaseData> list = new List<TestCaseData>();
            list.Add(new TestCaseData(TestDataHolder.EmptyName, ErrorHolder.projectCantBeCreatedWithoutName));
            list.Add(new TestCaseData(TestDataHolder.NullName, ErrorHolder.projectCantBeCreatedWithoutName));

            return list;

        }

    }
}

