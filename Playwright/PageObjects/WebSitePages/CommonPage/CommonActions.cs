

namespace Playwright.PageObjects
{
    public partial class Common
    {
        public static async Task CloseCookiesPopUp()
        {
            await Browser.Driver.ReloadAsync();
            await Button.Click(confirmCookieBtn);
        }


        public static async Task ClickAddTenTickets()
        {
            await Button.Click(addTenTicketBtn);
        }


        public static async Task ClickAddOneTicket()
        {
            await Button.Click(addOneTicketBtn);
        }


        public static async Task ClickAdd25Tickets()
        {
            await Button.Click(add25TicketBtn);
        }


        public static async Task ClickRemoveTenTickets()
        {
            await Button.Click(removeTenTicketBtn);
        }


        public static async Task ClickRemoveOneTicket()
        {
            await Button.Click(removeOneTicketBtn);
        }


        public static async Task ClickRemove25Tickets()
        {
            await Button.Click(remove25TicketBtn);
        }


        public static async Task ClickAddToBasketBtn()
        {
            await WaitUntil.WaitSomeInterval(1000);
            await Button.Click(btnAddToBasket);
            await WaitUntil.CustomElementIsVisible(Basket.checkOutNowBtn);
        }


        public static async Task ClickEnterBtn()
        {
            await Button.Click(enterBtn);
        }


        public static async Task<IPage> CloseTabAndWait30Seconds()
        {
            var newPage = await Browser.Driver.Context.NewPageAsync();
            await Browser.Driver.CloseAsync();
            await newPage.BringToFrontAsync();
            await Task.Delay(30000);
            return Browser.Page = newPage;
        }

    }
}
