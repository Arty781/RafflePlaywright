

namespace Playwright.PageObjects
{
    public partial class CmsLogin
    {

        public static async Task EnterLoginAndPassword(string email, string password)
        {
            await InputBox.Element(inputEmail, email);
            await InputBox.Element(inputPassword, password);
        }


        public static async Task ClickSignInBtn()
        {
            await Button.Click(btnSignIn);
        }



    }
}
