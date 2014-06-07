
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2014 14:05:02
-- Generated from EDMX file: C:\Users\AlunoInfnet\Desktop\Livraria\Livraria\Dominio\arquivos\ModeloLivraria.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Livraria];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LivroAutor_Autor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LivroAutor] DROP CONSTRAINT [FK_LivroAutor_Autor];
GO
IF OBJECT_ID(N'[dbo].[FK_LivroAutor_Livro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LivroAutor] DROP CONSTRAINT [FK_LivroAutor_Livro];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Autor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autor];
GO
IF OBJECT_ID(N'[dbo].[Livro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Livro];
GO
IF OBJECT_ID(N'[dbo].[LivroAutor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LivroAutor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Autor'
CREATE TABLE [dbo].[Autor] (
    [IdAutor] int  NOT NULL,
    [Nome] nvarchar(max)  NULL
);
GO

-- Creating table 'Livro'
CREATE TABLE [dbo].[Livro] (
    [IdLivro] int  NOT NULL,
    [Nome] nvarchar(max)  NULL,
    [Preco] decimal(14,2)  NULL,
    [DataPublicacao] datetime  NULL
);
GO

-- Creating table 'LivroAutor'
CREATE TABLE [dbo].[LivroAutor] (
    [Autor_IdAutor] int  NOT NULL,
    [Livro_IdLivro] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAutor] in table 'Autor'
ALTER TABLE [dbo].[Autor]
ADD CONSTRAINT [PK_Autor]
    PRIMARY KEY CLUSTERED ([IdAutor] ASC);
GO

-- Creating primary key on [IdLivro] in table 'Livro'
ALTER TABLE [dbo].[Livro]
ADD CONSTRAINT [PK_Livro]
    PRIMARY KEY CLUSTERED ([IdLivro] ASC);
GO

-- Creating primary key on [Autor_IdAutor], [Livro_IdLivro] in table 'LivroAutor'
ALTER TABLE [dbo].[LivroAutor]
ADD CONSTRAINT [PK_LivroAutor]
    PRIMARY KEY NONCLUSTERED ([Autor_IdAutor], [Livro_IdLivro] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Autor_IdAutor] in table 'LivroAutor'
ALTER TABLE [dbo].[LivroAutor]
ADD CONSTRAINT [FK_LivroAutor_Autor]
    FOREIGN KEY ([Autor_IdAutor])
    REFERENCES [dbo].[Autor]
        ([IdAutor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Livro_IdLivro] in table 'LivroAutor'
ALTER TABLE [dbo].[LivroAutor]
ADD CONSTRAINT [FK_LivroAutor_Livro]
    FOREIGN KEY ([Livro_IdLivro])
    REFERENCES [dbo].[Livro]
        ([IdLivro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LivroAutor_Livro'
CREATE INDEX [IX_FK_LivroAutor_Livro]
ON [dbo].[LivroAutor]
    ([Livro_IdLivro]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------