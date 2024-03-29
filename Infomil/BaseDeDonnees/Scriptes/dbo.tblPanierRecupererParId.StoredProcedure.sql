USE [BD_TEST]
GO
/****** Object:  StoredProcedure [dbo].[tblPanierRecupererParId]    Script Date: 1/12/2020 11:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblPanierRecupererParId]
	@iid int
AS
	BEGIN
		SELECT 
			ta.NOM,
			tp.QUANTITE,
			ta.PRIX
		FROM dbo.tblPANIER tp
		INNER JOIN dbo.tblARTICLES ta ON tp.ID_ARTICLE = ta.ID_ARTICLE
		WHERE tp.ID_PERSONNE = @iid
	END

GO
