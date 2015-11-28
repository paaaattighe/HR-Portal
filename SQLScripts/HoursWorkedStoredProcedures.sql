USE SWCCorp
GO

CREATE PROCEDURE AddTimeRecord
(
	@EmpID int,
	@DateWorked Date,
	@HoursWorked dec(4,2)
)
AS
INSERT INTO dbo.HoursWorked
	VALUES (@EmpID,@DateWorked,@HoursWorked)