namespace PlaywrightRaffle.PageObjects
{
    public partial class PageDiscountPage
    {
        public static async Task OpenPageDiscount()
        {
            await Browser.Driver.GotoAsync(WebEndpoints.PAGE_DISCOUNT);
            await WaitUntil.WaitSomeInterval(1000);
            await Element.Action("End");
            await WaitUntil.CustomElementIsVisible(btnTicketBundles);
        }

        public static async Task<string> SelectTicketBundle()
        {
            int num = RandomHelper.RandomIntNumber(3);
            string? bundleprice = await Browser.Driver.QuerySelectorAllAsync(textTicketBundlePrice).Result[num].TextContentAsync();
            await Button.ClickOnNthElement(btnTicketBundles, num);
            await WaitUntil.CustomElementIsVisible(Basket.btncheckOutNow);
            return bundleprice;
        }
    }
}
