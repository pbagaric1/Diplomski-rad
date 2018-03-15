namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableQuestionGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "QuestionGroupId", "dbo.QuestionGroups");
            DropIndex("dbo.Questions", new[] { "QuestionGroupId" });
            AlterColumn("dbo.Questions", "QuestionGroupId", c => c.Int());
            CreateIndex("dbo.Questions", "QuestionGroupId");
            AddForeignKey("dbo.Questions", "QuestionGroupId", "dbo.QuestionGroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestionGroupId", "dbo.QuestionGroups");
            DropIndex("dbo.Questions", new[] { "QuestionGroupId" });
            AlterColumn("dbo.Questions", "QuestionGroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "QuestionGroupId");
            AddForeignKey("dbo.Questions", "QuestionGroupId", "dbo.QuestionGroups", "Id", cascadeDelete: true);
        }
    }
}
