USE SoftUni

--1
SELECT FirstName, LastName
	FROM Employees
	WHERE LEFT(FirstName, 2) = 'Sa'

--2
SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

--3
SELECT FirstName
	FROM Employees
	WHERE DepartmentID IN (3,10) AND
	DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--4
SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT Name
	FROM Towns
	WHERE LEN(Name) = 5 OR LEN(Name) = 6
	ORDER BY Name

--6
SELECT *
	FROM Towns
	WHERE LEFT(Name, 1) = 'M' OR
	LEFT(Name, 1) = 'K'OR
	LEFT(Name, 1) = 'B'OR
	LEFT(Name, 1) = 'E'
	ORDER BY Name

--7
	SELECT *
	FROM Towns
	WHERE LEFT(Name, 1) != 'R' AND
	LEFT(Name, 1) != 'D'AND
	LEFT(Name, 1) != 'B'
	ORDER BY Name

--8
GO

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
	FROM Employees
	WHERE DATEPART(YEAR,HireDate) > 2000

--9
GO

SELECT FirstName ,LastName
	FROM Employees
	WHERE LEN(LastName) = 5

--10
SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK()
	OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--11
SELECT * FROM
(
SELECT EmployeeID, FirstName, LastName, Salary,DENSE_RANK()
	OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000 
) AS [Rank Table]
WHERE [Rank] = 2
ORDER BY Salary DESC

--12
USE Geography

SELECT CountryName, IsoCode
	FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY IsoCode

--13
USE Geography

SELECT p.PeakName, r.RiverName, 
LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1), r.RiverName)) AS Mix 
FROM Peaks AS p, Rivers AS r
WHERE RIGHT(p.PeakName,1) = LEFT(r.RiverName, 1)
ORDER BY Mix
--14
USE Diablo
	
SELECT TOP 50 Name, FORMAT([Start],'yyyy-MM-dd') AS Start
	FROM Games
	WHERE YEAR(Start) IN (2011,2012)
	ORDER BY Start,Name

--15
SELECT Username, SUBSTRING(Email , CHARINDEX('@',Email, 1) + 1 ,LEN(Email)) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username 

--16
SELECT Username, IpAddress
	FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
	ORDER BY Username ASC

--17
SELECT Name AS Game,
	CASE 
	WHEN  DATEPART(HOUR, Start) >= 0 AND  DATEPART(HOUR, Start) < 12 THEN 'Morning'
	WHEN  DATEPART(HOUR, Start) >= 12 AND  DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
	WHEN  DATEPART(HOUR, Start) >= 18 AND  DATEPART(HOUR, Start) < 24 THEN 'Evening'
	ELSE NULL
	END AS [Part of the day], 
	CASE 
	WHEN  Duration > 0 AND  Duration <= 3 THEN 'Extra Short'
	WHEN  Duration >= 4 AND  Duration <= 6 THEN 'Short'
	WHEN  Duration > 6 THEN 'Long'
	ELSE 'Extra Long'
	END AS [Duration]
	FROM Games
	ORDER BY Name ASC ,
	[Duration] ASC
	
--18
USE Orders

SELECT [ProductName], OrderDate, 
DATEADD(DAY, 3, OrderDate) AS [Pay Due],
DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

--19
SELECT DATEDIFF(YEAR, '2000-12-07 00:00:00.000', GETDATE()) AS [Age in Years]
,DATEDIFF(MONTH, '2000-12-07 00:00:00.000', GETDATE()) AS [Age in Months]
,DATEDIFF(DAY, '2000-12-07 00:00:00.000', GETDATE()) AS [Age in Days]
,DATEDIFF(MINUTE, '2000-12-07 00:00:00.000', GETDATE()) AS [Age in Minutes]
