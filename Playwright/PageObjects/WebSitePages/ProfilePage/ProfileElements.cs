namespace PlaywrightRaffle.PageObjects
{
    public partial class Profile
    {
        public const string tabSubscriptions = "div.profile-sidebar-side > button:nth-child(3)";

        #region My Details 

        public const string titleProfile = "div.my-details-container h1";
        public const string btnEditPersonal = "div.my-details-item.personal-details > div.personalTitle > button";
        public const string inputFirstName = "//input[@name='name']";
        public const string inputLastName = "//input[@name='surname']";
        public const string btnEditPassword = "//button[@data-edit='password']";
        public const string inputCurrentPassword = "//input[@name='oldPassword']";
        public const string inputNewPassword = "//input[@name='newPassword']";
        public const string inputConfirmPassword = "//input[@name='confirmPassword']";
        public const string btnEditAccount = "//button[@data-edit='account']";
        public const string inputEmail = "//input[@name='email']";
        public const string inputPhone = "//input[@name='phone']";
        public const string inputEmailCommunication = "//input[@value='emailCommunication']";
        public const string inputCorporateNotification = "//input[@value='corporateNotification']";
        public const string btnSave = "//button[contains(@class,'savingNewPassword visible')]";
        public const string SuccessUpdateDialog = "//div[contains(text(), 'Profile info update success')]";
        public const string SuccessUpdatePasswordDialog = "//div[contains(text(), 'Password update success')]";
        public const string textErrorMessage = "outlined-basic-helper-text";
        public const string textFirstNameErrorMessage = "//label[contains(text(), 'First name')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textLastNameErrorMessage = "//label[contains(text(), 'Last name')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textEmailErrorMessage = "//label[contains(text(), 'Email')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textPhoneErrorMessage = "//label[contains(text(), 'Phone')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textOldPasswordErrorMessage = "//input[@name='oldPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']";
        public const string textNewPasswordErrorMessage = "//input[@name='newPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']";
        public const string textConfirmPasswordErrorMessage = "//input[@name='confirmPassword']/ancestor::label/div/p[@id='outlined-basic-helper-text']";
        #endregion

        #region Order History

        public const string tabMyTicketsCompetitions = "//span[text()='My Tickets & Competitions']/parent::button";
        public const string listDreamHomeHistory = "div.history-accordion-inner > div.expand-accordion";
        public const string listWeeklyHistory = "//span[text()='Lifestyle Competitions']/ancestor::div[@class='history-accordion-inner']/div";
        public const string listFixedOddsHistory = "//span[text()='Fixed Odds']/ancestor::div[@class='history-accordion-inner']/div";
        public const string prizeName = "table.historyAreaTable tr > td:nth-child(1)";
        public const string prizeTickets = "table.historyAreaTable tr > td:nth-child(3)";
        public const string prizePrice = "table.historyAreaTable tbody tr td";
        public const string listHistory = "#history-accordion-droplist";
        #endregion

        #region Subscriptions

        public const string titleSubscriptionProfile = "//h1[text()='My subscription']";
        public const string btnDetails = "div.subscriptions-grid > div:nth-child(1) div.button-group > button";
        public const string titleSubscriptionStatus = "div.subscriptions-grid div.header";
        public const string cbbxCharitySelector = "div.subscriptions-grid div.details.expanded div.charity-dropdown-wrapper";
        public const string listCharities = "#menu- ul > li";
        public const string inputCharity = "div.select-wrapper input";
        public const string inputPause = "div.subscriptions-grid > div:nth-child(1) div.profile-checkbox input";
        public const string btnCancelSubscription = "div.subscriptions-grid > div:nth-child(1) > div.info-box button";
        public const string btnReactivateSubscription = "//button[text()='Reactivate Subscription']";
        public const string btnPausePopUp = "div.pause-dialog button:nth-child(1)";
        public const string btnUnpausePopUp = "div.pause-dialog button:nth-child(1)";
        public const string btnCancelPopUp = "div.dialog-window button:nth-child(1)";
        public const string btnReactivatePopUp = "div.dialog-window button:nth-child(1)";
        public const string btnBackPopUp = "//button[text()='Back']";
        public const string btnEditCard = "//div[@class='details expanded']//button[text()='Edit card']";
        public const string btnSaveCard = "#subscription-pay-button";
        public const string btnCloseCardPopup = "div.checkout-popup__header button";

        public const string btn10BundleWithoutSub = "div.subscription-bundle-card:nth-child(1)  div.buttons > button";
        public const string btn25BundleWithoutSub = "div.subscription-bundle-card:nth-child(2)  div.buttons > button";

        public const string btn10BundleWithSub = "div:nth-child(1) > div.button-group > button";
        public const string btn25BundleWithSub = "div:nth-child(2) > div.button-group > button";

        #endregion
    }
}
