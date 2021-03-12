﻿CREATE TABLE [dbo].[AspUser]
(
	[Id] INT IDENTITY NOT NULL,
	[Mail] NVARCHAR(256) NOT NULL,
	[Password] VARBINARY(32) NOT NULL,
	[Salt] UNIQUEIDENTIFIER NOT NULL,
	[LastName] NVARCHAR(64) NOT NULL,
	[FirstName] NVARCHAR(64) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[RegNational] CHAR(11) NOT NULL,
	[Bio] NVARCHAR(120),
	[Disabled] DATETIME2,
	CONSTRAINT CK_AspUser_BirthDate CHECK (DATEDIFF(YEAR,[BirthDate],GETDATE()) > 16),
	CONSTRAINT UK_AspUser_Email UNIQUE ([Mail]),
	CONSTRAINT CK_AspUser_RegNational CHECK (ISNUMERIC([RegNational]) = 1),
	CONSTRAINT UK_AspUser_RegNational UNIQUE ([RegNational]),
	CONSTRAINT PK_AspUser PRIMARY KEY ([Id])
)