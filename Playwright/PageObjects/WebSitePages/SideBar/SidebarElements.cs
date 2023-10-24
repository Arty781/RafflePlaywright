namespace PlaywrightRaffle.PageObjects
{
    public class SidebarElements
    {
        public const string btnSignIn = "//button[text()='Sign In']";
        public const string btnSignUp = "//button[text()='Sign Up']";
        public const string btnFreeEntry = "//button[@class='freeEntryBtn']";
        public const string btnBasket = "//button[@class='headerBtnCart']";
        public const string btnHomeList = "//span[text()='Home']/parent::button";
        public const string btnDreamHomeLink = "//button[text()='Dream Home']";
        public const string btnWinners = "//button[text()='Winners']";
        public const string btnContact = "//button[text()='Contact']";
        public const string btnTermsConditions = "//button[text()='T&Cs']";
        public const string btnPrivacyPolicy = "Privacy Policy";
        public const string btnLogout = "//button[text()='Logout']";
        public const string btnProfileDropdownList = "//button[@class='btnSidebarDropdown ']";

        #region Profile dropdown list

        public const string btnBackToMenu = "//button[text()='Back to Menu']";
        public const string btnMyTicketsAndCompetitions = "//button[text()='My Tickets & Competitions']";
        public const string btnMyDetails = "//button[text()='My Details']";

        #endregion

    }
}
