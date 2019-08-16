CREATE TABLE [dbo].[DotoTable] (
    [Id]   INT NOT NULL IDENTITY, 
    [Hero] NVARCHAR (50) NOT NULL,
    [WL]   NCHAR (10)    NOT NULL, 
    CONSTRAINT [PK_DotoTable] PRIMARY KEY ([Id])
);
