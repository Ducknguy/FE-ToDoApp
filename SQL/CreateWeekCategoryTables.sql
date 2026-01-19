-- T?o b?ng WeekCategory riêng bi?t
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeekCategory]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[WeekCategory](
        [CategoryId] INT IDENTITY(1,1) PRIMARY KEY,
        [CategoryName] NVARCHAR(255) NOT NULL,
        [WeekStartDate] DATE NOT NULL,
        [WeekEndDate] DATE NOT NULL,
        [OrderIndex] INT DEFAULT 0,
        [IsActive] BIT DEFAULT 1,
        [CreatedAt] DATETIME DEFAULT GETDATE(),
        [UpdatedAt] DATETIME DEFAULT GETDATE()
    )
END
GO

-- T?o index cho tìm ki?m nhanh
CREATE NONCLUSTERED INDEX IX_WeekCategory_WeekStartDate 
ON [dbo].[WeekCategory] ([WeekStartDate])
GO

CREATE NONCLUSTERED INDEX IX_WeekCategory_Active 
ON [dbo].[WeekCategory] ([IsActive])
GO

-- T?o b?ng WeekTask riêng bi?t (thay vì dùng Calendar)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeekTask]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[WeekTask](
        [TaskId] INT IDENTITY(1,1) PRIMARY KEY,
        [CategoryId] INT NOT NULL,
        [WeekStartDate] DATE NOT NULL,
        [DayOfWeek] INT NOT NULL, -- 1=Monday, 7=Sunday
        [Title] NVARCHAR(500) NOT NULL,
        [IsDone] BIT DEFAULT 0,
        [OrderIndex] INT DEFAULT 0,
        [CreatedAt] DATETIME DEFAULT GETDATE(),
        [UpdatedAt] DATETIME DEFAULT GETDATE(),
        FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[WeekCategory]([CategoryId]) ON DELETE CASCADE
    )
END
GO

-- T?o index cho WeekTask
CREATE NONCLUSTERED INDEX IX_WeekTask_Category 
ON [dbo].[WeekTask] ([CategoryId])
GO

CREATE NONCLUSTERED INDEX IX_WeekTask_Week 
ON [dbo].[WeekTask] ([WeekStartDate])
GO

PRINT 'WeekCategory and WeekTask tables created successfully!'
