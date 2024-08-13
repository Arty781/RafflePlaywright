namespace PlaywrightRaffle.PageObjects
{
    public partial class TMApp
    {
        public const string inputLogin = "input[name='email']";
        public const string inputPassword = "input[name='password']";
        public const string titleDashboard = "//h1[contains(text(),'Dashboard')]";
        public const string titleProductSku = "label[title='Product SKU']";
        public const string btnPhotoUpload = "#mobileCoverPhoto";
        public const string btnSaveLogin = "button[type='submit']";
        public const string messageNotification = "div.ant-notification-notice-description";
    }
}
