CREATE TABLE [dbo].[MaterialGroups]
(
    [MaterialGroupId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GroupTitle] NVARCHAR(50) NOT NULL, 
    [Parent] NVARCHAR(50) NULL, 
    [Support] NVARCHAR(50) NULL, 
    [Gost] NVARCHAR(50) NULL, 
    CONSTRAINT [AK_MaterialGroups_GroupTitle] UNIQUE ([GroupTitle])
)
