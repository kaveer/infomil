USE [BD_TEST]
GO
/****** Object:  StoredProcedure [dbo].[tblPersonnesRecuperePersonneParSuperviseur]    Script Date: 1/12/2020 11:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblPersonnesRecuperePersonneParSuperviseur] 
	@idpersonne int
AS
	BEGIN
		SELECT 
			tp.ID_PERSONNE [iid], 
			tp.NOM [Nom], 
			tp.PRENOM [Prenom], 
			tp.DATE_NAISSANCE [Date de naissance], 
			tp.SEXE [Sexe], 
			count(ta.ID_ARTICLE) [Nombre articles achetes], 
			sum(isnull(ta.PRIX, 0) * isnull(tp2.QUANTITE, 0)) [Montant total]
		FROM dbo.tblPERSONNES tp
		LEFT OUTER JOIN dbo.tblPANIER tp2 ON tp2.ID_PERSONNE = tp.ID_PERSONNE 
		LEFT OUTER JOIN dbo.tblARTICLES ta ON ta.ID_ARTICLE = tp2.ID_ARTICLE
		WHERE tp.ID_PERSONNE <> @idpersonne
		GROUP BY tp.ID_PERSONNE, tp.NOM, tp.PRENOM, tp.DATE_NAISSANCE, tp.SEXE
	END

GO
