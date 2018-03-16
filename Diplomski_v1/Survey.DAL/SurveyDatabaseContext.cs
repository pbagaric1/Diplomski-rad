using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Survey.DAL.Models.Mapping;
using System;
using Survey.DAL.Common;
using Survey.DAL.Models;

namespace Survey.DAL
{
    public class SurveyDatabaseContext : DbContext, ISurveyContext
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
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<RatingQuestion> RatingQuestions { get; set; }
        public DbSet<CheckboxQuestion> CheckboxQuestions { get; set; }
        public DbSet<RadiogroupQuestion> RadiogroupQuestions { get; set; }
        public DbSet<TextQuestion> TextQuestions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new AnswerMap());
            //modelBuilder.Configurations.Add(new QuestionMap());
            //modelBuilder.Configurations.Add(new PollMap());
        }
    }
}
