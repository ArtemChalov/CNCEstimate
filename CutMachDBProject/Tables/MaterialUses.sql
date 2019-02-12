CREATE TABLE [dbo].[MaterialUses]
(
	[MaterialUsesId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MaterialHeadersId] INT NOT NULL, 
    [CuttingMachinesId] TINYINT NOT NULL, 
    CONSTRAINT [FK_MaterialUses_To_MaterialHeders_Id] FOREIGN KEY ([MaterialHeadersId]) REFERENCES [MaterialHeaders]([MaterialHeadersId]), 
    CONSTRAINT [FK_MaterialUses_To_CuttingMachines_Id] FOREIGN KEY ([CuttingMachinesId]) REFERENCES [CuttingMachines]([CuttingMachineId])
)
