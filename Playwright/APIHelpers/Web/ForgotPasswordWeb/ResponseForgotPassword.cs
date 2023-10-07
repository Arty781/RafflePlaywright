﻿namespace Playwright.APIHelpers.Web.ForgotPasswordWeb
{
    public class RequestForgot
    {
        [JsonProperty("email")]
        public string? Email { get; set; }
    }
    public class ResponseForgotPassword
    {
        [JsonProperty("message")]
        public string? Message { get; set; }
    }

    public class RequestReset
    {
        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }
    }

    public class ResponseResetPassword
    {
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
