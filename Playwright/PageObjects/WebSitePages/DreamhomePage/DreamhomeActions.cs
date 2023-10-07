namespace Playwright.PageObjects
{
    public partial class Dreamhome
    {
        #region Ticket Selector


        public static async Task OpenHomePage()
        {
            await Browser.Driver.GotoAsync(WebEndpoints.WEBSITE_HOST);

        }


        public static async Task SelectFirstDreamhome()
        {
            await WaitUntil.CustomElementIsVisible(counterTwoDreamhomes);
            await Button.Click(cardDreamhome);
        }


        public static async Task SelectLastDreamhome()
        {
            await WaitUntil.CustomElementIsVisible(counterTwoDreamhomes);
            await Button.Click(cardDreamhome);
        }


        public static async Task OpenDreamHomeTicketSelector()
        {
            await Button.Click(btnDreamHome);

        }



        public static async Task SelectFirstBundleBtn()
        {
            await Button.Click(btnFirstBundle);
            await WaitUntil.WaitSomeInterval(2000);

        }


        public static async Task SelectSecondBundleBtn()
        {
            await Button.Click(btnSecondBundle);
            await WaitUntil.WaitSomeInterval(2000);

        }


        public static async Task SelectThirdBundleBtn()
        {
            await Button.Click(btnThirdBundle);
            await WaitUntil.WaitSomeInterval(2000);

        }


        public static async Task SelectForthBundleBtn()
        {
            await Button.Click(btnFourthBundle);
            await WaitUntil.WaitSomeInterval(2000);

        }
        #endregion

    }
}
