USE [SharabanyOrder]
GO
/****** Object:  StoredProcedure [dbo].[SP_pakegFrameStikrs]    Script Date: 3/14/2024 11:29:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER PROCEDURE [dbo].[SP_pakegFrameStikrs]
@id INT
AS
BEGIN

 SELECT FrameType.AgroupOfDoorFrames,FrameType.TypeOfDoorFrame, Frames.IronThickness, Frames.MaterialType, SUM(Frames.tbAmount) AS TotalAmount,Dir='Right'
FROM            Frames    INNER JOIN
FrameType ON Frames.ID = FrameType.FrameID 
WHERE        (Frames.OrderID = @id and Frames.Direction='RIGHT')
GROUP BY FrameType.AgroupOfDoorFrames, Frames.IronThickness, Frames.MaterialType,FrameType.TypeOfDoorFrame

 union

SELECT        FrameType.AgroupOfDoorFrames,FrameType.TypeOfDoorFrame, Frames.IronThickness, Frames.MaterialType, SUM(Frames.tbAmount) AS TotalAmount,Dir='Left'
FROM            Frames    INNER JOIN
FrameType ON Frames.ID = FrameType.FrameID 
WHERE        (Frames.OrderID = @id and Frames.Direction='Left')
GROUP BY FrameType.AgroupOfDoorFrames, Frames.IronThickness, Frames.MaterialType,FrameType.TypeOfDoorFrame
union

SELECT        FrameType.AgroupOfDoorFrames,FrameType.TypeOfDoorFrame, Frames.IronThickness, Frames.MaterialType, SUM(Frames.tbAmount) AS TotalAmount,Dir='All'
FROM            Frames    INNER JOIN
FrameType ON Frames.ID = FrameType.FrameID 
WHERE        (Frames.OrderID =@id)
GROUP BY FrameType.AgroupOfDoorFrames, Frames.IronThickness, Frames.MaterialType,FrameType.TypeOfDoorFrame


END