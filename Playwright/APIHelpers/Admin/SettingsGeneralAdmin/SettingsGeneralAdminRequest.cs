﻿using Chilkat;

namespace PlaywrightRaffle.APIHelpers.Admin
{
    public class SettingsGeneralAdmin
    {

        public static string SignIn(string login, string password)
        {

            SignInRequestModelWeb req = new()
            {
                Email = login,
                Password = password
            };
            return JsonConvert.SerializeObject(req);
        }

        public static SettingsGeneralAdminResponseModel? MakeAdminSignIn(string login, string password)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/users/cms/signin",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.LoadBodyFromString(SignIn(login, password), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            var token = JsonConvert.DeserializeObject<SettingsGeneralAdminResponseModel>(resp.BodyStr);

            return token;
        }

    }
}
