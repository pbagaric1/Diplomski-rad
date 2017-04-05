using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model.Common
{
    public interface IPollTypeDomain
    {
        Guid Id { get; set; }
        string Name { get; set; }

        ICollection<IPollDomain> Polls { get; set; }
    }
}
