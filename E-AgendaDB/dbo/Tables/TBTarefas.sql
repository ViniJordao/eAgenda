CREATE TABLE [dbo].[TBTarefas] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]            VARCHAR (200) NULL,
    [DataCriacao]       DATETIME      NULL,
    [DataFinalizacao]   DATETIME      NULL,
    [Prioridade]        VARCHAR (50)  NULL,
    [PercentualTarefas] VARCHAR (50)  NULL,
    [Percentual]        VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

