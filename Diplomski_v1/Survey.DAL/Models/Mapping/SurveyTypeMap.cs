using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models.Mapping
{
    public class SurveyTypeMap : EntityTypeConfiguration<SurveyType>
    {
        public SurveyTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);


            // Table & Column Mappings
            this.ToTable("SurveyTypes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");

        }
    }
}