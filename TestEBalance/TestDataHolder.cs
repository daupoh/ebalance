using eBalance.src.controller.NamesHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEBalance
{
    static class TestDataHolder
    {        
        public static string
            correctProjectName = "MyProject",
            correctStandartName="MyStandart",
            EmptyName = "",
            NullName=null
          
            ;
        public static int
            defaultCountOfGrades = 2,
            toManyGradesCount = NamesValuesHolder.maximumGradesInStandart+1,
            zeroCount=0,
            lessThanZeroCount = -5,
            oneCount=1
            ;
    }
}
