-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DonViTinh_Them 
	-- Add the parameters for the stored procedure here
	@TenDonViTinh nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @MaDonViTinh tinyint
	set @MaDonViTinh =1
	while @MaDonViTinh in (select MaDonViTinh from DonViTinh)
	set @MaDonViTinh=@MaDonViTinh+1
    -- Insert statements for procedure here
	insert into DonViTinh(MaDonViTinh,TenDonViTinh)
	values (@MaDonViTinh,@TenDonViTinh)
    -- Insert statements for procedure here
	
END
GO
