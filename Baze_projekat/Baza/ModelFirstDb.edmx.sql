
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 17:48:24
-- Generated from EDMX file: E:\milijevic\Desktop\Baze2_projekat\baze2_projekat\Baze_projekat\Baza\ModelFirstDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirstDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_IndustrijaObuceRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks] DROP CONSTRAINT [FK_IndustrijaObuceRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjekatGrad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objekats] DROP CONSTRAINT [FK_ObjekatGrad];
GO
IF OBJECT_ID(N'[dbo].[FK_IndustrijaObuceObjekat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objekats] DROP CONSTRAINT [FK_IndustrijaObuceObjekat];
GO
IF OBJECT_ID(N'[dbo].[FK_ObucarPravi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pravis] DROP CONSTRAINT [FK_ObucarPravi];
GO
IF OBJECT_ID(N'[dbo].[FK_ObucaPravi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pravis] DROP CONSTRAINT [FK_ObucaPravi];
GO
IF OBJECT_ID(N'[dbo].[FK_ObucaTipObuce]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Obucas] DROP CONSTRAINT [FK_ObucaTipObuce];
GO
IF OBJECT_ID(N'[dbo].[FK_MagacinMaterijalaNalazi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nalazis] DROP CONSTRAINT [FK_MagacinMaterijalaNalazi];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterijalNalazi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nalazis] DROP CONSTRAINT [FK_MaterijalNalazi];
GO
IF OBJECT_ID(N'[dbo].[FK_NalaziSastoji]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sastojis] DROP CONSTRAINT [FK_NalaziSastoji];
GO
IF OBJECT_ID(N'[dbo].[FK_ObucaSastoji]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sastojis] DROP CONSTRAINT [FK_ObucaSastoji];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdavnicaProdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prodajes] DROP CONSTRAINT [FK_ProdavnicaProdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_PraviProdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prodajes] DROP CONSTRAINT [FK_PraviProdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdavnicaRadi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radis] DROP CONSTRAINT [FK_ProdavnicaRadi];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdavacRadi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radis] DROP CONSTRAINT [FK_ProdavacRadi];
GO
IF OBJECT_ID(N'[dbo].[FK_Obucar_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Obucar] DROP CONSTRAINT [FK_Obucar_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_MagacinMaterijala_inherits_Objekat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objekats_MagacinMaterijala] DROP CONSTRAINT [FK_MagacinMaterijala_inherits_Objekat];
GO
IF OBJECT_ID(N'[dbo].[FK_Prodavnica_inherits_Objekat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objekats_Prodavnica] DROP CONSTRAINT [FK_Prodavnica_inherits_Objekat];
GO
IF OBJECT_ID(N'[dbo].[FK_Prodavac_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Prodavac] DROP CONSTRAINT [FK_Prodavac_inherits_Radnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[IndustrijaObuces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IndustrijaObuces];
GO
IF OBJECT_ID(N'[dbo].[Radniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks];
GO
IF OBJECT_ID(N'[dbo].[Objekats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Objekats];
GO
IF OBJECT_ID(N'[dbo].[Grads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grads];
GO
IF OBJECT_ID(N'[dbo].[Materijals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materijals];
GO
IF OBJECT_ID(N'[dbo].[Obucas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Obucas];
GO
IF OBJECT_ID(N'[dbo].[Pravis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pravis];
GO
IF OBJECT_ID(N'[dbo].[TipObuces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipObuces];
GO
IF OBJECT_ID(N'[dbo].[Prodajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prodajes];
GO
IF OBJECT_ID(N'[dbo].[Nalazis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nalazis];
GO
IF OBJECT_ID(N'[dbo].[Sastojis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sastojis];
GO
IF OBJECT_ID(N'[dbo].[Radis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radis];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Obucar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Obucar];
GO
IF OBJECT_ID(N'[dbo].[Objekats_MagacinMaterijala]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Objekats_MagacinMaterijala];
GO
IF OBJECT_ID(N'[dbo].[Objekats_Prodavnica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Objekats_Prodavnica];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Prodavac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Prodavac];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'IndustrijaObuces'
CREATE TABLE [dbo].[IndustrijaObuces] (
    [IdIO] int IDENTITY(1,1) NOT NULL,
    [NazIO] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Radniks'
CREATE TABLE [dbo].[Radniks] (
    [IdRad] int IDENTITY(1,1) NOT NULL,
    [imeRad] nvarchar(max)  NOT NULL,
    [PrzRad] nvarchar(max)  NOT NULL,
    [PltRad] int  NOT NULL,
    [IndustrijaObuceIdIO] int  NOT NULL,
    [TipRad] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Objekats'
CREATE TABLE [dbo].[Objekats] (
    [IdObj] int IDENTITY(1,1) NOT NULL,
    [NazObj] nvarchar(max)  NOT NULL,
    [AdrObj] nvarchar(max)  NOT NULL,
    [GradIdG] int  NOT NULL,
    [IndustrijaObuceIdIO] int  NOT NULL,
    [TipObj] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Grads'
CREATE TABLE [dbo].[Grads] (
    [IdG] int IDENTITY(1,1) NOT NULL,
    [NazG] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Materijals'
CREATE TABLE [dbo].[Materijals] (
    [IdMat] int IDENTITY(1,1) NOT NULL,
    [NazMat] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Obucas'
CREATE TABLE [dbo].[Obucas] (
    [IdOb] int IDENTITY(1,1) NOT NULL,
    [NazOb] nvarchar(max)  NOT NULL,
    [BrOb] int  NOT NULL,
    [CenaOb] int  NOT NULL,
    [TipObuceIdTipOb] int  NOT NULL
);
GO

-- Creating table 'Pravis'
CREATE TABLE [dbo].[Pravis] (
    [ObucarIdRad] int  NOT NULL,
    [ObucaIdOb] int  NOT NULL
);
GO

-- Creating table 'TipObuces'
CREATE TABLE [dbo].[TipObuces] (
    [IdTipOb] int IDENTITY(1,1) NOT NULL,
    [NazTip] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Prodajes'
CREATE TABLE [dbo].[Prodajes] (
    [ProdavnicaIdObj] int  NOT NULL,
    [ProdavnicaIndustrijaObuceIdIO] int  NOT NULL,
    [PraviObucarIdRad] int  NOT NULL,
    [PraviObucaIdOb] int  NOT NULL
);
GO

-- Creating table 'Nalazis'
CREATE TABLE [dbo].[Nalazis] (
    [MagacinMaterijalaIdObj] int  NOT NULL,
    [MagacinMaterijalaIndustrijaObuceIdIO] int  NOT NULL,
    [MaterijalIdMat] int  NOT NULL
);
GO

-- Creating table 'Sastojis'
CREATE TABLE [dbo].[Sastojis] (
    [NalaziMagacinMaterijalaIdObj] int  NOT NULL,
    [NalaziMagacinMaterijalaIndustrijaObuceIdIO] int  NOT NULL,
    [NalaziMaterijalIdMat] int  NOT NULL,
    [ObucaIdOb] int  NOT NULL
);
GO

-- Creating table 'Radis'
CREATE TABLE [dbo].[Radis] (
    [ProdavnicaIdObj] int  NOT NULL,
    [ProdavnicaIndustrijaObuceIdIO] int  NOT NULL,
    [ProdavacIdRad] int  NOT NULL
);
GO

-- Creating table 'Radniks_Obucar'
CREATE TABLE [dbo].[Radniks_Obucar] (
    [IdRad] int  NOT NULL
);
GO

-- Creating table 'Objekats_MagacinMaterijala'
CREATE TABLE [dbo].[Objekats_MagacinMaterijala] (
    [IdObj] int  NOT NULL,
    [IndustrijaObuceIdIO] int  NOT NULL
);
GO

-- Creating table 'Objekats_Prodavnica'
CREATE TABLE [dbo].[Objekats_Prodavnica] (
    [IdObj] int  NOT NULL,
    [IndustrijaObuceIdIO] int  NOT NULL
);
GO

-- Creating table 'Radniks_Prodavac'
CREATE TABLE [dbo].[Radniks_Prodavac] (
    [IdRad] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdIO] in table 'IndustrijaObuces'
ALTER TABLE [dbo].[IndustrijaObuces]
ADD CONSTRAINT [PK_IndustrijaObuces]
    PRIMARY KEY CLUSTERED ([IdIO] ASC);
GO

-- Creating primary key on [IdRad] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [PK_Radniks]
    PRIMARY KEY CLUSTERED ([IdRad] ASC);
GO

-- Creating primary key on [IdObj], [IndustrijaObuceIdIO] in table 'Objekats'
ALTER TABLE [dbo].[Objekats]
ADD CONSTRAINT [PK_Objekats]
    PRIMARY KEY CLUSTERED ([IdObj], [IndustrijaObuceIdIO] ASC);
GO

-- Creating primary key on [IdG] in table 'Grads'
ALTER TABLE [dbo].[Grads]
ADD CONSTRAINT [PK_Grads]
    PRIMARY KEY CLUSTERED ([IdG] ASC);
GO

-- Creating primary key on [IdMat] in table 'Materijals'
ALTER TABLE [dbo].[Materijals]
ADD CONSTRAINT [PK_Materijals]
    PRIMARY KEY CLUSTERED ([IdMat] ASC);
GO

-- Creating primary key on [IdOb] in table 'Obucas'
ALTER TABLE [dbo].[Obucas]
ADD CONSTRAINT [PK_Obucas]
    PRIMARY KEY CLUSTERED ([IdOb] ASC);
GO

-- Creating primary key on [ObucarIdRad], [ObucaIdOb] in table 'Pravis'
ALTER TABLE [dbo].[Pravis]
ADD CONSTRAINT [PK_Pravis]
    PRIMARY KEY CLUSTERED ([ObucarIdRad], [ObucaIdOb] ASC);
GO

-- Creating primary key on [IdTipOb] in table 'TipObuces'
ALTER TABLE [dbo].[TipObuces]
ADD CONSTRAINT [PK_TipObuces]
    PRIMARY KEY CLUSTERED ([IdTipOb] ASC);
GO

-- Creating primary key on [ProdavnicaIdObj], [ProdavnicaIndustrijaObuceIdIO], [PraviObucarIdRad], [PraviObucaIdOb] in table 'Prodajes'
ALTER TABLE [dbo].[Prodajes]
ADD CONSTRAINT [PK_Prodajes]
    PRIMARY KEY CLUSTERED ([ProdavnicaIdObj], [ProdavnicaIndustrijaObuceIdIO], [PraviObucarIdRad], [PraviObucaIdOb] ASC);
GO

-- Creating primary key on [MagacinMaterijalaIdObj], [MagacinMaterijalaIndustrijaObuceIdIO], [MaterijalIdMat] in table 'Nalazis'
ALTER TABLE [dbo].[Nalazis]
ADD CONSTRAINT [PK_Nalazis]
    PRIMARY KEY CLUSTERED ([MagacinMaterijalaIdObj], [MagacinMaterijalaIndustrijaObuceIdIO], [MaterijalIdMat] ASC);
GO

-- Creating primary key on [NalaziMagacinMaterijalaIdObj], [NalaziMagacinMaterijalaIndustrijaObuceIdIO], [NalaziMaterijalIdMat], [ObucaIdOb] in table 'Sastojis'
ALTER TABLE [dbo].[Sastojis]
ADD CONSTRAINT [PK_Sastojis]
    PRIMARY KEY CLUSTERED ([NalaziMagacinMaterijalaIdObj], [NalaziMagacinMaterijalaIndustrijaObuceIdIO], [NalaziMaterijalIdMat], [ObucaIdOb] ASC);
GO

-- Creating primary key on [ProdavnicaIdObj], [ProdavnicaIndustrijaObuceIdIO], [ProdavacIdRad] in table 'Radis'
ALTER TABLE [dbo].[Radis]
ADD CONSTRAINT [PK_Radis]
    PRIMARY KEY CLUSTERED ([ProdavnicaIdObj], [ProdavnicaIndustrijaObuceIdIO], [ProdavacIdRad] ASC);
GO

-- Creating primary key on [IdRad] in table 'Radniks_Obucar'
ALTER TABLE [dbo].[Radniks_Obucar]
ADD CONSTRAINT [PK_Radniks_Obucar]
    PRIMARY KEY CLUSTERED ([IdRad] ASC);
GO

-- Creating primary key on [IdObj], [IndustrijaObuceIdIO] in table 'Objekats_MagacinMaterijala'
ALTER TABLE [dbo].[Objekats_MagacinMaterijala]
ADD CONSTRAINT [PK_Objekats_MagacinMaterijala]
    PRIMARY KEY CLUSTERED ([IdObj], [IndustrijaObuceIdIO] ASC);
GO

-- Creating primary key on [IdObj], [IndustrijaObuceIdIO] in table 'Objekats_Prodavnica'
ALTER TABLE [dbo].[Objekats_Prodavnica]
ADD CONSTRAINT [PK_Objekats_Prodavnica]
    PRIMARY KEY CLUSTERED ([IdObj], [IndustrijaObuceIdIO] ASC);
GO

-- Creating primary key on [IdRad] in table 'Radniks_Prodavac'
ALTER TABLE [dbo].[Radniks_Prodavac]
ADD CONSTRAINT [PK_Radniks_Prodavac]
    PRIMARY KEY CLUSTERED ([IdRad] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IndustrijaObuceIdIO] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [FK_IndustrijaObuceRadnik]
    FOREIGN KEY ([IndustrijaObuceIdIO])
    REFERENCES [dbo].[IndustrijaObuces]
        ([IdIO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndustrijaObuceRadnik'
CREATE INDEX [IX_FK_IndustrijaObuceRadnik]
ON [dbo].[Radniks]
    ([IndustrijaObuceIdIO]);
GO

-- Creating foreign key on [GradIdG] in table 'Objekats'
ALTER TABLE [dbo].[Objekats]
ADD CONSTRAINT [FK_ObjekatGrad]
    FOREIGN KEY ([GradIdG])
    REFERENCES [dbo].[Grads]
        ([IdG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjekatGrad'
CREATE INDEX [IX_FK_ObjekatGrad]
ON [dbo].[Objekats]
    ([GradIdG]);
GO

-- Creating foreign key on [IndustrijaObuceIdIO] in table 'Objekats'
ALTER TABLE [dbo].[Objekats]
ADD CONSTRAINT [FK_IndustrijaObuceObjekat]
    FOREIGN KEY ([IndustrijaObuceIdIO])
    REFERENCES [dbo].[IndustrijaObuces]
        ([IdIO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndustrijaObuceObjekat'
CREATE INDEX [IX_FK_IndustrijaObuceObjekat]
ON [dbo].[Objekats]
    ([IndustrijaObuceIdIO]);
GO

-- Creating foreign key on [ObucarIdRad] in table 'Pravis'
ALTER TABLE [dbo].[Pravis]
ADD CONSTRAINT [FK_ObucarPravi]
    FOREIGN KEY ([ObucarIdRad])
    REFERENCES [dbo].[Radniks_Obucar]
        ([IdRad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ObucaIdOb] in table 'Pravis'
ALTER TABLE [dbo].[Pravis]
ADD CONSTRAINT [FK_ObucaPravi]
    FOREIGN KEY ([ObucaIdOb])
    REFERENCES [dbo].[Obucas]
        ([IdOb])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObucaPravi'
CREATE INDEX [IX_FK_ObucaPravi]
ON [dbo].[Pravis]
    ([ObucaIdOb]);
GO

-- Creating foreign key on [TipObuceIdTipOb] in table 'Obucas'
ALTER TABLE [dbo].[Obucas]
ADD CONSTRAINT [FK_ObucaTipObuce]
    FOREIGN KEY ([TipObuceIdTipOb])
    REFERENCES [dbo].[TipObuces]
        ([IdTipOb])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObucaTipObuce'
CREATE INDEX [IX_FK_ObucaTipObuce]
ON [dbo].[Obucas]
    ([TipObuceIdTipOb]);
GO

-- Creating foreign key on [MagacinMaterijalaIdObj], [MagacinMaterijalaIndustrijaObuceIdIO] in table 'Nalazis'
ALTER TABLE [dbo].[Nalazis]
ADD CONSTRAINT [FK_MagacinMaterijalaNalazi]
    FOREIGN KEY ([MagacinMaterijalaIdObj], [MagacinMaterijalaIndustrijaObuceIdIO])
    REFERENCES [dbo].[Objekats_MagacinMaterijala]
        ([IdObj], [IndustrijaObuceIdIO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaterijalIdMat] in table 'Nalazis'
ALTER TABLE [dbo].[Nalazis]
ADD CONSTRAINT [FK_MaterijalNalazi]
    FOREIGN KEY ([MaterijalIdMat])
    REFERENCES [dbo].[Materijals]
        ([IdMat])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaterijalNalazi'
CREATE INDEX [IX_FK_MaterijalNalazi]
ON [dbo].[Nalazis]
    ([MaterijalIdMat]);
GO

-- Creating foreign key on [NalaziMagacinMaterijalaIdObj], [NalaziMagacinMaterijalaIndustrijaObuceIdIO], [NalaziMaterijalIdMat] in table 'Sastojis'
ALTER TABLE [dbo].[Sastojis]
ADD CONSTRAINT [FK_NalaziSastoji]
    FOREIGN KEY ([NalaziMagacinMaterijalaIdObj], [NalaziMagacinMaterijalaIndustrijaObuceIdIO], [NalaziMaterijalIdMat])
    REFERENCES [dbo].[Nalazis]
        ([MagacinMaterijalaIdObj], [MagacinMaterijalaIndustrijaObuceIdIO], [MaterijalIdMat])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ObucaIdOb] in table 'Sastojis'
ALTER TABLE [dbo].[Sastojis]
ADD CONSTRAINT [FK_ObucaSastoji]
    FOREIGN KEY ([ObucaIdOb])
    REFERENCES [dbo].[Obucas]
        ([IdOb])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObucaSastoji'
CREATE INDEX [IX_FK_ObucaSastoji]
ON [dbo].[Sastojis]
    ([ObucaIdOb]);
GO

-- Creating foreign key on [ProdavnicaIdObj], [ProdavnicaIndustrijaObuceIdIO] in table 'Prodajes'
ALTER TABLE [dbo].[Prodajes]
ADD CONSTRAINT [FK_ProdavnicaProdaje]
    FOREIGN KEY ([ProdavnicaIdObj], [ProdavnicaIndustrijaObuceIdIO])
    REFERENCES [dbo].[Objekats_Prodavnica]
        ([IdObj], [IndustrijaObuceIdIO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PraviObucarIdRad], [PraviObucaIdOb] in table 'Prodajes'
ALTER TABLE [dbo].[Prodajes]
ADD CONSTRAINT [FK_PraviProdaje]
    FOREIGN KEY ([PraviObucarIdRad], [PraviObucaIdOb])
    REFERENCES [dbo].[Pravis]
        ([ObucarIdRad], [ObucaIdOb])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PraviProdaje'
CREATE INDEX [IX_FK_PraviProdaje]
ON [dbo].[Prodajes]
    ([PraviObucarIdRad], [PraviObucaIdOb]);
GO

-- Creating foreign key on [ProdavnicaIdObj], [ProdavnicaIndustrijaObuceIdIO] in table 'Radis'
ALTER TABLE [dbo].[Radis]
ADD CONSTRAINT [FK_ProdavnicaRadi]
    FOREIGN KEY ([ProdavnicaIdObj], [ProdavnicaIndustrijaObuceIdIO])
    REFERENCES [dbo].[Objekats_Prodavnica]
        ([IdObj], [IndustrijaObuceIdIO])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProdavacIdRad] in table 'Radis'
ALTER TABLE [dbo].[Radis]
ADD CONSTRAINT [FK_ProdavacRadi]
    FOREIGN KEY ([ProdavacIdRad])
    REFERENCES [dbo].[Radniks_Prodavac]
        ([IdRad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdavacRadi'
CREATE INDEX [IX_FK_ProdavacRadi]
ON [dbo].[Radis]
    ([ProdavacIdRad]);
GO

-- Creating foreign key on [IdRad] in table 'Radniks_Obucar'
ALTER TABLE [dbo].[Radniks_Obucar]
ADD CONSTRAINT [FK_Obucar_inherits_Radnik]
    FOREIGN KEY ([IdRad])
    REFERENCES [dbo].[Radniks]
        ([IdRad])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdObj], [IndustrijaObuceIdIO] in table 'Objekats_MagacinMaterijala'
ALTER TABLE [dbo].[Objekats_MagacinMaterijala]
ADD CONSTRAINT [FK_MagacinMaterijala_inherits_Objekat]
    FOREIGN KEY ([IdObj], [IndustrijaObuceIdIO])
    REFERENCES [dbo].[Objekats]
        ([IdObj], [IndustrijaObuceIdIO])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdObj], [IndustrijaObuceIdIO] in table 'Objekats_Prodavnica'
ALTER TABLE [dbo].[Objekats_Prodavnica]
ADD CONSTRAINT [FK_Prodavnica_inherits_Objekat]
    FOREIGN KEY ([IdObj], [IndustrijaObuceIdIO])
    REFERENCES [dbo].[Objekats]
        ([IdObj], [IndustrijaObuceIdIO])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdRad] in table 'Radniks_Prodavac'
ALTER TABLE [dbo].[Radniks_Prodavac]
ADD CONSTRAINT [FK_Prodavac_inherits_Radnik]
    FOREIGN KEY ([IdRad])
    REFERENCES [dbo].[Radniks]
        ([IdRad])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------