USE [BD_TEST]
GO
SET IDENTITY_INSERT [dbo].[tblPERSONNES] ON 

INSERT [dbo].[tblPERSONNES] ([ID_PERSONNE], [NIVEAU_UTILISATEUR], [NOM], [PRENOM], [DATE_NAISSANCE], [SEXE], [MOT_DE_PASSE], [ADDRESSE]) VALUES (1, 0, N'cliN', N'cliP', CAST(N'2019-11-11T16:10:28.000' AS DateTime), N'F', N'cliMdp', N'cliAdd')
INSERT [dbo].[tblPERSONNES] ([ID_PERSONNE], [NIVEAU_UTILISATEUR], [NOM], [PRENOM], [DATE_NAISSANCE], [SEXE], [MOT_DE_PASSE], [ADDRESSE]) VALUES (2, 1, N'chefN', N'chefP', CAST(N'2019-11-11T16:10:28.000' AS DateTime), N'M', N'chefMdp', N'chefAdd')
INSERT [dbo].[tblPERSONNES] ([ID_PERSONNE], [NIVEAU_UTILISATEUR], [NOM], [PRENOM], [DATE_NAISSANCE], [SEXE], [MOT_DE_PASSE], [ADDRESSE]) VALUES (3, 2, N'supN', N'supP', CAST(N'2019-11-11T16:10:28.000' AS DateTime), N'M', N'supMdp', N'supAdd')
INSERT [dbo].[tblPERSONNES] ([ID_PERSONNE], [NIVEAU_UTILISATEUR], [NOM], [PRENOM], [DATE_NAISSANCE], [SEXE], [MOT_DE_PASSE], [ADDRESSE]) VALUES (4, 0, N'cli2', N'cli2', CAST(N'2019-11-12T20:29:02.000' AS DateTime), N'M', N'cli2', N'cli2')
INSERT [dbo].[tblPERSONNES] ([ID_PERSONNE], [NIVEAU_UTILISATEUR], [NOM], [PRENOM], [DATE_NAISSANCE], [SEXE], [MOT_DE_PASSE], [ADDRESSE]) VALUES (5, 0, N'cli3', N'cli3', CAST(N'2019-11-12T20:58:51.000' AS DateTime), N'F', N'cli3', N'cli3')
INSERT [dbo].[tblPERSONNES] ([ID_PERSONNE], [NIVEAU_UTILISATEUR], [NOM], [PRENOM], [DATE_NAISSANCE], [SEXE], [MOT_DE_PASSE], [ADDRESSE]) VALUES (6, 1, N'chef2', N'chef2', CAST(N'2019-11-12T20:58:51.000' AS DateTime), N'F', N'chef2', N'chef2')
SET IDENTITY_INSERT [dbo].[tblPERSONNES] OFF
