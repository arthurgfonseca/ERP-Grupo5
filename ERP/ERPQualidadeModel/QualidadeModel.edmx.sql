
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/06/2011 16:31:15
-- Generated from EDMX file: C:\Users\Arthur Fonseca\ERP\ERP-Grupo5\ERP\ERPQualidadeModel\QualidadeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [erp_qualidade];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[SatisfacaoClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SatisfacaoClienteSet];
GO
IF OBJECT_ID(N'[dbo].[SatisfacaoFuncionarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SatisfacaoFuncionarioSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SatisfacaoClienteSet'
CREATE TABLE [dbo].[SatisfacaoClienteSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NULL,
    [data_avaliacao] datetime  NULL,
    [tempo_espera] decimal(18,0)  NULL,
    [qualidade_atendimento] decimal(18,0)  NULL,
    [outra_opiniao] bit  NULL,
    [nota_final] decimal(18,0)  NULL,
    [comentarios] nvarchar(max)  NULL
);
GO

-- Creating table 'SatisfacaoFuncionarioSet'
CREATE TABLE [dbo].[SatisfacaoFuncionarioSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nome_funcionario] nvarchar(max)  NULL,
    [codigo_funcionario] nvarchar(max)  NULL,
    [data_avaliacao] datetime  NULL,
    [nota_ambiente_trabalho] decimal(18,0)  NULL,
    [nota_colegas_trabalho] decimal(18,0)  NULL,
    [nota_satisfacao_pessoal] decimal(18,0)  NULL,
    [nota_final] decimal(18,0)  NULL,
    [comentarios] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'SatisfacaoClienteSet'
ALTER TABLE [dbo].[SatisfacaoClienteSet]
ADD CONSTRAINT [PK_SatisfacaoClienteSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SatisfacaoFuncionarioSet'
ALTER TABLE [dbo].[SatisfacaoFuncionarioSet]
ADD CONSTRAINT [PK_SatisfacaoFuncionarioSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------