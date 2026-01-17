-- =============================================
-- Script: Thêm c?t WeekStartDate và WeekEndDate vào b?ng WeekCategory
-- M?c ?ích: H? tr? l?u tr? kho?ng th?i gian tu?n cho m?i category
-- =============================================

USE [ToDoApp];
GO

-- Thêm c?t WeekStartDate n?u ch?a có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[WeekCategory]') AND name = 'WeekStartDate')
BEGIN
    ALTER TABLE [dbo].[WeekCategory]
    ADD [WeekStartDate] DATETIME NOT NULL DEFAULT(GETDATE());
    
    PRINT '?ã thêm c?t WeekStartDate vào WeekCategory';
END
ELSE
BEGIN
    PRINT 'C?t WeekStartDate ?ã t?n t?i';
END
GO

-- Thêm c?t WeekEndDate n?u ch?a có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[WeekCategory]') AND name = 'WeekEndDate')
BEGIN
    ALTER TABLE [dbo].[WeekCategory]
    ADD [WeekEndDate] DATETIME NOT NULL DEFAULT(DATEADD(day, 6, GETDATE()));
    
    PRINT '?ã thêm c?t WeekEndDate vào WeekCategory';
END
ELSE
BEGIN
    PRINT 'C?t WeekEndDate ?ã t?n t?i';
END
GO

-- C?p nh?t d? li?u m?u v?i kho?ng th?i gian tu?n hi?n t?i
DECLARE @CurrentWeekStart DATETIME;
DECLARE @CurrentWeekEnd DATETIME;

-- Tính Monday c?a tu?n hi?n t?i
SET @CurrentWeekStart = DATEADD(day, -(DATEPART(weekday, GETDATE()) + 5) % 7, CAST(GETDATE() AS DATE));
SET @CurrentWeekEnd = DATEADD(day, 6, @CurrentWeekStart);

-- C?p nh?t cho các category hi?n có
UPDATE [dbo].[WeekCategory]
SET 
    WeekStartDate = @CurrentWeekStart,
    WeekEndDate = @CurrentWeekEnd
WHERE WeekStartDate = CAST(GETDATE() AS DATE)  -- Ch? update nh?ng record có giá tr? default
   OR WeekEndDate = DATEADD(day, 6, CAST(GETDATE() AS DATE));

PRINT '?ã c?p nh?t WeekStartDate và WeekEndDate cho các category hi?n có';
GO

PRINT '=== Hoàn thành c?p nh?t database ===';
