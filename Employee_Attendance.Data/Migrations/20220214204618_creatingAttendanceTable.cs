using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Attendance.Data.Migrations
{
    public partial class creatingAttendanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_On = table.Column<DateTime>(nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(nullable: true),
                    AttendanceDay = table.Column<DateTime>(type: "Date", nullable: false),
                    CheckInDayStart = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    CheckOutLunchBrake = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    CheckInLunchBrake = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    CheckOutDayEnd = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    LateCheckIn = table.Column<bool>(type: "bit", nullable: false),
                    LateCheckInReason = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    EarlyCheckOutDayEnd = table.Column<bool>(type: "bit", nullable: false),
                    EarlyCheckOutReason = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");
        }
    }
}
