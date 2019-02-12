CREATE TABLE [dbo].[MaterialHeaders]
(
	[MaterialHeadersId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL,
	[Path] NVARCHAR(500) NULL, 
    [Density] FLOAT NOT NULL, 
    [MaterialGroupId] INT NOT NULL, 
    CONSTRAINT [UQ_Materials_Title] UNIQUE ([Title])
)
