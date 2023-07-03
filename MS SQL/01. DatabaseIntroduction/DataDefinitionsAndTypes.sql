CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions
(
	ID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	Age INT NOT NULL
)
CREATE TABLE Towns
(
	ID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL
)

ALTER TABLE Minions
ADD TownID INT FOREIGN KEY(ID) REFERENCES Town(ID)

INSERT INTO Town (ID, [Name]) 
VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions (ID, [Name], Age, TownID) 
VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',20,2)

DELETE FROM Minions
WHERE ID = 1

DROP TABLE Minions
DROP TABLE Town

CREATE TABLE People
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username NVARCHAR(200),
	Picture BINARY(2000) CHECK(DATALENGTH(Picture) <= 90 * 1024),
	Height DECIMAL(7,2),
	[Weight] DECIMAL(7,2),
	Gender VARCHAR(1) CHECK(Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX) 
)
INSERT INTO People(Username, Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Ivan0', 1.74, 75, 'm','04.25.2007','Ivan want to become CSharp Developer'),
('Ivana1', 1.74, 76, 'f','04.25.2007','Ivan want to become CSharp Developer'),
('Ivan3', 1.74, 77, 'm','04.25.2007','Ivan want to become CSharp Developer'),
('Ivana3', 1.74, 78, 'f','04.25.2007','Ivan want to become CSharp Developer'),
('Ivan5', 1.74, 79, 'm','04.25.2007','Ivan want to become CSharp Developer')

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture BINARY(900),
	LastLoginTime DATETIME NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
('Pesho0', '12345', '05.19.2020', 0),
('Pesho1', '12345', '05.19.2020', 1),
('Pesho2', '12345', '05.19.2020', 0),
('Pesho3', '12345', '05.19.2020', 1),
('Pesho4', '12345', '05.19.2020', 1)

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07E80F07DE]

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY(Id,Username)

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordAtLeast5Symbols CHECK(LEN(Password) >= 5)

ALTER TABLE UserS
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT [PK_IdUsername]

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CH_Users_UsernameLength CHECK(LEN(Username) >= 3)

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors 
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(35) NOT NULL,
	DirectorId INT FOREIGN KEY(Id) REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY(Id) REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY(Id) REFERENCES Categories(Id) NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes)
VALUES
	('Lubcho', 'nai-dobriq'),
	('Lubcho2', 'nai-dobriq'),
	('Lubcho3', 'nai-dobriq'),
	('Lubka', 'nai-dobrata'),
	('Lubka20', 'nai-dobrata')

INSERT INTO Genres(GenreName, Notes)
VALUES
	('Comedy', 'hahha'),
	('CiFi', 'izprostqlo'),
	('AI', 'hakeri i tenekii'),
	('Horror', 'nikak strashno'),
	('Romantic', 'rozichki')

INSERT INTO Categories(CategoryName)
VALUES
	('Category'),
	('Category2'),
	('Category3'),
	('Category4'),
	('Category5')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
	('King Slayer' ,5,1999,78,1,5,10,'vaji'),
	('ADASDA',4,2000,90,2,4,9,'vaji'),
	('VFRVRFVV',3,1980,100,3,3,5,'vaji'),
	('BBFBD',2,1890,20,4,2,10,'vaji'),
	('JYHTHR',1,1990,120,5,1,10,'vaji')

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(26) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MonthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY(Id) REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 90 * 1024),
	Condition VARCHAR(MAX) NOT NULL,
	Available BIT NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX) 
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] NVARCHAR(200) NOT NULL,
	City VARCHAR(20) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY(Id) REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY(Id) REFERENCES Customers(Id),
	CarId INT FOREIGN KEY(Id) REFERENCES Cars(ID),
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied INT NOT NULL,
	TaxRate DECIMAL(10,2) NOT NULL,
	OrderStatus NVARCHAR(200) NOT NULL,
	Notes NVARCHAR(MAX) 
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) 
VALUES
('Trucks', 4, 6, 8, 7),
('Supercars', 10, 10, 15, 20),
('Cars', 7, 8, 8, 7)

