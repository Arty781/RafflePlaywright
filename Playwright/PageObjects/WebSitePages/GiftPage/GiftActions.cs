namespace PlaywrightRaffle.PageObjects
{
    public partial class Gift
    {
        public static async Task GoToGiftPage()
        {
            await Browser.Navigate(WebEndpoints.GIFT);
            await Button.Click(btnPopupGotIt);
            //await Element.Action("End");
            await WaitUntil.CustomElementIsVisible(btnSendGift);
            
        }

        public static async Task<string> SendGift()
        {
            string email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fffff"), "@putsbox.com");
            await InputBox.Element(inputSenderName, Name.FirstName());
            await InputBox.Element(inputRecipientName, Name.FirstName());
            await Button.Click(radioBtnEmail);
            await WaitUntil.WaitSomeInterval(250);
            await InputBox.Element(inputEmail, email);
            await Button.Click(btnSendGift);
            await WaitUntil.CustomElementIsVisible(btnSendAnotherGift);
            await Button.Click(btnSendAnotherGift);
            return email;
        }
    }
}
