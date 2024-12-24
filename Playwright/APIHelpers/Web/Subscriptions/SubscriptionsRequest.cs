using Chilkat;
using Newtonsoft.Json.Linq;
using SharpCompress.Common;
using static PlaywrightRaffle.APIHelpers.Web.Subscriptions.SubsriptionsResponse;

namespace PlaywrightRaffle.APIHelpers.Web.Subscriptions
{
    public class SubscriptionsRequest
    {
        public static SubsriptionsResponse.Subscriptions? GetActiveSubscriptions()
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"/api/subscription-models/active",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            var response = JsonConvert.DeserializeObject<SubsriptionsResponse.Subscriptions>(resp.BodyStr);
            return response;
        }

        public static SubsriptionsResponse.Subscriptions? AddSubscriptions(SubsriptionsResponse.Subscriptions activeSub)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"/api/subscriptions",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.LoadBodyFromString(JsonBody(activeSub), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            var response = JsonConvert.DeserializeObject<SubsriptionsResponse.Subscriptions>(resp.BodyStr);
            return response;
        }

        public static SubsriptionsResponse.EmailsList? GetEmailsCount(string email)
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"/{email[..email.IndexOf('@')]}/requests_count",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("putsbox.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            // Split the input string into event and data parts
            string[] parts = resp.BodyStr.Split('\n');
            string eventData = parts[1].Substring("data: ".Length);

            // Parse the JSON data using Newtonsoft.Json
            JObject data = JObject.Parse(eventData);

            // Create a new JObject for the final result
            JObject result = new JObject();
            result["event"] = parts[0].Substring("event: ".Length);
            result["data"] = data;

            // Convert the JObject to JSON string
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            var response = JsonConvert.DeserializeObject<SubsriptionsResponse.EmailsList>(json);
            return response;
        }

        public static void CheckStatusFor17Minutes(DbModels.Subscriptions userSub, DbModels.UserResponse user)
        {
            DateTime startTime = DateTime.Now;
            int checkInterval = 60000; // in milliseconds
            bool statusChanged = false;
            int minutes = 17;

            while (DateTime.Now - startTime < TimeSpan.FromMinutes(minutes)) // loop for 15 minutes
            {
                if (userSub.Status != "FINISHED")
                {
                    Thread.Sleep(checkInterval); // wait for 60 seconds before checking again
                    userSub = AppDbHelper.Subscriptions.GetSubscriptionByUserId(user);
                }
                else
                {
                    statusChanged = true;
                    Console.WriteLine("Subscription status is FINISHED.");
                    break; // exit the loop since the status has changed
                }
            }

            if (!statusChanged)
            {
                throw new Exception($"Subscription status did not change within {minutes} minutes.");
            }
        }

        public static void CheckEmailsCountFor35Minutes(List<PutsboxEmail>? userEmails, string email)
        {
            TimeSpan maxWaitTime = TimeSpan.FromMinutes(35);
            var stopWatch = Stopwatch.StartNew();
            DateTime startTime = DateTime.Now;
            int checkInterval = 30000; // in milliseconds
            bool statusChanged = false;

            while (stopWatch.Elapsed <= maxWaitTime) // loop for 35 minutes
            {
                switch (userEmails.Any(x => x != null && !x.subject.Contains("How many stars would you give")))
                {
                    case false:
                        Thread.Sleep(checkInterval); // wait for 30 seconds before checking again
                        userEmails = PutsBox.GetAllEmails(email).Result;
                        break;

                    case true:
                        statusChanged = true;
                        goto LoopExit; // exit the loop since the status has changed

                }


            }
            stopWatch.Stop();
        LoopExit:
            // Continue with the rest of the code outside the switch statement            
            if (!statusChanged)
            {
                throw new Exception($"Subscription status did not change within {maxWaitTime.Minutes} minutes.");
            }
        }

        public static void ParseHTML(string html)
        {
            HtmlDocument doc = new();
            doc.LoadHtml(html); // Load the HTML document from a string
            dynamic jsonObj = new Newtonsoft.Json.Linq.JObject(); // Create a JSON object
            HtmlNode root = doc.DocumentNode;
            TraverseNodes(root, jsonObj); // Traverse the HTML document and add nodes to the JSON object
            string jsonStr = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            // Helper method to traverse HTML nodes and add them to the JSON object
            void TraverseNodes(HtmlNode node, dynamic obj)
            {
                switch (node.NodeType)
                {
                    case HtmlNodeType.Document:
                        TraverseNodes(node, obj);
                        break;
                    case HtmlNodeType.Element:
                        dynamic elemObj = new Newtonsoft.Json.Linq.JObject();
                        obj[node.Name] = elemObj;
                        foreach (var attr in node.Attributes)
                        {
                            elemObj[attr.Name] = attr.Value;
                        }
                        foreach (var childNode in node.ChildNodes)
                        {
                            TraverseNodes(childNode, elemObj);
                        }
                        break;
                    case HtmlNodeType.Text:
                        obj["text"] = node.InnerText;
                        break;
                    case HtmlNodeType.Comment:
                        obj["comment"] = node.InnerText;
                        break;
                }
            }
        }

        private static string JsonBody(SubsriptionsResponse.Subscriptions activeSub)
        {
            var body = new SubsriptionsResponse.SubscriptionsReq()
            {
                subscription = new SubsriptionsResponse.Subscription
                {
                    charity = "",
                    totalCost = activeSub.SubscriptionModels.FirstOrDefault().TotalCost,
                    numOfTickets = activeSub.SubscriptionModels.FirstOrDefault().NumOfTickets,
                    extra = activeSub.SubscriptionModels.FirstOrDefault().Extra,
                    subscriptionModel = activeSub.SubscriptionModels.FirstOrDefault().Id,
                    count = 0,
                    status = "PENDING_BASKET",
                    raffle = ""
                }
            };


            return JsonConvert.SerializeObject(body);
        }

    }
}
