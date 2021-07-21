namespace BankProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotationRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AllTransactions", "TransactionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AllTransactions", "TransactionDate", c => c.DateTime());
        }
    }
}
