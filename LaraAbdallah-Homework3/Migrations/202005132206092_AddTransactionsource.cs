namespace LaraAbdallah_Homework3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionsource : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "TansactionSource", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "TansactionSource");
        }
    }
}
