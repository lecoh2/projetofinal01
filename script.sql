USE [BDUSUARIOAPI]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 09/05/2024 11:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONTATO]    Script Date: 09/05/2024 11:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTATO](
	[ID] [uniqueidentifier] NOT NULL,
	[NOME] [nvarchar](100) NOT NULL,
	[EMAIL] [nvarchar](50) NOT NULL,
	[TELEFONE] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_CONTATO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 09/05/2024 11:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[ID] [uniqueidentifier] NOT NULL,
	[NOME] [nvarchar](100) NOT NULL,
	[EMAIL] [nvarchar](50) NOT NULL,
	[SENHA] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240509123733_Initial', N'8.0.3')
GO
INSERT [dbo].[CONTATO] ([ID], [NOME], [EMAIL], [TELEFONE]) VALUES (N'4d73c7cc-660d-41fb-8846-0a44d91ae930', N'Renato Costa silva2', N'lecoh2@hotmail.com', N'21964700780')
INSERT [dbo].[CONTATO] ([ID], [NOME], [EMAIL], [TELEFONE]) VALUES (N'6f9f910b-6ccd-4f41-a58a-8553ec68a1cf', N'Roberto Alves', N'ro@gmail.com', N'252525555')
GO
INSERT [dbo].[USUARIO] ([ID], [NOME], [EMAIL], [SENHA]) VALUES (N'80eafeed-341f-41a2-acce-683c9b19e7f9', N'Alex Sandro Costa dos Santos', N'lecoh2@hotmail.com', N'4429f702260179f0611a1a0ae9d2b65869418962d5f8b0b14b9f13249dc91cb6')
GO
