
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/14/2016 09:59:23
-- Generated from EDMX file: G:\代码存放\Asp\powerTest\powerTest.Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [powerTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfoUserAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAction] DROP CONSTRAINT [FK_UserInfoUserAction];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoUserAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAction] DROP CONSTRAINT [FK_ActionInfoUserAction];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRoleInfo_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRoleInfo] DROP CONSTRAINT [FK_UserInfoRoleInfo_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRoleInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRoleInfo] DROP CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[UserAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAction];
GO
IF OBJECT_ID(N'[dbo].[ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[UserInfoRoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoRoleInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfoActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfoActionInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(10)  NOT NULL,
    [UserPwd] varchar(50)  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [Remark] nvarchar(1000)  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'UserAction'
CREATE TABLE [dbo].[UserAction] (
    [IsAllow] bit  NOT NULL,
    [UserId] int  NOT NULL,
    [ActionId] int  NOT NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ActionId] int IDENTITY(1,1) NOT NULL,
    [ActionTitle] nvarchar(10)  NOT NULL,
    [ControllerName] nvarchar(50)  NOT NULL,
    [ActionName] varchar(20)  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [Remark] nvarchar(1000)  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [IsMenu] bit  NOT NULL,
    [MenuIcon] varchar(100)  NOT NULL
);
GO

-- Creating table 'RoleInfo'
CREATE TABLE [dbo].[RoleInfo] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(10)  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [Remark] nvarchar(1000)  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'UserInfoRoleInfo'
CREATE TABLE [dbo].[UserInfoRoleInfo] (
    [UserInfo_UserId] int  NOT NULL,
    [RoleInfo_RoleId] int  NOT NULL
);
GO

-- Creating table 'RoleInfoActionInfo'
CREATE TABLE [dbo].[RoleInfoActionInfo] (
    [RoleInfo_RoleId] int  NOT NULL,
    [ActionInfo_ActionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId], [ActionId] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [PK_UserAction]
    PRIMARY KEY CLUSTERED ([UserId], [ActionId] ASC);
GO

-- Creating primary key on [ActionId] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ActionId] ASC);
GO

-- Creating primary key on [RoleId] in table 'RoleInfo'
ALTER TABLE [dbo].[RoleInfo]
ADD CONSTRAINT [PK_RoleInfo]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserInfo_UserId], [RoleInfo_RoleId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [PK_UserInfoRoleInfo]
    PRIMARY KEY CLUSTERED ([UserInfo_UserId], [RoleInfo_RoleId] ASC);
GO

-- Creating primary key on [RoleInfo_RoleId], [ActionInfo_ActionId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [PK_RoleInfoActionInfo]
    PRIMARY KEY CLUSTERED ([RoleInfo_RoleId], [ActionInfo_ActionId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [FK_UserInfoUserAction]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfo]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionId] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [FK_ActionInfoUserAction]
    FOREIGN KEY ([ActionId])
    REFERENCES [dbo].[ActionInfo]
        ([ActionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoUserAction'
CREATE INDEX [IX_FK_ActionInfoUserAction]
ON [dbo].[UserAction]
    ([ActionId]);
GO

-- Creating foreign key on [UserInfo_UserId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_UserInfo]
    FOREIGN KEY ([UserInfo_UserId])
    REFERENCES [dbo].[UserInfo]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleInfo_RoleId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_RoleId])
    REFERENCES [dbo].[RoleInfo]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRoleInfo_RoleInfo'
CREATE INDEX [IX_FK_UserInfoRoleInfo_RoleInfo]
ON [dbo].[UserInfoRoleInfo]
    ([RoleInfo_RoleId]);
GO

-- Creating foreign key on [RoleInfo_RoleId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_RoleId])
    REFERENCES [dbo].[RoleInfo]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionInfo_ActionId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ActionId])
    REFERENCES [dbo].[ActionInfo]
        ([ActionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoActionInfo_ActionInfo'
CREATE INDEX [IX_FK_RoleInfoActionInfo_ActionInfo]
ON [dbo].[RoleInfoActionInfo]
    ([ActionInfo_ActionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------