namespace PlaywrightRaffle.PageObjects
{
    public partial class Activate
    {
        public static async Task VerifyIsDisplayedEmail(string email)
        {
            await WaitUntil.CustomElementIsVisible(inputEmail);
            Assert.That(TextBox.GetAttribute(inputEmail, "value").Result == email, Is.True, $"Emails are not matched, must be {email} but was {TextBox.GetAttribute(inputEmail, "value")}");
        }

        public static async Task VerifySuccessfullActivation()
        {
            await WaitUntil.CustomElementIsVisible(titleActivatedAccount);
        }
    }
}
