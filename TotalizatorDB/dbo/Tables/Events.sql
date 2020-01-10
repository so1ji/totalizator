CREATE TABLE [dbo].[Events] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [TypeId]        INT            NOT NULL,
    [Date]          DATETIME       NOT NULL,
    [Name]          NVARCHAR (50)  NOT NULL,
    [Description]   NVARCHAR (200) NULL,
    [Coefficient]   FLOAT (53)     NOT NULL,
    [TeamFirstId]   INT            NOT NULL,
    [TeamdSecondId] INT            NOT NULL,
    [WinnerId]      INT            NOT NULL,
    [TotalPoints]   FLOAT (53)     NOT NULL,
    [CreatorId]     INT            NOT NULL,
    [CreateDate]    DATETIME       NOT NULL,
    [EditorId]      INT            NULL,
    [EditDate]      INT            NULL,
    [Status]        TINYINT        NOT NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Events_Teams] FOREIGN KEY ([TeamFirstId]) REFERENCES [dbo].[Teams] ([Id]),
    CONSTRAINT [FK_Events_Teams1] FOREIGN KEY ([TeamdSecondId]) REFERENCES [dbo].[Teams] ([Id]),
    CONSTRAINT [FK_Events_Teams2] FOREIGN KEY ([WinnerId]) REFERENCES [dbo].[Teams] ([Id]),
    CONSTRAINT [FK_Events_Types] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Types] ([Id]),
    CONSTRAINT [FK_Events_Users] FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Events_Users1] FOREIGN KEY ([EditorId]) REFERENCES [dbo].[Users] ([Id])
);



