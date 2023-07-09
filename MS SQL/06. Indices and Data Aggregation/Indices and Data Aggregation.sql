--Part I
USE Gringotts

--1
SELECT COUNT(*) AS Count
	FROM WizzardDeposits
--2
SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
--3
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup
--4
SELECT TOP 2 DepositGroup
	FROM WizzardDeposits
	GROUP BY DepositGroup 
	ORDER BY AVG(MagicWandSize) ASC
--5
SELECT DepositGroup, SUM(DepositAmount)
	FROM WizzardDeposits
	GROUP BY DepositGroup 
	ORDER BY DepositGroup ASC
--6
SELECT DepositGroup, SUM(DepositAmount)
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup 
	ORDER BY DepositGroup ASC
--7
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup 
	HAVING SUM(DepositAmount) < 150000
	ORDER BY DepositGroup DESC
--8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge)
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup
--9
SELECT AgeGroup, COUNT(*) AS WizzardCount FROM
(
	SELECT 
	CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
	END AS AgeGroup, *
	FROM WizzardDeposits
) AS AgeGroupQuery
GROUP BY AgeGroup
--10
SELECT LEFT(FirstName, 1)
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY  LEFT(FirstName, 1)
--11
SELECT DepositGroup , IsDepositExpired, AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
	WHERE DepositStartDate > '01/01/1985'
	GROUP BY DepositGroup,IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired ASC
--12
SELECT SUM(Difference)
	FROM 
(
	SELECT
	w.FirstName AS [Host Wizard], 
	w.DepositAmount AS [Host Wizard Deposit],
	g.FirstName AS [Guest Wizard],  
	g.DepositAmount AS [Guest Wizard Deposit],
	(w.DepositAmount - g.DepositAmount) AS Difference
	FROM WizzardDeposits AS w
	JOIN WizzardDeposits AS g ON g.Id = w.Id + 1
) AS WizzardDepositsDIFF
--Part II
USE SoftUni

--13
SELECT DepartmentID, SUM(Salary) AS [TotalSalary]
	FROM Employees
	GROUP BY DepartmentID
--14
SELECT DepartmentID, MIN(Salary) AS [MinimumSalary]
	FROM Employees
	WHERE DepartmentID IN (2,5,7) AND 
	HireDate > '01/01/2000'
	GROUP BY DepartmentID
--15
SELECT * INTO EmployeesWithHighSalaries FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalaries
WHERE ManagerID = 42

UPDATE EmployeesWithHighSalaries 
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM EmployeesWithHighSalaries
	GROUP BY DepartmentID
--16
SELECT DepartmentID, MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000
--17
SELECT COUNT(*)
	FROM Employees
	WHERE ManagerID IS NULL
--18
SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary FROM
(
	SELECT DepartmentID, Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
) AS SalaryRankQuery
WHERE SalaryRank = 3
--19
SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e
WHERE e.Salary > (
			SELECT AVG(Salary) AS AverageSalary
			FROM Employees AS av
			WHERE av.DepartmentID = e.DepartmentID
			GROUP BY DepartmentID
)
ORDER BY DepartmentID