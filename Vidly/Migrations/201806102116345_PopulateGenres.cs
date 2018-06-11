namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES (1, 'Action')");
            Sql("INSERT INTO Genres VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres VALUES (3, 'Comedy')");
            Sql("INSERT INTO Genres VALUES (4, 'Drama')");
            Sql("INSERT INTO Genres VALUES (5, 'Kids')");
        }

        public override void Down()
        {
        }
    }
}
