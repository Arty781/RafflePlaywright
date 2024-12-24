namespace PlaywrightRaffle.APIHelpers.Admin
{
    public class SignInAssertionsAdmin
    {

        public static void VerifyIsAdminSignInSuccesfull(SignInResponseModelAdmin response)
        {
            Assert.That(Credentials.LOGIN_ADMIN.Equals(response.User.Email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
