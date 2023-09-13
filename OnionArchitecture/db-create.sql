CREATE DATABASE onion
GO

USE onion
GO

CREATE TABLE dbo.Student(
	Id UNIQUEIDENTIFIER NOT NULL,
	DateCreated DateTime NOT NULL,
	Deleted bit NOT NULL default 0,
	[Name] varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	Phone varchar(20) NOT NULL, 
	StudentLevel int NOT NULL default 0,
	CONSTRAINT PK_Student PRIMARY KEY (Id)
)
GO

CREATE TABLE dbo.Teacher(
	Id UNIQUEIDENTIFIER NOT NULL,
	DateCreated DateTime NOT NULL,
	Deleted bit NOT NULL default 0,
	[Name] varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	Phone varchar(20) NOT NULL, 	
	CONSTRAINT PK_Teacher PRIMARY KEY (Id)
)
GO
