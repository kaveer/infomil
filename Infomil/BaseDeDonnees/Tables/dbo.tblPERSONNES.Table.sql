USE [BD_TEST]
GO
/****** Object:  Table [dbo].[tblPERSONNES]    Script Date: 11/29/2019 5:43:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPERSONNES](
	[ID_PERSONNE] [int] IDENTITY(1,1) NOT NULL,
	[NIVEAU_UTILISATEUR] [int] NOT NULL,
	[NOM] [varchar](100) NOT NULL,
	[PRENOM] [varchar](100) NOT NULL,
	[DATE_NAISSANCE] [datetime] NULL,
	[SEXE] [char](1) NOT NULL,
	[MOT_DE_PASSE] [varchar](10) NULL,
	[ADDRESSE] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PERSONNE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
