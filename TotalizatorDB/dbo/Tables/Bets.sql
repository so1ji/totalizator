CREATE TABLE [dbo].[Bets] (
    [Id]      INT        IDENTITY (1, 1) NOT NULL,
    [UserId]  INT        NOT NULL,
    [EventId] INT        NOT NULL,
    [Amount]  FLOAT (53) NOT NULL,
    CONSTRAINT [PK_Bets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Bets_Events] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([Id]),
    CONSTRAINT [FK_Bets_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

