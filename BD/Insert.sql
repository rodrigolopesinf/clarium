USE [Millenium]
GO
SET IDENTITY_INSERT [dbo].[Nivel] ON 

INSERT [dbo].[Nivel] ([IdNivel], [Descricao]) VALUES (1, N'SUPER ADMINISTRADOR')
INSERT [dbo].[Nivel] ([IdNivel], [Descricao]) VALUES (2, N'GESTOR')
INSERT [dbo].[Nivel] ([IdNivel], [Descricao]) VALUES (3, N'OPERADOR')
SET IDENTITY_INSERT [dbo].[Nivel] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [IdNivel], [Nome], [Apelido], [Celular], [Email], [Login], [Senha], [ValidadeSenha], [Ativo], [Excluido], [DataAdmissao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao]) VALUES (1, 1, N'RODRIGO LOPES SILVA', N'LOPES', N'(21) 99999-9999', N'rodrigolopes2@hotmail.com', N'ADMIN', N'wKLD58/V2UE=', NULL, 1, 0, CAST(N'2015-01-01T00:00:00.000' AS DateTime), CAST(N'2015-06-20T17:00:00.547' AS DateTime), CAST(N'2015-07-30T01:16:32.103' AS DateTime), NULL, 1, 1, NULL)
INSERT [dbo].[Usuario] ([IdUsuario], [IdNivel], [Nome], [Apelido], [Celular], [Email], [Login], [Senha], [ValidadeSenha], [Ativo], [Excluido], [DataAdmissao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao]) VALUES (2, 3, N'FABIO DA PAZ', N'FABIO', N'(21) 99922-9229', N'fabio.hiluey@r7h.com.br', N'fabio', N'wKLD58/V2UE=', NULL, 1, 0, CAST(N'2015-01-01T00:00:00.000' AS DateTime), CAST(N'2015-07-23T10:43:03.050' AS DateTime), CAST(N'2015-09-07T18:23:06.600' AS DateTime), NULL, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[SituacaoCliente] ON 

INSERT [dbo].[SituacaoCliente] ([IdSituacaoCliente], [Descricao]) VALUES (1, N'ADIMPLENTE')
INSERT [dbo].[SituacaoCliente] ([IdSituacaoCliente], [Descricao]) VALUES (2, N'INADIMPLENTE')
SET IDENTITY_INSERT [dbo].[SituacaoCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCliente] ON 

INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (1, N'RESTAURANTE', 1, NULL, NULL, CAST(N'2015-06-25T09:02:50.330' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (2, N'ESCRITÓRIO', 1, NULL, NULL, CAST(N'2015-06-25T09:03:08.607' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (3, N'LOJA', 1, NULL, NULL, CAST(N'2015-06-25T09:03:20.213' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (4, N'BAR E LANCHONETE', 1, NULL, NULL, CAST(N'2015-06-25T09:03:37.093' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (5, N'PADARIA', 1, NULL, NULL, CAST(N'2015-06-25T09:03:48.720' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (6, N'CLINICA MÉDICA E ESTÉTICA', 1, NULL, NULL, CAST(N'2015-06-25T09:04:14.093' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (7, N'OUTROS', 1, NULL, NULL, CAST(N'2015-06-25T09:04:31.930' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (8, N'FACULDADES, ESCOLAS E CURSOS', 1, NULL, NULL, CAST(N'2015-06-25T09:04:53.157' AS DateTime), NULL, NULL, 1, 0)
INSERT [dbo].[TipoCliente] ([IdTipoCliente], [Descricao], [IdUsuarioCriacao], [IdUsuarioAlteracao], [IdUsuarioExclusao], [DataHoraCriacao], [DataHoraAlteracao], [DataHoraExclusao], [Ativo], [Excluido]) VALUES (9, N'EVENTO', 1, NULL, NULL, CAST(N'2015-06-25T09:05:08.470' AS DateTime), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[TipoCliente] OFF
GO
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (1, 1, N'ADMINISTRAÇÃO', N'Home', 0, N'~/Administrativa/Home', N'Administrativa_menu', N'Index')
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (2, 2, N'CADASTRO', N'Cadastro', 0, NULL, NULL, NULL)
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (3, 3, N'USUÁRIO', N'Usuario', 2, N'~/Cadastro/Usuario', N'Cadastro_menu', N'Index')
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (8, 4, N'TIPO DE CLIENTE', N'TipoCliente', 2, N'~/Cadastro/TipoCliente', N'Cadastro_menu', N'Index')
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (9, 6, N'CLIENTE', N'Cliente', 2, N'~/Cadastro/Cliente', N'Cadastro_menu', N'Index')
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (10, 5, N'TIPO DE SOLICITAÇÃO', N'TipoSolicitacao', 2, N'~/Cadastro/TipoSolicitacao', N'Cadastro_menu', N'Index')
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (200, 200, N'SOLICITAÇÕES', N'Solicitacao', 0, NULL, NULL, NULL)
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (201, 201, N'PESQUISAR', N'Pesquisa', 200, N'~/Solicitacao/Pesquisa', N'Solicitacao_menu', N'Index')
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (400, 400, N'FATURAMENTO', N'Faturamento', 0, NULL, NULL, NULL)
INSERT [dbo].[Menu] ([IdMenu], [SecMenu], [Descricao], [Controller], [MenuPaiId], [Url], [Route], [Action]) VALUES (401, 401, N'GERAR FATURAMENTO', N'Gerar', 400, N'~/Faturamento/Gerar', N'Faturamento_menu', N'Index')
GO
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (1, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (2, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (3, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (4, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (5, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (6, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (7, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (8, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (9, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (100, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (101, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (102, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (103, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (200, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (201, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (300, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (301, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (302, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (1, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (2, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (3, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (4, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (5, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (6, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (7, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (8, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (9, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (100, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (101, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (102, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (103, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (200, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (201, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (300, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (301, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (302, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (10, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (201, 3)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (200, 3)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (303, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (303, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (400, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (401, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (202, 1)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (202, 2)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (300, 3)
INSERT [dbo].[MenuUsuario] ([IdMenu], [IdNivel]) VALUES (301, 3)
GO
