USE [BD_TEST]
GO
/****** Object:  StoredProcedure [dbo].[tblPersonneMisAJour]    Script Date: 1/12/2020 11:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[tblPersonneMisAJour]
	@idpersonne int,
	@nom varchar(100),
	@prenom varchar(100),
	@adresses varchar(250),
	@naissance datetime,
	@sexe char(1),
	@niveau int = 0
AS 
	BEGIN
		BEGIN TRY
			BEGIN TRAN ajt

			UPDATE dbo.tblPERSONNES
			SET
			    dbo.tblPERSONNES.NIVEAU_UTILISATEUR = @niveau, -- int
			    dbo.tblPERSONNES.NOM = @nom, -- varchar
			    dbo.tblPERSONNES.PRENOM = @prenom, -- varchar
			    dbo.tblPERSONNES.DATE_NAISSANCE = @naissance, -- datetime
			    dbo.tblPERSONNES.SEXE = @sexe, -- char
			    dbo.tblPERSONNES.ADDRESSE = @adresses -- varchar
			WHERE dbo.tblPERSONNES.ID_PERSONNE = @idpersonne

			COMMIT TRAN ajt
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN ajt
		END CATCH
	END
GO
