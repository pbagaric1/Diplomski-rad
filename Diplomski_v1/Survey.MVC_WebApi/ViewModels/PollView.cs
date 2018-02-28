using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MVC_WebApi.ViewModels
{
    public class PollView
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid PollTypeId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //public virtual AspNetUserView AspNetUser { get; set; }
        //public virtual PollTypeView PollType { get; set; }
        public ICollection<QuestionView> Questions { get; set; }
    }
}