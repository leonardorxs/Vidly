namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1743b983-a42c-4220-bad2-a2ef9d1953b3', N'admin@vidly.com', 0, N'AC/xgPAb8O1qhY/YnJhFWM2b03y2eWGBjwE2wLG2MuCKgLpIWm/wzGVZWN2kKysVeg==', N'03b9a84d-e159-4805-b7b1-e98335ec9d97', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54460a26-0730-4611-b487-df0e0fe0259a', N'guest@vidly.com', 0, N'AN3Hk2fD5HagNdwhUiLH500b2gj+4PcF8kmKNrOeBr2wXGzL6FqNuOKTiyh+Ohy+aw==', N'90576e41-4c2f-4c7f-95bc-4a866801c6f2', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3cbb887c-ce28-4001-b9b6-b6d395bde2f9', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1743b983-a42c-4220-bad2-a2ef9d1953b3', N'3cbb887c-ce28-4001-b9b6-b6d395bde2f9')
");
        }

        public override void Down()
        {
        }
    }
}
