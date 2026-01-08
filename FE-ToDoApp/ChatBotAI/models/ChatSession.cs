public class ChatSession
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<ChatMessage> Messages { get; set; } = new();
}
//public class ChatSession
//{
//    public int Id { get; set; }
//    public string Title { get; set; }

//    public DateTime CreatedAt { get; set; } = DateTime.Now;

//    public List<ChatMessage> Messages { get; set; } = new();
//}
