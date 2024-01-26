using PlaywrightRaffle.APIHelpers.Admin.UsersPage;
using PlaywrightRaffle.APIHelpers.Web.Basket;
using PlaywrightRaffle.PageObjects;
using System.Security.Cryptography;
using YamlDotNet.Core.Tokens;
using static PlaywrightRaffle.APIHelpers.Web.Subscriptions.SubsriptionsResponse;
using static PlaywrightRaffle.Helpers.TempMail.MailModels;

namespace PlaywrightRaffle.Helpers
{
    public class ParseHelper
    {
        private static string IgnoreLinkInHtml(string html)
        {
            // Find the link in the HTML code
            string pattern = $"<a.href=\"" + "(.+?)\"";
            string result = Regex.Replace(html, pattern, "<a href=" + "\"" + "link with token" + "\"", RegexOptions.IgnoreCase);
            pattern = "src=\"([^\"]+)\"";
            result = Regex.Replace(result, pattern, "src=" + "\"" + "link with token" + "\"", RegexOptions.IgnoreCase);

            //pattern = "<td>(.+?)</td>";
            //result = Regex.Replace(result, pattern, "<td>" + "</td>", RegexOptions.IgnoreCase);
            //pattern = "<strong>Hi(.+?),";
            //result = Regex.Replace(result, pattern, "<strong>Hi \"Name\",", RegexOptions.IgnoreCase);

            return result;
        }

        private static void CompareEmailWithTemplate(string html, string template)
        {

            string expectedText = template;
            string actualText = html;

            Assert.Multiple(() =>
            {
                Assert.That(actualText, Is.EqualTo(expectedText), "Texts don't match");
                Assert.That(expectedText, Has.Length.EqualTo(actualText.Length), "Number of elements doesn't match");

                var mismatchedIndices = expectedText.Select((text, index) => new { text, index })
                    .Where(item => !actualText[item.index].Equals(item.text))
                    .Select(item => item.index)
                    .ToList();

                if (mismatchedIndices.Count > 0)
                {
                    string errorMessage = $"Expected text does not match the actual text at index(es): {string.Join(", ", mismatchedIndices)}";
                    Assert.Fail(errorMessage);
                }
            });
        }

        public static void ParseHtmlAndCompare(string html, string template)
        {
            // Load HTML code into an HtmlDocument object
            HtmlDocument htmlDoc = new();
            htmlDoc.LoadHtml(html);

            // Convert the modified HTML back to a string
            string parsedHtml = htmlDoc.DocumentNode.OuterHtml;

            //replase links
            parsedHtml = IgnoreLinkInHtml(parsedHtml);

            // Compare the parsed HTML with the template
            CompareEmailWithTemplate(parsedHtml, template);

        }



    }

    public class EmailVerificator
    {
        private static List<PutsboxEmail>? emailsList;

        private static async Task<(int?, double?)> ExpectedNumOfTicketsAndTotalCost(string email, int activeRaffles, string subscriptionStatus)
        {
            int? quantity = 0;
            double? value = 0;
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscription = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user).Where(x => x.Status == subscriptionStatus).Select(x => x).First();
            var subscriptionModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels().Last();
            if ((subscription.Count + 1) % subscriptionModel.BonusPeriod != 0)
            {
                switch (subscription.TotalCost)
                {
                    case < 2500 when activeRaffles == 2:
                        quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles) + 30;
                        break;

                    case < 2500 when activeRaffles == 1:
                        quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles) + 15;
                        break;

                    case 2500 when activeRaffles == 2:
                        quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles) + 100;
                        break;

