USE [Millenium]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[IdArea] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL CONSTRAINT [DF_Area_Ativo]  DEFAULT ((0)),
	[Excluido] [bit] NULL CONSTRAINT [DF_Area_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[IdArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bairro]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bairro](
	[IdBairro] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL CONSTRAINT [DF_Bairro_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_Bairro] PRIMARY KEY CLUSTERED 
(
	[IdBairro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassificacaoCliente]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassificacaoCliente](
	[IdClassificacaoCliente] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[QuantidadeInicial] [int] NULL,
	[QuantidadeFinal] [int] NULL,
	[DoseTeste] [int] NULL,
 CONSTRAINT [PK_ClassificacaoCliente] PRIMARY KEY CLUSTERED 
(
	[IdClassificacaoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCliente] [varchar](25) NULL,
	[IdTipoCliente] [int] NOT NULL,
	[IdEndereco] [int] NULL,
	[IdClassificacaoCliente] [int] NOT NULL,
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
	[IdDiaVencimento] [int] NOT NULL,
	[PrecoDose] [decimal](5, 2) NOT NULL,
	[QuantidadeCortesia] [int] NULL,
	[MinimoDoses] [int] NULL,
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
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contato]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContatoCliente]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContatoCliente](
	[IdCliente] [int] NULL,
	[IdContato] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dia]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dia](
	[IdDia] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_Dia] PRIMARY KEY CLUSTERED 
