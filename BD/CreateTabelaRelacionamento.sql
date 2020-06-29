USE [ValorCafe]
GO

/****** Object:  Table [dbo].[TipoLimite]    Script Date: 13/03/2015 09:40:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Relacionamento](
	[IdRelacionamento] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Finalizado] [bit] NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,	
	[Excluido] [bit] NULL,
 CONSTRAINT [PK_Relacionamento] PRIMARY KEY CLUSTERED 
(
	[IdRelacionamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Relacionamento]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamento_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO

ALTER TABLE [dbo].[Relacionamento] CHECK CONSTRAINT [FK_Relacionamento_Usuario_Criacao]
GO

ALTER TABLE [dbo].[Relacionamento]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamento_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO

ALTER TABLE [dbo].[Relacionamento] CHECK CONSTRAINT [FK_Relacionamento_Usuario_Alteracao]
GO

ALTER TABLE [dbo].[Relacionamento]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamento_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO

ALTER TABLE [dbo].[Relacionamento] CHECK CONSTRAINT [FK_Relacionamento_Usuario_Exclusao]
GO

ALTER TABLE [dbo].[Relacionamento]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamento_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO

ALTER TABLE [dbo].[Relacionamento] CHECK CONSTRAINT [FK_Relacionamento_Cliente]
GO


--Zerar Tabela do Banco
--DBCC CHECKIDENT('[tabela]', RESEED, 0)
