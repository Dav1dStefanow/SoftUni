USE SoftUni

--1
SELECT TOP 5 EmployeeID, JobTitle, e.AddressID, AddressText 
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	ORDER BY AddressID
--2
SELECT TOP 50 FirstName, LastName, t.Name AS Town, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	ORDER BY FirstName, LastName
--3
SELECT EmployeeID, FirstName, LastName , d.Name
	FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY EmployeeID
--4
SELECT TOP 5 EmployeeID, FirstName, Salary , d.Name
	FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE Salary > 15000
	ORDER BY e.DepartmentID 
--5
SELECT TOP 3 e.EmployeeID, e.FirstName 
	FROM Employees AS e
	FULL JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID ASC
--6
SELECT FirstName, LastName, HireDate, d.Name AS DeptName
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1.1.1999' AND
	d.Name IN ('Sales','Finance')
	ORDER BY e.HireDate ASC
--7
SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID	
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '08.13.2002' AND
	p.EndDate IS NULL
	ORDER BY EmployeeID ASC
--8
SELECT e.EmployeeID, e.FirstName,
	CASE 
	WHEN DATEPART(YEAR,p.StartDate) >= 2005 THEN NULL
	ELSE p.Name 
	END AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID	
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24 
--9
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
	FROM Employees AS e
	JOIN Employees AS m ON m.EmployeeID = e.ManagerID
	WHERE e.ManagerID IN (3,7)
	ORDER BY EmployeeID ASC
--10
 SELECT TOP 50
	e.EmployeeID
	,e.FirstName + ' ' + e.LastName AS EmployeeName
	,m.FirstName + ' ' + m.LastName AS ManagerName
	,d.Name AS DepartmentName
	FROM Employees AS e
	JOIN Employees AS m ON m.EmployeeID = e.ManagerID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID ASC
--11
SELECT TOP 1 AVG(e.Salary) AS MinAverageSalary
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	GROUP BY d.DepartmentID
	ORDER BY MinAverageSalary
--part II
USE Geography

--12
SELECT c.CountryCode,  m.MountainRange, p.PeakName, p.Elevation
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	JOIN Peaks AS p ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND
	p.Elevation > 2835
	ORDER BY p.Elevation DESC
--13
SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
	FROM  Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	WHERE c.CountryCode IN ('BG','US','RU')
	GROUP BY c.CountryCode
--14
SELECT TOP 5 c.CountryName,  r.RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName ASC
--15
SELECT ContinentCode, CurrencyCode, CurrencyCount AS CurrencyUsage FROM
(
	SELECT ContinentCode, CurrencyCode, CurrencyCount, 
	DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
	FROM
	(
		SELECT ContinentCode, CurrencyCode, 
		COUNT(*) AS CurrencyCount
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
	) AS CurrencyCountQuery
	WHERE CurrencyCount > 1
) AS CurrencyRankingQuery
WHERE CurrencyRank = 1
--16
SELECT COUNT(c.CountryCode)
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	WHERE m.Id IS NULL
--17
SELECT TOP 5 c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	JOIN Peaks AS p ON p.MountainId = m.Id
	JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	JOIN Rivers AS r ON r.Id = cr.RiverId
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC
