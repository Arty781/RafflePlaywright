using Chilkat;
using Playwright.APIHelpers.Web.Basket;

namespace Playwright.PageObjects
{
    public partial class gr4vy
    {
        
        public class KlavioList
        {
            [JsonProperty("data")]
            public List<Data> Data { get; set; }
        }

        public class Data
        {
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        private static string Body(List<DbModels.UserResponse> users)
        {
            List<Data> dataList = new List<Data>();

            foreach (var user in users)
            {
                Data userData = new Data
                {
                    Type = "profile",
                    Id = user.KlaviyoId
                };
                dataList.Add(userData);
            }

            KlavioList data = new KlavioList
            {
                Data = dataList
            };

            return JsonConvert.SerializeObject(data);
        }



        public static void AddUsersToKlavio(List<DbModels.UserResponse> users)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/lists/YdpuXx/relationships/profiles",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.AddHeader("authorization", $"Klaviyo-API-Key pk_fcab64dd1d921d2e4a77be26e5f9a091fe");
            req.LoadBodyFromString(Body(users), charset: "utf-8");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest("a.klaviyo.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

        }
    }
}
