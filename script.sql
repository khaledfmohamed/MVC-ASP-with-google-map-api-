create database [events1];
go
USE [events1]
GO

/****** Object: Table [dbo].[AspNetRoles] Script Date: 25/02/2018 12:12:56 ص ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);


GO
ALTER TABLE [dbo].[AspNetRoles]
    ADD CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC);


USE [events]
GO

/****** Object: Table [dbo].[AspNetUserClaims] Script Date: 25/02/2018 12:13:12 Õ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


USE [events]
GO

/****** Object: Table [dbo].[AspNetUserLogins] Script Date: 25/02/2018 12:13:27 Õ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[AspNetUserLogins];


GO
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL
);
USE [events]
GO

/****** Object: Table [dbo].[AspNetUserRoles] Script Date: 25/02/2018 12:13:45 Õ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRoles]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


USE [events]
GO

/****** Object: Table [dbo].[AspNetUsers] Script Date: 25/02/2018 12:14:21 Õ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);


GO
ALTER TABLE [dbo].[AspNetUsers]
    ADD CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC);


	USE [events]
GO

/****** Object: Table [dbo].[cities] Script Date: 25/02/2018 12:14:52 Õ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cities] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (MAX) NOT NULL,
    [country_id] INT            NOT NULL,
    [creator]    NVARCHAR (MAX) NULL,
    [created]    DATETIME       NULL,
    [changer]    NVARCHAR (MAX) NULL,
    [changed]    DATETIME       NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_country_id]
    ON [dbo].[cities]([country_id] ASC);


GO
ALTER TABLE [dbo].[cities]
    ADD CONSTRAINT [PK_dbo.cities] PRIMARY KEY CLUSTERED ([id] ASC);


GO
ALTER TABLE [dbo].[cities]
    ADD CONSTRAINT [FK_dbo.cities_dbo.countries_country_id] FOREIGN KEY ([country_id]) REFERENCES [dbo].[countries] ([id]);

	USE [events]
GO

/****** Object: Table [dbo].[countries] Script Date: 25/02/2018 12:15:00 Õ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[countries] (
    [id]      INT            IDENTITY (1, 1) NOT NULL,
    [name]    NVARCHAR (MAX) NOT NULL,
    [creator] NVARCHAR (MAX) NULL,
    [created] DATETIME       NULL,
    [changer] NVARCHAR (MAX) NULL,
    [changed] DATETIME       NULL
);

USE [events]
GO

/****** Object: Table [dbo].[events] Script Date: 25/02/2018 12:15:08 Õ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[events] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [title]       NVARCHAR (MAX) NOT NULL,
    [start_date]  DATETIME       NOT NULL,
    [end_date]    DATETIME       NOT NULL,
    [country_id]  INT            NOT NULL,
    [city_id]     INT            NOT NULL,
    [location]    NVARCHAR (MAX) NOT NULL,
    [image_path]  NVARCHAR (MAX) NOT NULL,
    [description] NVARCHAR (MAX) NULL,
    [creator]     NVARCHAR (MAX) NULL,
    [created]     DATETIME       NULL,
    [changer]     NVARCHAR (MAX) NULL,
    [changed]     DATETIME       NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_country_id]
    ON [dbo].[events]([country_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_city_id]
    ON [dbo].[events]([city_id] ASC);


GO
ALTER TABLE [dbo].[events]
    ADD CONSTRAINT [PK_dbo.events] PRIMARY KEY CLUSTERED ([id] ASC);


GO
ALTER TABLE [dbo].[events]
    ADD CONSTRAINT [FK_dbo.events_dbo.cities_city_id] FOREIGN KEY ([city_id]) REFERENCES [dbo].[cities] ([id]);


GO
ALTER TABLE [dbo].[events]
    ADD CONSTRAINT [FK_dbo.events_dbo.countries_country_id] FOREIGN KEY ([country_id]) REFERENCES [dbo].[countries] ([id]);








