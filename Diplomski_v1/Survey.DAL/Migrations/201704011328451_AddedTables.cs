namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        QuestionId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SurveyId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.SurveyTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Surveys", "SurveyTypeId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Surveys", "SurveyTypeId");
            AddForeignKey("dbo.Surveys", "SurveyTypeId", "dbo.SurveyTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.Surveys", "SurveyTypeId", "dbo.SurveyTypes");
            DropIndex("dbo.Surveys", new[] { "SurveyTypeId" });
            DropIndex("dbo.Questions", new[] { "SurveyId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropColumn("dbo.Surveys", "SurveyTypeId");
            DropTable("dbo.SurveyTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
