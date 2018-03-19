namespace Survey.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuestionOptionId = c.Guid(nullable: false),
                        AspNetUserId = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AspNetUserId = c.String(maxLength: 128),
                        OrganizationId = c.Guid(nullable: false),
                        Name = c.String(),
                        Instructions = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PollId = c.Guid(nullable: false),
                        QuestionOptionGroupId = c.Int(nullable: false),
                        Title = c.String(),
                        AnswerRequired = c.Boolean(nullable: false),
                        QuestionOrder = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionOptionGroups", t => t.QuestionOptionGroupId, cascadeDelete: true)
                .Index(t => t.PollId)
                .Index(t => t.QuestionOptionGroupId);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                        QuestionChoiceId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionChoices", t => t.QuestionChoiceId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.QuestionChoiceId);
            
            CreateTable(
                "dbo.UserPolls",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AspNetUserId = c.String(),
                        PollId = c.Guid(nullable: false),
                        CompletedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuestionOptionGroupId = c.Guid(nullable: false),
                        Name = c.String(),
                        QuestionOptionGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionOptionGroups", t => t.QuestionOptionGroup_Id)
                .Index(t => t.QuestionOptionGroup_Id);
            
            CreateTable(
                "dbo.QuestionOptionGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinimumRateDescription = c.String(),
                        MaximumRateDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionOptions", "QuestionChoiceId", "dbo.QuestionChoices");
            DropForeignKey("dbo.Questions", "QuestionOptionGroupId", "dbo.QuestionOptionGroups");
            DropForeignKey("dbo.QuestionChoices", "QuestionOptionGroup_Id", "dbo.QuestionOptionGroups");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Polls", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserPolls", "PollId", "dbo.Polls");
            DropForeignKey("dbo.Questions", "PollId", "dbo.Polls");
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.QuestionChoices", new[] { "QuestionOptionGroup_Id" });
            DropIndex("dbo.UserPolls", new[] { "PollId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionChoiceId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuestionOptionGroupId" });
            DropIndex("dbo.Questions", new[] { "PollId" });
            DropIndex("dbo.Polls", new[] { "AspNetUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.QuestionOptionGroups");
            DropTable("dbo.QuestionChoices");
            DropTable("dbo.Organizations");
            DropTable("dbo.UserPolls");
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.Questions");
            DropTable("dbo.Polls");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Answers");
        }
    }
}
