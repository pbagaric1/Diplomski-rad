using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model.Common
{
    public interface IPollDomain
    {
        Guid Id { get; set; }
        string UserId { get; set; }
        Guid PollTypeId { get; set; }
        string Name { get; set; }
        string Location { get; set; }

        //IAspNetUserDomain AspNetUser { get; set; }
        //ISurveyTypeDomain SurveyType { get; set; }
        //ICollection<IQuestionDomain> Questions { get; set; }
    }
}
