using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Models.QuestionTypeModels;
using Survey.Business.Models.ViewModels;

namespace Survey.Business.Mapping
{
    internal static class RatingTypeMap
    {
        public static RatingTypeModel MapToDto(QuestionView item)
        {
            if (item == null)
                return null;

            return new RatingTypeModel()
            {
                Title = item.Title,
                isRequired = item.isRequired,
                maximumRateDescription = item.maximumRateDescription,
                minimumRateDescription = item.minimumRateDescription
            };
        }
    }
}
