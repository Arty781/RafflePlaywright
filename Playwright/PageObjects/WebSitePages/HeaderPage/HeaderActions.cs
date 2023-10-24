namespace PlaywrightRaffle.PageObjects
{
    public partial class HeaderPage
    {
#if DEBUG || RELEASE || CHROME || FIREFOX

        #region Opening links in header
        public static async Task OpenHomePage(string url)
        {
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenDreamhomePage(string url)
        {
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenWinnersPage()
        {
            await Browser.Driver.GotoAsync(WebEndpoints.WINNERS);

        }


        public static async Task OpenSignInPage()
        {
            await Browser.Driver.GotoAsync(WebEndpoints.SIGN_IN);

        }

        public static async Task OpenSignUpPage()
        {

            await Browser.Driver.GotoAsync(WebEndpoints.SIGN_UP);

        }

        public static async Task OpenSidebar()
        {
            await Button.Click(btnBurgerMenu);
        }

        public static async Task OpenCartPage()
        {
            await Browser.Driver.GotoAsync(WebEndpoints.BASKET);

        }

        public static async Task OpenPostPage()
        {
            await Browser.Driver.GotoAsync(WebEndpoints.FREE_ENTRY);

        }

        public static async Task DoLogout()
        {
            await Button.Click(btnBurgerMenu);
            await WaitUntil.WaitSomeInterval(1000);
            await Button.Click(btnLogOut);
        }

        #endregion

#endif

#if DEBUG_MOBILE

        #region Opening links in header
        public static async Task OpenHomePage(string url)
        {
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenDreamhomePage(string url)
        {
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenWeeklyPrizesPage()
        {
            await Browser.Driver.GotoAsync(WebEndpoints.LIFESTYLE);

        }
        public static async Task OpenFixedOddsPrizesPage(string url)
        {
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenWinnersPage(string url)
        {
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenFAQsPage(string url)
        {
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenAboutPage(string url)
        {
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenSignInPage()
        {
            await WaitUntil.CustomElementIsClickable(btnHeaderBurgerMenu);
            await  Button.Click(btnHeaderBurgerMenu);
            await  Button.Click(signInBtn);

        }

        public static async Task OpenSignUpPage()
        {

            await WaitUntil.CustomElementIsClickable(btnHeaderBurgerMenu);
            await  Button.Click(btnHeaderBurgerMenu);
            await  Button.Click(signUpBtn);
            await  Button.Click(Pages.SignUp.btnCloseSignUpPopup);


        }

        public static async Task OpenFreeEntryPage(string url)
        {
            await WaitUntil.CustomElementIsClickable(btnHeaderBurgerMenu);
            await  Button.Click(btnHeaderBurgerMenu);
            await Browser.Driver.GotoAsync(url);

        }

        public static async Task OpenCartPage()
        {
            await WaitUntil.CustomElementIsClickable(btnCart);
            Browser.Driver.QuerySelectorAsync(btnCart).ClickAsync();

        }

        #endregion

#endif
    }
}
