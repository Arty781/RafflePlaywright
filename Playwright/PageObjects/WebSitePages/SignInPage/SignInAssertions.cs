namespace PlaywrightRaffle.PageObjects
{
    public partial class SignIn
    {

        public static async Task<string> VerifyIsSignIn()
        {
            await WaitUntil.CustomElementIsVisible(Profile.inputFirstName);
            return await TextBox.GetAttribute(Profile.inputFirstName, "value");
        }


        public static async Task<string> GetFirstName()
        {
            await WaitUntil.CustomElementIsVisible(Profile.inputFirstName);
            return await TextBox.GetAttribute(Profile.inputFirstName, "value");
        }


        public static async Task VerifyDisplayingEmailErrorMessage()
        {
            await WaitUntil.CustomElementIsVisible(textEmailErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textEmailErrorMessage)).IsVisibleAsync().Result, Is.True, "Email error message is not displayed");
        }


        public static async Task VerifyDisplayingPasswordErrorMessage()
        {
            await WaitUntil.CustomElementIsVisible(textPasswordErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textPasswordErrorMessage)).IsVisibleAsync().Result, Is.True, "Password error message is not displayed");
        }


        public static async Task VerifyValidationOnSignIn(SignUpResponse response)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        await EnterLoginAndPass("", Credentials.PASSWORD);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        await EnterLoginAndPass(response.User.Email.Replace("@p", "@ p"), Credentials.PASSWORD);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        await EnterLoginAndPass(response.User.Email.Replace(".com", ""), Credentials.PASSWORD);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        await EnterLoginAndPass(response.User.Email, "");
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 4:
                        await EnterLoginAndPass(response.User.Email, "qwertyzaq");
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 5:
                        await EnterLoginAndPass(response.User.Email, "123456789");
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 6:
                        await EnterLoginAndPass(response.User.Email, "Qaz1");
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                }
            }
        }

    }
}
