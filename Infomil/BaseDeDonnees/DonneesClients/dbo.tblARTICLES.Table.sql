USE [BD_TEST]
GO

TRUNCATE TABLE dbo.tblARTICLES
GO 

SET IDENTITY_INSERT [dbo].[tblARTICLES] ON 

INSERT [dbo].[tblARTICLES] ([ID_ARTICLE], [RAYON_ARTICLE], [NOM], [PRIX]) VALUES (1, N'fruit', N'pomme', CAST(10.00 AS Decimal(5, 2)))
INSERT [dbo].[tblARTICLES] ([ID_ARTICLE], [RAYON_ARTICLE], [NOM], [PRIX]) VALUES (2, N'fruit', N'banane', CAST(20.00 AS Decimal(5, 2)))
INSERT [dbo].[tblARTICLES] ([ID_ARTICLE], [RAYON_ARTICLE], [NOM], [PRIX]) VALUES (3, N'fruit', N'poir', CAST(5.00 AS Decimal(5, 2)))
INSERT [dbo].[tblARTICLES] ([ID_ARTICLE], [RAYON_ARTICLE], [NOM], [PRIX]) VALUES (4, N'legumes', N'pomme de terre', CAST(15.00 AS Decimal(5, 2)))
INSERT [dbo].[tblARTICLES] ([ID_ARTICLE], [RAYON_ARTICLE], [NOM], [PRIX]) VALUES (5, N'legumes', N'choux', CAST(15.00 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[tblARTICLES] OFF
