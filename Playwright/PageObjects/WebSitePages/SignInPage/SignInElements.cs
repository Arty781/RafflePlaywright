namespace PlaywrightRaffle.PageObjects
{
    public partial class SignIn
    {
        public const string inputLogin = "//input[@name='email']";
        public const string inputPassword = "//input[@name='password']";
        public const string btnSignIn = "div.authLeftSide > div > button";
        public const string btnSignInWithGoogle = "button.social-g-btn";
        public const string checkboxPolicy = "//input[@type='checkbox']";
        public const string btnForgotPassword = "//span[contains(text(), 'Forgot password?')]";
        public const string textEmailErrorMessage = "//label[contains(text(), 'Email')]/parent::div/p[@id='outlined-basic-helper-text']";
        public const string textPasswordErrorMessage = "//label[contains(text(), 'Password')]/parent::div/p[@id='outlined-basic-helper-text']";
    }
}
