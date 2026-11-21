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
CREATE PROCEDURE NguoiDung_Them
	-- Add the parameters for the stored procedure here
	@TenDangNhap varchar(50),
    @MatKhauMaHoa varchar(255),
    @HoTen nvarchar(100),
    @VaiTro nvarchar(30),
    @SoDienThoai varchar(15) = NULL,
    @Email varchar(100) = NULL,
    @KichHoat bit = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @MaNguoiDung tinyint
	set @MaNguoiDung =1
	while @MaNguoiDung in (select MaNguoiDung from NguoiDung)
	set @MaNguoiDung=@MaNguoiDung+1
    -- Insert statements for procedure here
	insert into NguoiDung(MaNguoiDung,TenDangNhap, MatKhauMaHoa, HoTen, SoDienThoai, Email, VaiTro, KichHoat)
	values (@MaNguoiDung,@TenDangNhap, @MatKhauMaHoa, @HoTen, @SoDienThoai, @Email, @VaiTro, @KichHoat)
END
GO
