namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [PhoneNum]) VALUES (N'5430a3f7-7408-4a0c-bfb4-835bee46c4c0', N'admin@vidly.com', 0, N'AEZ10oXrxuRk8g8r00QPAIzWdiGPRG1pLdO3epu58YQfDeAPqZ8obmPEyIU0ikFd5g==', N'522fa8bf-0cb7-4a7b-83e2-584a25a040db', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com', N'1234', N'09055232411')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [PhoneNum]) VALUES (N'856c8eb8-988f-478a-94ab-177406d55ca3', N'guest@vidly.com', 0, N'AJYYFAV/NAJomp7ECPVqD+ZyDmc3s+xlymgfZQFIaKvosnfl4uPSRlkQN/iww95oJA==', N'fa85bd59-e4bd-4751-9303-ba3b86f1d4e4', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com', N'1234', N'09055232411')


                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'350c1d0c-9121-4a16-993b-9c8dda195429', N'CanManageMoviesAndCustomer')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5430a3f7-7408-4a0c-bfb4-835bee46c4c0', N'350c1d0c-9121-4a16-993b-9c8dda195429')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
