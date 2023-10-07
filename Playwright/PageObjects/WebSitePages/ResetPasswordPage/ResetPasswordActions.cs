namespace Playwright.PageObjects
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
            var resetPassLink = PutsBox.GetLinkFromEmailWithValue(email, "Reset Password");
            await Browser.Navigate(resetPassLink);
        }


        public static async Task GetResetPassword()
        {
            await InputBox.Element(inputPassword, Credentials.NEW_PASWORD);
            await InputBox.Element(inputConfirmPassword, Credentials.NEW_PASWORD);
            await Button.Click(btnSetNewPassword);
        }
    }
}
