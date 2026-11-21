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
CREATE PROCEDURE PhieuNhap_Them
	-- Add the parameters for the stored procedure here
	 @NgayNhan date,
    @MaDonMua int,
    @MaNguoiNhan tinyint,
    @TrangThai nvarchar(30) = N'Nháp'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @MaPhieuNhap int
	set @MaPhieuNhap =1
	while @MaPhieuNhap in (select MaPhieuNhap from PhieuNhap)
	set @MaPhieuNhap=@MaPhieuNhap+1
    -- Insert statements for procedure here
	INSERT INTO PhieuNhap(MaPhieuNhap,NgayNhan, TrangThai, MaDonMua, MaNguoiNhan)
    VALUES (@MaPhieuNhap,@NgayNhan, @TrangThai, @MaDonMua, @MaNguoiNhan);
END
GO
