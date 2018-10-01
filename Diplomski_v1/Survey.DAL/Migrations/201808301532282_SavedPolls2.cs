namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavedPolls2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SavedPolls", "DateAdded", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SavedPolls", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
