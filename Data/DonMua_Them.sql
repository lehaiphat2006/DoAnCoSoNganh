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
CREATE PROCEDURE DonMua_Them
	-- Add the parameters for the stored procedure here
	@NgayLap date,
    @MaNhaCungCap int,
    @MaNguoiLap tinyint,
    @NgayDuKienGiao date = NULL,
    @TrangThai nvarchar(30) = N'Nháp',
    @TongTien decimal(18,2) = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @MaDonMua int
	set @MaDonMua =1
	while @MaDonMua in (select MaDonMua from DonMua)
	set @MaDonMua=@MaDonMua+1
    -- Insert statements for procedure here
	INSERT INTO DonMua(MaDonMua,NgayLap, NgayDuKienGiao, TrangThai, TongTien, MaNhaCungCap, MaNguoiLap)
    VALUES (@MaDonMua,@NgayLap, @NgayDuKienGiao, @TrangThai, @TongTien, @MaNhaCungCap, @MaNguoiLap);
    -- Insert statements for procedure here
	
END
GO
