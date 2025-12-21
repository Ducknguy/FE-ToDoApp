-- Bảng 1: Lưu danh sách các cuộc hội thoại (Hiện ở menu bên trái)
CREATE TABLE ChatSessions (
    SessionID NVARCHAR(50) PRIMARY KEY,
    Title NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Bảng 2: Lưu nội dung tin nhắn chi tiết
CREATE TABLE ChatMessages (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    SessionID NVARCHAR(50), 
    IsUser BIT,            -- 1 = Người, 0 = Máy
    Content NVARCHAR(MAX), -- Nội dung chat
    ThoiGian DATETIME DEFAULT GETDATE(),
    Files NVARCHAR(MAX)    -- Đường dẫn file đính kèm
);