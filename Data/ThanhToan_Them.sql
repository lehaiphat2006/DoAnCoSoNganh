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
CREATE PROCEDURE ThanhToan_Them
	-- Add the parameters for the stored procedure here
	@NgayTra date,
    @SoTien decimal(18,2),
    @HinhThuc nvarchar(30),
    @MaDonMua int,
    @MaNguoiGhi tinyint,
    @GhiChu nvarchar(255) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @MaThanhToan int
	set @MaThanhToan =1
	while @MaThanhToan in (select MaThanhToan from ThanhToan)
	set @MaThanhToan=@MaThanhToan+1
    -- Insert statements for procedure here
	INSERT INTO ThanhToan(MaThanhToan,NgayTra, SoTien, HinhThuc, GhiChu, MaDonMua, MaNguoiGhi)
    VALUES (@MaThanhToan,@NgayTra, @SoTien, @HinhThuc, @GhiChu, @MaDonMua, @MaNguoiGhi);

    -- Insert statements for procedure here

END
GO
