namespace PlaywrightRaffle.PageObjects
{
    public partial class Profile
    {

        public static async Task VerifyDisplayingSuccessfullToaster()
        {
            await WaitUntil.WaitSomeInterval(350);
            await WaitUntil.CustomElementIsVisible(SuccessUpdateDialog);
        }


        public static async Task VerifyUpdatePasswordSuccessfullToaster()
        {
            await WaitUntil.WaitSomeInterval(350);
            await WaitUntil.CustomElementIsVisible(SuccessUpdatePasswordDialog);
        }


        public static async Task VerifyAddingTickets(double price, int countOrders)
        {
            await WaitUntil.CustomElementIsVisible(prizePrice);
            for (int i = 0; i < countOrders; i++)
            {
                await (await Browser.Driver.QuerySelectorAllAsync(prizeName)).Last().ScrollIntoViewIfNeededAsync();
                await Browser.Driver.WaitForTimeoutAsync(250);
            }
            var item = await OrderHistoryVerificator.GetOrderHistory((await Browser.Driver.QuerySelectorAllAsync(prizePrice)).ToList(), countOrders);
            Assert.That((double)item.Item2, Is.EqualTo(price), $"Order total is not matched. Expected {price}, but was {(double)item.Item2}");

        }


        public static async Task VerifyDisplayingFirstNameErrorMessage()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(textFirstNameErrorMessage);
        }


        public static async Task VerifyDisplayingLastNameErrorMessage()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(textLastNameErrorMessage);
        }


        public static async Task VerifyDisplayingEmailErrorMessage()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(textEmailErrorMessage);
        }


        public static async Task VerifyDisplayingPhoneErrorMessage()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(textPhoneErrorMessage);
        }


        public static async Task VerifyDisplayingOldPasswordErrorMessage()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(textOldPasswordErrorMessage);
        }


        public static async Task VerifyDisplayingNewPasswordErrorMessage()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(textNewPasswordErrorMessage);
        }


        public static async Task VerifyDisplayingConfirmPasswordErrorMessage()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(textConfirmPasswordErrorMessage);
        }


        public static async Task VerifyValidationOnProfilePersonalDetails()
        {
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "");
                        await InputBox.Element(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "q");
                        await InputBox.Element(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "qtweqweqwueyqwyfeasdasgdjadasdasdasgdjadasdasdasgdjadasda"); //more than 50 characters
                        await InputBox.Element(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "qwe1234");
                        await InputBox.Element(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, "Qqweqe!@#$%");
                        await InputBox.Element(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 5:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputLastName, "");
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 6:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputLastName, "q");
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 7:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputLastName, "qtweqweqwueyqwyfeasdasgdjadasdasdasgdjadasdasdasgdjadasda"); //more than 50 characters
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 8:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputLastName, "qqweq123132");
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 9:
                        await WaitUntil.CustomElementIsVisible(inputFirstName);
                        await InputBox.Element(inputFirstName, Name.FirstName());
                        await InputBox.Element(inputLastName, "QWaass$%^&*");
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;

                }
            }
        }


        public static async Task VerifyValidationOnProfilePassword()
        {
            for (int i = 0; i < 11; i++)
            {
                switch (i)
                {
                    case 0:
                        await InputBox.Element(inputCurrentPassword, "");
                        await InputBox.Element(inputNewPassword, "Qaz11111!");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 1:
                        await InputBox.Element(inputCurrentPassword, "Qaz11");
                        await InputBox.Element(inputNewPassword, "Qaz11111!");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 2:
                        await InputBox.Element(inputCurrentPassword, "Qaz123456789012345678");
                        await InputBox.Element(inputNewPassword, "Qaz11111!");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 3:
                        await InputBox.Element(inputCurrentPassword, "Qwertyui");
                        await InputBox.Element(inputNewPassword, "Qaz11111!");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 4:
                        await InputBox.Element(inputCurrentPassword, "Qaz11111");
                        await InputBox.Element(inputNewPassword, "");
                        await InputBox.Element(inputConfirmPassword, "");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 5:
                        await InputBox.Element(inputCurrentPassword, "Qaz11111");
                        await InputBox.Element(inputNewPassword, "Qaz11");
                        await InputBox.Element(inputConfirmPassword, "Qaz11");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 6:
                        await InputBox.Element(inputCurrentPassword, "Qaz11111");
                        await InputBox.Element(inputNewPassword, "Qaz123456789012345678");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 7:
                        await InputBox.Element(inputCurrentPassword, "Qaz11111");
                        await InputBox.Element(inputNewPassword, "Qwertyui");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 8:
                        await InputBox.Element(inputCurrentPassword, "Qaz11111");
                        await InputBox.Element(inputNewPassword, "123456789");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 9:
                        await InputBox.Element(inputCurrentPassword, "Qaz11111");
                        await InputBox.Element(inputNewPassword, "!@#$%^^&!");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 10:
                        await InputBox.Element(inputCurrentPassword, "Qaz11111");
                        await InputBox.Element(inputNewPassword, "Qaz11111!");
                        await InputBox.Element(inputConfirmPassword, "");
                        await Button.Click(btnSave);
                        await VerifyDisplayingConfirmPasswordErrorMessage();
                        break;
                    case 11:
                        await InputBox.Element(inputCurrentPassword, "Qaz11111");
                        await InputBox.Element(inputNewPassword, "Qaz11111!");
                        await InputBox.Element(inputConfirmPassword, "Qaz11111");
                        await Button.Click(btnSave);
                        await VerifyDisplayingConfirmPasswordErrorMessage();
                        break;

                }
            }
        }


        public static async Task VerifyValidationOnProfileAccountDetails()
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        await InputBox.Element(inputEmail, "");
                        await InputBox.Element(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        await InputBox.Element(inputEmail, string.Join(" qatester-", DateTime.Now.ToString("yyyy-MM-dThh-mm-ss"), "  ", "@putsbox.com "));
                        await InputBox.Element(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "putsbox.com");
                        await InputBox.Element(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@@putsbox.com");
                        await InputBox.Element(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 4:
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox");
                        await InputBox.Element(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 5:
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "");
                        await Button.Click(btnSave);
                        await VerifyDisplayingPhoneErrorMessage();
                        break;
                    case 6:
                        await InputBox.Element(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.Element(inputPhone, "9532145");
                        await Button.Click(btnSave);
                        await VerifyDisplayingPhoneErrorMessage();
                        break;

                }
            }
        }
    }
}
