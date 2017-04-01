using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.SurveyId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SurveyId).HasColumnName("SurveyId");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.Survey)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.SurveyId);

        }
    }
}
