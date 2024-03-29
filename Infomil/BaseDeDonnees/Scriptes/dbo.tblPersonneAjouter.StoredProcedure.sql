USE [BD_TEST]
GO
/****** Object:  StoredProcedure [dbo].[tblPersonneAjouter]    Script Date: 1/12/2020 11:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblPersonneAjouter]
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

			INSERT INTO dbo.tblPERSONNES(NIVEAU_UTILISATEUR, NOM, PRENOM, DATE_NAISSANCE, SEXE, ADDRESSE )
			VALUES(@niveau, @nom, @prenom, @naissance, @sexe, @adresses)

			COMMIT TRAN ajt  
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN ajt
		END CATCH
	END
GO
