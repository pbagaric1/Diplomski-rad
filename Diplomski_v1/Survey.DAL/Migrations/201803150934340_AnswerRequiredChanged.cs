namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerRequiredChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "IsRequired", c => c.Boolean(nullable: false));
            DropColumn("dbo.Questions", "AnswerRequired");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "AnswerRequired", c => c.Boolean(nullable: false));
            DropColumn("dbo.Questions", "IsRequired");
        }
    }
}
