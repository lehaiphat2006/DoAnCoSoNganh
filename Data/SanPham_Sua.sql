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
CREATE PROCEDURE SanPham_Sua
	-- Add the parameters for the stored procedure here
	@MaSanPham int,
    @TenSanPham nvarchar(200),
    @MoTa nvarchar(500),
    @GiaNhapThamKhao decimal(18,2),
    @SoLuongTon int,
    @MucTonToiThieu int,
    @TrangThai nvarchar(30),
    @MaLoaiHang tinyint,
    @MaThuongHieu tinyint,
    @MaDonViTinh tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE SanPham
    SET TenSanPham = @TenSanPham,
        MoTa = @MoTa,
        GiaNhapThamKhao = @GiaNhapThamKhao,
        SoLuongTon = @SoLuongTon,
        MucTonToiThieu = @MucTonToiThieu,
        TrangThai = @TrangThai,
        MaLoaiHang = @MaLoaiHang,
        MaThuongHieu = @MaThuongHieu,
        MaDonViTinh = @MaDonViTinh
    WHERE MaSanPham = @MaSanPham;
    -- Insert statements for procedure here
	
END
GO
