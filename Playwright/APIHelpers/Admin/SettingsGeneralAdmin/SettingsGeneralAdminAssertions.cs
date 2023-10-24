namespace PlaywrightRaffle.APIHelpers.Admin
{
    public class SettingsGeneralAdminAssertions
    {

        public static void VerifyIsAdminSignInSuccesfull(SignInResponseModelAdmin response)
        {
            Assert.That(response.User.Email, Is.EqualTo(Credentials.LOGIN_ADMIN));
        }
    }
}
