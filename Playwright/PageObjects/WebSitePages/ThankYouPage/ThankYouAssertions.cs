namespace PlaywrightRaffle.PageObjects
{
    public partial class ThankYou
    {
        public static async Task VerifyThankYouPageIsDisplayed()
        {
            await Basket.VerifyUrl();
            await WaitUntil.CustomElementIsVisible(titleThankYouPage);
        }


    }
}