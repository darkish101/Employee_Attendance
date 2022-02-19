using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Attendance.Data.Migrations
{
    public partial class seedRoleAndAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, [Name], NormalizedName) VALUES ('1','Admin','ADMIN')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles(Id, [Name], NormalizedName) VALUES('2', 'Employee', 'EMPLOYEE')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
