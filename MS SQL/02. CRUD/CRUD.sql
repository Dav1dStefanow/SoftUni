USE SoftUni

--1
SELECT * 
	FROM Departments

--2
SELECT [Name] 
	FROM Departments

--3
SELECT FirstName, LastName, Salary 
	FROM Employees

--4
SELECT FirstName, MiddleName, LastName 
	FROM Employees

--5
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
	FROM Employees

--6
SELECT TOP 3 Salary
	FROM Employees

--7
SELECT * 
	FROM Employees
	WHERE JobTitle = 'Sales Representative'

--8
SELECT DISTINCT Salary
	FROM Employees

--10
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
	FROM Employees
	WHERE Salary IN (25000, 14000, 12500, 23600)

--11
	SELECT FirstName, LastName 
	FROM Employees
	WHERE ManagerID IS NULL

--12
SELECT FirstName, LastName, Salary
	FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC

--13
SELECT TOP 5 FirstName, LastName
	FROM Employees
	ORDER BY Salary DESC

--14
SELECT FirstName, LastName
	FROM Employees
	WHERE DepartmentId != 4

SELECT * 
	FROM Employees AS e
	JOIN Departments AS d ON d.Id = e.DepartmentId

--15
SELECT * 
	FROM Employees
	ORDER BY Salary DESC,
	FirstName ASC,
	LastName DESC,
	MiddleName 

--16
GO
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
	FROM Employees

--17
GO

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + COALESCE(MiddleName,'') + ' ' + LastName AS [Full Name], JobTitle
	FROM Employees

--18
GO

SELECT DISTINCT JobTitle
	FROM Employees

--19
SELECT TOP 10 * 
	FROM Projects 
	ORDER BY StartDate,
	Name

--20
SELECT TOP 7 FirstName, LastName, HireDate
	FROM Employees
	ORDER BY HireDate DESC

--21
UPDATE Employees
	SET Salary *= 1.12
	WHERE DepartmentId IN (1,2,4,11) 

SELECT Salary
	FROM Employees

--22
USE Geography

SELECT PeakName
	FROM Peaks
	 ORDER BY PeakName ASC

--23
SELECT TOP 30 CountryName, Population
	FROM Countries
	WHERE ContinentCode = 'EU'
	ORDER BY Population DESC

--24
SELECT CountryName, CountryCode,
	CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
	END AS Currency
	FROM Countries
	ORDER BY CountryName

--25
USE Diablo

SELECT Name FROM Characters
	ORDER BY Name