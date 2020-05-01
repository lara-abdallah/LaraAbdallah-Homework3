namespace LaraAbdallah_Homework3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckingAccounts", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CheckingAccounts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.CheckingAccounts", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.CheckingAccounts", "ApplicationUserId");
            AddForeignKey("dbo.CheckingAccounts", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckingAccounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.CheckingAccounts", new[] { "ApplicationUserId" });
            AlterColumn("dbo.CheckingAccounts", "LastName", c => c.String());
            AlterColumn("dbo.CheckingAccounts", "FirstName", c => c.String());
            DropColumn("dbo.CheckingAccounts", "ApplicationUserId");
        }
    }
}
