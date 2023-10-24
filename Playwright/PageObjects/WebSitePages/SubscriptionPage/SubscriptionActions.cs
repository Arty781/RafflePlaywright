namespace PlaywrightRaffle.PageObjects
{
    public partial class Subscription
    {
        public static async Task OpenSubscriptionPage()
        {
            await Browser.Navigate("https://staging.rafflehouse.com/subscription");
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowTop);
        }

        public static async Task<(double, int)> AddTenSubscriptionToBasket()
        {
            await Button.Click(btnSubscribeNowTop);
            await WaitUntil.WaitSomeInterval();
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector);
            double price = double.Parse((await Browser.Driver.QuerySelectorAllAsync(textPrice)).FirstOrDefault().TextContentAsync().Result.Substring(1, 2));
            int quantity = int.Parse((await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).FirstOrDefault().GetAttributeAsync("value").Result);
            await (await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).FirstOrDefault().ClickAsync();
            await WaitUntil.CustomElementIsVisible(Basket.framePaymentNumber);
            return (price, quantity);
        }

        public static async Task<(double, int)> AddTwentyFiveSubscriptionToBasket()
        {
            await Button.Click(btnSubscribeNowTop);
            await WaitUntil.WaitSomeInterval();
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector);
            double price = double.Parse((await Browser.Driver.QuerySelectorAllAsync(textPrice)).LastOrDefault().TextContentAsync().Result.Substring(1, 2));
            int quantity = int.Parse((await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).LastOrDefault().GetAttributeAsync("value").Result);
            await (await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).LastOrDefault().ClickAsync();
            await WaitUntil.CustomElementIsVisible(Basket.framePaymentNumber);
            return (price, quantity);
        }
    }
}
