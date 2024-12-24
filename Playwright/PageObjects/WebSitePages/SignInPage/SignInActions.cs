

namespace PlaywrightRaffle.PageObjects
{
    public partial class SignIn
    {

        public static async Task EnterLoginAndPass(string login, string password)
        {
            await WaitUntil.CustomElementIsVisible(inputLogin);
            await InputBox.Element(inputLogin, login);
            await InputBox.Element(inputPassword, password);
            await Button.Click(btnSignIn);
        }

        public static async Task EnterLoginAndPass(IPage page, string login, string password)
        {
            await WaitUntil.CustomElementIsVisible(page, inputLogin);
            await InputBox.Element(page, inputLogin, login);
            await InputBox.Element(page, inputPassword, password);
            await Button.Click(page, btnSignIn);
        }


        public static async Task MakeSignIn(string login, string password)
        {
            await Browser.Navigate(WebEndpoints.SIGN_IN);
            await InputBox.Element(inputLogin, login);
            await InputBox.Element(inputPassword, password);
            await Button.Click(btnSignIn);
        }


        public static async Task ClickForgotPassword()
        {
            await Button.Click(btnForgotPassword);
        }

    }
}
