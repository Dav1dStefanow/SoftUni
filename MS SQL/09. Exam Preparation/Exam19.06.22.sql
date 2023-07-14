CREATE DATABASE Zoo

USE Zoo
-- 1
CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50)NOT NULL,
	PhoneNumber VARCHAR(15)NOT NULL,
	Address VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30)NOT NULL
)

CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30)NOT NULL,
	BirthDate DATETIME NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages
(
	CageId INT FOREIGN KEY REFERENCES Cages(Id),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
)

CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30)NOT NULL
)

CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50)NOT NULL,
	PhoneNumber VARCHAR(15)NOT NULL,
	Address VARCHAR(50),
	AnimalId  INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId  INT FOREIGN KEY REFERENCES VolunteersDepartments(Id)NOT NULL
)
-- 2
INSERT INTO Volunteers (Name, PhoneNumber,	Address,	AnimalId,	DepartmentId) 
VALUES
('Anita Kostova',	'0896365412', 'Sofia, 5 Rosa str.',	15,	1),
('Dimitur Stoev',	'0877564223',	null,	42,	4),
('Kalina Evtimova',	'0896321112',	'Silistra, 21 Breza str.',	9,	7),
('Stoyan Tomov',	'0898564100',	'Montana, 1 Bor str.',	18,	8),
('Boryana Mileva',	'0888112233',	null,	31,	5)

INSERT INTO Animals (Name,	BirthDate,	OwnerId,	AnimalTypeId)
VALUES
('Giraffe',	'2018-09-21',	21,	1),
('Harpy Eagle',	'2015-04-17',	15,	3),
('Hamadryas Baboon',	'2017-11-02',	null,	1),
('Tuatara',	'2021-06-30',	2,	4)
-- 3
UPDATE Animals
SET OwnerId = 4 WHERE OwnerId IS NULL
-- 4
DELETE FROM Volunteers WHERE DepartmentId = 2
DELETE FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant' 
-- 5
SELECT v.Name, v.PhoneNumber, v.Address, AnimalId, v.DepartmentId
	FROM Volunteers AS v
	ORDER BY Name ASC, AnimalId ASC, DepartmentId ASC
-- 6
SELECT a.Name, at.AnimalType, 
FORMAT(BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
ORDER BY Name ASC
-- 7
SELECT TOP 5 o.Name AS Owner, COUNT(a.OwnerId) AS CountOfAnimals
FROM Animals AS a
JOIN Owners AS o ON o.Id = a.OwnerId
GROUP BY o.Name
ORDER BY COUNT(a.OwnerId) DESC, o.Name 
-- 8
SELECT CONCAT(o.Name, '-',a.Name)AS OwnersAnimals, PhoneNumber,	c.Id AS CageId
FROM Animals AS a
JOIN Owners AS o ON o.Id = a.OwnerId
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
JOIN Cages AS c ON c.Id = ac.CageId
WHERE AnimalType = 'Mammals'
ORDER BY o.Name ASC, a.Name DESC
-- 9
SELECT v.Name, v.PhoneNumber,
SUBSTRING(v.Address, CHARINDEX(',', v.Address) + 2, LEN(v.Address)) AS Address
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
WHERE vd.DepartmentName = 'Education program assistant' AND
Address LIKE '%Sofia%'
ORDER BY v.Name ASC
-- 10
SELECT a.Name, YEAR(BirthDate) AS BirthYear, at.AnimalType 
FROM Animals AS a
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId 
WHERE AnimalTypeId != 3
AND DATEDIFF(YEAR, BirthDate, '01/01/2022') < 5
AND a.OwnerId IS NULL
ORDER BY a.Name ASC
-- 11
GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(35))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(Name) FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd  ON vd.Id = v.DepartmentId
	WHERE DepartmentName = @VolunteersDepartment)
END
-- 12
GO
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(35))
AS
	BEGIN
IF (SELECT OwnerId FROM Animals
			WHERE Name = @AnimalName) IS NULL
	BEGIN 
		SELECT Name, 'For adoption' AS OwnerName
			FROM Animals
			WHERE Name = @AnimalName
	END
	ELSE
	BEGIN
		SELECT a.Name, o.Name as OwnerName
			FROM Animals AS a
			JOIN Owners AS o ON o.Id = a.OwnerId
			WHERE a.Name = @AnimalName
	END
END
