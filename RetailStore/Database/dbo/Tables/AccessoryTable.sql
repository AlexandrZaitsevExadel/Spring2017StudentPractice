CREATE TABLE [dbo].[AccessoryTable] (
    [AccessoryId]   INT           NOT NULL,
    [AccessoryName] NVARCHAR (50) NULL,
    [Price]         INT           NULL,
    CONSTRAINT [PK_AccessoryTable] PRIMARY KEY CLUSTERED ([AccessoryId] ASC)
);

