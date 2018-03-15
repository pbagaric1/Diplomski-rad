namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuestionGroupTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        minimumRateDescription = c.String(),
                        maximumRateDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "QuestionGroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "QuestionGroupId");
            AddForeignKey("dbo.Questions", "QuestionGroupId", "dbo.QuestionGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestionGroupId", "dbo.QuestionGroups");
            DropIndex("dbo.Questions", new[] { "QuestionGroupId" });
            DropColumn("dbo.Questions", "QuestionGroupId");
            DropTable("dbo.QuestionGroups");
        }
    }
}
