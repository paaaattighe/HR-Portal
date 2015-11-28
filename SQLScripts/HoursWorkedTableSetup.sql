USE SWCCorp
GO

--DROP TABLE dbo.HoursWorked

CREATE TABLE dbo.HoursWorked(
	HoursWorkedID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	EmpID int,
	CONSTRAINT FK_EmpID FOREIGN KEY (EmpID)
		REFERENCES dbo.Employee (EmpID),
	DateWorked date,
	HoursWorked dec(4,2)
)

INSERT INTO HoursWorked
	VALUES
	(1,'2015-11-13',10),
	(2,'2015-11-13',3.25),
	(3,'2015-11-08',6),
	(3,'2015-11-24',15.75),
	(3,'2015-11-25',3.25),
	(4,'2015-11-10',10),
	(4,'2015-11-25',8),
	(5,'2015-11-13',6.5),
	(7,'2015-11-25',4.75),
	(7,'2015-11-09',4),
	(9,'2015-11-10',8),
	(9,'2015-11-25',8.5),
	(10,'2015-11-13',1.75),
	(11,'2015-11-13',0.25),
	(12,'2015-11-13',4.5)
	
