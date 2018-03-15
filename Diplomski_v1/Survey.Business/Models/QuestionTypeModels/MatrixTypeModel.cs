using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.DAL.Models;

namespace Survey.Business.Models.QuestionTypeModels
{
    public class MatrixTypeModel
    {
        public string Title { get; set; }
        public bool isRequired { get; set; }

        public ICollection<MatrixRow> MatrixRows { get; set; }
        public ICollection<MatrixColumn> MatrixColumns { get; set; }
    }
}