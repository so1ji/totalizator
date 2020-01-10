CREATE TABLE [dbo].[Teams] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (20)  NOT NULL,
    [Description] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED ([Id] ASC)
);

