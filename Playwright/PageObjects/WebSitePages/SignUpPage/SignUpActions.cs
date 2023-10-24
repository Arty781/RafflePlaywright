namespace PlaywrightRaffle.PageObjects
{
    public partial class SignUp
    {
        public static async Task<string> EnterUserData(string email)
        {
            
            await InputBox.Element(inputFirstName, Name.FirstName());
            await InputBox.Element(inputSurname, Name.LastName());
            await InputBox.Element(inputEmail, email);
            await InputBox.Element(inputPhone, RandomHelper.RandomPhone());
            await InputBox.Element(inputPassword, "Qaz11111");
            await Button.Click(btnRememberMe);
            return email.ToLower();
        }

        public static async Task EnterUserDataForNonActivated(string email)
        {
            await InputBox.Element(inputFirstName, Name.FirstName());
            await InputBox.Element(inputSurname, Name.LastName());
            await InputBox.Element(inputEmail, email);
            await InputBox.Element(inputPhone, "");
            await InputBox.Element(inputPassword, "Qaz11111");
            await Button.Click(btnRememberMe);
        }

        public static async Task ClickSignUpBtn()
        {
            await Button.Click(btnSignUp);
        }

        public static async Task EnterFirstname(int charNumber, string charBefore, string charAfter)
        {
            await InputBox.Element(inputFirstName, String.Concat(charBefore, Lorem.Characters(charNumber), charAfter));
        }

        public static async Task EnterLastname(int charNumber, string charBefore, string charAfter)
        {
            await InputBox.Element(inputSurname, String.Concat(charBefore, Lorem.Characters(charNumber), charAfter));
        }

        public static async Task EnterEmail(string charBefore, string charInto, string charAfter)
        {
            await InputBox.Element(inputEmail, String.Concat(charBefore, "qatester-", DateTime.Now.ToString("yyyy-MM-dThh-mm-ss"), charInto, "@putsbox.com", charAfter));
        }

        public static async Task EnterPhone(int charNumber)
        {
            await InputBox.Element(inputPhone, RandomHelper.RandomPhone(charNumber));
        }

        public static async Task EnterPassword(string password)
        {
            await InputBox.Element(inputPassword, password);
        }

    }
}
