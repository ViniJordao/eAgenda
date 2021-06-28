CREATE TABLE [dbo].[TBAgenda] (
    [Id]       INT          NOT NULL,
    [nome]     VARCHAR (30) NULL,
    [email]    VARCHAR (30) NULL,
    [telefone] VARCHAR (10) NULL,
    [empresa]  NCHAR (30)   NULL,
    [cargo]    NCHAR (30)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

