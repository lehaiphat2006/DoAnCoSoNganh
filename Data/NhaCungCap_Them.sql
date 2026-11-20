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
CREATE PROCEDURE NhaCungCap_Them
	-- Add the parameters for the stored procedure here
	@TenNhaCungCap nvarchar(150),
    @DiaChi nvarchar(255) = NULL,
    @SoDienThoai varchar(15) = NULL,
    @Email varchar(100) = NULL,
    @NguoiLienHe nvarchar(100) = NULL,
    @MaSoThue varchar(20) = NULL,
    @DieuKhoanThanhToan nvarchar(100) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @MaNhaCungCap int
	set @MaNhaCungCap =1
	while @MaNhaCungCap in (select MaNhaCungCap from NhaCungCap)
	set @MaNhaCungCap=@MaNhaCungCap+1
	INSERT INTO NhaCungCap(MaNhaCungCap,TenNhaCungCap, DiaChi, SoDienThoai, Email,
                           NguoiLienHe, MaSoThue, DieuKhoanThanhToan)
    VALUES (@MaNhaCungCap,@TenNhaCungCap, @DiaChi, @SoDienThoai, @Email,
            @NguoiLienHe, @MaSoThue, @DieuKhoanThanhToan);
END
GO
