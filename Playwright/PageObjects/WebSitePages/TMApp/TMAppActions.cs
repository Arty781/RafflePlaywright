namespace PlaywrightRaffle.PageObjects
{
    public partial class TMApp
    {
        public static async Task EnterLoginAndPassword(string email, string password)
        {
            await InputBox.Element(inputLogin, email);
            await InputBox.Element(inputPassword, password);
        }


        public static async Task ClickSignInBtn()
        {
            await Button.Click(btnSaveLogin);
            await WaitUntil.CustomElementIsVisible(titleDashboard);
        }

        public static async Task OpenLogin()
        {
            
            await Browser.Navigate(WebEndpoints.TM_LOGIN);
            await WaitUntil.CustomElementIsVisible(inputLogin);
        }

        public static async Task OpenMembershipEditing(string membershipId)
        {
            
            await Browser.Navigate(string.Concat(WebEndpoints.TM_EDIT_MEMBERSHIP, membershipId));
            await WaitUntil.CustomElementIsVisible(titleProductSku);
        }

        public static async Task UploadImages(string imagePath)
        {
            await WaitUntil.WaitSomeInterval(250);
            await InputBox.ElementImage(btnPhotoUpload, imagePath);
            //await InputBox.ElementImage(btnPhotoUpload, String.Concat(Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_1));

        }

        public static async Task ClickSaveButton()
        {
            await Button.Click(btnSaveLogin);
            await WaitUntil.CustomElementIsVisible(messageNotification);
            await WaitUntil.CustomElementIsInvisible(messageNotification);
        }
    }
}
