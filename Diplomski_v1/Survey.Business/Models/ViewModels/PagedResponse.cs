using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Business.Models.ViewModels
{
    public class PagedResponse
    {
        public int Total { get; set; }
        public ICollection<PollView> Data  { get; set; }
    }
}
