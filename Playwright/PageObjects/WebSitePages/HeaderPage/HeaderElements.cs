namespace PlaywrightRaffle.PageObjects
{
    public partial class HeaderPage
    {

#if DEBUG || RELEASE || CHROME || FIREFOX

        public const string logo = "//a[@class='headerLogo']";
        public const string btnBurgerMenu = "div.menu-block > button";
        public const string liveCompetitionsList = "//button[contains(@class,'toggle-live-btn toggle-live-btn-desk')]";
        public const string linkDreamHome = "//a[@href='/dreamhome']";
        public const string winnersLink = "//nav[@class='headerNav']/a[@href='/winners']";
        public const string freeEntryBtn = "//button[@class='rafflebtn entry-button']";
        public const string btnCart = "//button[@class='headerBtnCart']";
        public const string btnDropDownAccount = "//button[@class='dropdownAccount ']";
        public const string btnLogOut = "//button[text()='Logout']";

#endif

#if DEBUG_MOBILE

        public const string logo = "//a[@class='headerLogo']";
        public const string btnHeaderBurgerMenu = "//button[@class='headerBurgerMenu']";
        public const string liveCompetitionsList = "//div[@class='headerSidebarMenu']/button[contains(@class,'toggle-live-btn')]";
        public const string linkDreamHome = "//button[text()='Dream Home']";
        public const string winnersLink = "//button[text()='Winners']";
        public const string linkFAQs = "//nav[@class='headerNav']/a[@href='https://help.rafflehouse.com']";
        public const string linkAboutUs = "//nav[@class='headerNav']/a[@href='/about-us']";
        public const string signInBtn = "//button[@class='rafflebtn secondary']";
        public const string signUpBtn = "//button[@class='rafflebtn primary']";
        public const string freeEntryBtn = "//button[text()='free entry']";
        public const string btnDropDownAccount = "//button[@class='btnSidebarDropdown ']/div[@class='header-drop-name']";
        public const string btnLogOut = "//button[text()='Logout']";
        public const string btnCart = "//button[@class='headerBtnCart']";
        public const string btnProfile = "//div/img[@class='header-user-icon']";


#endif
    }
}
