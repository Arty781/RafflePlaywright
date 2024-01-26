using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace PlaywrightRaffle.PageObjects
{
    public partial class GoogleCustom
    {
        public static async Task ClickSignInWithGoogle()
        {
            await Button.Click(SignIn.btnSignInWithGoogle);
        }

        public static async Task LogInGoogle(string email)
        {
            while (Browser.Driver.Context.Pages.Count < 2)
            {
                await Task.Delay(1000);
            }
            var windows = Browser.Driver.Context.Pages;
            var popup = windows[1];
            await popup.WaitForSelectorAsync(inputEmail, new() { Timeout = 10000 });
            await popup.TypeAsync(inputEmail, email, new() { Timeout = 10000 });
            await popup.WaitForSelectorAsync(btnNextEmail);
            await popup.ClickAsync(btnNextEmail, new() { Timeout = 10000 });
            await popup.WaitForSelectorAsync(inputPassword);
            await popup.TypeAsync(inputPassword, "Qaz11111", new() { Timeout = 10000 });
            await popup.WaitForSelectorAsync(btnNextPassword);
            await popup.ClickAsync(btnNextPassword, new() { Timeout = 10000 });
            while (Browser.Driver.Context.Pages.Count > 1)
            {
                await Task.Delay(1000);
            }

            Browser.Driver = windows[0];


        }

        public class ApiRequests
        {
            
            public static async Task GetEmailsBySubject()
            {
                // Set the path to your credentials file
                string credPath = Browser.RootPath() + "client_secret_1080640798483-bqaftm7hm7r5429hkbs26n944unhc3el.apps.googleusercontent.com.json";

                // Initialize the Gmail Service
                var service = GetGmailService(credPath);
                string targetSubject = "Subscription tickets receipt";

                var emailList = ListAndFetchEmails(service, "me", targetSubject, 10);

                // Print information from the list
                foreach (var email in emailList)
                {
                    Console.WriteLine($"Subject: {email.Subject}");
                    Console.WriteLine($"From: {email.From}");
                    Console.WriteLine($"Date: {email.Date}");
                    Console.WriteLine($"Body: {email.Body}");
                    Console.WriteLine("------------------------------------------------");
                }
            }

            static GmailService GetGmailService(string credPath)
            {
                // Read client secrets from the specified file
                using (var stream = new FileStream(credPath, FileMode.Open, FileAccess.Read))
                {
                    string credPathToken = "token.json";
                    var cred = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { GmailService.Scope.GmailReadonly },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPathToken, true)).Result;

                    // Create Gmail API service
                    return new GmailService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = cred,
                        ApplicationName = "RaffleH",
                    });
                }
            }

            static List<EmailInfo> ListAndFetchEmails(GmailService service, string userId, string targetSubject, int maxResults)
            {
                var emailList = new List<EmailInfo>();

                // Define the request to list messages
                var listRequest = service.Users.Messages.List(userId);
                listRequest.Q = $"subject:{targetSubject}";
                listRequest.MaxResults = maxResults;

                // Execute the request
                var listResponse = listRequest.Execute();

                // Fetch and store details of each email in the list
                foreach (var message in listResponse.Messages)
                {
                    var email = service.Users.Messages.Get(userId, message.Id).Execute();

                    // Fetch and store email body
                    string body = GetEmailBody(service, userId, message.Id);

                    // Create an EmailInfo object and add it to the list
                    var emailInfo = new EmailInfo
                    {
                        Subject = GetHeader(email.Payload.Headers, "Subject"),
                        From = GetHeader(email.Payload.Headers, "From"),
                        Date = GetHeader(email.Payload.Headers, "Date"),
                        Body = body
                    };

                    emailList.Add(emailInfo);
                }

                return emailList;
            }

            static string GetEmailBody(GmailService service, string userId, string messageId)
            {
                // Fetch the email
                var email = service.Users.Messages.Get(userId, messageId).Execute();

                // Extract and decode the body of the email
                string body = "";
                if (email.Payload.Body != null && email.Payload.Body.Data != null)
                {
                    body = Base64UrlDecode(email.Payload.Body.Data);
                }

                return body;
            }

            static string GetHeader(IList<MessagePartHeader> headers, string name)
            {
                var header = headers.FirstOrDefault(h => h.Name == name);
                return header?.Value;
            }

            static string Base64UrlDecode(string input)
            {
                var base64 = input.Replace('-', '+').Replace('_', '/');
                var padded = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');

                byte[] base64Bytes = Convert.FromBase64String(padded);
                return System.Text.Encoding.UTF8.GetString(base64Bytes);
            }
            class EmailInfo
            {
                public string Subject { get; set; }
                public string From { get; set; }
                public string Date { get; set; }
                public string Body { get; set; }
            }
        }

    }
}
