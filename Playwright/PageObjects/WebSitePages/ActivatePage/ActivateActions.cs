namespace PlaywrightRaffle.PageObjects
{
    public partial class Activate
    {
        public static async Task EnterFirstName()
        {
            await InputBox.Element(inputFirstName, Name.FirstName().Replace("'", ""));
        }

        public static async Task EnterLastName()
        {
            await InputBox.Element(inputLastName, Name.LastName().Replace("'", ""));
        }

        public static async Task EnterPhone()
        {
            await InputBox.Element(inputPhone, RandomHelper.RandomPhone());
        }

        public static async Task EnterPassword()
        {
            await InputBox.Element(inputPassword, Credentials.PASSWORD);
        }

        public static async Task ClickActivateBtn()
        {
            await Button.Click(btnActivateAccount);
        }


        public static async Task ActivateUser(string email)
        {
            await EnterFirstName();
            await EnterLastName();
            await EnterPhone();
            await EnterPassword();
            await VerifyIsDisplayedEmail(email);
            await ClickActivateBtn();
        }
    }
}
