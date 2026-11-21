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
CREATE PROCEDURE ThuongHieu_Them
	-- Add the parameters for the stored procedure here
	@TenThuongHieu nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @MaThuongHieu tinyint
	set @MaThuongHieu =1
	while @MaThuongHieu in (select MaThuongHieu from ThuongHieu)
	set @MaThuongHieu=@MaThuongHieu+1
    -- Insert statements for procedure here
	insert into ThuongHieu(MaThuongHieu,TenThuongHieu)
	values (@MaThuongHieu,@TenThuongHieu)
END
GO
