
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/04/2011 13:00:18
-- Generated from EDMX file: C:\Users\Alex Riabov\SeniorProjectERPRec\SeniorProjectERPRec\SeniorProjectERPRec\Models\SeniorProjectModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SeniorProjectERPRec];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PositionApplicant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applicants1] DROP CONSTRAINT [FK_PositionApplicant];
GO
IF OBJECT_ID(N'[dbo].[FK_ApplicantReimbursement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reimbursements] DROP CONSTRAINT [FK_ApplicantReimbursement];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Positions] DROP CONSTRAINT [FK_PositionDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_ReimbursementType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reimbursements] DROP CONSTRAINT [FK_ReimbursementType];
GO
IF OBJECT_ID(N'[dbo].[FK_ReimbursementBudget]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reimbursements] DROP CONSTRAINT [FK_ReimbursementBudget];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Applicants1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Applicants1];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Reimbursements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reimbursements];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[Budgets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Budgets];
GO
IF OBJECT_ID(N'[dbo].[Positions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Positions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Applicants1'
CREATE TABLE [dbo].[Applicants1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Major] nvarchar(max)  NOT NULL,
    [School] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [PositionId] int  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Reimbursements'
CREATE TABLE [dbo].[Reimbursements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [ApplicantId] int  NOT NULL,
    [TypeId] int  NOT NULL,
    [BudgetId] int  NOT NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Budgets'
CREATE TABLE [dbo].[Budgets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [DepartmentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Applicants1'
ALTER TABLE [dbo].[Applicants1]
ADD CONSTRAINT [PK_Applicants1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reimbursements'
ALTER TABLE [dbo].[Reimbursements]
ADD CONSTRAINT [PK_Reimbursements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Budgets'
ALTER TABLE [dbo].[Budgets]
ADD CONSTRAINT [PK_Budgets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PositionId] in table 'Applicants1'
ALTER TABLE [dbo].[Applicants1]
ADD CONSTRAINT [FK_PositionApplicant]
    FOREIGN KEY ([PositionId])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionApplicant'
CREATE INDEX [IX_FK_PositionApplicant]
ON [dbo].[Applicants1]
    ([PositionId]);
GO

-- Creating foreign key on [ApplicantId] in table 'Reimbursements'
ALTER TABLE [dbo].[Reimbursements]
ADD CONSTRAINT [FK_ApplicantReimbursement]
    FOREIGN KEY ([ApplicantId])
    REFERENCES [dbo].[Applicants1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ApplicantReimbursement'
CREATE INDEX [IX_FK_ApplicantReimbursement]
ON [dbo].[Reimbursements]
    ([ApplicantId]);
GO

-- Creating foreign key on [DepartmentId] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [FK_PositionDepartment]
    FOREIGN KEY ([DepartmentId])
    REFERENCES [dbo].[Departments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionDepartment'
CREATE INDEX [IX_FK_PositionDepartment]
ON [dbo].[Positions]
    ([DepartmentId]);
GO

-- Creating foreign key on [TypeId] in table 'Reimbursements'
ALTER TABLE [dbo].[Reimbursements]
ADD CONSTRAINT [FK_ReimbursementType]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[Types]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReimbursementType'
CREATE INDEX [IX_FK_ReimbursementType]
ON [dbo].[Reimbursements]
    ([TypeId]);
GO

-- Creating foreign key on [BudgetId] in table 'Reimbursements'
ALTER TABLE [dbo].[Reimbursements]
ADD CONSTRAINT [FK_ReimbursementBudget]
    FOREIGN KEY ([BudgetId])
    REFERENCES [dbo].[Budgets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReimbursementBudget'
CREATE INDEX [IX_FK_ReimbursementBudget]
ON [dbo].[Reimbursements]
    ([BudgetId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------