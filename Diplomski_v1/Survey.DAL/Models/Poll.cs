using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class Poll
    {
        public Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public Guid OrganizationId { get; set; }

        public string Name { get; set; }
        public string Instructions { get; set; }
        public DateTime CreatedOn { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        public ICollection<UserPoll> UserPolls { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
