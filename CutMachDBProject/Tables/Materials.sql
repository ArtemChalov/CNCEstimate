CREATE TABLE [dbo].[Materials]
(
	[MaterialId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Title] NVARCHAR(50) NOT NULL, 
	[Density] FLOAT NOT NULL, 
	[MaterialGroupId] INT NOT NULL, 
	[Support] NVARCHAR(10) NOT NULL, 
	CONSTRAINT [FK_Materials_MaterialGroupId] FOREIGN KEY ([MaterialGroupId]) REFERENCES [MaterialGroups]([MaterialGroupId])
)
