using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Attendance.Data.Migrations
{
    public partial class createStoreProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var storeprocidual = @"
CREATE PROCEDURE [dbo].[sp_Attandence]
	@p_Employee_ID nvarchar(450) = NULL
,	@p_TypeOfOpration Nvarchar(100) = NULL--checkOut, LunchBrakeOUT, LunchBrakeIN, 
,	@p_Note nvarchar(150) = NULL
AS
BEGIN
	DECLARE @l_Attendance_ID int = 0

--if employee has attendance today no need to create another one
	IF EXISTS(SELECT * FROM Attendances WHERE Employee_ID = @p_Employee_ID AND AttendanceDay = CONVERT(date, GETDATE()))
		BEGIN
			SELECT @l_Attendance_ID = ID FROM Attendances WHERE Employee_ID = @p_Employee_ID AND AttendanceDay = CONVERT(date, GETDATE())
		-- if type of opration is lunch brake out update the record in database 
			IF(@p_TypeOfOpration = 'LunchBrakeOUT')
				UPDATE Attendances SET CheckOutLunchBrake = CONVERT(time, GETDATE()), LastUpdatedDate = GETDATE()
								WHERE Id = @l_Attendance_ID
			ELSE IF(@p_TypeOfOpration = 'LunchBrakeIN')
				UPDATE Attendances SET CheckInLunchBrake = CONVERT(time, GETDATE()), LastUpdatedDate = GETDATE()
								WHERE Id = @l_Attendance_ID
			ELSE
				BEGIN
				-- log employee attendance out 
					UPDATE Attendances SET CheckOutDayEnd = CONVERT(time, GETDATE()), LastUpdatedDate = GETDATE()
									WHERE Employee_ID = @p_Employee_ID AND AttendanceDay = CONVERT(date, GETDATE())
				-- if employee try to log out before 3 pm flag the record as early checkout 
					IF(DATEPART(HOUR, GETDATE()) < 15 )
						UPDATE Attendances SET EarlyCheckOutDayEnd = 1, EarlyCheckOutReason = @p_Note, LastUpdatedDate = GETDATE()
									WHERE Id = @l_Attendance_ID
				END
		END
	ELSE
		BEGIN
		-- insert record of employee attendance 
			INSERT INTO Attendances(Created_On, AttendanceDay, Employee_ID, CheckInDayStart) 
							 VALUES(GETDATE(), CONVERT (date, GETDATE()), @p_Employee_ID, CONVERT(time, GETDATE()))
			SET @l_Attendance_ID = SCOPE_IDENTITY()
		-- if attendance is late flag the record
			--IF(DATEPART(HOUR, GETDATE()) >= 8 AND DATEPART(MINUTE, GETDATE()) >= 30 )
			IF(CONVERT(TIME, GETDATE()) >= '08:30:00')
					UPDATE Attendances SET LateCheckIn = 1, LateCheckInReason = @p_Note, LastUpdatedDate = GETDATE()
										WHERE Id = @l_Attendance_ID-- will get the inserted record id 
		END
		SELECT * FROM Attendances WHERE Id = @l_Attendance_ID
END
";
			migrationBuilder.Sql(storeprocidual);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
