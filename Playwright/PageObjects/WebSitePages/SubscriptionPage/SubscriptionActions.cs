namespace PlaywrightRaffle.PageObjects
{
    public partial class Subscription
    {
        public static async Task OpenSelectorViaSubscriptionPage()
        {
            await Browser.Navigate("https://staging.rafflehouse.com/subscription");
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowTop);
            await Button.Click(btnSubscribeNowTop);
        }

        public static async Task OpenDiscountSubscriptionSelector()
        {
            await Browser.Navigate("https://staging.rafflehouse.com/ticket-selector?subscription-discount=true");
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector);
        }

        public static async Task OpenTicketSelector()
        {
            await Browser.Navigate("https://staging.rafflehouse.com/ticket-selector");
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector);
        }

        public static async Task AddFiftySubscriptionToBasket()
        {
            await WaitUntil.WaitSomeInterval();
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector);
           // double price = double.Parse((await Browser.Driver.QuerySelectorAllAsync(textPrice)).FirstOrDefault().TextContentAsync().Result.Substring(1, 2));
            //int quantity = int.Parse((await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).FirstOrDefault().GetAttributeAsync("value").Result);
            await (await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).FirstOrDefault().ClickAsync();
            await WaitUntil.CustomElementIsVisible(Basket.framePaymentNumber);
            //return (price, quantity);
        }

        public static async Task AddThirtySubscriptionToBasket()
        {
            await WaitUntil.WaitSomeInterval();
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector);
           // double price = double.Parse((await Browser.Driver.QuerySelectorAllAsync(textPrice)).TakeLast(2).FirstOrDefault().TextContentAsync().Result.Substring(1, 2));
           // int quantity = int.Parse((await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).TakeLast(2).FirstOrDefault().TextContentAsync().Result);
            await (await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).TakeLast(2).FirstOrDefault().ClickAsync();
            await WaitUntil.CustomElementIsVisible(Basket.framePaymentNumber);
            //return (price, quantity);
        }

        public static async Task AddTenSubscriptionToBasket()
        {
            await WaitUntil.WaitSomeInterval();
            await WaitUntil.CustomElementIsVisible(btnSubscribeNowSelector);
            //double price = double.Parse((await Browser.Driver.QuerySelectorAllAsync(textPrice)).LastOrDefault().TextContentAsync().Result.Substring(1, 2));
            //int quantity = int.Parse((await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).LastOrDefault().GetAttributeAsync("value").Result);
            await (await Browser.Driver.QuerySelectorAllAsync(btnSubscribeNowSelector)).LastOrDefault().ClickAsync();
            await WaitUntil.CustomElementIsVisible(Basket.framePaymentNumber);
            //return (price, quantity);
        }


    }
}
