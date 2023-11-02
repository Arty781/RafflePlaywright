using Fizzler.Systems.HtmlAgilityPack;
using PlaywrightRaffle.PageObjects;
using RestSharp;
using System.Collections.ObjectModel;

namespace PlaywrightRaffle.Helpers
{


    public class Button
    {
        public static async Task Click(string element)
        {
            await WaitUntil.CustomElementIsVisible(element);
            await Browser.Driver.QuerySelectorAsync(element).Result.ScrollIntoViewIfNeededAsync();
            await Browser.Driver.ClickAsync(element);

        }


        public static async Task ClickCountry(string selector)
        {
            await Browser.Driver.QuerySelectorAsync($"//ul[@role='listbox']/li[contains(text(),'{Country.COUNTRY_CODES[RandomHelper.RandomCountry()]}')]");
            await WaitUntil.CustomElementIsVisible(selector);
            await Browser.Driver.ClickAsync(selector);
        }

        public static async Task ClickOnNthElement(string selector, int nthNum)
        {
            await WaitUntil.CustomElementIsVisible(selector);
            await Browser.Driver.QuerySelectorAllAsync(selector).Result[nthNum].ClickAsync();
        }

    }

    public class DropdownList
    {
        public static async Task SelectDropdownItemByText(string selector, string text)
        {
            await WaitUntil.CustomElementIsVisible(selector);
            var element = (await Browser.Driver.QuerySelectorAllAsync(selector)).Where(x => x.TextContentAsync().Result == text)
                              .Select(x => x).First().ClickAsync();
        }

        public static async Task SelectDropdownItemByValue(string selector, string text)
        {
            await WaitUntil.CustomElementIsVisible(selector);
            await Browser.Driver.QuerySelectorAllAsync(selector).Result
                .Where(x => x.TextContentAsync().Result == text)
                .Select(x => x).First().ClickAsync();
        }
    }
    public class InputBox
    {
        public static async Task Element(string element, string data)
        {
            await WaitUntil.CustomElementIsVisible(element);
            await Browser.Driver.FocusAsync(element);
            await Browser.Driver.Keyboard.PressAsync("Control+A");
            await Browser.Driver.Keyboard.PressAsync("Delete");
            await Browser.Driver.QuerySelectorAsync(element).Result.FillAsync(data);
            await WaitUntil.WaitSomeInterval(350);
        }

        public static async Task ElementImage(string element, string data)
        {
            await WaitUntil.CustomElementIsVisible(element);
            await Browser.Driver.QuerySelectorAsync(element).Result.FillAsync(data);
        }

        public static async Task CbbxElement(string element, int seconds, string data)
        {
            await WaitUntil.CustomElementIsVisible(element);
            await Browser.Driver.QuerySelectorAllAsync(element).Result
                .Where(x => x.TextContentAsync().Result == data)
                .Select(x => x).First().ClickAsync();
        }

        public static async Task ElementList(string element, int i, string data)
        {
            await WaitUntil.CustomElementIsVisible(element);
            await Browser.Driver.QuerySelectorAllAsync(element).Result[i].FocusAsync();
            await Browser.Driver.Keyboard.PressAsync("Control+A");
            await Browser.Driver.Keyboard.PressAsync("Delete");
            await Browser.Driver.QuerySelectorAllAsync(element).Result[i].FillAsync(data);
            await WaitUntil.WaitSomeInterval(350);
        }

    }

    public class TextBox
    {
        public static async Task<string> GetText(string element)
        {
            await WaitUntil.CustomElementIsVisible(element);
            var t = await Browser.Driver.QuerySelectorAsync(element).Result.TextContentAsync();
            return Regex.Replace(t, @"&nbsp;|[\u00A0]", "");
        }

        public static async Task<string> GetAttribute(string element, string attribute)
        {
            await WaitUntil.CustomElementIsVisible(element);
            return await Browser.Driver.QuerySelectorAsync(element).Result.GetAttributeAsync(attribute);
        }

        public static async Task<string> GetTextForList(string selector, int index)
        {
            await WaitUntil.CustomElementIsVisible(selector);
            var t = (await Browser.Driver.QuerySelectorAllAsync(selector))[index].TextContentAsync().Result ?? throw new Exception("Element is null");
            return Regex.Replace(t, @"&nbsp;|[\u00A0]", "");
        }

