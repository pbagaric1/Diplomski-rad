using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Survey.DAL.Models.Mapping;

namespace Survey.DAL.Models
{
    public partial class SurveyDatabaseContext : DbContext
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
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyType> SurveyTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new SurveyMap());
            modelBuilder.Configurations.Add(new SurveyTypeMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new AnswerMap());
        }
    }
}
