-- Lection 
USE Bank

CREATE TABLE AccountChanges
(
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldBalance DECIMAL NOT NULL,
	NewBalance DECIMAL NOT NULL,
	DateOfCharge DATETIME NOT NULL
)
GO
-- Create Transaction
CREATE PROC us_TransferFunds(@FromAccId INT, @ToAccId INT, @Ammount DECIMAL(15,2))
AS
BEGIN TRANSACTION
IF (SELECT Balance FROM Accounts WHERE Id = @FromAccId) < 1
BEGIN
ROLLBACK;
THROW 50001, 'Insufficient funds', 1;
END
IF NOT EXISTS(SELECT Balance FROM Accounts WHERE Id = @FromAccId)
BEGIN
ROLLBACK;
THROW 50002, '@FromAccId not found!', 1;
END
IF NOT EXISTS(SELECT Balance FROM Accounts WHERE Id = @ToAccId)
BEGIN
ROLLBACK;
THROW 50003, '@ToAccId not found!', 1;
END

UPDATE Accounts SET Balance = Balance - @Ammount WHERE Id = @FromAccId
UPDATE Accounts SET Balance = Balance + @Ammount WHERE Id = @ToAccId
COMMIT
GO
-- Create trigger
CREATE TRIGGER tr_OnAccountChangeAddLogRecord
ON Accounts FOR UPDATE
AS
	INSERT INTO AccountChanges(AccountId, OldBalance, NewBalance, DateOfCharge)
	SELECT i.Id, d.Balance, i.Balance, GETDATE()
		FROM inserted AS i
		JOIN deleted AS d ON i.Id = d.Id
		WHERE i.Balance != d.Balance
GO
-- Create an INSTEAD OF trigger
CREATE OR ALTER TRIGGER tr_OnDeletedAccountHoldersSetIsDeleted
ON AccountHolders INSTEAD OF DELETE
AS
	UPDATE AccountHolders SET IsDeleted = 1
	WHERE Id IN (SELECT Id FROM deleted)
GO
-- Part I
-- 1
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum DECIMAL(15,2) NOT NULL,
	NewSum DECIMAL(15,2) NOT NULL
)

GO
CREATE TRIGGER tr_AccountChangeLogRecord 
ON Accounts FOR UPDATE
AS
	INSERT Logs (AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance != d.Balance

SELECT * FROM Accounts
SELECT * FROM AccountHolders
-- 2
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	Subject NVARCHAR(MAX) NOT NULL,
	Body NVARCHAR(MAX)
)
GO
CREATE TRIGGER tr_AccountChangeEmailRecord
ON Accounts FOR UPDATE
AS
	INSERT NotificationEmails(Recipient, Subject, Body)
	SELECT i.Id
	,'Balance change for account: ' + CAST(i.Id AS NVARCHAR)
	,'On ' + CAST(DATEPART(MONTH,GETDATE()) AS NVARCHAR) + ' ' + CAST(DATEPART(DAY,GETDATE()) AS NVARCHAR) + ' ' + 
	CAST(DATEPART(YEAR,GETDATE()) AS NVARCHAR) + ' ' + CAST(DATEPART(HOUR,GETDATE()) AS NVARCHAR) + 
	':' + CAST(DATEPART(MINUTE,GETDATE()) AS NVARCHAR) +
	'PM your balance was changed from ' + CAST(d.Balance AS NVARCHAR) + ' to ' + CAST(i.Balance AS NVARCHAR) + '.'
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance != d.Balance
GO
-- 3
CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(10,4))
AS
	UPDATE Accounts 
	SET Balance += @MoneyAmount WHERE Id = @AccountId	
GO
-- 4
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(10, 4))
AS
BEGIN TRANSACTION
	IF (@MoneyAmount < 0 OR @MoneyAmount IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid amount of money', 1;
	END

	IF (NOT EXISTS(
		SELECT a.Id FROM Accounts AS a 
		WHERE a.Id = @AccountId) OR @AccountId IS NULL)
	BEGIN 
		ROLLBACK;
		THROW 50002, 'Invalid accountId', 1
	END

	UPDATE Accounts
	   SET Balance -= @MoneyAmount
	 WHERE Id = @AccountId
COMMIT

EXEC usp_WithdrawMoney 2, 500
GO
-- 5	
CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(10,4)) 
AS
BEGIN TRANSACTION
IF (@Amount = 0 OR @Amount IS NULL)
BEGIN
		ROLLBACK;
		THROW 50001,'Invalid ammount of money', 1
END
IF (NOT EXISTS( SELECT Id FROM Accounts 
		WHERE Id = @SenderId) OR @SenderId IS NULL)
BEGIN
		ROLLBACK;
		THROW 50002, '@SenderId was not valid', 1
END
IF (NOT EXISTS( SELECT Id FROM Accounts 
		WHERE Id = @ReceiverId) OR @ReceiverId IS NULL)
BEGIN
		ROLLBACK;
		THROW 50002, '@ReceiverId was not valid', 1
END
	EXEC usp_WithdrawMoney @SenderId, @Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount
COMMIT
GO
-- Part III
-- 8
USE SoftUni
GO
CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
		DECLARE @projects INT;
		SET @projects = (SELECT COUNT(EmployeeID) FROM EmployeesProjects
		WHERE EmployeeID = @emloyeeId)

		IF(@projects >= 3)
		BEGIN
		ROLLBACK;
		THROW 50016, 'The employee has too many projects!', 1
		END

		INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
	    VALUES (@emloyeeId, @projectID)
COMMIT
-- 9
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(35),
	LastName NVARCHAR(35), 
	MiddleName NVARCHAR(35),
	JobTitle NVARCHAR(35),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentId), 
	Salary DECIMAL(18,2)
	)

GO
CREATE TRIGGER tr_DeletedEmployeesRecords 
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
		SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary FROM deleted