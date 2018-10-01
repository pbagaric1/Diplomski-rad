namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "IsFinal", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Polls", "IsFinal");
        }
    }
}