                    case 2500 when activeRaffles == 1:
                        quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles) + 50;
                        break;

                    default:
                        // Handle other cases if needed
                        break;
                }

                value = subscription.TotalCost / 100;
            }
            else if ((subscription.Count + 1) % subscriptionModel.BonusPeriod == 0)
            {
                switch (subscription.TotalCost)
                {
                    case < 2500 when activeRaffles == 2:
                        quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles) + 30;
                        break;

                    case < 2500 when activeRaffles == 1:
                        quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles) + 15;
                        break;

                    case 2500 when activeRaffles == 2:
                        quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles) + 100;
                        break;

                    case 2500 when activeRaffles == 1:
                        quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles) + 50;
                        break;

                    default:
                        // Handle other cases if needed
                        break;
                }

                value = subscription.TotalCost / 100;
            }
            else
            {
                quantity = ((subscription.NumOfTickets + subscription.Extra) * activeRaffles);
                value = subscription.TotalCost / 100;
            }

            return (quantity, value);
        }

        public static async Task VerifyInitialEmailAuth(string email, string name, string charity, int activeRaffles)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            (int?, double?) expectedResult = await ExpectedNumOfTicketsAndTotalCost(email, activeRaffles, SubscriptionStatuses.ACTIVE);
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            string emailInitial = Elements.GgetHtmlBody(email, id).Result;
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.InitialAuth(name, expectedResult.Item1, expectedResult.Item2, charity));

        }

        public static async Task VerifyInitialEmailUnauth(string email, string name, string charity, int activeRaffles)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            (int?, double?) expectedResult = await ExpectedNumOfTicketsAndTotalCost(email, activeRaffles, SubscriptionStatuses.ACTIVE);
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            string emailInitial = Elements.GgetHtmlBody(email, id).Result;
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.InitialUnauth(name, expectedResult.Item1, expectedResult.Item2, charity));

        }

        public static async Task VerifyMonthlyEmailAuth(string email, string name, string charity, int activeRaffles)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(25);
            bool statusChanged = false;
            int checkInterval = 300000;
            var emailsList = await TempMail.GetMailsList(email);
            (int?, double?) expectedResult = await ExpectedNumOfTicketsAndTotalCost(email, activeRaffles, SubscriptionStatuses.ACTIVE);
            if (emailsList.Where(x => x.MailSubject == "Subscription tickets receipt").Select(q => q.MailId).Count() <= 1)
            {
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed <= maxWaitTime)
                {
                    switch (emailsList.Where(x => x.MailSubject == "Subscription tickets receipt").Select(q => q.MailId).Count() > 1)
                    {
                        case false:
                            await Task.Delay(checkInterval);
                            emailsList = await TempMail.GetMailsList(email);
                            break;
                        case true:
                            expectedResult = await ExpectedNumOfTicketsAndTotalCost(email, activeRaffles, SubscriptionStatuses.ACTIVE);
                            statusChanged = true;
                            goto LoopExit;
                    }
                    
                }
                stopwatch.Stop();
            LoopExit:
                if (!statusChanged)
                {
                    throw new Exception($"There are no emails within {maxWaitTime.Minutes} minutes.");
                }
            }
            var html = emailsList.Where(x => x.MailSubject == "Subscription tickets receipt").Select(q => q.MailHtml).LastOrDefault();
            ParseHelper.ParseHtmlAndCompare(html, SubscriptionEmailsTemplate.MonthlyAuth(name, expectedResult.Item1, expectedResult.Item2, charity));

        }

        public static async Task VerifyCancelationEmail(string email, string name)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription cancellation receipt").Select(q => q.id).FirstOrDefault();
            string emailInitial = Elements.GgetHtmlBody(email, id).Result;
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Cancel(name));

        }

        public static async Task VerifyPauseEmail(string email, string name)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Paused subscription").Select(q => q.id).FirstOrDefault();
            string emailInitial = Elements.GgetHtmlBody(email, id).Result;
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Pause(name));

        }

        public static async Task VerifyUnpauseEmail(string email, string name, string charity, int activeRaffles)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(35);
            bool statusChanged = false;
            int checkInterval = 300000;
            (int?, double?) expectedResult = await ExpectedNumOfTicketsAndTotalCost(email, activeRaffles, SubscriptionStatuses.PAUSED);
            var emailsList = await TempMail.GetMailsList(email);
            if (emailsList.Where(x => x.MailSubject == "Subscription pause reactivation").Select(q => q.MailId).Count() <= 1)
            {
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed <= maxWaitTime)
                {
                    switch (emailsList.Where(x => x.MailSubject == "Subscription pause reactivation").Select(q => q.MailId).Count() == 1)
                    {
                        case false:
                            await Task.Delay(checkInterval);
                            emailsList = await TempMail.GetMailsList(email);
                            break;
                        case true:
                            statusChanged = true;
                            goto LoopExit;
                    }
                }
                stopwatch.Stop();
            LoopExit:
                if (!statusChanged)
                {
                    throw new Exception($"There are no emails within {maxWaitTime.Minutes} minutes.");
                }
            }
            var html = emailsList.Where(x => x.MailSubject == "Subscription pause reactivation").Select(q => q.MailHtml).LastOrDefault();
            ParseHelper.ParseHtmlAndCompare(html, SubscriptionEmailsTemplate.Unpause(name, expectedResult.Item1, expectedResult.Item2, charity));
        }

        public static async Task VerifyIsUnpauseEmailTempMail(string email, string name, string charity, int activeRaffles)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(35);
            bool statusChanged = false;
            int checkInterval = 300000;
            (int?, double?) expectedResult = await ExpectedNumOfTicketsAndTotalCost(email, activeRaffles, SubscriptionStatuses.ACTIVE);
            var emailsList = await TempMail.GetMailsList(email);
            if (emailsList.Where(x => x.MailSubject == "Subscription pause reactivation").Select(q => q.MailId).Count() <= 1)
            {
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed <= maxWaitTime)
                {
                    switch (emailsList.Where(x => x.MailSubject == "Subscription pause reactivation").Select(q => q.MailId).Count() == 1)
                    {
                        case false:
                            await Task.Delay(checkInterval);
                            emailsList = await TempMail.GetMailsList(email);
                            break;
                        case true:
                            statusChanged = true;
                            goto LoopExit;
                    }
                }
                stopwatch.Stop();
            LoopExit:
                if (!statusChanged)
                {
                    throw new Exception($"There are no emails within {maxWaitTime.Minutes} minutes.");
                }
            }
            var html = emailsList.Where(x => x.MailSubject == "Subscription pause reactivation").Select(q => q.MailHtml).LastOrDefault();
            ParseHelper.ParseHtmlAndCompare(html, SubscriptionEmailsTemplate.Unpause(name, expectedResult.Item1, expectedResult.Item2, charity));
        }

        public static async Task VerifyIsUnpauseEmail(string email, string name, string charity, int activeRaffles)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(35);
            bool statusChanged = false;
            int checkInterval = 300000;
            (int?, double?) expectedResult = await ExpectedNumOfTicketsAndTotalCost(email, activeRaffles, SubscriptionStatuses.ACTIVE);
            var emailsList = await Elements.GgetAllEmailData(email);
            if (emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).Count() <= 1)
            {
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed <= maxWaitTime)
                {
                    switch (emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).Count() == 1)
                    {
                        case false:
                            await Task.Delay(checkInterval);
                            emailsList = await Elements.GgetAllEmailData(email);
                            break;
                        case true:
                            statusChanged = true;
                            goto LoopExit;
                    }
                }
                stopwatch.Stop();
            LoopExit:
                if (!statusChanged)
                {
                    throw new Exception($"There are no emails within {maxWaitTime.Minutes} minutes.");
                }
            }
            var html = Elements.GgetHtmlBody(email, emailsList[0].id).Result;
            ParseHelper.ParseHtmlAndCompare(html, SubscriptionEmailsTemplate.Unpause(name, expectedResult.Item1, expectedResult.Item2, charity));
        }

        public static async Task VerifyReminderEmail(string email, string name)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription pause reminder").Select(q => q.id).FirstOrDefault();
            string emailInitial = Elements.GgetHtmlBody(email, id).Result;
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.SevenDaysBeforeUnpause(name));

        }

        public static async Task VerifyPurchaseFailedEmail(string email, string name)
        {
            await WaitUntil.WaitSomeInterval();
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Failed subscription payment").Select(q => q.id).FirstOrDefault();
            string emailInitial = Elements.GgetHtmlBody(email, id).Result;
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.PurchaseFailed(name));

        }

    }

    public class OrderHistoryVerificator
    {
        private static async Task<(List<WebMOdels.Profile.OrderHistory>, int)> SplitIntoRows(List<IElementHandle> inputList, int elementsPerRow, int maxRows)
        {
            List<WebMOdels.Profile.OrderHistory> historyList = new();
            int sum = 0;
            int numRows = inputList.Count / elementsPerRow;
            if (numRows < maxRows)
            {
                throw new Exception("Not enough rows available.");
            }
            numRows = Math.Min(maxRows, numRows); // Calculate the actual number of rows to include
            for (int i = 0; i < numRows * elementsPerRow; i += elementsPerRow)
            {
                IElementHandle prizeElement = inputList[i+1];
                IElementHandle purchaseDateElement = inputList[i + 2];
                IElementHandle numTicketsElement = inputList[i + 4];
                IElementHandle priceElement = inputList[i + 5];

                WebMOdels.Profile.OrderHistory item = new()
                {
                    PRIZE = await prizeElement.TextContentAsync() ?? throw new Exception("Prize is null"),
                    PURCHASE_DATE = await purchaseDateElement.TextContentAsync() ?? throw new Exception("Date is null"),
                    NUM_TICKETS = int.Parse(await numTicketsElement.TextContentAsync() ?? throw new Exception("Tickets is null")),
                    PRICE = int.Parse(priceElement.TextContentAsync().Result[1..])
                };
                sum += item.PRICE; // Accumulate the price
                historyList.Add(item);
            }

            int totalPriceSum = sum;

            return (historyList, totalPriceSum);
        }

        public static async Task<(List<WebMOdels.Profile.OrderHistory>, int)> GetOrderHistory(List<IElementHandle> inputList, int maxRows)
        {
            var history = await SplitIntoRows(inputList, 6, maxRows);
            List<WebMOdels.Profile.OrderHistory> result = history.Item1;
            int totalPriceSum = history.Item2;

            return (result, totalPriceSum);
        }


    }

    public class TempMail
    {
        public static async Task<List<TempMailJSON>> GetMailsList(string email)
        {
            //Chilkat.HttpRequest req = new()
            //{
            //    HttpVerb = "GET",
            //    Path = $"request/mail/id/{CalculateMD5Hash(email)}/",
            //};

            ////req.AddHeader("connection", "Keep-Alive");
            ////req.AddHeader("accept-encoding", "gzip, deflate, br");
            //req.AddHeader("X-RapidAPI-Key", "29c883e97fmshba68047a499e098p11b255jsne4d44893783d");
            //req.AddHeader("X-RapidAPI-Host", "privatix-temp-mail-v1.p.rapidapi.com");

            //Chilkat.Http http = new Chilkat.Http();

            //Chilkat.HttpResponse resp = http.SynchronousRequest("privatix-temp-mail-v1.p.rapidapi.com", 443, true, req);
            //if (http.LastMethodSuccess != true) { throw new ArgumentException(http.LastErrorText); }

            var body = string.Empty;

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://privatix-temp-mail-v1.p.rapidapi.com/request/mail/id/{CalculateMD5Hash(email)}/"),
                Headers =
                {
                    { "X-RapidAPI-Key", "29c883e97fmshba68047a499e098p11b255jsne4d44893783d" },
                    { "X-RapidAPI-Host", "privatix-temp-mail-v1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<List<TempMailJSON>>(body);
        }

        private static string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // Convert each byte to a hexadecimal string
                }

                return sb.ToString();
            }
        }

        public class MailModels
        {
            public partial class TempMailJSON
            {
                [JsonProperty("_id")]
                public Id Id { get; set; }

                [JsonProperty("createdAt")]
                public CreatedAt CreatedAt { get; set; }

                [JsonProperty("mail_id")]
                public string MailId { get; set; }

                [JsonProperty("mail_address_id")]
                public string MailAddressId { get; set; }

                [JsonProperty("mail_from")]
                public string MailFrom { get; set; }

                [JsonProperty("mail_subject")]
                public string MailSubject { get; set; }

                [JsonProperty("mail_preview")]
                public string MailPreview { get; set; }

                [JsonProperty("mail_text_only")]
                public string MailTextOnly { get; set; }

                [JsonProperty("mail_text")]
                public string MailText { get; set; }

                [JsonProperty("mail_html")]
                public string MailHtml { get; set; }

                [JsonProperty("mail_timestamp")]
                public double MailTimestamp { get; set; }

                [JsonProperty("mail_attachments_count")]
                public long MailAttachmentsCount { get; set; }

                [JsonProperty("mail_attachments")]
                public MailAttachments MailAttachments { get; set; }
            }

            public partial class CreatedAt
            {
                [JsonProperty("milliseconds")]
                public long Milliseconds { get; set; }
            }

            public partial class Id
            {
                [JsonProperty("oid")]
                public string Oid { get; set; }
            }

            public partial class MailAttachments
            {
                [JsonProperty("attachment")]
                public object[] Attachment { get; set; }
            }
        }
    }
}
