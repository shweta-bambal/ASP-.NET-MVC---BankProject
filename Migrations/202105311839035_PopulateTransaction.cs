namespace BankProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTransaction : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Transactions values('Deposit')");
            Sql("insert into Transactions values('Withdraw')");
        }
        
        public override void Down()
        {
        }
    }
}
