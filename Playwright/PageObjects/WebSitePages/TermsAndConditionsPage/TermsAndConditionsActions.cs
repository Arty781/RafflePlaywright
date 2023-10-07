namespace Playwright.PageObjects
{
    public partial class TermsAndConditions
    {
        public static async Task<string> GetTextTerms()
        {
            await WaitUntil.CustomElementIsVisible(titleTermsAndConditions);
            return await Browser.Driver.QuerySelectorAsync(textTerms).Result.TextContentAsync();
        }

        public static async Task<string> GetTextPrivacy()
        {
            await WaitUntil.CustomElementIsVisible(titleTermsAndConditions);
            return await Browser.Driver.QuerySelectorAsync(textPrivacy).Result.TextContentAsync();
        }
    }
}
