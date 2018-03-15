using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.DAL.Models
{
    public class RatingTypeModel : Question
    {
        public string MinimumRateDescription { get; set; }
        public string MaximumRateDescription { get; set; }
    }
}