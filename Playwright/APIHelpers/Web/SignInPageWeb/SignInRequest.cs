﻿using Chilkat;

namespace PlaywrightRaffle.APIHelpers.Web.SignIn
{
    public class SignInRequestWeb
    {

        public static string RequestBuilder(string login, string password)
        {
            SignInRequestModelWeb req = new()
            {
                Email = login,
                Password = password
            };
            return JsonConvert.SerializeObject(req);
        }

        public static void MakeSignIn(string login, string password, out SignInResponseModelWeb? token)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/users/signin",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.LoadBodyFromString(RequestBuilder(login, password), charset: "utf-8");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            token = JsonConvert.DeserializeObject<SignInResponseModelWeb>(resp.BodyStr);
        }

        public static async Task<SignInResponseModelWeb?> MakeSignIn(string login, string password)
        {
            await System.Threading.Tasks.Task.Delay(500);
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/users/signin",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.LoadBodyFromString(RequestBuilder(login, password), charset: "utf-8");

            Http http = new Http();

            var resp = http.SynchronousRequestAsync(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            var s = resp.GetResultBytes();
            return JsonConvert.DeserializeObject<SignInResponseModelWeb>(s.ToString());
        }

    }
}
