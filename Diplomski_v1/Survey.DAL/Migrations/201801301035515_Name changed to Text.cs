namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamechangedtoText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Text", c => c.String());
            DropColumn("dbo.Answers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Name", c => c.String());
            DropColumn("dbo.Answers", "Text");
        }
    }
}
