namespace Playwright.PageObjects
{
    public partial class ResetPasswordPage
    {
        public static async Task VerifySuccessfullMessageAppeared(string email)
        {
            await WaitUntil.CustomElementIsVisible(titleResetSuccess);
            var title = await Browser.Driver.QuerySelectorAsync(titleResetSuccessEmail).Result.TextContentAsync();
            Assert.That(title == email, Is.True, $"Expected {email}, but was {title}");
        }
    }
}