(
	[IdDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DiaVencimento]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaVencimento](
	[IdDiaVencimento] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [int] NOT NULL,
 CONSTRAINT [PK_DiaVencimento] PRIMARY KEY CLUSTERED 
(
	[IdDiaVencimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Endereco](
	[IdEndereco] [int] IDENTITY(1,1) NOT NULL,
	[Logradouro] [varchar](500) NULL,
	[Numero] [varchar](20) NULL,
	[Complemento] [varchar](50) NULL,
	[Cep] [varchar](9) NULL,
	[Estado] [varchar](2) NULL,
	[Cidade] [varchar](100) NULL,
	[IdBairro] [int] NULL,
	[DataHoraInicio] [datetime] NULL,
	[DataHoraFim] [datetime] NULL,
	[Instalacao] [bit] NULL,
	[Retirada] [bit] NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[IdEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FaturadoMes]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FaturadoMes](
	[IdCliente] [int] NOT NULL,
	[Mes] [varchar](50) NOT NULL,
	[IdFaturamento] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faturamento]    Script Date: 29/05/2019 00:11:27 ******/
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
/****** Object:  Table [dbo].[Insumo]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Insumo](
	[IdInsumo] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[Preco] [decimal](5, 2) NULL,
	[CodigoCfop] [varchar](6) NULL,
	[CodigoProduto] [varchar](6) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL CONSTRAINT [DF_Insumo_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[IdInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InsumoEndereco]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsumoEndereco](
	[IdEndereco] [int] NULL,
	[IdInsumo] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsumoRelacionamento]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsumoRelacionamento](
	[IdInsumo] [int] NULL,
	[IdRelacionamento] [int] NULL,
	[Quantidade] [int] NULL,
	[Finalizado] [bit] NULL,
	[DataHoraFinalizacao] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InsumoVisita]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsumoVisita](
	[IdInsumo] [int] NOT NULL,
	[IdVisita] [int] NOT NULL,
	[QuantidadeAtual] [int] NOT NULL,
	[Quantidade] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Maquina]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Maquina](
	[IdMaquina] [int] IDENTITY(1,1) NOT NULL,
	[IdEndereco] [int] NULL,
	[IdModelo] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[NumeroSerie] [varchar](50) NULL,
	[NumeroIdentificacao] [varchar](50) NOT NULL,
	[Voltagem] [varchar](50) NOT NULL,
	[Observacao] [varchar](500) NULL,
	[DataAquisicao] [datetime] NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL CONSTRAINT [DF_Maquina_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_Maquina] PRIMARY KEY CLUSTERED 
(
	[IdMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaquinaCliente]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaquinaCliente](
	[IdCliente] [int] NULL,
	[IdMaquina] [int] NULL,
	[IdArea] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaquinaEnderecoHistorico]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaquinaEnderecoHistorico](
	[IdMaquina] [int] NULL,
	[IdEndereco] [int] NULL,
	[IdArea] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuUsuario]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuUsuario](
	[IdMenu] [int] NULL,
	[IdNivel] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meses]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Meses](
	[IdMes] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_Meses] PRIMARY KEY CLUSTERED 
(
	[IdMes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modelo](
	[IdModelo] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL CONSTRAINT [DF_Modelo_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[IdModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nivel]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patrimonio]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patrimonio](
	[IdPatrimonio] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL CONSTRAINT [DF_Patrimonio_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_Patrimonio] PRIMARY KEY CLUSTERED 
(
	[IdPatrimonio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatrimonioCliente]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatrimonioCliente](
	[IdPatrimonio] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Quantidade] [int] NOT NULL,
	[DataHoraCriacao] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PatrimonioRelacionamento]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatrimonioRelacionamento](
	[IdPatrimonio] [int] NULL,
	[IdRelacionamento] [int] NULL,
	[Quantidade] [int] NULL,
	[Finalizado] [bit] NULL,
	[DataHoraFinalizacao] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PatrimonioVisita]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatrimonioVisita](
	[IdPatrimonio] [int] NULL,
	[IdVisita] [int] NULL,
	[Quantidade] [int] NULL,
	[Autorizado] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Relacionamento]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Rota]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rota](
	[IdRota] [int] IDENTITY(1,1) NOT NULL,
	[IdOperador] [int] NULL,
	[Descricao] [varchar](255) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL,
	[Excluido] [bit] NULL CONSTRAINT [DF_Rota_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_Rota] PRIMARY KEY CLUSTERED 
(
	[IdRota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roteirizacao]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roteirizacao](
	[IdRota] [int] NULL,
	[IdEndereco] [int] NULL,
	[IdDia] [int] NULL,
	[Sequencia] [int] NULL,
	[IdArea] [int] NULL,
	[IdCliente] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SituacaoCliente]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatusMaquina]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatusMaquina](
	[IdStatus] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_StatusMaquina] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoCliente]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
	[Ativo] [bit] NULL CONSTRAINT [DF_TipoCliente_Ativo]  DEFAULT ((0)),
	[Excluido] [bit] NULL CONSTRAINT [DF_TipoCliente_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_TipoCliente] PRIMARY KEY CLUSTERED 
(
	[IdTipoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoDose]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDose](
	[IdTipoDose] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[IdUsuarioExclusao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[DataHoraExclusao] [datetime] NULL,
	[Ativo] [bit] NULL CONSTRAINT [DF_TipoDose_Ativo]  DEFAULT ((0)),
	[Excluido] [bit] NULL CONSTRAINT [DF_TipoDose_Excluido]  DEFAULT ((0)),
 CONSTRAINT [PK_TipoDose] PRIMARY KEY CLUSTERED 
(
	[IdTipoDose] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoDoseMaquina]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDoseMaquina](
	[IdTipoDose] [int] NULL,
	[IdMaquina] [int] NULL,
	[Contador] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoDoseModelo]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDoseModelo](
	[IdTipoDose] [int] NULL,
	[IdModelo] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoDoseVisita]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDoseVisita](
	[IdTipoDose] [int] NOT NULL,
	[IdMaquina] [int] NOT NULL,
	[Contador] [int] NULL,
	[IdVisita] [int] NOT NULL,
	[ContadorAntigo] [int] NOT NULL,
	[QuantidadeDoseTeste] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[IdUsuarioCriacao] [int] NOT NULL,
	[DataHoraAlteracao] [datetime] NULL,
	[IdUsuarioAlteracao] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoProblema]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoProblema](
	[IdTipoProblema] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_TipoProblema] PRIMARY KEY CLUSTERED 
(
	[IdTipoProblema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoProblemaRelacionamento]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoProblemaRelacionamento](
	[IdTipoProblema] [int] NULL,
	[IdRelacionamento] [int] NULL,
	[Descricao] [varchar](255) NULL,
	[Finalizado] [bit] NULL,
	[DataHoraFinalizacao] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoProblemaVisita]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoProblemaVisita](
	[IdTipoProblema] [int] NULL,
	[IdVisita] [int] NULL,
	[IdMaquina] [int] NULL,
	[Descricao] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoVisita]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoVisita](
	[IdTipoVisita] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoVisita] PRIMARY KEY CLUSTERED 
(
	[IdTipoVisita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
	[Ativo] [bit] NOT NULL CONSTRAINT [DF_Usuario_Ativo]  DEFAULT ((0)),
	[Excluido] [bit] NOT NULL CONSTRAINT [DF_Usuario_Excluido]  DEFAULT ((0)),
	[DataAdmissao] [datetime] NULL CONSTRAINT [DF_Usuario_DataAdmissao]  DEFAULT (NULL),
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Visita]    Script Date: 29/05/2019 00:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Visita](
	[IdVisita] [int] IDENTITY(1,1) NOT NULL,
	[IdRota] [int] NOT NULL,
	[IdEndereco] [int] NOT NULL,
	[IdDia] [int] NOT NULL,
	[IdArea] [int] NULL,
	[Sequencia] [int] NULL,
	[IdOperador] [int] NULL,
	[IdCliente] [int] NOT NULL,
	[IdMaquina] [int] NOT NULL,
	[Competencia] [varchar](7) NULL,
	[Observacoes] [varchar](500) NULL,
	[IdUsuarioCriacao] [int] NULL,
	[DataHoraCriacao] [datetime] NOT NULL,
	[DataHoraFim] [datetime] NULL,
	[DataHoraLimite] [datetime] NULL,
	[IdOperadorAntigo] [int] NULL,
	[IdTipoVisita] [int] NULL,
	[Finalizada] [bit] NULL,
 CONSTRAINT [PK_Visita] PRIMARY KEY CLUSTERED 
(
	[IdVisita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Ativo]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Excluido]  DEFAULT ((0)) FOR [Excluido]
GO
ALTER TABLE [dbo].[Contato] ADD  CONSTRAINT [DF_Contato_Ativo]  DEFAULT ((0)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Contato] ADD  CONSTRAINT [DF_Contato_Excluido]  DEFAULT ((0)) FOR [Excluido]
GO
ALTER TABLE [dbo].[Relacionamento] ADD  CONSTRAINT [DF_Relacionamento_Excluido]  DEFAULT ((0)) FOR [Excluido]
GO
ALTER TABLE [dbo].[Visita] ADD  CONSTRAINT [DF_Visita_Finalizada]  DEFAULT ((0)) FOR [Finalizada]
GO
ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_Area_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_Area_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_Area_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_Area_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_Area_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_Area_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[Bairro]  WITH CHECK ADD  CONSTRAINT [FK_Bairro_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Bairro] CHECK CONSTRAINT [FK_Bairro_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Bairro]  WITH CHECK ADD  CONSTRAINT [FK_Bairro_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Bairro] CHECK CONSTRAINT [FK_Bairro_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Bairro]  WITH CHECK ADD  CONSTRAINT [FK_Bairro_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Bairro] CHECK CONSTRAINT [FK_Bairro_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_ClassificacaoCliente] FOREIGN KEY([IdClassificacaoCliente])
REFERENCES [dbo].[ClassificacaoCliente] ([IdClassificacaoCliente])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_ClassificacaoCliente]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Cliente]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_DiaVencimento] FOREIGN KEY([IdDiaVencimento])
REFERENCES [dbo].[DiaVencimento] ([IdDiaVencimento])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_DiaVencimento]
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
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Bairro] FOREIGN KEY([IdBairro])
REFERENCES [dbo].[Bairro] ([IdBairro])
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Bairro]
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
ALTER TABLE [dbo].[Insumo]  WITH CHECK ADD  CONSTRAINT [FK_Insumo_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Insumo] CHECK CONSTRAINT [FK_Insumo_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Insumo]  WITH CHECK ADD  CONSTRAINT [FK_Insumo_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Insumo] CHECK CONSTRAINT [FK_Insumo_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Insumo]  WITH CHECK ADD  CONSTRAINT [FK_Insumo_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Insumo] CHECK CONSTRAINT [FK_Insumo_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[InsumoEndereco]  WITH CHECK ADD  CONSTRAINT [FK_InsumoEndereco_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[InsumoEndereco] CHECK CONSTRAINT [FK_InsumoEndereco_Endereco]
GO
ALTER TABLE [dbo].[InsumoEndereco]  WITH CHECK ADD  CONSTRAINT [FK_InsumoEndereco_Insumo] FOREIGN KEY([IdInsumo])
REFERENCES [dbo].[Insumo] ([IdInsumo])
GO
ALTER TABLE [dbo].[InsumoEndereco] CHECK CONSTRAINT [FK_InsumoEndereco_Insumo]
GO
ALTER TABLE [dbo].[InsumoRelacionamento]  WITH CHECK ADD  CONSTRAINT [FK_InsumoRelacionamento_Insumo] FOREIGN KEY([IdInsumo])
REFERENCES [dbo].[Insumo] ([IdInsumo])
GO
ALTER TABLE [dbo].[InsumoRelacionamento] CHECK CONSTRAINT [FK_InsumoRelacionamento_Insumo]
GO
ALTER TABLE [dbo].[InsumoRelacionamento]  WITH CHECK ADD  CONSTRAINT [FK_InsumoRelacionamento_Relacionamento] FOREIGN KEY([IdRelacionamento])
REFERENCES [dbo].[Relacionamento] ([IdRelacionamento])
GO
ALTER TABLE [dbo].[InsumoRelacionamento] CHECK CONSTRAINT [FK_InsumoRelacionamento_Relacionamento]
GO
ALTER TABLE [dbo].[InsumoVisita]  WITH CHECK ADD  CONSTRAINT [FK_InsumoVisita_Insumo] FOREIGN KEY([IdInsumo])
REFERENCES [dbo].[Insumo] ([IdInsumo])
GO
ALTER TABLE [dbo].[InsumoVisita] CHECK CONSTRAINT [FK_InsumoVisita_Insumo]
GO
ALTER TABLE [dbo].[InsumoVisita]  WITH CHECK ADD  CONSTRAINT [FK_InsumoVisita_Visita] FOREIGN KEY([IdVisita])
REFERENCES [dbo].[Visita] ([IdVisita])
GO
ALTER TABLE [dbo].[InsumoVisita] CHECK CONSTRAINT [FK_InsumoVisita_Visita]
GO
ALTER TABLE [dbo].[Maquina]  WITH CHECK ADD  CONSTRAINT [FK_Maquina_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[Maquina] CHECK CONSTRAINT [FK_Maquina_Endereco]
GO
ALTER TABLE [dbo].[Maquina]  WITH CHECK ADD  CONSTRAINT [FK_Maquina_Modelo] FOREIGN KEY([IdModelo])
REFERENCES [dbo].[Modelo] ([IdModelo])
GO
ALTER TABLE [dbo].[Maquina] CHECK CONSTRAINT [FK_Maquina_Modelo]
GO
ALTER TABLE [dbo].[Maquina]  WITH CHECK ADD  CONSTRAINT [FK_Maquina_StatusMaquina] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[StatusMaquina] ([IdStatus])
GO
ALTER TABLE [dbo].[Maquina] CHECK CONSTRAINT [FK_Maquina_StatusMaquina]
GO
ALTER TABLE [dbo].[Maquina]  WITH CHECK ADD  CONSTRAINT [FK_Maquina_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Maquina] CHECK CONSTRAINT [FK_Maquina_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Maquina]  WITH CHECK ADD  CONSTRAINT [FK_Maquina_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Maquina] CHECK CONSTRAINT [FK_Maquina_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Maquina]  WITH CHECK ADD  CONSTRAINT [FK_Maquina_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Maquina] CHECK CONSTRAINT [FK_Maquina_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[MaquinaCliente]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaCliente_Area] FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([IdArea])
GO
ALTER TABLE [dbo].[MaquinaCliente] CHECK CONSTRAINT [FK_MaquinaCliente_Area]
GO
ALTER TABLE [dbo].[MaquinaCliente]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaCliente_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[MaquinaCliente] CHECK CONSTRAINT [FK_MaquinaCliente_Cliente]
GO
ALTER TABLE [dbo].[MaquinaCliente]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaCliente_Maquina] FOREIGN KEY([IdMaquina])
REFERENCES [dbo].[Maquina] ([IdMaquina])
GO
ALTER TABLE [dbo].[MaquinaCliente] CHECK CONSTRAINT [FK_MaquinaCliente_Maquina]
GO
ALTER TABLE [dbo].[MaquinaEnderecoHistorico]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaEnderecoHistorico_Area] FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([IdArea])
GO
ALTER TABLE [dbo].[MaquinaEnderecoHistorico] CHECK CONSTRAINT [FK_MaquinaEnderecoHistorico_Area]
GO
ALTER TABLE [dbo].[MaquinaEnderecoHistorico]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaEnderecoHistorico_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[MaquinaEnderecoHistorico] CHECK CONSTRAINT [FK_MaquinaEnderecoHistorico_Endereco]
GO
ALTER TABLE [dbo].[MaquinaEnderecoHistorico]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaEnderecoHistorico_Maquina] FOREIGN KEY([IdMaquina])
REFERENCES [dbo].[Maquina] ([IdMaquina])
GO
ALTER TABLE [dbo].[MaquinaEnderecoHistorico] CHECK CONSTRAINT [FK_MaquinaEnderecoHistorico_Maquina]
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Modelo] CHECK CONSTRAINT [FK_Modelo_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Modelo] CHECK CONSTRAINT [FK_Modelo_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Modelo] CHECK CONSTRAINT [FK_Modelo_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[Patrimonio]  WITH CHECK ADD  CONSTRAINT [FK_Patrimonio_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Patrimonio] CHECK CONSTRAINT [FK_Patrimonio_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Patrimonio]  WITH CHECK ADD  CONSTRAINT [FK_Patrimonio_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Patrimonio] CHECK CONSTRAINT [FK_Patrimonio_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Patrimonio]  WITH CHECK ADD  CONSTRAINT [FK_Patrimonio_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Patrimonio] CHECK CONSTRAINT [FK_Patrimonio_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[PatrimonioCliente]  WITH CHECK ADD  CONSTRAINT [FK_PatrimonioCliente_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[PatrimonioCliente] CHECK CONSTRAINT [FK_PatrimonioCliente_Cliente]
GO
ALTER TABLE [dbo].[PatrimonioCliente]  WITH CHECK ADD  CONSTRAINT [FK_PatrimonioCliente_Patrimonio] FOREIGN KEY([IdPatrimonio])
REFERENCES [dbo].[Patrimonio] ([IdPatrimonio])
GO
ALTER TABLE [dbo].[PatrimonioCliente] CHECK CONSTRAINT [FK_PatrimonioCliente_Patrimonio]
GO
ALTER TABLE [dbo].[PatrimonioRelacionamento]  WITH CHECK ADD  CONSTRAINT [FK_PatrimonioRelacionamento_Patrimonio] FOREIGN KEY([IdPatrimonio])
REFERENCES [dbo].[Patrimonio] ([IdPatrimonio])
GO
ALTER TABLE [dbo].[PatrimonioRelacionamento] CHECK CONSTRAINT [FK_PatrimonioRelacionamento_Patrimonio]
GO
ALTER TABLE [dbo].[PatrimonioRelacionamento]  WITH CHECK ADD  CONSTRAINT [FK_PatrimonioRelacionamento_Relacionamento] FOREIGN KEY([IdRelacionamento])
REFERENCES [dbo].[Relacionamento] ([IdRelacionamento])
GO
ALTER TABLE [dbo].[PatrimonioRelacionamento] CHECK CONSTRAINT [FK_PatrimonioRelacionamento_Relacionamento]
GO
ALTER TABLE [dbo].[PatrimonioVisita]  WITH CHECK ADD  CONSTRAINT [FK_PatrimonioVisita_Patrimonio] FOREIGN KEY([IdPatrimonio])
REFERENCES [dbo].[Patrimonio] ([IdPatrimonio])
GO
ALTER TABLE [dbo].[PatrimonioVisita] CHECK CONSTRAINT [FK_PatrimonioVisita_Patrimonio]
GO
ALTER TABLE [dbo].[PatrimonioVisita]  WITH CHECK ADD  CONSTRAINT [FK_PatrimonioVisita_Visita] FOREIGN KEY([IdVisita])
REFERENCES [dbo].[Visita] ([IdVisita])
GO
ALTER TABLE [dbo].[PatrimonioVisita] CHECK CONSTRAINT [FK_PatrimonioVisita_Visita]
GO
ALTER TABLE [dbo].[Relacionamento]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamento_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Relacionamento] CHECK CONSTRAINT [FK_Relacionamento_Cliente]
GO
ALTER TABLE [dbo].[Relacionamento]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamento_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Relacionamento] CHECK CONSTRAINT [FK_Relacionamento_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Relacionamento]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamento_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Relacionamento] CHECK CONSTRAINT [FK_Relacionamento_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Relacionamento]  WITH CHECK ADD  CONSTRAINT [FK_Relacionamento_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Relacionamento] CHECK CONSTRAINT [FK_Relacionamento_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[Rota]  WITH CHECK ADD  CONSTRAINT [FK_Rota_Usuario] FOREIGN KEY([IdOperador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Rota] CHECK CONSTRAINT [FK_Rota_Usuario]
GO
ALTER TABLE [dbo].[Rota]  WITH CHECK ADD  CONSTRAINT [FK_Rota_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Rota] CHECK CONSTRAINT [FK_Rota_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[Rota]  WITH CHECK ADD  CONSTRAINT [FK_Rota_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Rota] CHECK CONSTRAINT [FK_Rota_Usuario_Criacao]
GO
ALTER TABLE [dbo].[Rota]  WITH CHECK ADD  CONSTRAINT [FK_Rota_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Rota] CHECK CONSTRAINT [FK_Rota_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[Roteirizacao]  WITH CHECK ADD  CONSTRAINT [FK_Roteirizacao_Area] FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([IdArea])
GO
ALTER TABLE [dbo].[Roteirizacao] CHECK CONSTRAINT [FK_Roteirizacao_Area]
GO
ALTER TABLE [dbo].[Roteirizacao]  WITH CHECK ADD  CONSTRAINT [FK_Roteirizacao_Dia] FOREIGN KEY([IdDia])
REFERENCES [dbo].[Dia] ([IdDia])
GO
ALTER TABLE [dbo].[Roteirizacao] CHECK CONSTRAINT [FK_Roteirizacao_Dia]
GO
ALTER TABLE [dbo].[Roteirizacao]  WITH CHECK ADD  CONSTRAINT [FK_Roteirizacao_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[Roteirizacao] CHECK CONSTRAINT [FK_Roteirizacao_Endereco]
GO
ALTER TABLE [dbo].[Roteirizacao]  WITH CHECK ADD  CONSTRAINT [FK_Roteirizacao_Rota] FOREIGN KEY([IdRota])
REFERENCES [dbo].[Rota] ([IdRota])
GO
ALTER TABLE [dbo].[Roteirizacao] CHECK CONSTRAINT [FK_Roteirizacao_Rota]
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
ALTER TABLE [dbo].[TipoDose]  WITH CHECK ADD  CONSTRAINT [FK_TipoDose_Usuario_Alteracao] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoDose] CHECK CONSTRAINT [FK_TipoDose_Usuario_Alteracao]
GO
ALTER TABLE [dbo].[TipoDose]  WITH CHECK ADD  CONSTRAINT [FK_TipoDose_Usuario_Criacao] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoDose] CHECK CONSTRAINT [FK_TipoDose_Usuario_Criacao]
GO
ALTER TABLE [dbo].[TipoDose]  WITH CHECK ADD  CONSTRAINT [FK_TipoDose_Usuario_Exclusao] FOREIGN KEY([IdUsuarioExclusao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoDose] CHECK CONSTRAINT [FK_TipoDose_Usuario_Exclusao]
GO
ALTER TABLE [dbo].[TipoDoseMaquina]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseMaquina_Maquina] FOREIGN KEY([IdMaquina])
REFERENCES [dbo].[Maquina] ([IdMaquina])
GO
ALTER TABLE [dbo].[TipoDoseMaquina] CHECK CONSTRAINT [FK_TipoDoseMaquina_Maquina]
GO
ALTER TABLE [dbo].[TipoDoseMaquina]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseMaquina_TipoDose] FOREIGN KEY([IdTipoDose])
REFERENCES [dbo].[TipoDose] ([IdTipoDose])
GO
ALTER TABLE [dbo].[TipoDoseMaquina] CHECK CONSTRAINT [FK_TipoDoseMaquina_TipoDose]
GO
ALTER TABLE [dbo].[TipoDoseModelo]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseModelo_Modelo] FOREIGN KEY([IdModelo])
REFERENCES [dbo].[Modelo] ([IdModelo])
GO
ALTER TABLE [dbo].[TipoDoseModelo] CHECK CONSTRAINT [FK_TipoDoseModelo_Modelo]
GO
ALTER TABLE [dbo].[TipoDoseModelo]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseModelo_TipoDose] FOREIGN KEY([IdTipoDose])
REFERENCES [dbo].[TipoDose] ([IdTipoDose])
GO
ALTER TABLE [dbo].[TipoDoseModelo] CHECK CONSTRAINT [FK_TipoDoseModelo_TipoDose]
GO
ALTER TABLE [dbo].[TipoDoseVisita]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseMaquinaVisita_Maquina] FOREIGN KEY([IdMaquina])
REFERENCES [dbo].[Maquina] ([IdMaquina])
GO
ALTER TABLE [dbo].[TipoDoseVisita] CHECK CONSTRAINT [FK_TipoDoseMaquinaVisita_Maquina]
GO
ALTER TABLE [dbo].[TipoDoseVisita]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseMaquinaVisita_TipoDose] FOREIGN KEY([IdTipoDose])
REFERENCES [dbo].[TipoDose] ([IdTipoDose])
GO
ALTER TABLE [dbo].[TipoDoseVisita] CHECK CONSTRAINT [FK_TipoDoseMaquinaVisita_TipoDose]
GO
ALTER TABLE [dbo].[TipoDoseVisita]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseMaquinaVisita_Visita] FOREIGN KEY([IdVisita])
REFERENCES [dbo].[Visita] ([IdVisita])
GO
ALTER TABLE [dbo].[TipoDoseVisita] CHECK CONSTRAINT [FK_TipoDoseMaquinaVisita_Visita]
GO
ALTER TABLE [dbo].[TipoDoseVisita]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseVisita_Usuario] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoDoseVisita] CHECK CONSTRAINT [FK_TipoDoseVisita_Usuario]
GO
ALTER TABLE [dbo].[TipoDoseVisita]  WITH CHECK ADD  CONSTRAINT [FK_TipoDoseVisita_Usuario1] FOREIGN KEY([IdUsuarioAlteracao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TipoDoseVisita] CHECK CONSTRAINT [FK_TipoDoseVisita_Usuario1]
GO
ALTER TABLE [dbo].[TipoProblemaRelacionamento]  WITH CHECK ADD  CONSTRAINT [FK_TipoProblemaRelacionamento_Relacionamento] FOREIGN KEY([IdRelacionamento])
REFERENCES [dbo].[Relacionamento] ([IdRelacionamento])
GO
ALTER TABLE [dbo].[TipoProblemaRelacionamento] CHECK CONSTRAINT [FK_TipoProblemaRelacionamento_Relacionamento]
GO
ALTER TABLE [dbo].[TipoProblemaRelacionamento]  WITH CHECK ADD  CONSTRAINT [FK_TipoProblemaRelacionamento_TipoProblema] FOREIGN KEY([IdTipoProblema])
REFERENCES [dbo].[TipoProblema] ([IdTipoProblema])
GO
ALTER TABLE [dbo].[TipoProblemaRelacionamento] CHECK CONSTRAINT [FK_TipoProblemaRelacionamento_TipoProblema]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Nivel] FOREIGN KEY([IdNivel])
REFERENCES [dbo].[Nivel] ([IdNivel])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Nivel]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Area] FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([IdArea])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Area]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Cliente]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Dia] FOREIGN KEY([IdDia])
REFERENCES [dbo].[Dia] ([IdDia])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Dia]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Endereco]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Maquina] FOREIGN KEY([IdMaquina])
REFERENCES [dbo].[Maquina] ([IdMaquina])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Maquina]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Rota] FOREIGN KEY([IdRota])
REFERENCES [dbo].[Rota] ([IdRota])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Rota]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_TipoVisita] FOREIGN KEY([IdTipoVisita])
REFERENCES [dbo].[TipoVisita] ([IdTipoVisita])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_TipoVisita]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Usuario] FOREIGN KEY([IdOperador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Usuario]
GO
ALTER TABLE [dbo].[Visita]  WITH CHECK ADD  CONSTRAINT [FK_Visita_Usuario1] FOREIGN KEY([IdUsuarioCriacao])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Visita] CHECK CONSTRAINT [FK_Visita_Usuario1]
GO
