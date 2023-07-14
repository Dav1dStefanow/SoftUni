CREATE DATABASE Boardgames
-- 1
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30)NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)NOT NULL,
	Website NVARCHAR(40),
	Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY,
	MinPlayers INT NOT NULL,
	MaxPlayers INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(10,2)NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	PublisherId INT FOREIGN KEY REFERENCES Publishers(Id),
	PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id)
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT FOREIGN KEY REFERENCES Creators(Id),
	BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id)
)

-- 2
INSERT INTO Boardgames ([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId) VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris'	,2016,	9.78,	7,	1,	5),
('Catan: Starfarers',	2021,	9.87,	7,	13,	6),
('Bleeding Kansas',	2020,	3.25,	3,	7,	4),
('One Small Step',	2019,	5.75,	5,	9,	2)

INSERT INTO Publishers ([Name], AddressId, Website, Phone) VALUES
('Agman Games',	5,	'www.agmangames.com',	'+16546135542'),
('Amethyst Games',	7,	'www.amethystgames.com', '+15558889992'),
('BattleBooks',	13	,'www.battlebooks.com',	'+12345678907')
-- 3
UPDATE PlayersRanges
SET MaxPlayers += 1
WHERE MaxPlayers = 2 AND MinPlayers = 2

UPDATE Boardgames
SET Name = Name + 'V2'
WHERE YearPublished >= 2020
-- 4
DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (1,16,31,47)
DELETE FROM Boardgames WHERE PublisherId IN (1,16)
DELETE FROM Publishers WHERE AddressId IN (5)
DELETE FROM Addresses WHERE Town LIKE 'L%'
-- 5
SELECT Name, Rating FROM Boardgames
ORDER BY YearPublished ASC, Name DESC
-- 6
SELECT b.Id, b.Name, b.YearPublished, c.Name 
	FROM Boardgames AS b
	JOIN Categories AS c ON c.Id = b.CategoryId
	WHERE c.Name IN ('Strategy Games', 'Wargames')
	ORDER BY YearPublished DESC
-- 7
 SELECT 
	c.Id
	,c.FirstName + ' ' +  c.LastName AS CreatorName
	,c.Email
FROM  Creators AS c
LEFT JOIN CreatorsBoardgames AS cb
ON c.Id=cb.CreatorId
WHERE cb.CreatorId IS NULL
ORDER BY CreatorName 
-- 8
SELECT TOP 5 b.Name, Rating, c.Name 
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
WHERE (b.Name LIKE '%a%' AND Rating > 7) OR 
(Rating > 7.50 AND pr.MinPlayers = 2 AND pr.MaxPlayers = 5)
ORDER BY b.Name ASC, Rating DESC
-- 9
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name], Email, MAX(Rating) AS Rating	
	FROM Creators AS c
	JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
	JOIN Boardgames AS b ON b.Id = cb.BoardgameId
	WHERE Email LIKE '%.com'
	GROUP BY CONCAT(FirstName, ' ', LastName), Email
	ORDER BY CONCAT(FirstName, ' ', LastName)
-- 10
SELECT LastName, CEILING(AVG(Rating)), p.Name FROM Creators
 AS c
	JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
	JOIN Boardgames AS b ON b.Id = cb.BoardgameId
	JOIN Publishers AS p ON p.Id = b.PublisherId
	WHERE cb.CreatorId IS NOT NULL
	GROUP BY LastName, p.Name
	HAVING p.Name = 'Stonemaier Games'
	ORDER BY AVG(Rating) DESC
-- 11
GO
CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(35)) 
RETURNS INT
AS
BEGIN
	DECLARE @result INT = (SELECT COUNT(FirstName) FROM Creators AS c
							JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
							JOIN Boardgames AS b ON b.Id = cb.BoardgameId
							WHERE  cb.CreatorId IS NOT NULL AND FirstName = @name)
	RETURN @result
END
-- 12
GO
CREATE PROC usp_SearchByCategory(@category VARCHAR(35))
AS
	SELECT b.Name, b.YearPublished, b.Rating, c.Name, p.Name, 
		CAST(MinPlayers AS VARCHAR) + ' people' AS MinPlayers,
		CAST(MaxPlayers AS VARCHAR) + ' people' AS MaxPlayers
		FROM Boardgames AS b
		JOIN Categories AS c ON c.Id = b.CategoryId
		JOIN Publishers AS p ON p.Id = b.PublisherId
		JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
		WHERE c.Name = @category
		ORDER BY p.Name ASC, b.YearPublished DESC


