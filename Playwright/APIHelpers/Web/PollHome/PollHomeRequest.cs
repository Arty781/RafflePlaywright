using Chilkat;
using PlaywrightRaffle.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightRaffle.APIHelpers.Web.PollHome
{
    public partial class PollHome
    {
        private static string RequestBuilder()
        {
            string[] pollBullets = new string[3]
            {
                "home","travel","share"
            };

            PollRequest req = new()
            {
                data = new() 
                { 
                    value = pollBullets[RandomHelper.RandomNumber(3)]
                },
                values = string.Join(",", pollBullets)
            };
            return JsonConvert.SerializeObject(req);
        }

        public static void MakePollRandomVote(SignInResponseModelWeb signIn, out PollResponse? content)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/votes/65b00942e3ed2d338070a572/create",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.AddHeader("authorization", $"Bearer {signIn.Token}");
            req.LoadBodyFromString(RequestBuilder(), charset: "utf-8");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            content = JsonConvert.DeserializeObject<PollResponse>(resp.BodyStr);
        }
    }
}
