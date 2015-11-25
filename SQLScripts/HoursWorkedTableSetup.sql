USE SWCCorp
GO

--DROP TABLE dbo.HoursWorked

CREATE TABLE dbo.HoursWorked(
	HoursWorkedID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	EmpID int,
	CONSTRAINT FK_EmpID FOREIGN KEY (EmpID)
		REFERENCES dbo.Employee (EmpID),
	DateWorked date,
	HoursWorked int
)

INSERT INTO HoursWorked
	VALUES
	(4,'2015-11-10',10),
	(9,'2015-11-10',8),
	(7,'2015-11-09',4),
	(3,'2015-11-08',6)