        public static async Task<List<string>> GetListOfTexts(string selector)
        {
            List<string> list = new List<string>();
            await WaitUntil.CustomElementIsVisible(selector);
            var t = Browser.Driver.QuerySelectorAllAsync(selector).Result.ToList();
            foreach(var item in t)
            {
                var text = item.TextContentAsync().Result;
                list.Add(Regex.Replace(text, @"&nbsp;|[\u00A0]|&ZeroWidthSpace;|[\u200B]", ""));
            }
            return list;
        }
    }

    public class Element
    {
        private static async Task<string?> GetTextContent(IElementHandle element, string selector)
        {
            var queryResult = await element.QuerySelectorAsync(selector);
            return queryResult != null ? await queryResult.TextContentAsync() : null;
        }

        public static async Task<IElementHandle> FindSpecificDreamhome(string titleDreamhome)
        {

            await WaitUntil.CustomElementIsVisible($"//tbody/tr/td[text()='{titleDreamhome}']");
            return await Browser.Driver.QuerySelectorAsync($"//tbody/tr/td[text()='{titleDreamhome}']") ?? throw new Exception("Dreamhome is not find");

        }

        public static async Task<UserRowModel> FindSpecificUser(string email)
        {
            await WaitUntil.CustomElementIsVisible($"//td[text()='{email}']");

            UserRowModel user = new()
            {
                Name = await Browser.Driver.QuerySelectorAsync($"//td[text()='{email}']/parent::tr/td[1]").Result.TextContentAsync(),
                Surname = await Browser.Driver.QuerySelectorAsync($"//td[text()='{email}']/parent::tr/td[2]").Result.TextContentAsync(),
                Email = await Browser.Driver.QuerySelectorAsync($"//td[text()='{email}']").Result.TextContentAsync(),
                Phone = await Browser.Driver.QuerySelectorAsync($"//td[text()='{email}']/parent::tr/td[4]").Result.TextContentAsync(),
                toggleStatus = $"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Show']",
                btnShow = $"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Show']",
                btnEdit = $"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/a[@aria-label='Edit']",
                btnDelete = $"//td[text()='{email}']/parent::tr//div[@class='actions-table-body']/div"
            };

            return user;
        }

        public class UserRowModel
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public string? toggleStatus { get; set; }
            public string? btnShow { get; set; }
            public string? btnEdit { get; set; }
            public string? btnDelete { get; set; }
        }

        public static async Task<List<CompetitionRowModel>> FindSpecificCompetitionRows(string competition)
        {
            await WaitUntil.CustomElementIsInvisible(CmsUserManagement.textNoOrders);
            await WaitUntil.CustomElementIsVisible($"//td[text()='{competition}']");

            var competitionRowElements = await Browser.Driver.QuerySelectorAllAsync($"//td[text()='{competition}']/parent::tbody");
            var listOfCompetitions = new List<CompetitionRowModel>();

            foreach (var item in competitionRowElements)
            {
                var competitionRow = new CompetitionRowModel
                {
                    Competition = await GetTextContent(item, "table > tbody > td:nth-child(1)"),
                    Product = await GetTextContent(item, "table > tbody > td:nth-child(2)"),
                    NumberOfTickets = await GetTextContent(item, "table > tbody > td:nth-child(3)"),
                    DrawDate = await GetTextContent(item, "table > tbody > td:nth-child(4)"),
                    btnShowtickets = "table > tbody > td:nth-child(5) > div > svg:nth-child(1)",
                    btnEditTickets = "table > tbody > td:nth-child(5) > div > svg:nth-child(2)",
                    btnDeleteTickets = "table > tbody > td:nth-child(5) > div > div > svg:nth-child(1)"
                };

                listOfCompetitions.Add(competitionRow);
            }

            return listOfCompetitions;
        }

        public class CompetitionRowModel
        {
            public string? Competition { get; set; }
            public string? Product { get; set; }
            public string? NumberOfTickets { get; set; }
            public string? DrawDate { get; set; }
            public string? btnShowtickets { get; set; }
            public string? btnEditTickets { get; set; }
            public string? btnDeleteTickets { get; set; }
        }

