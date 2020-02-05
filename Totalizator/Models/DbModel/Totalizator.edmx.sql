
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/05/2020 16:34:54
-- Generated from EDMX file: C:\Users\german.samolazov\Desktop\totalizator\Totalizator\Models\DbModel\Totalizator.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [totalizator];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Bets_Events]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bets] DROP CONSTRAINT [FK_Bets_Events];
GO
IF OBJECT_ID(N'[dbo].[FK_Bets_Teams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bets] DROP CONSTRAINT [FK_Bets_Teams];
GO
IF OBJECT_ID(N'[dbo].[FK_Bets_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bets] DROP CONSTRAINT [FK_Bets_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Teams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Events_Teams];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Teams1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Events_Teams1];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Teams2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Events_Teams2];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Types]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Events_Types];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Events_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Events_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bets];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bets'
CREATE TABLE [dbo].[Bets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [EventId] int  NOT NULL,
    [TeamId] int  NOT NULL,
    [Amount] float  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(200)  NULL,
    [TeamFirstId] int  NOT NULL,
    [TeamSecondId] int  NOT NULL,
    [TeamFirstCoefficient] float  NOT NULL,
    [TeamSecondCoefficient] float  NOT NULL,
    [WinnerId] int  NULL,
    [TeamFirstPoints] float  NOT NULL,
    [TeamSecondPoints] float  NOT NULL,
    [CreatorId] int  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [EditorId] int  NULL,
    [EditDate] datetime  NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [Description] nvarchar(200)  NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [Roles_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bets'
ALTER TABLE [dbo].[Bets]
ADD CONSTRAINT [PK_Bets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Roles_Id], [Users_Id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([Roles_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EventId] in table 'Bets'
ALTER TABLE [dbo].[Bets]
ADD CONSTRAINT [FK_Bets_Events]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bets_Events'
CREATE INDEX [IX_FK_Bets_Events]
ON [dbo].[Bets]
    ([EventId]);
GO

-- Creating foreign key on [TeamId] in table 'Bets'
ALTER TABLE [dbo].[Bets]
ADD CONSTRAINT [FK_Bets_Teams]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bets_Teams'
CREATE INDEX [IX_FK_Bets_Teams]
ON [dbo].[Bets]
    ([TeamId]);
GO

-- Creating foreign key on [UserId] in table 'Bets'
ALTER TABLE [dbo].[Bets]
ADD CONSTRAINT [FK_Bets_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bets_Users'
CREATE INDEX [IX_FK_Bets_Users]
ON [dbo].[Bets]
    ([UserId]);
GO

-- Creating foreign key on [TeamFirstId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Events_Teams]
    FOREIGN KEY ([TeamFirstId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Teams'
CREATE INDEX [IX_FK_Events_Teams]
ON [dbo].[Events]
    ([TeamFirstId]);
GO

-- Creating foreign key on [TeamSecondId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Events_Teams1]
    FOREIGN KEY ([TeamSecondId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Teams1'
CREATE INDEX [IX_FK_Events_Teams1]
ON [dbo].[Events]
    ([TeamSecondId]);
GO

-- Creating foreign key on [WinnerId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Events_Teams2]
    FOREIGN KEY ([WinnerId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Teams2'
CREATE INDEX [IX_FK_Events_Teams2]
ON [dbo].[Events]
    ([WinnerId]);
GO

-- Creating foreign key on [TypeId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Events_Types]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[Types]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Types'
CREATE INDEX [IX_FK_Events_Types]
ON [dbo].[Events]
    ([TypeId]);
GO

-- Creating foreign key on [CreatorId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Events_Users]
    FOREIGN KEY ([CreatorId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Users'
CREATE INDEX [IX_FK_Events_Users]
ON [dbo].[Events]
    ([CreatorId]);
GO

-- Creating foreign key on [EditorId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Events_Users1]
    FOREIGN KEY ([EditorId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Users1'
CREATE INDEX [IX_FK_Events_Users1]
ON [dbo].[Events]
    ([EditorId]);
GO

-- Creating foreign key on [Roles_Id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_Roles]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_Users]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRoles_Users'
CREATE INDEX [IX_FK_UserRoles_Users]
ON [dbo].[UserRoles]
    ([Users_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------