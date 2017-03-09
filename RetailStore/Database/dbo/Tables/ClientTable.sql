CREATE TABLE [dbo].[ClientTable] (
    [ClientId]   INT           IDENTITY (1, 1) NOT NULL,
    [ClientName] NVARCHAR (50) DEFAULT ('NoName') NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientId] ASC)
);



