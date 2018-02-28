using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    
    public class UserPoll
    {
        public Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public Guid PollId { get; set; }

        public DateTime CompletedOn { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
