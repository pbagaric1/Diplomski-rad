using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MVC_WebApi.ViewModels
{
    public class PollTypeView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PollView> Polls { get; set; }
    }
}