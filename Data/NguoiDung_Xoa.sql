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
CREATE PROCEDURE NguoiDung_Xoa
	-- Add the parameters for the stored procedure here
	@MaNguoiDung tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 IF EXISTS (SELECT 1 FROM DonMua WHERE MaNguoiLap = @MaNguoiDung)
    BEGIN
        RAISERROR(N'Không thể xóa: dữ liệu đang được dùng trong bảng DonMua.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM PhieuNhap WHERE MaNguoiNhan = @MaNguoiDung)
    BEGIN
        RAISERROR(N'Không thể xóa: dữ liệu đang được dùng trong bảng PhieuNhap.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM ThanhToan WHERE MaNguoiGhi = @MaNguoiDung)
    BEGIN
        RAISERROR(N'Không thể xóa: dữ liệu đang được dùng trong bảng ThanhToan.', 16, 1);
        RETURN;
    END
    DELETE FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung;
    -- Insert statements for procedure here
	
END
GO
