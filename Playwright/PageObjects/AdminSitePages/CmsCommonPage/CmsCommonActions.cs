

namespace Playwright.PageObjects
{
    public partial class CmsCommon
    {
        #region Opening sidebar menu's tabs


        public static async Task OpenPrizeManagementList()
        {
            await WaitUntil.CustomElementIsVisible(pagePrizeManagement);
            await Button.Click(pagePrizeManagement);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenDreamHomePage()
        {
            await WaitUntil.CustomElementIsVisible(pageDreamHome);
            await Button.Click(pageDreamHome);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenLifestylePrizesPage()
        {
            await WaitUntil.CustomElementIsVisible(pagePrizes);
            await Button.Click(pagePrizes);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenCompetitionsPage()
        {
            await WaitUntil.CustomElementIsVisible(pageCompetitions);
            await Button.Click(pageCompetitions);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenUserManagementPage()
        {
            await WaitUntil.CustomElementIsVisible(pageUsers);
            await Button.Click(pageUsers);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenStaffManagementPage()
        {
            await WaitUntil.CustomElementIsVisible(pageStaff);
            await Button.Click(pageStaff);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenSettingsList()
        {
            await WaitUntil.CustomElementIsVisible(pageSettings);
            await Button.Click(pageSettings);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenGeneralPage()
        {
            await WaitUntil.CustomElementIsVisible(pageSettingsGeneral);
            await Button.Click(pageSettingsGeneral);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenWinnersPage()
        {
            await WaitUntil.CustomElementIsVisible(pageSettingsWinners);
            await Button.Click(pageSettingsWinners);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenReferralsPage()
        {
            await WaitUntil.CustomElementIsVisible(pageSettingsReferrals);
            await Button.Click(pageSettingsReferrals);
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task OpenReportsPage()
        {
            await WaitUntil.CustomElementIsVisible(pageSettingsReports);
            await Button.Click(pageSettingsReports);
            await WaitUntil.WaitSomeInterval(250);
        }

        #endregion


        public static async Task ClickSaveBtn()
        {
            await WaitUntil.WaitSomeInterval(150);
            await Button.Click(btnSave);
            await WaitUntil.WaitSomeInterval(1000);
        }


        public static async Task ClickSaveChangesBtn()
        {
            await WaitUntil.WaitSomeInterval(150);
            await Button.Click(btnSaveChanges);
            await WaitUntil.WaitSomeInterval(1000);
        }


        public static async Task ClickCancelBtn()
        {
            await WaitUntil.CustomElementIsVisible(btnCancel);
            await Browser.Driver.QuerySelectorAsync(btnCancel).Result.ScrollIntoViewIfNeededAsync();
            await WaitUntil.WaitSomeInterval(250);
        }


        public static async Task ClickRemoveBtn()
        {
            await WaitUntil.WaitSomeInterval(150);
            await Button.Click(btnRemove);
            await WaitUntil.WaitSomeInterval(500);
        }


        public static async Task OpenDiscountTab()
        {
            await WaitUntil.CustomElementIsVisible(tabDiscount);
            await Button.Click(tabDiscount);
            await WaitUntil.WaitSomeInterval(1000);
        }

    }
}
