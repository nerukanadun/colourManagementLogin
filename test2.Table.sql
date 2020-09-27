CREATE TABLE [dbo].[Table]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NULL, 
    [Role] NCHAR(10) NULL
)
