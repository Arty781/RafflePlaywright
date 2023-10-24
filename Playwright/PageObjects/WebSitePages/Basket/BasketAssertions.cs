namespace PlaywrightRaffle.PageObjects
{
    public partial class Basket
    {
        public static async Task VerifyUrl()
        {
            await WaitUntil.CustomCheckoutIsDisplayed();
            await Task.Delay(500);
            string expectedUrl = WebEndpoints.WEBSITE_HOST;
            string currentUrl = Browser.Driver.Url;

            if (currentUrl.Contains("localhost") && !currentUrl.Contains(expectedUrl))
            {
                Thread.Sleep(250);
                var waitForSelectorOptions = new PageWaitForURLOptions { Timeout = 30000 };
                await Browser.Driver.WaitForURLAsync(url => url.Contains("localhost"), waitForSelectorOptions);
                currentUrl = currentUrl.Replace("http://localhost:8000", expectedUrl);
                await Browser.Navigate(currentUrl);
                await WaitUntil.CustomElementIsVisible(ThankYou.titleThankYouPage);
            }
        }

        public static async Task VerifyErrorMessageIsDisplayed()
        {
            await VerifyUrl();
            await WaitUntil.CustomElementIsVisible(Common.toaster);
            await WaitUntil.CustomElementIsVisible(checkOutNowBtn);
        }

        public static async Task VerifyErrorMessageOnPaymentPage(string message)
        {
            await WaitUntil.CustomElementIsVisible(textErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textErrorMessage)).TextContentAsync().Result.ToLower(), Is.EqualTo(message.ToLower()));
        }

    }
}
