CREATE TABLE [dbo].[TBCompromisso] (
    [Id]              INT          NOT NULL,
    [Assunto]         VARCHAR (50) NULL,
    [Local]           VARCHAR (50) NULL,
    [DataCompromisso] DATETIME     NULL,
    [HoraInicio]      DATETIME     NULL,
    [HoraTermino]     DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);