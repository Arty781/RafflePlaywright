namespace PlaywrightRaffle.PageObjects
{
    public partial class ThankYou
    {

        public static async Task ClickActivateMyAccount()
        {
            await Button.Click(btnActivateMyAccount);
        }

        public static async Task ClickViewTickets()
        {
            await Button.Click(btnViewTickets);
        }
    }

}
