namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdatesInDb : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1/1/1997' WHERE id = 1");
            Sql("UPDATE Customers SET Birthdate = null WHERE id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
