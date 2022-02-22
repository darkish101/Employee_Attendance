using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Attendance.Data.Migrations
{
    public partial class seedRoleAndAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, [Name], NormalizedName) VALUES ('1','Admin','ADMIN')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles(Id, [Name], NormalizedName) VALUES('2', 'Employee', 'EMPLOYEE')");
            migrationBuilder.Sql(@"INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash
                                                          , SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd
                                                          , LockoutEnabled, AccessFailedCount, Discriminator, Employment_Id, Employee_Name, Added_By, Created_On, LastUpdatedDate)
                                                   VALUES ('customeAdminUserId', 'admin', 'ADMIN', 'admin@admin.com', 'ADMIN@ADMIN.COM', 0
                                                          , 'AQAAAAEAACcQAAAAEOm25pGNcoJ9hBh3g+sveEKVxtcHr288To8jiZj6Kf42hjGctL4Nj6ynXsLU5wm+kA==', 'JTXWYSUZZV62AUEGB4AKMKWYKRVPFQDJ'
                                                          , '56c3aed7-14d7-469b-b3cb-4519d044f1c5', NULL, 0, 0, NULL, 1, 0	
                                                          , 'Employee', 'E10001', 'Admin FullName', NULL	, NULL	, NULL)");

            migrationBuilder.Sql("INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('customeAdminUserId', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
