namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.QuestionOptionGroups", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionOptionGroups", "QuestionId", c => c.Guid(nullable: false));
        }
    }
}
