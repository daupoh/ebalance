using eBalance.src.controller.NamesHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src.controller.Holders
{
    class ErrorHolder
    {
        public static string
           notUniqueGradeAddedToStandartError = "Ошибка при добавлении оценки стандарту. Оценка с таким именем уже присутствует.",
           standartIsAlreadyParentToGrade = "Ошибка при назначении стандарта оценке. Стандарт с таким именем уже привязан к этой оценке.",
           toManyGradesForStandart = "Ошибка при добавлении оценки стандарту. Превышено максимальное количество оценок для стандарта - " + NameHolder.maximumGradesInStandart + " .",
           projectIsAlreadyParentToStandart = "Ошибка при назначении проекта стандарту. Проект с таким именем уже привязан к этому стандарту.",
            projectCantBeCreatedWithoutName = "Ошибка при создании проекта. Проект не может быть создан с пустым именем.",
            projectCantHaveNullStandartList = "Ошибка при создании проекта. Список стандартов проекта не может быть равен Null",
            projectCantAddNullStandart = "Ошибка при добавлении стандарта в проект. Стандарт не может быть равен Null";

    }
}
