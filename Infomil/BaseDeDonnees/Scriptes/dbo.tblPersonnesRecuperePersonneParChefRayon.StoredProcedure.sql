USE [BD_TEST]
GO
/****** Object:  StoredProcedure [dbo].[tblPersonnesRecuperePersonneParChefRayon]    Script Date: 1/12/2020 11:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblPersonnesRecuperePersonneParChefRayon] 
	@idpersonne int
AS
	BEGIN
		SELECT 
			tp2.ID_PERSONNE [iid], 
			tp2.NOM [Nom], 
			tp2.PRENOM [Prenom], 
			tp2.DATE_NAISSANCE [Date de naissance], 
			tp2.SEXE [Sexe], 
			count(ta.ID_ARTICLE) [Nombre articles achetes], 
			sum(isnull(ta.PRIX, 0) * isnull(tp.QUANTITE, 0)) [Montant total]
		FROM dbo.tblPANIER tp
		INNER JOIN dbo.tblARTICLES ta ON tp.ID_ARTICLE = ta.ID_ARTICLE
		INNER JOIN dbo.tblRESPONSABLES_RAYONS trr ON ta.RAYON_ARTICLE = trr.RAYON_ARTICLE 
			AND trr.ID_PERSONNE = @idpersonne
		INNER JOIN dbo.tblPERSONNES tp2 ON tp2.ID_PERSONNE = tp.ID_PERSONNE
		GROUP BY tp2.ID_PERSONNE, tp2.NOM, tp2.PRENOM, tp2.DATE_NAISSANCE, tp2.SEXE
	END

GO
