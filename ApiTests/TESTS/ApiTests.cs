using ApiTests.BASE;
using MongoDB.Driver;
using NUnit.Framework;
using PlaywrightRaffle.APIHelpers.Web.PollHome;
using PlaywrightRaffle.APIHelpers.Admin;
using PlaywrightRaffle.APIHelpers.Admin.DreamHomePage;
using PlaywrightRaffle.APIHelpers.Admin.UsersPage;
using PlaywrightRaffle.APIHelpers.Web;
using PlaywrightRaffle.APIHelpers.Web.ForgotPasswordWeb;
using PlaywrightRaffle.APIHelpers.Web.SignIn;
using PlaywrightRaffle.APIHelpers.Web.SignUpPageWeb;
using PlaywrightRaffle.APIHelpers.Web.Subscriptions;
using PlaywrightRaffle.APIHelpers.Web.Weekly;
using PlaywrightRaffle.Helpers;
using PlaywrightRaffle.PageObjects;
using Telegram.Bot.Types;

namespace API
{
    [TestFixture]
    public class DemoTests : TestBaseApi
    {
        [Test]

        public async Task Demo()
        {
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            AppDbHelper.Insert.InsertUser(raffle.FirstOrDefault());
            var gifts = AppDbHelper.Gifts.GetAllGiftsByType("recipient");
            AppDbHelper.Insert.InsertUsersByGifts(gifts);


        }

        [Test]
        public async Task Demo2()
        {
            //Insert.InsertSubscriptionModel(Errors.ErrorTotalCost.ERROR_BAD_TRACK_DATA);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            SignUpResponse? responseFail = null;
            SignUpResponse? response = null;

            for (int i = 0; i < 5; i++)
            {
                //var emailPause = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fffff"), "@putsbox.com");
                //SignUpRequest.RegisterNewUser(emailPause, out responseFail);
                //var userFail = AppDbHelper.Users.GetUserByEmail(emailPause);
                //AppDbHelper.Insert.InsertSubscriptionsToUsers(userFail, raffle.FirstOrDefault(), subscriptionsModel);

                //string emailCancell = "qatester" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff") + "@putsbox.com";
                //SignUpRequest.RegisterNewUser(emailCancell, out response);
                //var user = AppDbHelper.Users.GetUserByEmailpattern(emailCancell).FirstOrDefault();
                //Insert.InsertSubscriptionsToUserForFailPayment(user, raffle.FirstOrDefault(), subscriptionsModel);

                var emailActive = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffffff"), "@putsbox.com");
                SignUpRequest.RegisterNewUser(emailActive, out responseFail);
                var userActive = AppDbHelper.Users.GetUserByEmail(emailActive);
                AppDbHelper.Insert.InsertActiveSubscriptionsToUsers(userActive, raffle.FirstOrDefault(), subscriptionsModel);

            }

            //var users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            //gr4vy.AddUsersToKlavio(users);
        }
    }


    [TestFixture]
    public class ApiTests : TestBaseApi
    {


        [Test]
        public static void AddTicketsToBasket()
        {
            SignInResponseModelWeb? token = null;
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out token);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            for (int q = 0; q < 50; q++)
            {
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                WaitUntil.WaitSomeInterval(250);
            }

        }

        [Test]
        public static void DeleteUsers()
        {
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(tokenAdmin, "");
            foreach (var user in users.Users)
            {
                if (user.Email.Contains("@putsbox.com"))
                {
                    UsersRequest.DeleteUser(tokenAdmin, user.Id);
                }

            }

        }

