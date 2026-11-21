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
CREATE PROCEDURE ThanhToan_Sua 
	-- Add the parameters for the stored procedure here
	@MaThanhToan int,
    @NgayTra date,
    @SoTien decimal(18,2),
    @HinhThuc nvarchar(30),
    @GhiChu nvarchar(255),
    @MaDonMua int,
    @MaNguoiGhi tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 UPDATE ThanhToan
    SET NgayTra = @NgayTra,
        SoTien = @SoTien,
        HinhThuc = @HinhThuc,
        GhiChu = @GhiChu,
        MaDonMua = @MaDonMua,
        MaNguoiGhi = @MaNguoiGhi
    WHERE MaThanhToan = @MaThanhToan;
END
GO
