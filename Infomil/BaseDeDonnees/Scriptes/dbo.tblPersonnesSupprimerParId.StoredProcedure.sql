USE [BD_TEST]
GO
/****** Object:  StoredProcedure [dbo].[tblPersonnesSupprimerParId]    Script Date: 1/12/2020 11:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblPersonnesSupprimerParId]
	@idpersonne int
AS
	BEGIN
		BEGIN TRY  
			BEGIN TRAN del
			
			DELETE FROM dbo.tblPERSONNES
			WHERE dbo.tblPERSONNES.ID_PERSONNE = @idpersonne

			COMMIT TRAN del
		END TRY 
		BEGIN CATCH  
		   ROLLBACK TRAN del
		END CATCH  
		
	END
GO
