using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEBalance
{
    public static class TestMessageHolder
    {
        public static string
            projectExpectedNameNotEqualActualName = "Проверка создания проекта с корректным именем провалена. Ожидаемое имя проекта не совпадает с реальным.",
            projectExceptionDsntThrow = "Проверка создания проекта с некорректным именем провалена. Ожидаемое исключение не выброшено или выброшено иное исключение";

    }
}
