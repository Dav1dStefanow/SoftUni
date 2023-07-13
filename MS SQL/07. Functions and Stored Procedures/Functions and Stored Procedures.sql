--Part I
--1
CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAbove35000 AS
BEGIN
SELECT FirstName AS [First Name], LastName AS [Last Name]
FROM Employees
WHERE Salary > 35000
END

EXECUTE usp_GetEmployeesSalaryAbove35000

GO
--2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Num DECIMAL(18,4)) 
AS
BEGIN
SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @Num
END

GO
--3
CREATE OR ALTER PROC usp_GetTownsStartingWith (@String NVARCHAR(50))
AS
BEGIN
    SELECT [Name] AS Town
	FROM Towns
	WHERE [Name] LIKE @String + '%'
END

EXECUTE usp_GetTownsStartingWith 'b'

GO
--4
CREATE OR ALTER PROC usp_GetEmployeesFromTown (@GivenTown NVARCHAR(50))
AS
BEGIN
    SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.Name = @GivenTown
END

EXEC usp_GetEmployeesFromTown Sofia

GO
--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(50) 
AS
BEGIN
IF (@salary < 30000)
BEGIN 
RETURN 'Low'
END
ELSE IF (@salary >= 30000 AND @salary <= 50000)
BEGIN 
RETURN 'Average'
END
RETURN 'High'
END

GO
SELECT Salary, dbo.ufn_GetSalaryLevel(Salary)
	FROM Employees

GO
--6
CREATE OR ALTER PROC usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(15))
AS 
BEGIN
SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
END

EXEC usp_EmployeesBySalaryLevel high

GO
--7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50)) 
RETURNS BIT
AS
BEGIN
DECLARE @count INT = 1
WHILE(@count <= LEN(@word))
BEGIN
DECLARE @curLetter CHAR(1) = SUBSTRING(@word,@count,1)
IF(CHARINDEX(@curLetter,@setOfLetters) = 0)
RETURN 0
SET @count += 1
END
RETURN 1
END

GO
--8
ALTER TABLE Employees
ALTER COLUMN DepartmentID INT NULL

ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

GO
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL
DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
UPDATE Employees
SET ManagerID = NULL
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
DELETE FROM Employees
WHERE DepartmentID = @departmentId
DELETE FROM Departments
WHERE DepartmentID = @departmentId

SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId

GO
--Part II
--9
CREATE PROCEDURE usp_GetHoldersFullName 
AS
SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM AccountHolders
GO
--10
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@rndmNum DECIMAL(18,4))
AS
SELECT FirstName AS [First Name],LastName AS[Last  Name]
	FROM AccountHolders AS ah
	JOIN Accounts AS ac ON ac.AccountHolderId = ah.Id
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @rndmNum
	ORDER BY FirstName, LastName
GO
--11
CREATE FUNCTION ufn_CalculateFutureValue(@InitialSum DECIMAL(15,2),@Interest FLOAT,@Years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
RETURN @InitialSum * (POWER((1 + @Interest), @Years))
END

GO
--12
CREATE PROC usp_CalculateFutureValueForAccount (@accountID INT, @InterestRate FLOAT)
AS
SELECT a.Id, ah.FirstName, ah.LastName, a.Balance
	,dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5)
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.ID = @accountID
GO
--Part III
--13
USE Diablo

GO
CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(100))
RETURNS TABLE
AS
RETURN
SELECT SUM(K.Cash) AS TotalCash
FROM (
	SELECT Cash,
	ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNumber
	FROM Games AS g
	JOIN UsersGames AS ug ON ug.GameId = g.Id
	WHERE Name = @GameName ) AS k
	WHERE k.RowNumber % 2 = 1

SELECT * FROM ufn_CashInUsersGames('Love in a mist')