DELETE FROM [dbo].[Task];

-- 2. Chèn dữ liệu mẫu để test đủ 4 thẻ trên Dashboard
-- Chèn Task cho NGÀY HÔM NAY (Today)
INSERT INTO [dbo].[Task] ([Title], [DueDate], [Category], [Status]) 
VALUES (N'Họp tiến độ dự án', GETDATE(), N'Work', N'Pending');

-- Chèn Task QUÁ HẠN (Overdue) - Ngày hôm qua
INSERT INTO [dbo].[Task] ([Title], [DueDate], [Category], [Status]) 
VALUES (N'Gửi báo cáo tuần', DATEADD(day, -1, GETDATE()), N'Work', N'Pending');

-- Chèn Task SẮP TỚI (Upcoming) - Ngày mai
INSERT INTO [dbo].[Task] ([Title], [DueDate], [Category], [Status]) 
VALUES (N'Mua quà sinh nhật', DATEADD(day, 1, GETDATE()), N'Personal', N'Pending');

-- Chèn Task ĐÃ HOÀN THÀNH (Completed)
INSERT INTO [dbo].[Task] ([Title], [DueDate], [Category], [Status]) 
VALUES (N'Chạy bộ buổi sáng', GETDATE(), N'Health', N'Done');