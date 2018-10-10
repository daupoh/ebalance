using eBalance.src.controller.NamesHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src.controller.Holders
{
    public static class ErrorHolder
    {
        public static string
           standartCantAddNotUniqueGrade = "Ошибка при добавлении оценки стандарту. Оценка с таким именем уже присутствует.",
            standartCantAddNullGrade = "Ошибка при добавлении оценки стандарту. Оценка не может быть равна Null.",
            standartCantAddNullListGrades = "Ошибка при добавлении оценок стандарту. Список оценок не может быть равен Null или быть пустым",
           standartIsAlreadyParentToGrade = "Ошибка при назначении стандарта оценке. Стандарт с таким именем уже привязан к этой оценке.",
           standartCantHaveToMuchGrades = "Ошибка при добавлении оценки стандарту. Превышено максимальное количество оценок для стандарта - " + NamesValuesHolder.maximumGradesInStandart + " .",
           standartCantBeCreatedWithoutName = "Ошибка при создании стандарта. Стандарт не может быть создан с пустым именем.",
           standartCantBeWithLesserThanTwoGrades = "Ошибка при создании стандарта. Стандарт не может иметь меньше двух оценок.",
           standartCantHaveNullProjectParent = "Ошибка при назначении проекта стандарту. Проект не может быть равен Null.",
           standartAlreadyHaveThisParent = "Ошибка при назначении проекта стандарту. Проект с таким именем уже привязан к этому стандарту.",
           standartCantCompareWithNull = "Ошибка при сравнении стандартов. Стандарт не может сравниваться с Null",
            

            gradeCantBeCreatedWithoutName = "Ошибка при создании оценки. Оценка не может быть создана с пустым именем",
            gradeCantHaveNullStandartParent = "Ошибка при назначении стандарта оценке. Оценка не может быть привязана к Null",
            gradeCantCompareWithNull = "Ошибка при сравнении оценок. Оценка не может сравниваться с Null",
           
           projectCantBeCreatedWithoutName = "Ошибка при создании проекта. Проект не может быть создан с пустым именем.",
           projectCantHaveNullStandartList = "Ошибка при создании проекта. Список стандартов проекта не может быть равен Null",
           projectCantAddNullStandart = "Ошибка при добавлении стандарта в проект. Стандарт не может быть равен Null",
            projectCantAddTwoStandartWithSameNames = "Ошибка при добавлении стандарта в проект. " +
            "Стандарт не может быть добавлен, так как стандарт с таким именем уже добавлен"
            ,projectDsntHaveParrents = "Ошибка. Проект не может иметь родителя"

            ,controllerCantReturnNameOfEmtyProject ="Ошибка при возвращении имени проекта. Невозможно вернуть имя проекта равного Null"
            ,controllerCantReturnNameOfEmptyCurentStandart ="Ошибка при возвращении имени текущего стандарта. Невозможно вернуть имя стандарта равного Null"
            ,controllerCantReturnListOfStandarts = "Ошибка при возвращении списка стандартов проекта. Невозможно вернуть список стандартов равный Null. "
            ,controllerCantReturnListOfGrades = "Ошибка при возвращении списка оценок стандарта. Невозможно вернуть список оценок равный Null."
            ;

    }
}
