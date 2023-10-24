namespace PlaywrightRaffle.PageObjects
{
    public partial class CmsCommon
    {
        #region SideBarMenu
        public const string pagePrizeManagement = "//li[@role='menuitem']//span[contains(text(),'Prize Management')]";

        public const string pageDreamHome = "//a[@href='#/dreamHome']";

        public const string tabDiscount = "//a[@href='#/dreamHome/create/3']";

        public const string pagePrizes = "//a[@href='#/prizes']";

        public const string pageFixedOdds = "//a[@href='#/fixedOdds']";

        public const string pageCompetitions = "//a[@href='#/competitions']";

        public const string pageUsers = "//a[@href='#/users']";

        public const string pageStaff = "//a[@href='#/staffUsers']";

        public const string pageSettings = "//li[@role='menuitem']//span[contains(text(),'Settings')]";

        public const string pageSettingsGeneral = "//a[@href='#/general']";

        public const string pageSettingsWinners = "//a[@href='#/winners']";

        public const string pageSettingsReferrals = "//a[@href='#/referrals']";

        public const string pageSettingsReports = "//a[@href='#/reports']";

        #endregion
        #region Save, Remove and Cancel btns
        public const string btnSave = "//span[text()='Save']/parent::button";

        public const string btnSaveChanges = "//span[text()='Save Changes']/parent::button";

        public const string btnCancel = "//span[contains(text(),'Cancel')]/parent::button";

        public const string btnRemove = "//span[contains(text(),'Remove')]/parent::button";

        #endregion
        #region Pagination
        public const string btnFirstPage = "//div[@title='First Page']";

        public const string btnPreviousPage = "//div[@title='Previous Page']";

        public const string btnNextPage = "//div[@title='Next Page']";

        public const string btnLastPage = "//div[@title='Last Page']";

        #endregion
        #region Alerts
        public const string textAlertMessage = "//div[@role='alert']/div";

        #endregion
    }
}