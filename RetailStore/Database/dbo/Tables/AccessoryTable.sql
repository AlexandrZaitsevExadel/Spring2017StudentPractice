CREATE TABLE [dbo].[AccessoryTable] (
    [AccessoryId]   INT           IDENTITY (1, 1) NOT NULL,
    [AccessoryName] NVARCHAR (50) DEFAULT ('NoName') NOT NULL,
    [Price]         INT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([AccessoryId] ASC)
);



