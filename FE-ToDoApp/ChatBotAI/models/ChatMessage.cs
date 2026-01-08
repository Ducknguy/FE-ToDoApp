public class ChatMessage
{
    public bool IsUser { get; set; }
    public string Content { get; set; }
    public DateTime Time { get; set; } = DateTime.Now;
    public List<string> Files { get; set; } = new();
}
