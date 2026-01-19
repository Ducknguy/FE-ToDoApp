-- Ki?m tra xem CategoryId có ph?i IDENTITY không
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    COLUMNPROPERTY(OBJECT_ID('WeekCategory'), COLUMN_NAME, 'IsIdentity') AS IsIdentity
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'WeekCategory'
ORDER BY ORDINAL_POSITION;

-- N?u CategoryId không ph?i IDENTITY, c?n t?o l?i b?ng
-- Backup d? li?u c?
SELECT * INTO WeekCategory_Backup FROM WeekCategory;

-- Xóa b?ng c?
DROP TABLE WeekCategory;

-- T?o l?i b?ng v?i CategoryId IDENTITY
CREATE TABLE [dbo].[WeekCategory](
    [CategoryId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [CategoryName] NVARCHAR(50) NOT NULL,
    [WeekStartDate] DATETIME NOT NULL,
    [WeekEndDate] DATETIME NOT NULL,
    [OrderIndex] INT NULL,
    [IsActive] BIT NULL DEFAULT 1
);

-- Khôi ph?c d? li?u (CategoryId s? t? ??ng t?ng)
SET IDENTITY_INSERT WeekCategory ON;

INSERT INTO WeekCategory (CategoryId, CategoryName, WeekStartDate, WeekEndDate, OrderIndex, IsActive)
SELECT CategoryId, CategoryName, WeekStartDate, WeekEndDate, OrderIndex, IsActive
FROM WeekCategory_Backup;

SET IDENTITY_INSERT WeekCategory OFF;

-- Xóa backup
DROP TABLE WeekCategory_Backup;

PRINT 'WeekCategory table recreated with IDENTITY on CategoryId';
