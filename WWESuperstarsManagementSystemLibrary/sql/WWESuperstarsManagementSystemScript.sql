USE master
GO
CREATE DATABASE WWESuperstarsManagementSystem
GO
USE WWESuperstarsManagementSystem
GO


CREATE TABLE Gender
(
IDGender INT CONSTRAINT PK_IDGender PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

GO

CREATE TABLE Brand
(
IDBrand INT CONSTRAINT PK_IDBrand PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

GO

CREATE TABLE Country
(
IDCountry INT CONSTRAINT PK_IDCountry PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

GO

CREATE TABLE City
(
IDCity INT CONSTRAINT PK_IDCity PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
CountryID INT CONSTRAINT FK_City_IDCountry FOREIGN KEY REFERENCES Country(IDCountry) NOT NULL
)

GO

CREATE TABLE Superstar
(
IDSuperstar INT CONSTRAINT PK_IDSuperstar PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
HeightCm DECIMAL(4,1) NOT NULL,
WeightKg DECIMAL(4,1) NOT NULL,
GenderID INT CONSTRAINT FK_Superstar_IDGender FOREIGN KEY REFERENCES Gender(IDGender) NOT NULL,
BrandID INT CONSTRAINT FK_Superstar_IDBrand FOREIGN KEY REFERENCES Brand(IDBrand) NOT NULL,
CityID INT CONSTRAINT FK_Superstar_IDCity FOREIGN KEY REFERENCES City(IDCity) NOT NULL
)
 
GO

INSERT INTO Gender([Name]) VALUES('Male')
INSERT INTO Gender([Name]) VALUES('Female')

INSERT INTO Brand([Name]) VALUES('Raw')
INSERT INTO Brand([Name]) VALUES('Smackdown Live')
INSERT INTO Brand([Name]) VALUES('NXT')
INSERT INTO Brand([Name]) VALUES('Hall Of Fame')
INSERT INTO Brand([Name]) VALUES('Alumni')

INSERT INTO Country([Name]) VALUES('Ohio')
INSERT INTO Country([Name]) VALUES('France')
INSERT INTO Country([Name]) VALUES('Washington D.C.')
INSERT INTO Country([Name]) VALUES('Ireland')
INSERT INTO Country([Name]) VALUES('Florida')
INSERT INTO Country([Name]) VALUES('Canada')
INSERT INTO Country([Name]) VALUES('California')
INSERT INTO Country([Name]) VALUES('Massachusetts')
INSERT INTO Country([Name]) VALUES('Missouri')
INSERT INTO Country([Name]) VALUES('Iowa')
INSERT INTO Country([Name]) VALUES('Texas')
INSERT INTO Country([Name]) VALUES('Connecticut')

INSERT INTO City([Name], CountryID) VALUES('Columbus', 1)
INSERT INTO City([Name], CountryID) VALUES('Grenoble', 2)
INSERT INTO City([Name], CountryID) VALUES('Washington D.C.', 3)
INSERT INTO City([Name], CountryID) VALUES('Dublin', 4)
INSERT INTO City([Name], CountryID) VALUES('Tampa', 5)
INSERT INTO City([Name], CountryID) VALUES('Calgary', 6)
INSERT INTO City([Name], CountryID) VALUES('Winnipeg', 6)
INSERT INTO City([Name], CountryID) VALUES('Miami', 5)
INSERT INTO City([Name], CountryID) VALUES('Bray', 4)
INSERT INTO City([Name], CountryID) VALUES('Venice Beach', 7)
INSERT INTO City([Name], CountryID) VALUES('West Newbury', 8)
INSERT INTO City([Name], CountryID) VALUES('St. Louis', 9)
INSERT INTO City([Name], CountryID) VALUES('San Diego', 7)
INSERT INTO City([Name], CountryID) VALUES('Pensacola', 5)
INSERT INTO City([Name], CountryID) VALUES('Devanport', 10)
INSERT INTO City([Name], CountryID) VALUES('Victoria', 11)
INSERT INTO City([Name], CountryID) VALUES('Hollywood', 7)
INSERT INTO City([Name], CountryID) VALUES('Greenwich', 12)
INSERT INTO City([Name], CountryID) VALUES('Houston', 11)

INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Alexa Bliss', 155.0, 46.0, 2, 1, 1)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Andre The Giant', 224.0, 236.0, 1, 4, 2)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Batista', 198.0, 137.0, 1, 5, 3)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Becky Lynch', 168.0, 61.0, 2, 1, 4)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Big Show', 213.0, 174.0, 1, 5, 5)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Bret Hart', 183.0, 107.0, 1, 4, 6)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Chris Jericho', 183.0, 103.0, 1, 5, 7)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Dwayne "The Rock" Johnson', 196.0, 118.0, 1, 2, 8)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Finn Balor', 180.0, 86.0, 1, 3, 9)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Hulk Hugan', 201.0, 137.0, 1, 4, 10)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('John Cena', 185.0, 114.0, 1, 5, 11)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Natalya', 165.0, 61.0, 2, 2, 6)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Randy Orton', 196.0, 113.0, 1, 1, 12)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Rey Mysterio', 168.0, 79.0, 1, 2, 13)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Roman Reigns', 191.0, 120.0, 1, 2, 14)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Seth Rollins', 185.0, 98.0, 1, 2, 15)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('"Stone Cold" Steve Austin', 188.0, 114.0, 1, 4, 16)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('The Miz', 188.0, 100.0, 1, 1, 17)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Triple H', 193.0, 116.0, 1, 1, 18)
INSERT INTO Superstar([Name], HeightCm, WeightKg, GenderID, BrandID, CityID) VALUES('Undertaker', 208.0, 140.0, 1, 1, 19)