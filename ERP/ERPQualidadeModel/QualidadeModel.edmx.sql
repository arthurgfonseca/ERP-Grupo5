
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/28/2011 00:25:09
-- Generated from EDMX file: C:\Users\Danilo\Documents\Visual Studio 2010\Projects\PCS2046\ERP\ERPQualidadeModel\QualidadeModel.edmx
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
    [nome] nvarchar(max)  NOT NULL,
    [data_avaliacao] datetime  NOT NULL,
    [tempo_espera] decimal(18,0)  NOT NULL,
    [qualidade_atendimento] decimal(18,0)  NOT NULL,
    [outra_opiniao] bit  NOT NULL,
    [nota_final] decimal(18,0)  NOT NULL,
    [comentarios] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SatisfacaoFuncionarioSet'
CREATE TABLE [dbo].[SatisfacaoFuncionarioSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nome_funcionario] nvarchar(max)  NOT NULL,
    [codigo_funcionario] nvarchar(max)  NOT NULL,
    [data_avaliacao] datetime  NOT NULL,
    [nota_ambiente_trabalho] decimal(18,0)  NOT NULL,
    [nota_colegas_trabalho] decimal(18,0)  NOT NULL,
    [nota_satisfacao_pessoal] decimal(18,0)  NOT NULL,
    [nota_final] decimal(18,0)  NOT NULL,
    [comentarios] nvarchar(max)  NOT NULL
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