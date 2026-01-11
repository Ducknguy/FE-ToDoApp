-- =============================================
-- Script: T?o b?ng WeekCategory và c?p nh?t WeekPlanTask
-- M?c ?ích: H? tr? phân lo?i tasks theo categories
-- =============================================

-- 1. T?o b?ng WeekCategory
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeekCategory]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[WeekCategory](
        [CategoryId] INT IDENTITY(1,1) NOT NULL,
        [CategoryName] NVARCHAR(200) NOT NULL,
        [OrderIndex] INT NOT NULL DEFAULT(0),
        [IsActive] BIT NOT NULL DEFAULT(1),
        CONSTRAINT [PK_WeekCategory] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
    );
    
    PRINT '?ã t?o b?ng WeekCategory';
END
ELSE
BEGIN
    PRINT 'B?ng WeekCategory ?ã t?n t?i';
END
GO

-- 2. Thêm c?t CategoryId vào WeekPlanTask (n?u ch?a có)
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[WeekPlanTask]') AND name = 'CategoryId')
BEGIN
    ALTER TABLE [dbo].[WeekPlanTask]
    ADD [CategoryId] INT NULL;
    
    PRINT '?ã thêm c?t CategoryId vào WeekPlanTask';
END
ELSE
BEGIN
    PRINT 'C?t CategoryId ?ã t?n t?i trong WeekPlanTask';
END
GO

-- 3. Insert d? li?u m?u cho WeekCategory
IF NOT EXISTS (SELECT * FROM WeekCategory WHERE CategoryName = N'Công vi?c')
BEGIN
    SET IDENTITY_INSERT [dbo].[WeekCategory] ON;
    
    INSERT INTO [dbo].[WeekCategory] ([CategoryId], [CategoryName], [OrderIndex], [IsActive])
    VALUES 
        (1, N'Công vi?c', 0, 1),
        (2, N'H?c t?p', 1, 1),
        (3, N'Cá nhân', 2, 1);
    
    SET IDENTITY_INSERT [dbo].[WeekCategory] OFF;
    
    PRINT '?ã thêm d? li?u m?u cho WeekCategory';
END
ELSE
BEGIN
    PRINT 'D? li?u m?u ?ã t?n t?i';
END
GO

-- 4. C?p nh?t CategoryId m?c ??nh cho các task c?
UPDATE WeekPlanTask
SET CategoryId = 1
WHERE CategoryId IS NULL;

PRINT '?ã c?p nh?t CategoryId cho các task c?';
GO

-- 5. T?o Foreign Key constraint (tùy ch?n)
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_WeekPlanTask_WeekCategory')
BEGIN
    ALTER TABLE [dbo].[WeekPlanTask]
    ADD CONSTRAINT [FK_WeekPlanTask_WeekCategory] 
    FOREIGN KEY([CategoryId]) REFERENCES [dbo].[WeekCategory] ([CategoryId]);
    
    PRINT '?ã t?o Foreign Key constraint';
END
ELSE
BEGIN
    PRINT 'Foreign Key constraint ?ã t?n t?i';
END
GO

-- 6. T?o Index ?? t?ng hi?u su?t query
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_WeekPlanTask_CategoryId')
BEGIN
    CREATE NONCLUSTERED INDEX [IX_WeekPlanTask_CategoryId]
    ON [dbo].[WeekPlanTask] ([CategoryId])
    INCLUDE ([WeekPlanId], [DayOfWeek], [IsDone]);
    
    PRINT '?ã t?o Index cho CategoryId';
END
ELSE
BEGIN
    PRINT 'Index ?ã t?n t?i';
END
GO

PRINT '=== Hoàn thành c?p nh?t database ===';
