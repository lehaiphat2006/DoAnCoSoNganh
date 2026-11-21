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
CREATE PROCEDURE ChiTietPhieuNhap_Them
@SoLuongNhan int,
    @MaPhieuNhap int,
    @MaChiTietDonMua int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @MaChiTietPhieuNhap int
	set @MaChiTietPhieuNhap =1
	while @MaChiTietPhieuNhap in (select MaChiTietPhieuNhap from ChiTietPhieuNhap)
	set @MaChiTietPhieuNhap=@MaChiTietPhieuNhap+1
    -- Insert statements for procedure here
	 INSERT INTO ChiTietPhieuNhap(MaChiTietPhieuNhap,SoLuongNhan, MaPhieuNhap, MaChiTietDonMua)
    VALUES (@MaChiTietPhieuNhap,@SoLuongNhan, @MaPhieuNhap, @MaChiTietDonMua);
END
GO
