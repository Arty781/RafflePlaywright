namespace PlaywrightRaffle.PageObjects
{
    public partial class TMApp
    {
        public static async Task VerifyPriceOfAddedOrder(string bundlePrice)
        {
            await WaitUntil.CustomElementIsVisible(Basket.orderTotalVal);
            Assert.Multiple(async () =>
            {
                Assert.That(bundlePrice == (await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice)).FirstOrDefault().TextContentAsync().Result, Is.True,
                            $"{(await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice)).FirstOrDefault().TextContentAsync().Result}");
                //Assert.That((await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice)).LastOrDefault().TextContentAsync().Result == "£0", Is.True,
                //    $"{(await Browser.Driver.QuerySelectorAllAsync(Basket.textPrice)).LastOrDefault().TextContentAsync().Result}");
            });
        }
    }
}
