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
        public string UserId { get; set; }
        public Guid PollTypeId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual PollType PollType { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
