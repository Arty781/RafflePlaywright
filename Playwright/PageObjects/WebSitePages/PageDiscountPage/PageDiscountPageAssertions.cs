namespace Playwright.PageObjects
{
    public partial class PageDiscountPage
    {
        public static async Task VerifyPriceOfAddedOrder(string bundlePrice)
        {
            await WaitUntil.CustomElementIsVisible(Basket.checkOutNowBtn);
            var actualPrice = await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice).Result.FirstOrDefault().TextContentAsync();
            Assert.That(bundlePrice == actualPrice, Is.True, $"{actualPrice}");
        }
    }
}
