using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FE_ToDoApp.Calendar
{
    public class GoogleHelper
    {
        // Chỉ cần quyền đọc lịch
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "ToDoApp Calendar";

        public static async Task<List<Event>> LaySuKienTrongThang(int month, int year)
        {
            try
            {
                UserCredential credential;

                // Kiểm tra xem file có tồn tại không
                if (!File.Exists("credentials.json"))
                {
                    return null; // Không tìm thấy file key
                }

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true));
                }

                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Xác định ngày đầu tháng và cuối tháng
                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = startDate.AddMonths(1).AddSeconds(-1);

                EventsResource.ListRequest request = service.Events.List("primary");
                request.TimeMin = startDate;
                request.TimeMax = endDate;
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                Events events = await request.ExecuteAsync();
                return (List<Event>)events.Items;
            }
            catch (Exception)
            {
                return null; // Trả về null nếu lỗi mạng hoặc lỗi khác
            }
        }
    }
}