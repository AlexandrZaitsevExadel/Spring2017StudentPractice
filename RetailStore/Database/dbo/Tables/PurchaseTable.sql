CREATE TABLE [dbo].[PurchaseTable] (
    [PurchaseId]  INT NULL,
    [AccessoryId] INT NULL,
    [ClientId]    INT NULL,
    [Quantity]    INT NULL,
    CONSTRAINT [FK_AccessoryTable_PurchaseTable] FOREIGN KEY ([AccessoryId]) REFERENCES [dbo].[AccessoryTable] ([AccessoryId]),
    CONSTRAINT [FK_ClientTable_PurchaseTable] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[ClientTable] ([ClientId])
);

