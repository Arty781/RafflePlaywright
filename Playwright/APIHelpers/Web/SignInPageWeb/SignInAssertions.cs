namespace PlaywrightRaffle.APIHelpers.Web.SignIn
{
    public class SignInAssertionsWeb
    {

        public static void VerifyIsAdminSignInSuccesfull(SignInResponseModelWeb response)
        {
            Assert.That(Credentials.LOGIN.Equals(response.User.Email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
