using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace eBalance.src_2
{
    public static class SCXmlHelper
    {
        static XmlDocument m_xmlExceptionsText;

        public static string getExceptionsTextByNode(string nodeName)
        {
            if (m_xmlExceptionsText == null)
            {
                initializeExceptionsText();
            }
            string textException = "";
            XmlElement xRoot = m_xmlExceptionsText.DocumentElement;
            bool nodeHasFinded = false;
            foreach (XmlElement xnode in xRoot)
            {
               
                if (xnode.LocalName == nodeName)
                {
                    textException = xnode.InnerText;
                    nodeHasFinded = true;
                    break;
                }               
            }
            if (!nodeHasFinded)
            {
                throw new FormatException(getExceptionsTextByNode("wrongExceptionNode"));
            }
            return textException;
        }

        private static void initializeExceptionsText()
        {
            m_xmlExceptionsText = new XmlDocument();
            m_xmlExceptionsText.Load("C:/Users/user/source/repos/eBalance/eBalance/src_2/ExceptionsText.xml");
        }
    }
}
