

namespace Playwright.PageObjects
{
    public partial class CmsDreamhome
    {

        public static async Task<string> GetDreamhomeTitle()
        {
            await WaitUntil.CustomElementIsVisible(inputTitle);
            return (await Browser.Driver.QuerySelectorAsync(inputTitle)).GetAttributeAsync("value").Result;
        }
    }
}