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
CREATE PROCEDURE NhaCungCap_Sua
	-- Add the parameters for the stored procedure here
	@MaNhaCungCap int,
    @TenNhaCungCap nvarchar(150),
    @DiaChi nvarchar(255) = NULL,
    @SoDienThoai varchar(15) = NULL,
    @Email varchar(100) = NULL,
    @NguoiLienHe nvarchar(100) = NULL,
    @MaSoThue varchar(20) = NULL,
    @DieuKhoanThanhToan nvarchar(100) = NULL,
    @TrangThai nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE NhaCungCap
    SET TenNhaCungCap = @TenNhaCungCap, DiaChi = @DiaChi,
        SoDienThoai = @SoDienThoai, Email = @Email, NguoiLienHe = @NguoiLienHe,
        MaSoThue = @MaSoThue, DieuKhoanThanhToan = @DieuKhoanThanhToan,
        TrangThai = @TrangThai
    WHERE MaNhaCungCap = @MaNhaCungCap;
END
GO
