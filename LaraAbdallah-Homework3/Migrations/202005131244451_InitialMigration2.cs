namespace LaraAbdallah_Homework3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "TransactionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "TransactionDate", c => c.String());
        }
    }
}
