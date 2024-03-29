USE [BD_TEST]
GO
/****** Object:  StoredProcedure [dbo].[tblPersonnesRechercherParUtilisateurMotDePasse]    Script Date: 1/12/2020 11:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblPersonnesRechercherParUtilisateurMotDePasse]
	@utilisateur int,
	@motdepasse varchar(10)
AS
	BEGIN
		IF(@motdepasse = '' OR @motdepasse IS NULL)
			BEGIN
				SELECT *
				FROM dbo.tblPERSONNES tp
				WHERE tp.NIVEAU_UTILISATEUR = 0 AND tp.ID_PERSONNE = @utilisateur
			END
		ELSE
			BEGIN
				SELECT *
				FROM dbo.tblPERSONNES tp
				WHERE tp.NIVEAU_UTILISATEUR != 0 AND tp.ID_PERSONNE = @utilisateur AND tp.MOT_DE_PASSE = @motdepasse
			END
		
	END
GO
