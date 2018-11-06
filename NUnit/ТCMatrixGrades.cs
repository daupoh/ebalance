using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBalance.src_2;
using eBalance.src_2.models.Matrixes;
using NUnit.Framework;

namespace NUnit
{
    [TestFixture]
    class ТCMatrixGrades
    {
        IMatrixGrades m_pMatrixGrades;
        string messageAssertionFailureText = "",            
            messageAssertionDsntWork = "";

        [SetUp]
        public void initialize()
        {
            messageAssertionFailureText = "Не соответствие ожидаемого результата реальному. ";
            messageAssertionDsntWork = "Ожидаемое исключение не было брошено";
        }
        
        [TestCase]
        public void canGetExceptionString()
        {
            string test = SCXmlHelper.getExceptionsTextByNode("test");          
            Assert.AreEqual("TestText", test, messageAssertionFailureText);
        }

        [TestCaseSource("getPositiveAlternativeCountAndCriterionCounts")]
        public void canGetAlternativesAndCriterionsCounts(uint nAlternatives, uint nCriterions)
        {
            m_pMatrixGrades = new CMatrixGrades(nAlternatives, nCriterions);
            uint nAlt = m_pMatrixGrades.CountOfAlternatives,
                nCrits = m_pMatrixGrades.CountOfCriterions;
            Assert.AreEqual(nAlternatives, nAlt, messageAssertionFailureText);
            Assert.AreEqual(nCriterions, nCrits, messageAssertionFailureText);
        }

        [TestCaseSource("getNegativeAlternativeCountAndCriterionCounts")]
        public void cantInitializeMatrix(uint nAlternatives, uint nCriterions)
        {
            try
            {
                m_pMatrixGrades = new CMatrixGrades(nAlternatives, nCriterions);
            }
            catch (FormatException exc)
            {                
                Assert.AreEqual(SCXmlHelper
                    .getExceptionsTextByNode("countOfAlternativesOrCriterionLessThenTwo"),
                    exc.Message, messageAssertionFailureText);
                return;
            }
            Assert.Fail(messageAssertionDsntWork);
        }

        public static List<TestCaseData> getNegativeAlternativeCountAndCriterionCounts()
        {
            uint one = 1, two = 2, zero = +0;
            List<TestCaseData> list = new List<TestCaseData>();
            list.Add(new TestCaseData(one, two));
            list.Add(new TestCaseData(zero, zero));
            list.Add(new TestCaseData(two, one));
            
            return list;
        }
        public static List<TestCaseData> getPositiveAlternativeCountAndCriterionCounts()
        {
            uint five = 5, two = 2;
            List<TestCaseData> list = new List<TestCaseData>();
            list.Add(new TestCaseData(five, two));
            list.Add(new TestCaseData(five, five));
            list.Add(new TestCaseData(two, five));

            return list;
        }


        [TearDown]
        public void cleanUp()
        {

        }
    }
}
