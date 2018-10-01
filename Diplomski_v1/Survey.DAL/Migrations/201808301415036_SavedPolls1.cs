namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavedPolls1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedPolls", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SavedPolls", "DateAdded");
        }
    }
}