INSERT INTO Cars(PlateNumber, Manufacturer, Model,
CarYear, CategoryId, Doors, Condition, Available)
VALUES
('2222','TRABANT', 'ANG', '2018', 3, 2, 'been better',0),
('3333','Subaru', 'SU-57', '2016', 1, 4, 'been better',1),
('7777','Porche', 'GTS-RS3', '2022', 2, 2, 'been better',0)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES
('Lubcho', 'Genchew', 'Montior'),
('Lubcho', 'Vaskow', 'Montior'),
('Lubcho', 'Taskov', 'Montior')

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES
('42347648', 'Lichi Mama', 'U tqh', 'Pz', '4623842'),
('87295629', 'Lichi Bate', 'U tqh', 'Pz', '3612325'),
('75834757', 'Lichi Tate', 'U tqh', 'Pz', '1231231')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus)
VALUES
(1, 1, 1, 120, 20, 300, 320, '06.01.2022', '06.20.2022', 20, 12, 300.50, 'otlichen'),
(2, 2, 2, 130, 30, 400, 500, '08.03.2022', '08.21.2022', 18, 16, 310.50, 'otlichen'),
(3, 3, 3, 150, 50, 300, 500, '10.05.2022', '10.20.2022', 15, 18, 350.50, 'otlichen')

ALTER TABLE Customers
ADD CONSTRAINT CH_Customers_DriverlicenceNum CHECK(LEN(DriverLicenceNumber) <= 10)

CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		Title NVARCHAR(20) NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Customers(
		AccountNumber INT PRIMARY KEY NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		PhoneNumber INT NOT NULL,
		EmergencyName NVARCHAR(10),
		EmergencyNumber INT,
		NOTES NVARCHAR(100)
)

CREATE TABLE RoomStatus(
		RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE RoomTypes(
		RoomType NVARCHAR(30) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE BedTypes(
		BedType NVARCHAR(20) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Rooms(
		RoomNumber INT PRIMARY KEY NOT NULL,
		RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
		BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
		Rate INT,
		RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Payments(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
		PaymentDate DATE NOT NULL,
		AccountNumber INT NOT NULL,
		FirstDateOccupied DATE,
		LastDateOccupied DATE,
		TotalDays INT,
		AmountCharged INT,
		TaxRate DECIMAL(3,2) NOT NULL,
		TaxAmount INT NOT NULL,
		PaymentTotal INT,
		Notes NVARCHAR(30)
)

CREATE TABLE Occupancies(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
		DateOccupied DATE NOT NULL,
		AccountNumber INT NOT NULL,
		RoomNumber INT NOT NULL,
		RateApplied INT NOT NULL,
		PhoneCharge INT,
		Notes NVARCHAR(20)
)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES
('Lubcho', 'Kurtacha', 'Zaglavie'),
('Lubka', 'Kurtachkova', 'Zaglavie'),
('Lubcho1', 'Kurteto', 'Zaglavie')


INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES
(1542, 'Lubcho', 'MINCHEW', 0884552, 'Lichi', 07744),
(1522, 'LubchoDWE', 'MINCHEV', 0884552, 'Lichi', 07744),
(1532, 'LubchoTRI', 'MINCHEWICH', 0884552, 'Lichi', 07744)

INSERT INTO RoomStatus(RoomStatus)
VALUES
('Available'),
('Busy'),
('busy2')

INSERT INTO RoomTypes(RoomType)
VALUES
('squad'),
('duo'),
('solo')

INSERT INTO BedTypes(BedType)
VALUES
('kingsize'),
('baby'),
('normal')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, RoomStatus)
VALUES
(1425, 'squad', 'kingsize', 'Busy'),
(1456, 'duo', 'baby', 'busy2'),
(14266, 'solo', 'normal', 'Available')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, TaxRate, TaxAmount)
VALUES
(1, '04.18.2020', 23 , 2.58, 550),
(2, '04.18.2020', 44 , 4.58, 533),
(2, '04.18.2020', 12, 1.58, 512)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied)
VALUES
(1, '12.24.2020', 17, 1, 85),
(2, '12.24.2020', 77, 2, 65),
(3, '12.24.2020', 177, 4, 12)


CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Addresstext VARCHAR(35) NOT NULL,
	TownId INT FOREIGN KEY(Id) REFERENCES Towns(Id) NOT NULL,
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(35) NOT NULL,
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	MiddleName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	JobTitle VARCHAR(20) NOT NULL,
	DepartmentId INT FOREIGN KEY(Id) REFERENCES Departments(Id) NOT NULL,
	HireDate DATETIME NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
)

INSERT INTO Towns VALUES
('Sofia'),('Plovdiv'),('Varna'),('Burgas')

INSERT INTO Departments VALUES
('Engineering'), ('Sales'), ('Marketing'), ('Software Development'),
('Quality Assurance')


INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000),
('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)	

SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments 
ORDER BY [Name] ASC

SELECT * FROM Employees 
ORDER BY Salary DESC

UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees

UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments



