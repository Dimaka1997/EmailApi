CREATE DATABASE TestTaskDb;
GO
USE TestTaskDb;
CREATE TABLE MessageLogs
(
    Id INT IDENTITY PRIMARY KEY,
    Subject NVARCHAR(50) NOT NULL,
    Body NVARCHAR(max) NOT NULL,
    Recipients NVARCHAR(max) NOT NULL,
    Result NVARCHAR(10) NOT NULL,
	FailedMessage NVARCHAR(200),
	Created datetime not null
)