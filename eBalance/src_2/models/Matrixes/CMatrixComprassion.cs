using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;

namespace eBalance.src_2.models.Matrixes
{
    class CMatrixComprassion : IMatrixComprassion
    {
        double[][] m_dbar2Matrix;
        uint m_uiSizeOfMatrix;
        double[] m_dbarSameNumbers;
        double m_dbMaxSameNumber, m_dbIndexOfConsistency, m_dbRandomIndex, m_dbRelativeConsistency;

        Dictionary<uint, double> m_pRandomIndexes = new Dictionary<uint, double>
        {
            {2, 0.0},{3, 0.58},{4, 0.9},{5,1.12 },
            {6, 1.24},{7,1.32 },{8,1.41 },{9,1.45 },{10,1.49 },
            {11, 1.51},{12,1.48 },{13,1.56 },{14,1.57 },{15,1.59 }
        };

        public CMatrixComprassion(uint sizeOfMatrix)
        {
            checkSizeOfMatrix(sizeOfMatrix);

            m_dbar2Matrix = new double[sizeOfMatrix][];
            m_uiSizeOfMatrix = sizeOfMatrix;
            m_dbarSameNumbers = new double[sizeOfMatrix];
            for (int i = 0; i < sizeOfMatrix; i++)
            {
                m_dbarSameNumbers[i] = 0;
                m_dbar2Matrix[i] = new double[sizeOfMatrix];
            }
            initializeMatrixOfComprassion();
        }

        public double[] getSameNumbers
        {
            get
            {
                checkMatrixInitialization();
                checkSameNumberVector();
                return m_dbarSameNumbers;
            }
        }

        public double getRelativeConsistency
        {
            get
            {
                checkMatrixInitialization();
                checkSameNumberVector();
                checkMatrixDataIsFull();

                m_dbMaxSameNumber = getMaxSameNumber();
                m_dbIndexOfConsistency = (m_dbMaxSameNumber - m_uiSizeOfMatrix) / 2;
                m_dbRelativeConsistency = m_dbIndexOfConsistency / m_dbRandomIndex;

                return m_dbRelativeConsistency;

            }

        }

        public double getElement(uint rowNumber, uint columnNumber)
        {
            checkMatrixInitialization();
            if (rowNumber >= m_uiSizeOfMatrix || columnNumber >= m_uiSizeOfMatrix)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("outOfRangeMatrix"));
            }

            double element = m_dbar2Matrix[rowNumber][columnNumber];

            return element;
        }
        public void setElement(uint rowNumber, uint columnNumber, double value)
        {
            checkMatrixInitialization();
            if (rowNumber >= m_uiSizeOfMatrix || columnNumber >= m_uiSizeOfMatrix )
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("outOfRangeMatrix"));
            }
            if (rowNumber == columnNumber)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("cantSetElementOnDiagonal"));
            }
            if (value<=0 || value>9)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("notValidMatrixComprassionsValue"));
            }
            m_dbar2Matrix[rowNumber][columnNumber] = value;
            m_dbar2Matrix[columnNumber][rowNumber] = 1 / value;
        }

        private void checkSameNumberVector()
        {
            bool vectorIsValid = true;
            if (m_dbarSameNumbers != null)
            {
                foreach (double d in m_dbarSameNumbers)
                {
                    if (d >= 1 || d <= 0)
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
        private void checkSizeOfMatrix(uint sizeOfMatrix)
        {
            double randomIndex = 0;
            bool canGetRandomIndex = m_pRandomIndexes.TryGetValue(sizeOfMatrix, out randomIndex);
            if (canGetRandomIndex)
            {
                m_dbRandomIndex = randomIndex;
            }
            else
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("exceededLimitOfRandomIndexes"));
            }
        }
        private void checkMatrixInitialization()
        {
            if (m_dbar2Matrix == null)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("matrixIsNotInitialize"));
            }
        }
        private void initializeMatrixOfComprassion()
        {
            for (int i = 0; i < m_uiSizeOfMatrix; i++)
            {
                m_dbar2Matrix[i][i] = 1.0;
            }
        }
        private void checkMatrixDataIsFull()
        {
            bool dataFull = true;
            uint i = 0;
            while (dataFull && i < m_uiSizeOfMatrix)
            {
                double[] ds = m_dbar2Matrix[i];
                foreach (double d in ds)
                {
                    if (d == 0)
                    {
                        dataFull = false;
                        break;
                    }
                }
                i++;
            }
            if (!dataFull)
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("cantGetRelativeConsistency"));
            }
        }
        private double getMaxSameNumber()
        {
            
            double maxSameNumber = 0;
            double[] sumByColumns = new double[m_uiSizeOfMatrix];
            for (int i = 0; i < m_uiSizeOfMatrix; i++)
            {
                sumByColumns[i] = 0;
                for (int j = 0; j < m_uiSizeOfMatrix; j++)
                {
                    sumByColumns[i] += m_dbar2Matrix[j][i];
                }
            }
            for (int i = 0; i < m_uiSizeOfMatrix; i++)
            {
                maxSameNumber += sumByColumns[i] * m_dbarSameNumbers[i];
            }
            return maxSameNumber;
        }
    }
}
