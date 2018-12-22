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
        static XmlDocument m_xmlConstantValues;

        public static string getExceptionsTextByNode(string nodeName)
        {
            return getByNodeFrom(nodeName, m_xmlExceptionsText, "wrongExceptionNode", 
                "C:/Users/user/source/repos/eBalance/eBalance/src_2/ExceptionsText.xml");
        }
        public static string getConstantByNode(string nodeName)
        {
            return getByNodeFrom(nodeName, m_xmlConstantValues, "wrongExceptionNode",
               "C:/Users/user/source/repos/eBalance/eBalance/src_2/ConstantValues.xml");
        }
        private static string getByNodeFrom(string nodeName, XmlDocument xmlDoc, string wrongNode, string path)
        {
            if (wrongNode=="")
            {
                throw new FormatException("XML not found exception");
            }
            if (xmlDoc == null)
            {
                initializeXml(path,xmlDoc);
            }
            string text = "";
            XmlElement xRoot = xmlDoc.DocumentElement;
            bool nodeHasFinded = false;
            foreach (XmlElement xnode in xRoot)
            {

                if (xnode.LocalName == nodeName)
                {
                    text = xnode.InnerText;
                    nodeHasFinded = true;
                    break;
                }
            }
            if (!nodeHasFinded)
            {
                throw new FormatException(getByNodeFrom(wrongNode, xmlDoc,"",path));
            }
            return text;
        }
        private static void initializeXml(string path, XmlDocument xmlDoc)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            
        }
    }
}
