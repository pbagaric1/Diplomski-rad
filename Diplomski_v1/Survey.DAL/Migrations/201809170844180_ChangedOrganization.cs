namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedOrganization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "Organization", c => c.String());
            DropColumn("dbo.Polls", "OrganizationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Polls", "OrganizationId", c => c.Guid(nullable: false));
            DropColumn("dbo.Polls", "Organization");
        }
    }
}
