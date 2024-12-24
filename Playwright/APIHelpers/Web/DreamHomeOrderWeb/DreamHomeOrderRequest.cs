using Chilkat;

namespace PlaywrightRaffle.APIHelpers.Web
{
    public class DreamHomeOrderRequestWeb
    {
        public static class SubscriptionList
        {
            private static readonly List<SubscriptionRequestModel> Subscriptions = new();

            static SubscriptionList()
            {
                AddSubscription("", 1000, 5, 40, "642d5866f2d6b25c843fcc99", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 1);
                AddSubscription("", 3000, 15, 165, "667946903b19fe0033a827d2", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 1);
                AddSubscription("", 5000, 25, 425, "666ae7798dd015003297b4ca", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 1);
                AddSubscription("", 8100, 15, 165, "667946903b19fe0033a827d2", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 3);
                AddSubscription("", 13500, 25, 425, "666ae7798dd015003297b4ca", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 3);
                AddSubscription("", 14400, 15, 165, "667946903b19fe0033a827d2", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 6);
                AddSubscription("", 24000, 25, 425, "666ae7798dd015003297b4ca", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 6);
                AddSubscription("", 25200, 15, 165, "667946903b19fe0033a827d2", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 12);
                AddSubscription("", 42000, 25, 425, "666ae7798dd015003297b4ca", 0, "PENDING_BASKET", "67473dc94102530049ecddbd", 12);
            }

            private static void AddSubscription(
                string charity, int totalCost, int numOfTickets, int extra,
                string subscriptionModel, int count, string status, string raffle, int months)
            {
                Subscriptions.Add(new SubscriptionRequestModel
                {
                    subscription = new Subscription
                    {
                        charity = charity,
                        totalCost = totalCost,
                        numOfTickets = numOfTickets,
                        extra = extra,
                        subscriptionModel = subscriptionModel,
                        count = count,
                        status = status,
                        raffle = raffle,
                        months = months
                    }
                });
            }

            public static SubscriptionRequestModel GetRandomSubscription()
            {
                var random = new Random(); 
                return Subscriptions[random.Next(Subscriptions.Count)];
            }
        }

        private static string RequestBuilder(string id)
        {
            DreamHomeOrderRequestModel req = new()
            {
                NumOfTickets = "150", //$"{RandomHelper.RandomNumber()}",
                PrizeType = "raffle",
                PrizeId = id
            };

            return JsonConvert.SerializeObject(req);
        }

        private static string RequestSubscriptionBuilder()
        {
            return JsonConvert.SerializeObject(SubscriptionList.GetRandomSubscription());
        }
        private static string RequestBuilderWithError(string id, int numOfTickets)
        {
            DreamHomeOrderRequestModel req = new()
            {
                NumOfTickets = $"{numOfTickets}",
                PrizeType = "raffle",
                PrizeId = id
            };

            return JsonConvert.SerializeObject(req);
        }

        public static async Task<DreamHomeOrderResponseModelWeb?> AddDreamhomeTickets(SignInResponseModelWeb SignIn, CountdownResponseModelDreamHomeWeb countdown)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/orders"

            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.AddHeader("authorization", $"Bearer {SignIn.Token}");
            req.LoadBodyFromString(RequestBuilder(countdown.Id), charset: "utf-8");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            var response = JsonConvert.DeserializeObject<DreamHomeOrderResponseModelWeb>(resp.BodyStr);
            Assert.That(response.Message, Is.EqualTo("Order created!"), "Order is not created");
            await WaitUntil.WaitSomeInterval(250);
            return response;

        }

        public static DreamHomeOrderResponseModelWeb? AddDreamhomeTicketsForError(SignInResponseModelWeb SignIn, CountdownResponseModelDreamHomeWeb countdown, int numOfTickets)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/orders",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.AddHeader("authorization", $"Bearer {SignIn.Token}");
            req.LoadBodyFromString(RequestBuilderWithError(countdown.Id, numOfTickets), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            var response = JsonConvert.DeserializeObject<DreamHomeOrderResponseModelWeb>(resp.BodyStr);

            return response;
        }

        public static async System.Threading.Tasks.Task MultipleAddDreamhomeTickets(SignInResponseModelWeb SignIn, CountdownResponseModelDreamHomeWeb countdown, int numOfRepetitions)
        {
            for (int i = 0; i < numOfRepetitions; i++)
            {
                await AddDreamhomeTickets(SignIn, countdown);
                await WaitUntil.WaitSomeInterval(250);
            }

        }

        public static async Task<DreamHomeOrderResponseModelWeb?> AddSubscriptions(SignInResponseModelWeb SignIn)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/subscriptions"

            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.AddHeader("authorization", $"Bearer {SignIn.Token}");
            req.LoadBodyFromString(RequestSubscriptionBuilder(), charset: "utf-8");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            var response = JsonConvert.DeserializeObject<DreamHomeOrderResponseModelWeb>(resp.BodyStr);
            Assert.That(response.Message, Is.EqualTo("Subscription created!"), "Order is not created");
            await WaitUntil.WaitSomeInterval(250);
            return response;

        }
    }
}
