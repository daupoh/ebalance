using eBalance.src.controller.NamesHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public static class MessageHolder
    {
        public static string
            checkNewProjectNameFailed = "Ошибка сравнения. Имя нового проекта по умолчанию должно быть: "+NameHolder.defaultProjectName+"." ;
    }
}
