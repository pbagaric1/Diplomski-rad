namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedOptionGroupId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "OptionGroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "OptionGroupId", c => c.Guid());
        }
    }
}
