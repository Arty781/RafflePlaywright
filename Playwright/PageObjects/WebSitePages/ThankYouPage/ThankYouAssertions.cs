namespace PlaywrightRaffle.PageObjects
{
    public partial class ThankYou
    {
        public static async Task VerifyThankYouPageIsDisplayed()
        {
            //await Basket.VerifyUrl();
            await WaitUntil.CustomElementIsVisible(titleThankYouPage);
            //await WaitUntil.CustomElementIsVisible(btnCloseThirdPartyPopup);
            //await Button.Click(btnCloseThirdPartyPopup);
        }

        public static async Task VerifyThankSubYouPageIsDisplayed()
        {
            //await Basket.VerifyUrl();
            await WaitUntil.CustomElementIsVisible(titleThankYouPageSub);
            //await WaitUntil.CustomElementIsVisible(btnCloseThirdPartyPopup);
            //await Button.Click(btnCloseThirdPartyPopup);
        }

        public static async Task VerifyThankSubYouPageIsDisplayed(IPage page)
        {
            await WaitUntil.CustomElementIsVisible(page, titleThankYouPageSub);
        }

    }
}