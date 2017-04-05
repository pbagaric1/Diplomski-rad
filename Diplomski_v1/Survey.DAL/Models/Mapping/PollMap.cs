using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DAL.Models.Mapping
{
    public class PollMap : EntityTypeConfiguration<Poll>
    {
        public PollMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired();

            this.Property(t => t.UserId)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Polls");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Location).HasColumnName("Location");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.Polls)
                .HasForeignKey(d => d.UserId);

            this.HasRequired(t => t.PollType)
                .WithMany(t => t.Polls)
                .HasForeignKey(d => d.PollTypeId);

        }
    }
}
