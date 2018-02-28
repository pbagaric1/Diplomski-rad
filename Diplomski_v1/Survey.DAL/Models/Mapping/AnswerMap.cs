using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired();

            //this.Property(t => t.QuestionId)
            //    .IsRequired();

            //// Table & Column Mappings
            //this.ToTable("Answers");
            //this.Property(t => t.Id).HasColumnName("Id");
            //this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            //this.Property(t => t.Text).HasColumnName("Text");

            //// Relationships
            //this.HasRequired(t => t.Question)
            //    .WithMany(t => t.Answers)
            //    .HasForeignKey(d => d.QuestionId);

        }

    }
}
