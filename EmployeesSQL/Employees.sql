﻿CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [CompanyID] INT FOREIGN KEY REFERENCES Companies(Id) NULL
)
