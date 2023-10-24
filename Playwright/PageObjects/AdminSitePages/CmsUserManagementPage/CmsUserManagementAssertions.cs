using static PlaywrightRaffle.Helpers.Element;

namespace PlaywrightRaffle.PageObjects
{
    public partial class CmsUserManagement
    {
        public static async Task SearchUser(string email)
        {
            await WaitUntil.CustomElementIsVisible(textTitleUserManagement, 25);
            await Action("End");
            await Button.Click(CmsCommon.btnLastPage);
            await WaitUntil.CustomElementIsVisible(FindSpecificUser(email).Result.btnEdit);
        }

        public void VerifyUserIsEdited(Element.UserRowModel userData, string email)
        {
            Assert.Multiple(() =>
            {
                Assert.That(FindSpecificUser(email).Result.Name, Is.EqualTo(userData.Name), string.Concat("Name doesn't match!", $" Expected: {userData.Name} but was {FindSpecificUser(email).Result.Name}"));
                Assert.That(FindSpecificUser(email).Result.Surname, Is.EqualTo(userData.Surname), string.Concat("Surname doesn't match!", $" Expected: {userData.Surname} but was {FindSpecificUser(email).Result.Surname}"));
                Assert.That(FindSpecificUser(email).Result.Email, Is.EqualTo(userData.Email), string.Concat("Email doesn't match!", $" Expected: {userData.Email} but was {FindSpecificUser(email).Result.Email}"));
                Assert.That(FindSpecificUser(email).Result.Phone, Is.EqualTo(userData.Phone), string.Concat("Phone doesn't match!", $" Expected: {userData.Phone} but was {FindSpecificUser(email).Result.Phone}"));

            });
        }

        public static async Task VerifyTicketsIsAdded(List<CompetitionRowModel> competitionList, string competition, int numOfTickets)
        {
            await WaitUntil.WaitSomeInterval();
            Assert.Multiple(() =>
            {
                Assert.That(int.Parse(SelectTicketsDataByCompetition(competition).FirstOrDefault().NumberOfTickets), Is.EqualTo(int.Parse(competitionList.FirstOrDefault().NumberOfTickets) + numOfTickets), string.Concat("Competition doesn't match!", $" Expected: {int.Parse(competitionList.FirstOrDefault().NumberOfTickets) + numOfTickets} but was {SelectTicketsDataByCompetition(competition).FirstOrDefault().NumberOfTickets}"));

            });
        }
    }
}