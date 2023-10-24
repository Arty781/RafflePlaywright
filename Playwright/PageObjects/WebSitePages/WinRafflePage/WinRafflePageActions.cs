namespace PlaywrightRaffle.PageObjects
{
    public partial class WinRafflePage
    {
        public static async Task OpenWinRaffle()
        {
            await Browser.Navigate(WebEndpoints.WIN_RAFFLE);
            await WaitUntil.CustomElementIsVisible(btnTicketBundles);
            await WaitUntil.WaitSomeInterval(1000);
            await Element.Action("End");
            await WaitUntil.CustomElementIsVisible(btnTicketBundles);
        }

        public static async Task<string> SelectTicketBundle()
        {
            int num = RandomHelper.RandomIntNumber(3);
            string bundleprice = (await Browser.Driver.QuerySelectorAllAsync(textTicketBundlePrice))[num].TextContentAsync().Result ?? throw new Exception("Price is null");
            await Browser.Driver.QuerySelectorAllAsync(btnTicketBundles).Result[num].ClickAsync();
            await WaitUntil.CustomElementIsVisible(Basket.btncheckOutNow);
            return bundleprice;
        }
    }
}
