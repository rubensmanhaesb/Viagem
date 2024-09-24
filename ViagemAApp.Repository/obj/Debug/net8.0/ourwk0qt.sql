IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_COMPANIA_AEREA] (
    [Id] uniqueidentifier NOT NULL,
    [nm_compania_aerea] nvarchar(150) NOT NULL,
    CONSTRAINT [PK_TB_COMPANIA_AEREA] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_PROGRAMA_FIDELIDADE] (
    [Id] uniqueidentifier NOT NULL,
    [nm_programa_fidelidade] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_TB_PROGRAMA_FIDELIDADE] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_PARCERIA_FIDELIDADE] (
    [IdCompaniaAeria] uniqueidentifier NOT NULL,
    [IdProgramaFidelidade] uniqueidentifier NOT NULL,
    [qtd_cpfs] int NULL,
    CONSTRAINT [PK_TB_PARCERIA_FIDELIDADE] PRIMARY KEY ([IdCompaniaAeria], [IdProgramaFidelidade]),
    CONSTRAINT [FK_TB_PARCERIA_FIDELIDADE_TB_COMPANIA_AEREA_IdCompaniaAeria] FOREIGN KEY ([IdCompaniaAeria]) REFERENCES [TB_COMPANIA_AEREA] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TB_PARCERIA_FIDELIDADE_TB_PROGRAMA_FIDELIDADE_IdProgramaFidelidade] FOREIGN KEY ([IdProgramaFidelidade]) REFERENCES [TB_PROGRAMA_FIDELIDADE] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_TB_PARCERIA_FIDELIDADE_IdProgramaFidelidade] ON [TB_PARCERIA_FIDELIDADE] ([IdProgramaFidelidade]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240918185910_Initial', N'8.0.8');
GO

COMMIT;
GO

