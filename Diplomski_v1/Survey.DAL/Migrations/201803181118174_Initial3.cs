namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionChoices", "QuestionOptionGroup_Id", "dbo.QuestionOptionGroups");
            DropIndex("dbo.QuestionChoices", new[] { "QuestionOptionGroup_Id" });
            DropColumn("dbo.QuestionChoices", "QuestionOptionGroup_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionChoices", "QuestionOptionGroup_Id", c => c.Int());
            CreateIndex("dbo.QuestionChoices", "QuestionOptionGroup_Id");
            AddForeignKey("dbo.QuestionChoices", "QuestionOptionGroup_Id", "dbo.QuestionOptionGroups", "Id");
        }
    }
}
