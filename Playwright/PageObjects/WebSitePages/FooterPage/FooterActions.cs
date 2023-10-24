namespace PlaywrightRaffle.PageObjects
{
    public partial class Footer
    {
        public static async Task OpenTerms()
        {
            var linkTerms = (await Browser.Driver.QuerySelectorAllAsync(textLinkContactsFooter)).Where(x => x.TextContentAsync().Result.Contains("Terms & Conditions")).Select(x => x).First();
            await linkTerms.ClickAsync();
        }

        public static async Task OpenPrivacy()
        {
            var linkTerms = (await Browser.Driver.QuerySelectorAllAsync(textLinkContactsFooter)).Where(x => x.TextContentAsync().Result.Contains("Privacy Policy")).Select(x => x).First();
            await linkTerms.ClickAsync();
        }
    }
}
