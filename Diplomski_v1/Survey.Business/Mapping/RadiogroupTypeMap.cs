using System.Collections.Generic;
using Survey.Business.Models.QuestionTypeModels;
using Survey.DAL.Models;

namespace Survey.Business.Mapping
{
    public static class RadiogroupTypeMap
    {
        public static RadiogroupTypeModel MapToDto(Question item, List<string> questionChoices)
        {
            if (item == null)
                return null;

            return new RadiogroupTypeModel()
            {
                Title = item.Title,
                isRequired = item.IsRequired,
                Choices = questionChoices
            };
        }
    }
}
