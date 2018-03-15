using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Business.Models.QuestionTypeModels;
using Survey.Business.Models.ViewModels;

namespace Survey.Business.Mapping
{
    internal static class CommentTypeMap
    {
        public static CommentTypeModel MapToDto(QuestionView item)
        {
            if (item == null)
                return null;

            return new CommentTypeModel()
            {
                Title = item.Title,
                isRequired = item.isRequired
            };
        }
    }
}
