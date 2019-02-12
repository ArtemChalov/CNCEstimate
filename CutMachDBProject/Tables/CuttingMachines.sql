CREATE TABLE [dbo].[CuttingMachines]
(
	[CuttingMachineId] TINYINT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeTitle] NVARCHAR(50) NOT NULL, 
    [ShortTitle] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [UA_CuttingMachines_TypeTitle] UNIQUE ([TypeTitle]), 
    CONSTRAINT [UQ_CuttingMachines_ShortTitle] UNIQUE ([ShortTitle]) 
)
