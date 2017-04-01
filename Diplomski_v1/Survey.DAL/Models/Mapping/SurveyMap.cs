﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models.Mapping
{
    public class SurveyMap : EntityTypeConfiguration<Survey>
    {
        public SurveyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Surveys");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.Surveys)
                .HasForeignKey(d => d.UserId);

            this.HasRequired(t => t.SurveyType)
                .WithMany(t => t.Surveys)
                .HasForeignKey(d => d.SurveyTypeId);

        }
    }
}
