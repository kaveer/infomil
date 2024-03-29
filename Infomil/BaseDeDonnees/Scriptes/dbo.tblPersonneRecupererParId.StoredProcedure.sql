USE [BD_TEST]
GO
/****** Object:  StoredProcedure [dbo].[tblPersonneRecupererParId]    Script Date: 1/12/2020 11:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblPersonneRecupererParId]
	@iid int
AS
	BEGIN
		SELECT 
			tp.ID_PERSONNE, 
			tp.NIVEAU_UTILISATEUR, 
			tp.NOM, 
			tp.PRENOM, 
			tp.SEXE, 
			tp.ADDRESSE, 
			tp.DATE_NAISSANCE
		FROM dbo.tblPERSONNES tp
		WHERE tp.ID_PERSONNE = @iid
	END

GO
