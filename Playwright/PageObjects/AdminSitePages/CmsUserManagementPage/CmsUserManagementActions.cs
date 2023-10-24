using static PlaywrightRaffle.Helpers.Element;

namespace PlaywrightRaffle.PageObjects
{
    public partial class CmsUserManagement
    {
        static async Task OpenUserManagement()
        {
            await Browser.Navigate(AdminEndpoints.USER_MANAGEMENT);
        }

        static async Task ClickAddNewBtn()
        {
            await Button.Click(btnAddUser);
        }

        static async Task EnterUserData(string email)
        {
            await WaitUntil.CustomElementIsVisible(inputFirstName);
            await InputBox.Element(inputFirstName, Name.FirstName());
            await InputBox.Element(inputLastName, Name.LastName());
            await InputBox.Element(inputEmail, email);
            await InputBox.Element(inputPhone, RandomHelper.RandomPhone());
        }

        public static async Task<UserRowModel> GetUserData()
        {
            await WaitUntil.CustomElementIsVisible(inputFirstName);
            UserRowModel user = new()
            {
                Name = TextBox.GetAttribute(inputFirstName, "value").Result,
                Surname = TextBox.GetAttribute(inputLastName, "value").Result,
                Email = TextBox.GetAttribute(inputEmail, "value").Result,
                Phone = TextBox.GetAttribute(inputPhone, "value").Result,
            };
            return user;
        }

        static async Task ClickEditUser(string email)
        {
            await Button.Click(FindSpecificUser(email).Result.btnEdit);
        }

        static async Task OpenSecurityTab()
        {
            await Button.Click(tabSecurity);
            await WaitUntil.CustomElementIsVisible(inputNewPassword);
        }

        static async Task SetNewPassword()
        {
            await InputBox.Element(inputNewPassword, "Qaz11111");
            await InputBox.Element(inputConfirmPassword, "Qaz11111");
            await CmsCommon.ClickSaveChangesBtn();
            await WaitUntil.CustomElementIsVisible(CmsCommon.textAlertMessage);
            Assert.That(Browser.Driver.QuerySelectorAsync(CmsCommon.textAlertMessage).Result.TextContentAsync().Result, Is.EqualTo("Password changed"), "Password is not changed");
        }

        static async Task DeleteUser(string email)
        {
            await Button.Click(FindSpecificUser(email).Result.btnDelete);
            await CmsCommon.ClickRemoveBtn();
            await WaitUntil.WaitSomeInterval();
        }

        static async Task OpenTicketsTab()
        {
            await Button.Click(tabTickets);
            await WaitUntil.WaitSomeInterval(1000);
        }

        static async Task ClickAddTicketBtn()
        {
            await Button.Click(btnAddTicket);
            await WaitUntil.CustomElementIsVisible(inputNumberOfTickets);
        }

        static async Task AddTicketsToUser(int numOfTickets)
        {
            await InputBox.Element(inputNumberOfTickets, $"{numOfTickets}");
            await Button.Click(btnSaveInPopup);
        }

        public static List<CompetitionRowModel> SelectTicketsDataByCompetition(string competition)
        {
            return FindSpecificCompetitionRows(competition).Result;
        }

        static async Task ClickEditTicketBtn(List<CompetitionRowModel> competitionRow)
        {
            await Button.Click(competitionRow.First().btnEditTickets);
            await Button.Click(btnAddTicketsInPopUp);
            await WaitUntil.CustomElementIsVisible(inputNumberOfTickets);
        }

        static async Task ClickDeleteTicketBtn(List<CompetitionRowModel> competitionRow)
        {
            await Button.Click(competitionRow.First().btnDeleteTickets);
            await CmsCommon.ClickRemoveBtn();
            await WaitUntil.CustomElementIsInvisible(competitionRow.First().btnDeleteTickets);
        }

    }
}