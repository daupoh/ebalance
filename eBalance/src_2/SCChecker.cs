using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2
{
    public static class SCChecker
    {
        public static void isStringNotEmpty(string someStr)
        {
            if (someStr==null || someStr=="")
            {
                throw new FormatException(SCXmlHelper.getExceptionsTextByNode("stringIsEmpty"));
            }
        }
    }
}
