

namespace PlaywrightRaffle.PageObjects
{
    public partial class CmsCommon
    {

        public static async Task VerifyIsLoginSuccessfull()
        {
            await WaitUntil.CustomElementIsVisible(pagePrizeManagement);
            Assert.That(Browser.Driver.QuerySelectorAsync(pagePrizeManagement).Result.IsVisibleAsync().Result, Is.True);
        }


        public static async Task VerifyIsDreamhomeCreatedSuccessfully(string dreamhomeTitle)
        {
            await WaitUntil.CustomElementIsVisible(CmsDreamhome.titleAddedDreamhome, 25);
            await Element.Action("End");
            await Button.Click(btnLastPage);
            await WaitUntil.CustomElementIsVisible($"//tbody/tr/td[text()='{dreamhomeTitle}']");
            Assert.That(dreamhomeTitle, Is.EqualTo(await Element.FindSpecificDreamhome(dreamhomeTitle).Result.TextContentAsync()));
        }

        public static async Task VerifyIsUserCreatedSuccessfully(string email)
        {
            await WaitUntil.CustomElementIsVisible(CmsDreamhome.titleAddedDreamhome, 25);
            await Element.Action("End");
            await Button.Click(btnLastPage);
            await WaitUntil.CustomElementIsVisible(Element.FindSpecificUser(email).Result.btnEdit);
        }
    }
}
