using Chilkat;

namespace PlaywrightRaffle.APIHelpers.Web
{
    public partial class HomeDataRequestWeb
    {
        public static async Task<HomeData?> GetHomeData()
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"/api/raffles/home/data/",
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
            var response = JsonConvert.DeserializeObject<HomeData?>(resp.BodyStr);
            return response;
        }

        
    }
}
