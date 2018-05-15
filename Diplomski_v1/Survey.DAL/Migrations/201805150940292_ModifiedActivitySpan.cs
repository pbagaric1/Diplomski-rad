namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedActivitySpan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "ActivityEndTime", c => c.DateTime());
            DropColumn("dbo.Polls", "ActivityDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Polls", "ActivityDuration", c => c.Time(precision: 7));
            DropColumn("dbo.Polls", "ActivityEndTime");
        }
    }
}
