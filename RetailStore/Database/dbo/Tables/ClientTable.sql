CREATE TABLE [dbo].[ClientTable] (
    [ClientId]   INT           NOT NULL,
    [ClientName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_ClientTable] PRIMARY KEY CLUSTERED ([ClientId] ASC)
);

