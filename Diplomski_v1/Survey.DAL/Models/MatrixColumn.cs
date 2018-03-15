using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models
{
    public class MatrixColumn
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
