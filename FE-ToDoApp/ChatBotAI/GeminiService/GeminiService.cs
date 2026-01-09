using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FE_ToDoApp.ChatBotAI.GeminiService
{
    public class GeminiService
    {
        private readonly string apiKey;
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(60) // Tăng timeout vì upload ảnh lâu hơn
        };

        public GeminiService(string key)
        {
            apiKey = key;
        }

        // Thêm tham số imagePaths vào hàm
        public async Task<string> SendAsync(List<string> history, List<string> imagePaths)
        {
            // 1. Tạo danh sách "parts" cho nội dung
            var parts = new List<object>();

            // 1a. Thêm lịch sử chat (Text cũ)
            // Lưu ý: Để đơn giản và tiết kiệm token, ta gom lịch sử thành 1 cục text
            string fullHistory = string.Join("\n", history);
            parts.Add(new { text = fullHistory });

            // 1b. Xử lý ảnh (Nếu có) - Chỉ gửi ảnh của tin nhắn hiện tại
            if (imagePaths != null && imagePaths.Count > 0)
            {
                foreach (string path in imagePaths)
                {
                    if (File.Exists(path))
                    {
                        byte[] bytes = File.ReadAllBytes(path);
                        string base64 = Convert.ToBase64String(bytes);
                        string mimeType = GetMimeType(path);

                        // Cấu trúc của Gemini cho dữ liệu file
                        parts.Add(new
                        {
                            inline_data = new
                            {
                                mime_type = mimeType,
                                data = base64
                            }
                        });
                    }
                }
            }

            // 2. Tạo Body JSON
            var body = new
            {
                contents = new[]
                {
                    new { parts = parts }
                }
            };

            var json = JsonSerializer.Serialize(body);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            // 3. Gửi Request
            try
            {
                var res = await client.PostAsync(
                    $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash-lite:generateContent?key={apiKey}",
                    httpContent
                );

                var str = await res.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(str);

                // Kiểm tra lỗi
                if (doc.RootElement.TryGetProperty("error", out var errorElem))
                {
                    string msg = errorElem.GetProperty("message").GetString();
                    return $"❌ Lỗi API: {msg}";
                }

                // Lấy kết quả
                if (doc.RootElement.TryGetProperty("candidates", out var candidates) && candidates.GetArrayLength() > 0)
                {
                    var firstCandidate = candidates[0];
                    if (firstCandidate.TryGetProperty("content", out var content) &&
                        content.TryGetProperty("parts", out var partsProp) &&
                        partsProp.GetArrayLength() > 0)
                    {
                        return partsProp[0].GetProperty("text").GetString();
                    }
                }
                return "⚠️ AI không phản hồi.";
            }
            catch (Exception ex)
            {
                return "❌ Lỗi kết nối: " + ex.Message;
            }
        }

        // Hàm phụ trợ xác định loại file
        private string GetMimeType(string path)
        {
            string ext = Path.GetExtension(path).ToLower();
            return ext switch
            {
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".webp" => "image/webp",
                ".heic" => "image/heic",
                ".heif" => "image/heif",
                ".pdf" => "application/pdf", // Gemini mới hỗ trợ cả PDF
                _ => "application/octet-stream"
            };
        }
    }
}