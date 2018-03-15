namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedProperties : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.QuestionChoices", "minimumRateDescription");
            DropColumn("dbo.QuestionChoices", "maximumRateDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionChoices", "maximumRateDescription", c => c.String());
            AddColumn("dbo.QuestionChoices", "minimumRateDescription", c => c.String());
        }
    }
}
