using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Survey.DAL.Models.Mapping;
using Survey.DAL.Common;
using System;

namespace Survey.DAL.Models
{
    public partial class SurveyDatabaseContext : DbContext, ISurveyContext
    {
        static SurveyDatabaseContext()
        {
            Database.SetInitializer<SurveyDatabaseContext>(null);
        }

        public SurveyDatabaseContext()
            : base("Name=SurveyConnString")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollType> PollTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new PollMap());
            modelBuilder.Configurations.Add(new PollTypeMap());
        }
    }
}
