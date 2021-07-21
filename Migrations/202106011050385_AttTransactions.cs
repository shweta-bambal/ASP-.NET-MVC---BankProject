namespace BankProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttTransactions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.Customers", new[] { "TransactionId" });
            DropColumn("dbo.Customers", "TransactionDate");
            DropColumn("dbo.Customers", "TransactionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "TransactionId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "TransactionDate", c => c.DateTime());
            CreateIndex("dbo.Customers", "TransactionId");
            AddForeignKey("dbo.Customers", "TransactionId", "dbo.Transactions", "Id", cascadeDelete: true);
        }
    }
}
