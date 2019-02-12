CREATE TABLE [dbo].[MaterialHeaders]
(
	[MaterialHeadersId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Density] FLOAT NOT NULL, 
    CONSTRAINT [UQ_Materials_Title] UNIQUE ([Title])
)
