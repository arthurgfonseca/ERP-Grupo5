
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/23/2011 15:23:57
-- Generated from EDMX file: C:\Projects\danilo.yokoyama\ERP\ErpAdministracaoModel\AdministracaoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [erp_administracao];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ConvenioServicoConvenioPlanoSaude]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConvenioServicoSet] DROP CONSTRAINT [FK_ConvenioServicoConvenioPlanoSaude];
GO
IF OBJECT_ID(N'[dbo].[FK_ConvenioServicoServicoMedico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServicoMedicoSet] DROP CONSTRAINT [FK_ConvenioServicoServicoMedico];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ConvenioPlanoSaudeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConvenioPlanoSaudeSet];
GO
IF OBJECT_ID(N'[dbo].[ConvenioServicoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConvenioServicoSet];
GO
IF OBJECT_ID(N'[dbo].[ServicoMedicoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServicoMedicoSet];
GO
IF OBJECT_ID(N'[dbo].[SatisfacaoClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].SatisfacaoClienteSet;
GO
IF OBJECT_ID(N'[dbo].[SatisfacaoFuncionarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].SatisfacaoFuncionarioSet;
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ConvenioPlanoSaudeSet'
CREATE TABLE [dbo].[ConvenioPlanoSaudeSet] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [empresa] nvarchar(max)  NOT NULL,
    [plano] nvarchar(max)  NOT NULL,
    [telefone] nvarchar(max)  NOT NULL,
    [observacoes] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ConvenioServicoSet'
CREATE TABLE [dbo].[ConvenioServicoSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [porcentagem_desconto] float  NOT NULL,
    [ConvenioPlanoSaude_codigo] int  NOT NULL
);
GO

-- Creating table 'ServicoMedicoSet'
CREATE TABLE [dbo].[ServicoMedicoSet] (
    [codigo] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [descricao] nvarchar(max)  NOT NULL,
    [preco] float  NOT NULL,
    [ConvenioServico_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [codigo] in table 'ConvenioPlanoSaudeSet'
ALTER TABLE [dbo].[ConvenioPlanoSaudeSet]
ADD CONSTRAINT [PK_ConvenioPlanoSaudeSet]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [id] in table 'ConvenioServicoSet'
ALTER TABLE [dbo].[ConvenioServicoSet]
ADD CONSTRAINT [PK_ConvenioServicoSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [codigo] in table 'ServicoMedicoSet'
ALTER TABLE [dbo].[ServicoMedicoSet]
ADD CONSTRAINT [PK_ServicoMedicoSet]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ConvenioPlanoSaude_codigo] in table 'ConvenioServicoSet'
ALTER TABLE [dbo].[ConvenioServicoSet]
ADD CONSTRAINT [FK_ConvenioServicoConvenioPlanoSaude]
    FOREIGN KEY ([ConvenioPlanoSaude_codigo])
    REFERENCES [dbo].[ConvenioPlanoSaudeSet]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConvenioServicoConvenioPlanoSaude'
CREATE INDEX [IX_FK_ConvenioServicoConvenioPlanoSaude]
ON [dbo].[ConvenioServicoSet]
    ([ConvenioPlanoSaude_codigo]);
GO

-- Creating foreign key on [ConvenioServico_id] in table 'ServicoMedicoSet'
ALTER TABLE [dbo].[ServicoMedicoSet]
ADD CONSTRAINT [FK_ConvenioServicoServicoMedico]
    FOREIGN KEY ([ConvenioServico_id])
    REFERENCES [dbo].[ConvenioServicoSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConvenioServicoServicoMedico'
CREATE INDEX [IX_FK_ConvenioServicoServicoMedico]
ON [dbo].[ServicoMedicoSet]
    ([ConvenioServico_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------