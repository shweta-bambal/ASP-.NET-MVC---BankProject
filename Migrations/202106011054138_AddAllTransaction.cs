namespace BankProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        TransactionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllTransactions", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.AllTransactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AllTransactions", new[] { "TransactionId" });
            DropIndex("dbo.AllTransactions", new[] { "CustomerId" });
            DropTable("dbo.AllTransactions");
        }
    }
}
