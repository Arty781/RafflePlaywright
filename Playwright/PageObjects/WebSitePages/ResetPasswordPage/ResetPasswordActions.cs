using RimuTec.Faker;
using YamlDotNet.Core.Tokens;
using static PlaywrightRaffle.APIHelpers.Web.Subscriptions.SubsriptionsResponse;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightRaffle.PageObjects
{
    public partial class ResetPasswordPage
    {

        public static async Task RequestForgotPassword(string email)
        {
            await InputBox.Element(inputEmail, email);
            await Button.Click(btnRequest);
        }


        public static async Task ClickOkBtn()
        {
            await Button.Click(btnOk);
        }


        public static async Task GoToResetPassLink(string email)
        {
            //var resetPassLink = PutsBox.GetLinkFromEmailWithValue(email, "Reset Password");
            //await Browser.Navigate(resetPassLink);

            TimeSpan maxWaitTime = TimeSpan.FromMinutes(35);
            List<PutsboxEmail>? emailsList = await Elements.GgetAllEmailData(email);
            if (emailsList.Where(x => x.subject == "Password Reset").Select(q => q.id).Count() <= 1)
            {
                var stopwatch = Stopwatch.StartNew();
                while (stopwatch.Elapsed <= maxWaitTime)
                {
                    emailsList = await Elements.GgetAllEmailData(email);
                    if (emailsList.Where(x => x.subject == "Password Reset").Select(q => q.id).Count() == 1)
                    {
                        break;
                    }
                    await Task.Delay(5000);
                }
                stopwatch.Stop();
            }
            var id = emailsList.Where(x => x.subject == "Password Reset").Select(q => q.id).FirstOrDefault();
            string emailInitial = Elements.GgetHtmlBody(email, id).Result;
            var link = PutsBox.ParseAllLinks(emailInitial).Link.First((PutsboxWrapper.Link x) => x.Name == "Reset Password").Url ?? throw new Exception("URL not found");
            await Browser.Navigate(link);
        }


        public static async Task GetResetPassword()
        {
            await InputBox.Element(inputPassword, Credentials.NEW_PASWORD);
            await InputBox.Element(inputConfirmPassword, Credentials.NEW_PASWORD);
            await Button.Click(btnSetNewPassword);
        }
    }
}
