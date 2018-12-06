using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.controllers
{
    interface IStandartController:IParrentEntityController
    {
        void addStandart(string standartName, uint gradesCount);
    }
}