        [Test]
        public static void Registerreferrals()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            for (int i = 0; i < 10; i++)
            {
                SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
            }

        }

        [Test]
        public static void AddCreditsToUserForVerifyingOfExpirationEmailsTomorrow()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            var token = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var users = UsersRequest.GetUser(token, response.User.Email);
            UsersRequest.AddCreditsToUser(token, users.Users.FirstOrDefault().Id, "tomorrow");
        }

        [Test]
        //[Repeat(250)]
        public static void RegisterNewUser()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out _);
        }

        [Test]
        public static void ResetPassword()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            RequestForgotPassword.ForgotPassword(response.User.Email);
            string s = PutsBox.GetLinkFromEmailWithValue(response.User.Email, "Reset Password").Result[29..];
            var token = RequestForgotPassword.GetResetLink(s)[47..];
            var reset = RequestForgotPassword.ResetPassword(token);
            Console.WriteLine(reset.Message);
        }

        [Test]
        public static void EditTwoDreamhome()
        {
            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            AppDbHelper.Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, 720, -1);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, 50, -7920);
        }
    }

    [TestFixture]
    public class DbApi : TestBaseApi
    {
        [Test]

        public void RemoveSubscriptionsByUserId()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
        }

        [Test]

        public void RemoveOrdersAndSubscriptionsByUserId()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            AppDbHelper.Orders.DeleteOrdersByUserId(users);
            AppDbHelper.Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");
        }

        [Test]

        public void RemoveUserDataByEmail()
        {
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
        }

        [Test]

        public void RemoveSubscriptionsOrders()
        {
            AppDbHelper.Orders.DeleteSubscriptionsOrders();
        }

        [Test]

        public void InsertSubscriptionsByUsersEmail()
        {
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@xitroo.com")).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

        }

        [Test]

        public void UpdateSubscriptionsToNextPurchase()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@xitroo.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                AppDbHelper.Subscriptions.UpdateSubscriptionDateByIdToNextPurchase(user);
            }

        }

        [Test]

        public void DeleteUsersByEmail()
        {
            AppDbHelper.Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@raffle-house\\.com)).*$");
        }

        [Test]
        public void CreateUsersAndAddSubscription()
        {
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            for (int i = 0; i < 1; i++)
            {
                AppDbHelper.Insert.InsertUser(raffle);
            }
            var users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            //AppDbHelper.Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

        }

        [Test]
        public void AddUsers()
        {
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles();
            for (int i = 0; i < 1; i++)
            {
                AppDbHelper.Insert.InsertUser(raffle);
            }

        }

        [Test]
        public void CreateUsersAndAddSubscriptionForFailPayment()
        {
            #region Preconditions

            var email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fff"), "@putsbox.com");

            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().FirstOrDefault();
            AppDbHelper.Insert.InsertSubscriptionModel(Errors.ErrorTotalCost.ERROR_BAD_TRACK_DATA);
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle, email);
            var user = AppDbHelper.Users.GetUserByEmail(email);
            AppDbHelper.Insert.InsertSubscriptionsToUserForFailPayment(user, raffle, subscriptionsModel);
            EmailVerificator.VerifyPurchaseFailedEmail(email, user.Name);

            #endregion

            #region PostConditions

            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(user);
            AppDbHelper.Users.DeleteUsersByEmail(email);
            AppDbHelper.Subscriptions.DeleteLastSubscriptionModel(subscriptionsModel.LastOrDefault());

            #endregion


        }



        [Test]

        public void RemoveSubscriptions()
        {

            AppDbHelper.Subscriptions.DeleteSubscriptions();


        }

        [Test]

        public void UpdateTwoActiveDreamhomes()
        {
            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = AppDbHelper.DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = AppDbHelper.DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            AppDbHelper.DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            AppDbHelper.DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
        }

        [Test]

        public void UpdateOneActiveDreamhome()
        {
            int addFirstStartHours = -3600;
            int addFirstEndHours = 3600;

            List<DbModels.Raffle> activeDreamhomeList = AppDbHelper.DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = AppDbHelper.DreamHome.GetAllRaffles().Where(x => x.IsClosed == true).Select(x => x).ToList();
            AppDbHelper.DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            AppDbHelper.DreamHome.ActivateOneClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours);
        }

        [Test]

        public void ReplaceUserIdInOrders()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(predicate: x => x.Email == "qatester91311@gmail.com").Select(x => x).ToList();
            foreach (var user in users)
            {
                AppDbHelper.Orders.UpdateOrderByUserId(user, "64c25b1438658f0035652fbf");
            }

        }
    }
}
