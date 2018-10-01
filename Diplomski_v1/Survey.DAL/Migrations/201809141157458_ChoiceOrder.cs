namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChoiceOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionChoices", "ChoiceOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionChoices", "ChoiceOrder");
        }
    }
}
