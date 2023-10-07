namespace Playwright.PageObjects
{
    public partial class SignUp
    {
        public static async Task<string> GetEmail()
        {
            await WaitUntil.CustomElementIsVisible(SignUp.inputEmail);
            var getEmail = await Browser.Driver.GetAttributeAsync(inputEmail, "value");
            return getEmail.ToLower();
        }


        public static async Task VerifyEmail(string email)
        {
            await WaitUntil.CustomElementIsVisible(Profile.titleProfile);
            var emailFld = await Browser.Driver.GetAttributeAsync(inputEmail, "value");
            Assert.That(emailFld.ToLower(), Is.EqualTo(email.ToLower()));
        }


        public static async Task VerifyVisibilityOfToaster(string email)
        {
            string s = PutsBox.GetLinkFromEmailWithValue(email, "Verify");
            await Browser.Driver.GotoAsync(s);
            await WaitUntil.CustomElementIsVisible(toasterSuccessMessage);
        }


        public static async Task VerifyDisplayingFirstNameErrorMessage()
        {
            await WaitUntil.CustomElementIsVisible(textFirstNameErrorMessage);
            Assert.That(await Browser.Driver.QuerySelectorAsync(textFirstNameErrorMessage).Result.IsVisibleAsync(), Is.True, "First name error message is not displayed");
        }


        public static async Task VerifyDisplayingLastNameErrorMessage()
        {
            await WaitUntil.CustomElementIsVisible(textLastNameErrorMessage);
            Assert.That(await Browser.Driver.QuerySelectorAsync(textLastNameErrorMessage).Result.IsVisibleAsync(), Is.True, "Last name error message is not displayed");
        }


        public static async Task VerifyDisplayingEmailErrorMessage()
        {
            await WaitUntil.CustomElementIsVisible(textEmailErrorMessage);
            Assert.IsTrue(await Browser.Driver.QuerySelectorAsync(textEmailErrorMessage).Result.IsVisibleAsync(), "Email error message is not displayed");
        }


        public static async Task VerifyDisplayingPhoneErrorMessage()
        {
            await WaitUntil.CustomElementIsVisible(textPhoneErrorMessage);
            Assert.IsTrue(await Browser.Driver.QuerySelectorAsync(textPhoneErrorMessage).Result.IsVisibleAsync(), "Phone error message is not displayed");
        }


        public static async Task VerifyDisplayingPasswordErrorMessage()
        {
            await WaitUntil.CustomElementIsVisible(textPasswordErrorMessage);
            Assert.IsTrue(await Browser.Driver.QuerySelectorAsync(textPasswordErrorMessage).Result.IsVisibleAsync(), "Password error message is not displayed");
        }


        public static async Task VerifyFirstnameValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "");
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "q");
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Lorem.ParagraphByChars(51).Trim(' ')); //51 characters
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "qwe1234");
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "Qqweqe!@#$%");
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                }
            }
        }


        public static async Task VerifyLastnameValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, "");
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, "q");
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Lorem.ParagraphByChars(51).Trim(' ')); //51 characters
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, "qqweq123132");
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, "QWaass$%^&*");
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                }
            }
        }


        public static async Task VerifyEmailValidationOnSignUp()
        {
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + " @putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11111");
                        await ClickSignUpBtn();
                        await VerifyDisplayingEmailErrorMessage();
                        break;


                }
            }
        }


        public static async Task VerifyPasswordValidationOnSignUp()
        {
            for (int i = 0; i <= 5; i++)
            {
                switch (i)
                {

                    case 0:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz11");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "Qaz123456789012345678"); //21 characters
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "qwertyi");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "1234567");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;
                    case 5:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputSurname, Name.LastName());
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await InputBox.Element(inputPassword, "!@#$%^&");
                        await ClickSignUpBtn();
                        await VerifyDisplayingPasswordErrorMessage();
                        break;

                }
            }
        }
    }
}
