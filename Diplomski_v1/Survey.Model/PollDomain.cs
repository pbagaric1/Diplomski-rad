using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model
{
    public class PollDomain : IPollDomain
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid PollTypeId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //public virtual IAspNetUserDomain AspNetUser { get; set; }
        //public virtual IPollTypeDomain PollType { get; set; }
        public ICollection<IQuestionDomain> Questions { get; set; }
    }
}
