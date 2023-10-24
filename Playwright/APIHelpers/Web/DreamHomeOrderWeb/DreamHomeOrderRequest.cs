using Chilkat;

namespace PlaywrightRaffle.APIHelpers.Web
{
    public class DreamHomeOrderRequestWeb
    {
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

    }
}
