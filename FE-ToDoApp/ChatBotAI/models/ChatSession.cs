using System;
using System.Collections.Generic;

public class ChatSession
{
    // 1. Sửa Id thành int (để khớp với SQL Identity)
    public int Id { get; set; } = 0;

    public int UserId { get; set; }              // mỗi user có ls riêng
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
}
//public class ChatSession
//{
//    public int Id { get; set; }
//    public string Title { get; set; }

//    public DateTime CreatedAt { get; set; } = DateTime.Now;

//    public List<ChatMessage> Messages { get; set; } = new();
//}
