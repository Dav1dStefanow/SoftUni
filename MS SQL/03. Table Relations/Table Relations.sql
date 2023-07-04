CREATE DATABASE Project

USE Project

--1
CREATE TABLE Passports
(
	ID INT PRIMARY KEY ,
	PassportNumber CHAR(8) 
)

CREATE TABLE Persons
(
	ID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(ID) NOT NULL
)

INSERT INTO Passports(ID, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
('Roberto', 43300, 102),
('Tom', 56100, 103),
('Yana', 60200, 101)

--2
CREATE TABLE Manufacturers
(
	ID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL,
	EstablishedOn DATETIME NOT NULL
)

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY,
	Name VARCHAR(20) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ID)
)

INSERT INTO Manufacturers(Name, EstablishedOn)
VALUES
('BMW','1916.03.07'),
('Tesla','2003.01.01'),
('Lada','1966.05.01')

INSERT INTO Models(ModelID, Name, ManufacturerID)
VALUES
(101, 'XL', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

--3
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
)

INSERT INTO Students([Name])
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams([Name])
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentID_ExamID
PRIMARY KEY (StudentID, ExamID),

CONSTRAINT FK_StudentsExams_Students
FOREIGN KEY (StudentID)
REFERENCES Students(StudentID),

CONSTRAINT FK_StudentsExams_Exams
FOREIGN KEY (ExamID)
REFERENCES Exams(ExamID)


--4

CREATE TABLE Teachers
(
	ID INT PRIMARY KEY IDENTITY(101,1),
	Name VARCHAR(30) NOT NULL,
	ManagerID INT 
)

INSERT INTO Teachers(Name, ManagerID)
VALUES
('Jhon', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

ALTER TABLE Teachers
ADD CONSTRAINT FK_TeacherID_ManagerID
FOREIGN KEY (ManagerID)
REFERENCES Teachers(ID)

--5
CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
	OrderID INT REFERENCES Orders(OrderID),
	ItemID INT REFERENCES Items(ItemID),
	PRIMARY KEY (OrderID, ItemID)
)

--6
CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(20) NOT NULL
)

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(20) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATETIME NOT NULL,
	PaymentAmount DECIMAL(7,2) NOT NULL,
	StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID),
	PRIMARY KEY (StudentID, SubjectID)
)

USE Geography

SELECT MountainRange, PeakName, Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON m.Id = p.MountainId
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC