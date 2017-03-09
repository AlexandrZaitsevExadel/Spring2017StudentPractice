CREATE TABLE [dbo].[PurchaseTable] (
    [PurchaseId]   INT      IDENTITY (1, 1) NOT NULL,
    [AccessoryId]  INT      NULL,
    [ClientId]     INT      NULL,
    [Quantity]     INT      DEFAULT ((0)) NOT NULL,
    [PurchaseDate] DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseId] ASC),
    FOREIGN KEY ([AccessoryId]) REFERENCES [dbo].[AccessoryTable] ([AccessoryId]),
    FOREIGN KEY ([ClientId]) REFERENCES [dbo].[ClientTable] ([ClientId])
);







