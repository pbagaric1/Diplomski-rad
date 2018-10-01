namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTakesCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "TakesCount", c => c.Int(nullable: false));
            AddColumn("dbo.Polls", "Description", c => c.String());
            AddColumn("dbo.Polls", "TakesCount", c => c.Int(nullable: false));
            DropColumn("dbo.Polls", "Instructions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Polls", "Instructions", c => c.String());
            DropColumn("dbo.Polls", "TakesCount");
            DropColumn("dbo.Polls", "Description");
            DropColumn("dbo.Questions", "TakesCount");
        }
    }
}
