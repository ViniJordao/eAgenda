CREATE TABLE [dbo].[TBTarefas] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]        VARCHAR (100) NULL,
    [DataCriacao]   DATETIME      NULL,
    [DataConclusao] DATETIME      NULL,
    [Prioridade]    VARCHAR (30)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

