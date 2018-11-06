using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Matrixes
{
    public class CMatrixGrades : IMatrixGrades
    {
        double[][] m_dbar2Matrix;
        uint m_uiAlternativesCount, m_uiCriterionsCount;

        public CMatrixGrades(uint nAlternatives, uint nCriterions)
        {
            if (nAlternatives < 2 || nCriterions < 2)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("countOfAlternativesOrCriterionLessThenTwo"));
            }

            m_dbar2Matrix = new double[nAlternatives][];
            m_uiAlternativesCount = nAlternatives;
            m_uiCriterionsCount = nCriterions;

            for (int i = 0; i < nAlternatives; i++)
            {
                m_dbar2Matrix[i] = new double[nCriterions];
            }
        }
        public uint CountOfAlternatives {
            get
            {
                checkMatrixInitialization();
                return m_uiAlternativesCount;
            }
        }
        public uint CountOfCriterions {
            get
            {
                checkMatrixInitialization();
                return m_uiCriterionsCount;
            }
        }

        public double getElement(uint rowNumber, uint columnNumber)
        {
            checkMatrixInitialization();
            if (rowNumber < m_uiAlternativesCount && columnNumber < m_uiCriterionsCount)
            {
                return m_dbar2Matrix[rowNumber][columnNumber];
            }
            else
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("outOfRangeMatrix") + "\r\n" +
                    SCXmlHelper.getExceptionsTextByNode("matrixIsNotInitialize"));
            }
        }
        public void setElement(uint rowNumber, uint columnNumber, double value)
        {
            checkMatrixInitialization();
            if (rowNumber < m_uiAlternativesCount && columnNumber < m_uiCriterionsCount
                && value > 0 && value < 1)
            {
                m_dbar2Matrix[rowNumber][columnNumber] = value;
            }
            else
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("outOfRangeMatrix") + "\r\n" +
                    SCXmlHelper.getExceptionsTextByNode("notValidMatrixGradesValue") + "\r\n" +
                    SCXmlHelper.getExceptionsTextByNode("matrixIsNotInitialize"));
            }
        }

        public void normalizeMatrix()
        {
            checkMatrixInitialization();

            double[] sumByColumns = new double[m_uiCriterionsCount];
            for (int i = 0; i < m_uiCriterionsCount; i++)
            {
                sumByColumns[i] = 0;
                for (int j = 0; j < m_uiAlternativesCount; j++)
                {
                    sumByColumns[i] += m_dbar2Matrix[j][i];
                }
            }
            for (int i = 0; i < m_uiAlternativesCount; i++)
            {
                for (int j = 0; j < m_uiCriterionsCount; j++)
                {
                    m_dbar2Matrix[i][j] = m_dbar2Matrix[i][j] / sumByColumns[i];
                }
            }

        }
        public double[] getRelativeWeight(double[] criterionWeight)
        {
            checkCriterionWeight(criterionWeight);
            checkMatrixInitialization();

            double[] relativeWeight = new double[m_uiAlternativesCount];

            for (int i = 0; i < m_uiAlternativesCount; i++)
            {
                relativeWeight[i] = 0;
                for (int j = 0; j < m_uiCriterionsCount; j++)
                {
                    relativeWeight[i] += criterionWeight[j] * m_dbar2Matrix[i][j];
                }
            }
            return relativeWeight;
        }

        private void checkCriterionWeight(double[] vector)
        {
            bool vectorIsValid = true;
            if (vector!=null)
            {
                foreach(double d in vector)
                {
                    if (d>=1 || d <= 0)
                    {
                        vectorIsValid = false;
                        break;
                    }
                }

            }
            else
            {
                vectorIsValid = false;
            }
            if (!vectorIsValid)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("nonvalidcriterionweightvector"));
            }
        }
        private void checkMatrixInitialization()
        {
            if (m_dbar2Matrix == null)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("matrixIsNotInitialize"));
            }
        }
    }
}
