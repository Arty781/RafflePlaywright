namespace PlaywrightRaffle.PageObjects
{
    public partial class Common
    {
        public const string enterBtn = "//button[@class='enter-now__button']";

        public const string confirmCookieBtn = "//button[@class='cookie-close-button']";

        public const string addOneTicketBtn = "//ul[@class='ticket-selector__grid']/li[5]";

        public const string addTenTicketBtn = "//ul[@class='ticket-selector__grid']/li[6]";

        public const string add25TicketBtn = "//ul[@class='ticket-selector__grid']/li[7]";

        public const string removeOneTicketBtn = "//ul[@class='ticket-selector__grid']/li[3]";

        public const string removeTenTicketBtn = "//ul[@class='ticket-selector__grid']/li[2]";

        public const string remove25TicketBtn = "//ul[@class='ticket-selector__grid']/li[1]";

        public const string btnAddToBasket = "//span[@class='add-basket']/ancestor::div[@class='popular-tickets-container']/button";

        public const string loader = "//div[@class='loader']";

        #region Toaster

        public const string toaster = "//div[contains(text(), 'Error')]/parent::div/div[2]";

        #endregion






    }
}
