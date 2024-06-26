USE [Millenium]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCliente] [varchar](25) NULL,
	[IdTipoCliente] [int] NOT NULL,
	[IdEndereco] [int] NULL,
	[NomeFantasia] [varchar](255) NULL,
	[RazaoSocial] [varchar](255) NULL,
	[Nome] [varchar](50) NULL,
	[Cpf] [varchar](15) NULL,
	[Cnpj] [varchar](18) NULL,
	[TelefonePrincipal] [varchar](15) NOT NULL,
	[RamalPrincipal] [varchar](5) NULL,
	[TelefoneSecundario] [varchar](15) NULL,
	[RamalSecundario] [varchar](5) NULL,
	[EmailPrincipal] [varchar](255) NOT NULL,
	[EmailSecundario] [varchar](255) NULL,
	[Site] [varchar](max) NULL,
	[FaturaEmail] [bit] NOT NULL,
	[IdSituacaoCliente] [int] NOT NULL,
	[Observacao] [varchar](1000) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL,
	[DiaVencimento] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contato]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contato](
	[IdContato] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Celular] [varchar](16) NOT NULL,
	[CelularSecundario] [varchar](16) NULL,
	[Email] [varchar](255) NOT NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL,
 CONSTRAINT [PK_Contato] PRIMARY KEY CLUSTERED 
(
	[IdContato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContatoCliente]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContatoCliente](
	[IdCliente] [int] NULL,
	[IdContato] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[IdEndereco] [int] IDENTITY(1,1) NOT NULL,
	[Logradouro] [varchar](500) NULL,
	[Numero] [varchar](20) NULL,
	[Complemento] [varchar](50) NULL,
	[Cep] [varchar](9) NULL,
	[Estado] [varchar](2) NULL,
	[Cidade] [varchar](100) NULL,
	[Bairro] [varchar](100) NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[IdEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FaturadoMes]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaturadoMes](
	[IdCliente] [int] NOT NULL,
	[Mes] [varchar](50) NOT NULL,
	[IdFaturamento] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faturamento]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faturamento](
	[IdFaturamento] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[QuantidadeDosesSimples] [int] NOT NULL,
	[QuantidadeDosesDuplas] [int] NOT NULL,
	[QuantidadeDosesTeste] [int] NOT NULL,
	[QuantidadeDosesCortesia] [int] NOT NULL,
	[Preco] [decimal](7, 2) NOT NULL,
	[Total] [decimal](7, 2) NOT NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Excluido] [bit] NULL,
 CONSTRAINT [PK_Faturamento] PRIMARY KEY CLUSTERED 
(
	[IdFaturamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[IdMenu] [int] NOT NULL,
	[SecMenu] [int] NULL,
	[Descricao] [varchar](50) NOT NULL,
	[Controller] [varchar](50) NULL,
	[MenuPaiId] [int] NULL,
	[Url] [varchar](255) NULL,
	[Route] [varchar](50) NULL,
	[Action] [varchar](50) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[IdMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuUsuario]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuUsuario](
	[IdMenu] [int] NULL,
	[IdNivel] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nivel]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nivel](
	[IdNivel] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_NivelAcesso] PRIMARY KEY CLUSTERED 
(
	[IdNivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SituacaoCliente]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SituacaoCliente](
	[IdSituacaoCliente] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_SituacaoCliente] PRIMARY KEY CLUSTERED 
(
	[IdSituacaoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitacao]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitacao](
	[IdSolicitacao] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Excluido] [bit] NULL,
	[Nome] [varchar](50) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Cpf] [varchar](15) NOT NULL,
	[Rg] [varchar](10) NOT NULL,
	[NomePai] [varchar](50) NOT NULL,
	[NomeMae] [varchar](50) NOT NULL,
	[IdTipoSolicitacao] [int] NOT NULL,
	[IdEndereco] [int] NULL,
 CONSTRAINT [PK_Solicitacao] PRIMARY KEY CLUSTERED 
(
	[IdSolicitacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCliente]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCliente](
	[IdTipoCliente] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL,
 CONSTRAINT [PK_TipoCliente] PRIMARY KEY CLUSTERED 
(
	[IdTipoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoSolicitacao]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoSolicitacao](
	[IdTipoSolicitacao] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL,
 CONSTRAINT [PK_TipoSolicitacao] PRIMARY KEY CLUSTERED 
(
	[IdTipoSolicitacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 31/01/2022 18:52:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdNivel] [int] NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Apelido] [varchar](50) NULL,
	[Celular] [varchar](15) NULL,
	[Email] [varchar](255) NULL,
	[Login] [varchar](50) NOT NULL,
	[Senha] [varchar](max) NOT NULL,
	[ValidadeSenha] [datetime] NULL,
	[Ativo] [bit] NOT NULL,
	[Excluido] [bit] NOT NULL,
	[DataAdmissao] [datetime] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Ativo]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Excluido]  DEFAULT ((0)) FOR [Excluido]