        public static async Task Action(string key)
        {
            await Browser.Driver.WaitForTimeoutAsync(700);
            await Browser.Driver.Keyboard.PressAsync(key);
            await Browser.Driver.WaitForTimeoutAsync(300);
        }

    }

    public class PutsBox
    {

        private static string GetHtmlUrl(string email)
        {
            string arg = email[..email.IndexOf('@')];
            return $"https://preview.putsbox.com/p/{arg}/last.html";
        }
        private static string GetHtmlUrl(string email, string id)
        {
            string arg = email[..email.IndexOf('@')];
            return $"https://preview.putsbox.com/p/{arg}/{id}.html";
        }
        private static string GetHtmlUrlToInspect(string email)
        {
            string arg = email[..email.IndexOf('@')];
            return $"https://putsbox.com/{arg}/inspect";
        }
        private static string GetJsonUrl(string email)
        {
            string arg = email[..email.IndexOf('@')];
            return $"https://preview.putsbox.com/p/{arg}/last.json";
        }

        private static string GetBodyData(string value)
        {
            int startIndex = value.IndexOf("body");
            return value.Substring(startIndex);
        }

        private static string Decode(string rawData)
        {
            return Regex.Unescape(rawData);
        }

        private static PutsboxWrapper.Email ParseAllLinks(string rawData)
        {
            PutsboxWrapper.Email email = new();
            Collection<PutsboxWrapper.Link> collection = new();
            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(rawData);
            foreach (HtmlNode item in htmlDocument.DocumentNode.QuerySelectorAll("a"))
            {
                collection.Add(new PutsboxWrapper.Link
                {
                    Name = item.InnerText,
                    Url = item.GetAttributeValue("href", null)
                });
            }

            email.Link = collection;
            return email;
        }

        private static string ParseAllText(string rawData)
        {
            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(rawData);
            StringBuilder sb = new();
            foreach (HtmlNode item in htmlDocument.DocumentNode.QuerySelectorAll("p"))
            {
                sb.AppendLine(item.InnerText);
            }

            return sb.ToString();
        }

        private static string GetJsonContent(string email)
        {
            RestClient client = new(GetJsonUrl(email));
            RestRequest request = new("");
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
        }

        private static string GetHtmlContent(string email)
        {
            RestClient client = new(GetHtmlUrl(email));
            RestRequest request = new("");
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
        }

        private static async Task<string> GetHtmlContent(string email, string id)
        {
            RestClient client = new(GetHtmlUrl(email, id));
            RestRequest request = new("");
            var response = await client.ExecuteGetAsync(request);
            return response.Content ?? throw new Exception("Content is null.");
        }

        private static string GetEmailContent(string email)
        {
            RestClient client = new(GetHtmlUrlToInspect(email));
            RestRequest request = new("");
            return client.ExecuteGetAsync(request).Result.Content ?? throw new Exception("Content is null.");
        }

        public static string GetLinkFromEmailWithValue(string domain, string value)
        {
            var maxTime = TimeSpan.FromMinutes(5);
            var stopWatch = Stopwatch.StartNew();
            Thread.Sleep(2000);
            string jsonContent = GetJsonContent(domain);
            while(stopWatch.Elapsed <= maxTime)
            {
                if (!jsonContent.Contains("Not Found"))
                {
                    jsonContent = GetJsonContent(domain);
                    break;
                }
                Thread.Sleep(10000);
            }
            stopWatch.Stop();

            string text = Decode(jsonContent);
            GetBodyData(text);
            return ParseAllLinks(text).Link.First((PutsboxWrapper.Link x) => x.Name == value).Url ?? throw new Exception("URL is null.");
        }

        public static string GetTextFromEmailWithValue(string domain, string value)
        {
            var maxTime = TimeSpan.FromMinutes(5);
            var stopWatch = Stopwatch.StartNew();
            Thread.Sleep(2000);
            string jsonContent = GetJsonContent(domain);
            while (stopWatch.Elapsed <= maxTime)
            {
                if (!jsonContent.Contains("Not Found"))
                {
                    jsonContent = GetJsonContent(domain);
                    break;
                }
                Thread.Sleep(10000);
            }
            stopWatch.Stop();

            string text = Decode(jsonContent);
            GetBodyData(text);
            string[] texts = ParseAllText(text)
                .Split(Environment.NewLine)
                .Where(x => x.Contains(value))
                .ToArray();
            return ParseAllText(text).Split(Environment.NewLine).Where(x => x.Contains(value)).FirstOrDefault().Replace($"{value}", "");
        }

        public static string GetHtmlFromEmail(string domain)
        {
            var maxTime = TimeSpan.FromMinutes(5);
            var stopWatch = Stopwatch.StartNew();
            Thread.Sleep(2000);
            string Content = GetHtmlContent(domain);
            while(stopWatch.Elapsed <= maxTime)
            {
                if (!Content.Contains("Not Found"))
                {
                    Content = GetHtmlContent(domain);
                    break;
                }
                Thread.Sleep(10000);
            }
            stopWatch.Stop();

            string text = Decode(Content);
            return text;
        }

        public static async Task<string> GetHtmlFromEmail(string domain, string id)
        {
            var maxTime = TimeSpan.FromMinutes(5);
            var stopWatch = Stopwatch.StartNew();
            Thread.Sleep(2000);
            string Content = GetHtmlContent(domain, id).Result;
            while (stopWatch.Elapsed <= maxTime)
            {
                if (!Content.Contains("Not Found"))
                {
                    Content = GetHtmlContent(domain, id).Result;
                    break;
                }
                Thread.Sleep(10000);
            }
            stopWatch.Stop();

            string text = Decode(Content);
            return text;
        }

        public static async Task<List<PutsboxEmail>?> GetAllEmails(string domain)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(2);
            var stopWatch = Stopwatch.StartNew();
            int checkInterval = 10000;
            var htmlContent = GetEmailContent(domain);

            while (stopWatch.Elapsed <= maxWaitTime) // loop for 35 minutes
            {
                if (!htmlContent.Contains("Not Found"))
                {
                    break;
                }
                await Task.Delay(checkInterval);
                htmlContent = GetEmailContent(domain);
            }
            stopWatch.Stop();
            return JsonConvert.DeserializeObject<List<PutsboxEmail>?>(htmlContent);
        }

    }

    public class Xitroo
    {
        public const string nameTab = "//*[contains(text(),'qatester')]";

        public const string nameEmailSubject = "//tbody//td[1]";
    }

    public class Elements
    {

        public static async Task EnterText(string element, string text)
        {
            await WaitUntil.CustomElementIsVisible(element);
            await Browser.Driver.Keyboard.PressAsync("Control+A");
            await Browser.Driver.Keyboard.PressAsync("Backspace");
            await Browser.Driver.QuerySelectorAsync(element).Result.FillAsync(text);
        }

        public static async Task<string> GetAttribute(string element, string attribute)
        {
            await WaitUntil.CustomElementIsVisible(element);
            return Browser.Driver.QuerySelectorAsync(element).Result.GetAttributeAsync(attribute).Result;
        }

        public static async Task ScrollTo(string element)
        {
            await WaitUntil.CustomElementIsVisible(element);
            await Browser.Driver.QuerySelectorAsync(element).Result.ScrollIntoViewIfNeededAsync();
        }


        public static async Task GoToActivationLink(string email)
        {
            var activateLink = PutsBox.GetLinkFromEmailWithValue(email, "Activate account");
            await Browser.Navigate(activateLink);
        }


        public static void GgetHtmlBody(string email, out string emailInitial)
        {
            emailInitial = PutsBox.GetHtmlFromEmail(email);
        }

        //
        public static void GgetHtmlBody(string email, string id, out string emailInitial)
        {
            emailInitial = PutsBox.GetHtmlFromEmail(email, id).Result;
        }

        //
        public static async Task<List<PutsboxEmail>?> GgetAllEmailData(string email)
        {
            var emailList = await PutsBox.GetAllEmails(email);
            SubscriptionsRequest.CheckEmailsCountFor35Minutes(emailList, email);
            emailList = await PutsBox.GetAllEmails(email);

            return emailList;
        }

    }
}
