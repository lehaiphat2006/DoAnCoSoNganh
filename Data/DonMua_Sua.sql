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
CREATE PROCEDURE DonMua_Sua 
	-- Add the parameters for the stored procedure here
	@MaDonMua int,
    @NgayLap date,
    @NgayDuKienGiao date,
    @TrangThai nvarchar(30),
    @TongTien decimal(18,2),
    @MaNhaCungCap int,
    @MaNguoiLap tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 UPDATE DonMua
    SET NgayLap = @NgayLap,
        NgayDuKienGiao = @NgayDuKienGiao,
        TrangThai = @TrangThai,
        TongTien = @TongTien,
        MaNhaCungCap = @MaNhaCungCap,
        MaNguoiLap = @MaNguoiLap
    WHERE MaDonMua = @MaDonMua;
END
GO