GO
ALTER TABLE [dbo].[Contato] ADD  CONSTRAINT [DF_Contato_Ativo]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Contato] ADD  CONSTRAINT [DF_Contato_Excluido]  DEFAULT ((0)) FOR [Excluido]
GO
ALTER TABLE [dbo].[TipoCliente] ADD  CONSTRAINT [DF_TipoCliente_Ativo]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [dbo].[TipoCliente] ADD  CONSTRAINT [DF_TipoCliente_Excluido]  DEFAULT ((0)) FOR [Excluido]
GO
ALTER TABLE [dbo].[TipoSolicitacao] ADD  CONSTRAINT [DF_TipoSolicitacao_Ativo]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [dbo].[TipoSolicitacao] ADD  CONSTRAINT [DF_TipoSolicitacao_Excluido]  DEFAULT ((0)) FOR [Excluido]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Ativo]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Excluido]  DEFAULT ((0)) FOR [Excluido]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_DataAdmissao]  DEFAULT (NULL) FOR [DataAdmissao]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Cliente]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Endereco]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_SituacaoCliente] FOREIGN KEY([IdSituacaoCliente])
REFERENCES [dbo].[SituacaoCliente] ([IdSituacaoCliente])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_SituacaoCliente]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_TipoCliente] FOREIGN KEY([IdTipoCliente])
REFERENCES [dbo].[TipoCliente] ([IdTipoCliente])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_TipoCliente]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Contato_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Contato_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Contato_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[ContatoCliente]  WITH CHECK ADD  CONSTRAINT [FK_ContatoCliente_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[ContatoCliente] CHECK CONSTRAINT [FK_ContatoCliente_Cliente]
GO
ALTER TABLE [dbo].[ContatoCliente]  WITH CHECK ADD  CONSTRAINT [FK_ContatoCliente_Contato] FOREIGN KEY([IdContato])
REFERENCES [dbo].[Contato] ([IdContato])
GO
ALTER TABLE [dbo].[ContatoCliente] CHECK CONSTRAINT [FK_ContatoCliente_Contato]
GO
ALTER TABLE [dbo].[FaturadoMes]  WITH CHECK ADD  CONSTRAINT [FK_FaturadoMes_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[FaturadoMes] CHECK CONSTRAINT [FK_FaturadoMes_Cliente]
GO
ALTER TABLE [dbo].[FaturadoMes]  WITH CHECK ADD  CONSTRAINT [FK_FaturadoMes_Faturamento] FOREIGN KEY([IdFaturamento])
REFERENCES [dbo].[Faturamento] ([IdFaturamento])
GO
ALTER TABLE [dbo].[FaturadoMes] CHECK CONSTRAINT [FK_FaturadoMes_Faturamento]
GO
ALTER TABLE [dbo].[Faturamento]  WITH CHECK ADD  CONSTRAINT [FK_Faturamento_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Faturamento] CHECK CONSTRAINT [FK_Faturamento_Cliente]
GO
ALTER TABLE [dbo].[Faturamento]  WITH CHECK ADD  CONSTRAINT [FK_Faturamento_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Faturamento] CHECK CONSTRAINT [FK_Faturamento_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Faturamento]  WITH CHECK ADD  CONSTRAINT [FK_Faturamento_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Faturamento] CHECK CONSTRAINT [FK_Faturamento_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[Faturamento]  WITH CHECK ADD  CONSTRAINT [FK_Faturamento_Usuario-Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Faturamento] CHECK CONSTRAINT [FK_Faturamento_Usuario-Alteracao]
GO
ALTER TABLE [dbo].[Solicitacao]  WITH CHECK ADD  CONSTRAINT [FK_Solicitacao_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Solicitacao] CHECK CONSTRAINT [FK_Solicitacao_Cliente]
GO
ALTER TABLE [dbo].[Solicitacao]  WITH CHECK ADD  CONSTRAINT [FK_Solicitacao_TipoSolicitacao] FOREIGN KEY([IdTipoSolicitacao])
REFERENCES [dbo].[TipoSolicitacao] ([IdTipoSolicitacao])
GO
ALTER TABLE [dbo].[Solicitacao] CHECK CONSTRAINT [FK_Solicitacao_TipoSolicitacao]
GO
ALTER TABLE [dbo].[Solicitacao]  WITH CHECK ADD  CONSTRAINT [FK_Solicitacao_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Solicitacao] CHECK CONSTRAINT [FK_Solicitacao_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Solicitacao]  WITH CHECK ADD  CONSTRAINT [FK_Solicitacao_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Solicitacao] CHECK CONSTRAINT [FK_Solicitacao_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Solicitacao]  WITH CHECK ADD  CONSTRAINT [FK_Solicitacao_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Solicitacao] CHECK CONSTRAINT [FK_Solicitacao_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[TipoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TipoCliente_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoCliente] CHECK CONSTRAINT [FK_TipoCliente_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[TipoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TipoCliente_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoCliente] CHECK CONSTRAINT [FK_TipoCliente_Usuario_Criacao]
GO
ALTER TABLE [dbo].[TipoCliente]  WITH CHECK ADD  CONSTRAINT [FK_TipoCliente_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoCliente] CHECK CONSTRAINT [FK_TipoCliente_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[TipoSolicitacao]  WITH CHECK ADD  CONSTRAINT [FK_TipoSolicitacao_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoSolicitacao] CHECK CONSTRAINT [FK_TipoSolicitacao_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[TipoSolicitacao]  WITH CHECK ADD  CONSTRAINT [FK_TipoSolicitacao_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoSolicitacao] CHECK CONSTRAINT [FK_TipoSolicitacao_Usuario_Criacao]
GO
ALTER TABLE [dbo].[TipoSolicitacao]  WITH CHECK ADD  CONSTRAINT [FK_TipoSolicitacao_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoSolicitacao] CHECK CONSTRAINT [FK_TipoSolicitacao_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Nivel] FOREIGN KEY([IdNivel])
REFERENCES [dbo].[Nivel] ([IdNivel])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Nivel]
GO
