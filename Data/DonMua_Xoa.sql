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
CREATE PROCEDURE DonMua_Xoa
	-- Add the parameters for the stored procedure here
	@MaDonMua int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT 1 FROM ChiTietDonMua WHERE MaDonMua = @MaDonMua)
    BEGIN
        RAISERROR(N'Không thể xóa: dữ liệu đang được dùng trong bảng ChiTietDonMua.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM PhieuNhap WHERE MaDonMua = @MaDonMua)
    BEGIN
        RAISERROR(N'Không thể xóa: dữ liệu đang được dùng trong bảng PhieuNhap.', 16, 1);
        RETURN;
    END
    IF EXISTS (SELECT 1 FROM ThanhToan WHERE MaDonMua = @MaDonMua)
    BEGIN
        RAISERROR(N'Không thể xóa: dữ liệu đang được dùng trong bảng ThanhToan.', 16, 1);
        RETURN;
    END
    DELETE FROM DonMua WHERE MaDonMua = @MaDonMua;
END
GO
