CREATE DATABASE ToDoListDB;
GO

USE ToDoListDB;
GO

CREATE TABLE Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    StartDate DATETIME NOT NULL,
    Status NVARCHAR(50) DEFAULT N'New'
);
GO

INSERT INTO Tasks (Title, Description, StartDate, Status) 
VALUES 
(N'Họp team dự án', N'Họp tại phòng 301', '2025-12-20 09:00:00', N'New'),
(N'Đi siêu thị', N'Mua đồ ăn tối', '2025-12-20 17:30:00', N'New');
GO

SELECT * FROM Tasks;