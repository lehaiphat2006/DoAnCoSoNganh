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
CREATE PROCEDURE SanPham_Them 
	-- Add the parameters for the stored procedure here
	@TenSanPham nvarchar(200),
    @MaLoaiHang tinyint,
    @MaThuongHieu tinyint,
    @MaDonViTinh tinyint,
    @MoTa nvarchar(500) = NULL,
    @GiaNhapThamKhao decimal(18,2) = 0,
    @SoLuongTon int = 0,
    @MucTonToiThieu int = 0,
	@TrangThai nvarchar(30) = N'Đang kinh doanh'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @MaSanPham tinyint
	set @MaSanPham =1
	while @MaSanPham in (select MaSanPham from SanPham)
	set @MaSanPham=@MaSanPham+1
    -- Insert statements for procedure here
	insert into SanPham(MaSanPham,TenSanPham, MoTa, GiaNhapThamKhao, SoLuongTon, MucTonToiThieu, TrangThai,MaLoaiHang, MaThuongHieu, MaDonViTinh)
    VALUES (@MaSanPham,@TenSanPham, @MoTa, @GiaNhapThamKhao, @SoLuongTon, @MucTonToiThieu, @TrangThai,@MaLoaiHang, @MaThuongHieu, @MaDonViTinh);
	 
END
GO
