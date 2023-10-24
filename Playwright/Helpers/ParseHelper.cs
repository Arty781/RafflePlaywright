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

        public static async Task VerifyInitialEmailAuth(string email, string name, string charity)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
            var quantity = sub.NumOfTickets + sub.Extra;
            var value = sub.TotalCost / 100;
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.InitialAuth(name, quantity, value, charity));

        }

        public static async Task VerifyInitialEmailUnauth(string email, string name, string charity, int activeRaffles)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
            var quantity = sub.NumOfTickets + sub.Extra;
            var value = sub.TotalCost / 100;
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.InitialUnauth(name, quantity * activeRaffles, value, charity));

        }

        public static async Task VerifyMonthlyEmailAuth(string email, string name, string charity, int activeRaffles)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(35);
            emailsList = await Elements.GgetAllEmailData(email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
            var quantity = sub.NumOfTickets + sub.Extra;
            var value = sub.TotalCost / 100;
            emailsList = await Elements.GgetAllEmailData(email);
            if(emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).Count() <= 1)
            {
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed <= maxWaitTime)
                {
                    emailsList = await Elements.GgetAllEmailData(email);
                    if(emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).Count() > 1)
                    {
                        break;
                    }
                    await Task.Delay(30000);
                }
                stopwatch.Stop();
            }
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.MonthlyAuth(name, quantity * activeRaffles, value, charity));

        }

        public static async Task VerifyCancelationEmail(string email, string name)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription cancellation receipt").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Cancel(name));

        }

        public static async Task VerifyPauseEmail(string email, string name)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Paused subscription").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Pause(name));

        }

        public static async Task VerifyUnpauseEmail(string email, string name, string charity)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(35);
            emailsList = await Elements.GgetAllEmailData(email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "PAUSED" && x.PausedAt != null).Select(x => x).First();
            var quantity = sub.NumOfTickets + sub.Extra;
            var value = sub.TotalCost / 100;
            var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(user);
            emailsList = await Elements.GgetAllEmailData(email);
            if (emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).Count() <= 1)
            {
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed <= maxWaitTime)
                {
                    emailsList = await Elements.GgetAllEmailData(email);
                    if (emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).Count() == 1)
                    {
                        break;
                    }
                    await Task.Delay(30000);
                }
                stopwatch.Stop();
            }
            var id = emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Unpause(name, quantity, value, charity));
        }

        public static async Task VerifyIsUnpauseEmail(string email, string name, string charity)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(35);
            emailsList = await Elements.GgetAllEmailData(email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(user);
            var sub = subscriptionList.Where(x => x.Status == "ACTIVE" && x.PausedAt == null).Select(x => x).First();
            var quantity = sub.NumOfTickets + sub.Extra;
            var value = sub.TotalCost / 100;
            var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(user);
            emailsList = await Elements.GgetAllEmailData(email);
            if (emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).Count() <= 1)
            {
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed <= maxWaitTime)
                {
                    emailsList = await Elements.GgetAllEmailData(email);
                    if (emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).Count() == 1)
                    {
                        break;
                    }
                    await Task.Delay(30000);
                }
                stopwatch.Stop();
            }
            var id = emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.Unpause(name, quantity, value, charity));
        }

        public static async Task VerifyReminderEmail(string email, string name)
        {
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription pause reminder").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.SevenDaysBeforeUnpause(name));

        }

        public static async Task VerifyPurchaseFailedEmail(string email, string name)
        {
            await WaitUntil.WaitSomeInterval();
            emailsList = await Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Failed subscription payment").Select(q => q.id).FirstOrDefault();
            Elements.GgetHtmlBody(email, id, out string emailInitial);
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
                IElementHandle prizeElement = inputList[i];
                IElementHandle purchaseDateElement = inputList[i + 1];
                IElementHandle numTicketsElement = inputList[i + 2];
                IElementHandle priceElement = inputList[i + 3];

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
            var history = await SplitIntoRows(inputList, 4, maxRows);
            List<WebMOdels.Profile.OrderHistory> result = history.Item1;
            int totalPriceSum = history.Item2;

            return (result, totalPriceSum);
        }


    }

}
