namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "OptionGroupId", "dbo.OptionGroups");
            DropIndex("dbo.Questions", new[] { "OptionGroupId" });
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AlterColumn("dbo.Questions", "OptionGroupId", c => c.Guid());
            CreateIndex("dbo.Questions", "OptionGroupId");
            AddForeignKey("dbo.Questions", "OptionGroupId", "dbo.OptionGroups", "Id");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Place");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Place", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            DropForeignKey("dbo.Questions", "OptionGroupId", "dbo.OptionGroups");
            DropIndex("dbo.Questions", new[] { "OptionGroupId" });
            AlterColumn("dbo.Questions", "OptionGroupId", c => c.Guid(nullable: false));
            DropColumn("dbo.AspNetUsers", "City");
            CreateIndex("dbo.Questions", "OptionGroupId");
            AddForeignKey("dbo.Questions", "OptionGroupId", "dbo.OptionGroups", "Id", cascadeDelete: true);
        }
    }
}
