using Microsoft.Playwright;
using static Playwright.Helpers.AppDbHelper;

namespace WebSiteTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    public class Demo : BaseWeb
    {
        [Test]
        public void Demotest()
        {
            //Insert.InsertSubscriptionModel(Errors.ErrorTotalCost.ERROR_BAD_TRACK_DATA);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            SignUpResponse? responseFail = null;
            SignUpResponse? response = null;

            for (int i = 0; i < 10; i++)
            {
                var emailFail = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fff"), "@putsbox.com");
                SignUpRequest.RegisterNewUser(emailFail, out responseFail);
                var userFail = AppDbHelper.Users.GetUserByEmail(emailFail);
                Insert.InsertSubscriptionsToUserForFailPayment(userFail, raffle.FirstOrDefault(), subscriptionsModel);

                string email = "qatester" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "@putsbox.com";
                SignUpRequest.RegisterNewUser(email, out response);
                var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();
                var user = AppDbHelper.Users.GetUserByEmailpattern(email).FirstOrDefault();
                AppDbHelper.Insert.InsertSubscriptionsToUsers(user, raffle.FirstOrDefault(), subscriptionsModel);
            }
            var users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            gr4vy.AddUsersToKlavio(users);





        }


    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    [AllureTag("Regression"), AllureOwner("Artem Sukharevskyi"), AllureSeverity(SeverityLevel.critical), AllureSubSuite("Authorisation")]
    public class Authorization : Base
    {
        [Test, Category("Authorized"), Author("Artem", "qatester91311@gmail.com")]
        public async Task LoginByEmail()
        {

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox");

            #endregion

        }

        [Test, Category("Authorized"), Author("Artem", "qatester91311@gmail.com")]
        public async Task RegisterNewUser()
        {
            string email = "qatester-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "@putsbox.com";
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignUpPage();
            await SignUp.EnterUserData(email);
            await SignUp.ClickSignUpBtn();
            await WaitUntil.WaitSomeInterval(1000);
            await SignUp.VerifyEmail(email);
            await Profile.ClickEmailCommunication();
            await WaitUntil.WaitSomeInterval(1000);
            await Profile.ClickEmailCommunication();
            await WaitUntil.WaitSomeInterval(1000);

            #region Postconditions
            //AppDbHelper.Users.DeleteTestUserData("@putsbox");
            #endregion

        }

        [Test, Category("Unauthorized"), Author("Artem", "qatester91311@gmail.com")]
        public async Task RegisterNewNonActivatedUser()
        {
            await Common.CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            await Home.AddTicketsToBasket(0);
            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await HeaderPage.OpenSignUpPage();
            await SignUp.EnterUserDataForNonActivated(email);
            await SignUp.ClickSignUpBtn();
            await SignUp.VerifyEmail(email);

            #region Postconditions
            AppDbHelper.Users.DeleteTestUserData("@putsbox");
            #endregion

        }

        [Test, Category("Authorized"), Author("Artem", "qatester91311@gmail.com")]
        public async Task EditUserData()
        {
            //SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            string email = "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com";
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignUpPage();
            await SignUp.EnterUserData(email);
            await SignUp.ClickSignUpBtn();
            await SignUp.VerifyEmail(email);

            //await Common.CloseCookiesPopUp();
            //await HeaderPage.OpenSignInPage();
            //await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            //await SignIn.VerifyIsSignIn();
            
            //await Profile.ClickEditPasswordBtn();
            //await Profile.EditPassword();
            //await Profile.VerifyUpdatePasswordSuccessfullToaster();
            await Profile.ClickEditAccountBtn();
            await Profile.EditAccountData();
            await Profile.VerifyDisplayingSuccessfullToaster();
            await Profile.ClickEditPersonalDataBtn();
            await Profile.EditPersonalData();
            await Profile.VerifyDisplayingSuccessfullToaster();
            await Profile.ClickEditAccountBtn();
            await Profile.EditAccountData();
            await Profile.VerifyDisplayingSuccessfullToaster();

            #region Postconditions
            //var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            //UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Authorized"), Author("Artem", "qatester91311@gmail.com")]
        public async Task ResetPassword()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.ClickForgotPassword();
            await ResetPasswordPage.RequestForgotPassword(response.User.Email);
            await ResetPasswordPage.VerifySuccessfullMessageAppeared(response.User.Email);
            await ResetPasswordPage.ClickOkBtn();
            await ResetPasswordPage.GoToResetPassLink(response.User.Email);
            await ResetPasswordPage.GetResetPassword();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.NEW_PASWORD);
            await SignIn.VerifyIsSignIn();

            #region Postconditions
            AppDbHelper.Users.DeleteTestUserData("@putsbox");
            #endregion

        }

        [Test, Category("Unauthorized"), Author("Artem", "qatester91311@gmail.com")]
        public async Task ResetPasswordAfterPaymentAsUnauthorized()
        {
            #region Preconditions

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            #endregion

            await Common.CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            await Home.AddTicketsToBasket(0);
            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await HeaderPage.OpenSignInPage();
            await SignIn.ClickForgotPassword();
            await ResetPasswordPage.RequestForgotPassword(response.User.Email);
            await ResetPasswordPage.VerifySuccessfullMessageAppeared(response.User.Email);
            await ResetPasswordPage.ClickOkBtn();
            await ResetPasswordPage.GoToResetPassLink(response.User.Email);
            await ResetPasswordPage.GetResetPassword();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.NEW_PASWORD);
            await SignIn.VerifyIsSignIn();

            #region Postconditions
            AppDbHelper.Users.DeleteTestUserData("@putsbox");
            #endregion

        }
    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    [AllureTag("Regression"), AllureOwner("Artem Sukharevskyi"), AllureSeverity(SeverityLevel.critical), AllureSubSuite("SubscriptionsCommon")]
    public class SubscriptionsCommon : TestBaseWeb
    {
        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PurchaseTenPoundsSubscriptionAsUnauthorizedUser()
        {

            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions(); ;
            await Profile.OpenDreamHomeHistoryList(); ;
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PurchaseTwentyFivePoundsSubscriptionAsUnauthorizedUser()
        {

            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions(); ;
            await Profile.OpenDreamHomeHistoryList(); ;
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PurchaseMultipleofSubscriptionAsUnauthorizedUser()
        {

            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            await Common.CloseCookiesPopUp();
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
                        await ThankYou.VerifyThankYouPageIsDisplayed();
                        break;
                    case 1:
                        await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
                        await ThankYou.VerifyThankYouPageIsDisplayed();
                        await WaitUntil.WaitSomeInterval(120000);
                        break;
                    case 2:
                        await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
                        await ThankYou.VerifyThankYouPageIsDisplayed();
                        break;
                    case 3:
                        await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
                        await ThankYou.VerifyThankYouPageIsDisplayed();
                        break;
                }
            }
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions(); ;
            await Profile.OpenDreamHomeHistoryList(); ;
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PurchaseTwentyFivePoundsSubscriptionAsAuthorizedUserLive()
        {
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Subscription.OpenSubscriptionPage();
            await Subscription.AddTwentyFiveSubscriptionToBasket();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtnSub();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions(); ;
            await Profile.OpenDreamHomeHistoryList(); ;
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PauseSubscriptionAsAuthorizedUser()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            string? name;
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            name = await SignIn.VerifyIsSignIn();
            await Basket.MakeAPurchaseSubscriptionAsAuthorizedUser(subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions(); ;
            await Profile.OpenDreamHomeHistoryList(); ;
            await Profile.OpenSubscriptionInProfile();
            await Profile.PauseSubscription();
            await Profile.VerifyPauseEmail(response.User.Email, name);
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task UnpauseSubscriptionAsAuthorizedUser()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            string? name;
            var raffle = DreamHome.GetAciveRaffles();

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            name = await SignIn.VerifyIsSignIn();
            await Basket.MakeAPurchaseSubscriptionAsAuthorizedUser(subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions(); ;
            await Profile.OpenDreamHomeHistoryList(); ;
            await Profile.OpenSubscriptionInProfile();
            await Profile.PauseSubscription();
            await Profile.OpenSubscriptionInProfile();
            await Profile.UnpauseSubscription();
            await Profile.VerifyUnpauseEmail(response.User.Email,
                                    name,
                                    "None Selected",
                                    raffle.Count);
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task CancelSubscriptionAsAuthorizedUser()
        {

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            string? name;
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            name = await SignIn.VerifyIsSignIn();
            await Basket.MakeAPurchaseSubscriptionAsAuthorizedUser(subscriptionsList.SubscriptionModels.LastOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.OpenSubscriptionInProfile();
            await Profile.CancelSubscription();
            await Profile.VerifyCancelationEmail(response.User.Email, name);
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PurchaseNormalTicketsAsSubscribedAuthorizedUser()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Subscription.OpenSubscriptionPage();
            await Subscription.AddTenSubscriptionToBasket();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtnSub();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList(); ;
            await Home.AddTicketsToBasket(2);
            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList(); ;
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PurchaseSubFromSubscriptionPageAsUnauthorizedUser()
        {
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            await Common.CloseCookiesPopUp();
            await Subscription.OpenSubscriptionPage();
            await Subscription.AddTenSubscriptionToBasket();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.Last().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList(); ;
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task VerifyTextsOnSubscriptionsPage()
        {
            await Subscription.OpenSubscriptionPage();
            await Common.CloseCookiesPopUp();
            await Element.Action("End");
            await Subscription.VerifyDisplayingH1();
            await Subscription.VerifyDisplayingH2();
            await Subscription.VerifyDisplayingH3();
            await Subscription.VerifyDisplayingParagraphs();
        }

    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    [AllureTag("Regression"), AllureOwner("Artem Sukharevskyi"), AllureSeverity(SeverityLevel.critical), AllureSubSuite("SubscriptionsDoubleTickets")]
    public class SubscriptionsDoubleTickets : TestBaseWeb
    {
        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PurchaseTenPoundsSubscriptionUnauthorized()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            var activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails


            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 1000).Select(x => x).FirstOrDefault();

            #endregion


            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Elements.GoToActivationLink(email);
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(2);
            await Profile.VerifyAddingTickets((double?)subscriptionsList.TotalCost / 100 ?? throw new Exception("TotalCost is null."), 2);

        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task Purchase25PoundsSubscriptionOneRaffleExpired()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = -80;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails


            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();
            var activeRaffles = DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();

            #endregion


            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Elements.GoToActivationLink(email);
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(1);
            await Profile.VerifyAddingTickets((double?)subscriptionsList.TotalCost / 100 ?? throw new Exception("TotalCost is null."), activeRaffles.Count);

        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task Purchase10PoundsSubscriptionOneRaffleActive()
        {
            #region Preconditions

            //int addFirstStartHours = -3600;
            //int addFirstEndHours = 360;

            //List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            //List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            //DreamHome.DeactivateDreamHome(activeDreamhomeList);
            //dreamhomeList.Reverse();
            //DreamHome.ActivateOneClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours);
            //Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails


            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();
            var activeRaffles = DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();

            #endregion


            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Elements.GoToActivationLink(email);
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(1);
            await Profile.VerifyAddingTickets((double?)subscriptionsList.TotalCost / 100 ?? throw new Exception("TotalCost is null."), activeRaffles.Count);
        }

        [Test]
        [Category("Subscriptions")]
        [Author("Artem", "qatester91311@gmail.com")]
        public async Task PurchaseSubscriptionOneRaffleExpired()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = -80;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);
            Subscriptions.DeleteSubscriptions();
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$"); //Delete all users except these emails


            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.Where(x => x.TotalCost == 2500).Select(x => x).FirstOrDefault();

            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            for (int i = 0; i < 1; i++)
            {
                AppDbHelper.Insert.InsertUser(raffle.FirstOrDefault(), email);

            }
            var users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com").FirstOrDefault();
            AppDbHelper.Insert.InsertSubscriptionsToUsers(users, raffle.FirstOrDefault(), subscriptionsModel);

            #endregion


            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.WaitUntilScriptRuning(raffle.Count);
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(1);
            await Profile.VerifyAddingTickets((double?)subscriptionsList.TotalCost / 100 ?? throw new Exception("TotalCost is null."), raffle.Count);


        }

    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    public class SubscriptionsMailing : TestBaseWeb
    {
        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyInitialSubscriptionEmailAsUnauthorizedUser()
        {
            string name = string.Empty;
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscription = SubscriptionsRequest.GetActiveSubscriptions().SubscriptionModels.FirstOrDefault();
            var activeRaffles = DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();

            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscription.Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.VerifyInitialEmailUnauth(email,
                                    name,
                                    subscription.NumOfTickets + subscription.Extra ?? throw new Exception("NumOfTickets is null."),
                                    (double?)subscription.TotalCost ?? throw new Exception("TotalCost is null."),
                                    "None Selected",
                                    activeRaffles.Count);
        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyPauseSubscriptionEmailAsUnauthorizedUser()
        {

            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            string? name;
            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Elements.GoToActivationLink(email);
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            name = await SignIn.VerifyIsSignIn();
            await Profile.OpenSubscriptionInProfile();
            await Profile.PauseSubscription();
            await Profile.VerifyPauseEmail(email, name);

        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyUnpauseSubscriptionEmailAsUnauthorizedUser()
        {

            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();
            var raffle = DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            string? name;
            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Elements.GoToActivationLink(email);
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            name = await SignIn.VerifyIsSignIn();
            await Profile.OpenSubscriptionInProfile();
            await Profile.PauseSubscription();
            await Profile.OpenSubscriptionInProfile();
            await Profile.UnpauseSubscription();
            await Profile.VerifyUnpauseEmail(email,
                                    name,
                                    "None Selected",
                                    raffle.Count);

        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyCancelSubscriptionEmailAsUnauthorizedUser()
        {
            string? name;
            string email = String.Concat("qatester", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss-fff"), "@putsbox.com");
            var subscriptionsList = SubscriptionsRequest.GetActiveSubscriptions();

            await Common.CloseCookiesPopUp();
            await Basket.MakeAPurchaseSubscriptionAsUnauthorizedUser(email, subscriptionsList.SubscriptionModels.FirstOrDefault().Id);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Elements.GoToActivationLink(email);
            await Activate.ActivateUser(email);
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD);
            name = await SignIn.VerifyIsSignIn();
            await Profile.OpenSubscriptionInProfile();
            await Profile.CancelSubscription();
            await Profile.VerifyCancelationEmail(email, name);


        }
    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    public class CheckingEmailAfterScriptRunning : TestBaseApi
    {


        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifySubscriptionEmailsAfterRunScript()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);


            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            int pauseEndReminder = 168;
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);
            AppDbHelper.Insert.InsertReminderSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEndReminder);
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);

                await EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                                        user.Name,
                                                        charity,
                                                        raffle.Count);
                await EmailVerificator.VerifyUnpauseEmail(user.Email,
                                                    user.Name,
                                                    charity);
                await EmailVerificator.VerifyReminderEmail(user.Email,
                                                     user.Name);
            }


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyPauseSubscriptionWithTwoRafflesActive()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            Subscriptions.DeleteSubscriptionsByUserId(users);
            Orders.DeleteOrdersByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);

            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, 50);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = Subscriptions.GetAllSubscriptionModels();
            Insert.InsertUser(raffle);
            users = Users.GetUserByEmailpattern("@putsbox.com");
            var charity = "None Selected";
            int nextPurchaseDate = 100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);

            #endregion

            users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                await EmailVerificator.VerifyUnpauseEmail(user.Email, user.Name, charity);
            }


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyPauseSubscriptionWithTwoRafflesOneExpire()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            Subscriptions.DeleteSubscriptionsByUserId(users);
            Orders.DeleteOrdersByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);

            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, -50);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = Subscriptions.GetAllSubscriptionModels();
            Insert.InsertUser(raffle);
            users = Users.GetUserByEmailpattern("@putsbox.com");
            var charity = "None Selected";
            int nextPurchaseDate = 100;
            int purchaseDate = 0;
            int pausedAt = -720;
            int pauseEnd = -24;
            Insert.InsertPauseSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate, pausedAt, pauseEnd);

            #endregion

            users = Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                await EmailVerificator.VerifyUnpauseEmail(user.Email, user.Name, charity);
            }


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyActiveSubscriptionWithTwoRafflesActive()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);

            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, 50);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                List<PutsboxEmail>? emailsList = await Elements.GgetAllEmailData(user.Email);
                await EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                                        user.Name,
                                                        charity,
                                                        raffle.Count);
            }


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyActiveSubscriptionWithTwoRafflesOneExpire()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, -50);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffle);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffle, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                List<PutsboxEmail>? emailsList = await Elements.GgetAllEmailData(user.Email);
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var sub = subscriptionList.Where(x => x.Status == "ACTIVE").Select(x => x).First();
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
                await EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                                        user.Name,
                                                        charity,
                                                        raffle.Count);
            }


        }

        [Test]
        [Category("Subscriptions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Subscriptions")]
        public async Task VerifyActiveSubscriptionWithInactiveRaffle()
        {
            #region Preconditions

            int addFirstStartHours = -3600;
            int addFirstEndHours = 360;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 1780;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            //Delete all subscritions and test users 
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            AppDbHelper.Subscriptions.DeleteSubscriptionsByUserId(users);
            Users.DeleteUsersByEmail("^(?!.*(@gmail\\.com|@outlook\\.com|@anuitex\\.net|@test\\.co|@raffle-house\\.com)).*$");

            //Edit raffles
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);

            var charity = "None Selected";
            int nextPurchaseDate = -100;
            int purchaseDate = 0;
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, true, -170, 720);
            DreamHomeRequest.EditDreamHomeStartEndDate(tokenAdmin, dreamResponse, false, -7920, 50);
            dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out raffleCloseEarlier);
            var subscriptionsModel = AppDbHelper.Subscriptions.GetAllSubscriptionModels();
            AppDbHelper.Insert.InsertUser(raffleCloseEarlier);
            users = AppDbHelper.Users.GetUserByEmailpattern("@putsbox.com");
            AppDbHelper.Insert.InsertActiveSubscriptionToUser(users, raffleCloseEarlier, subscriptionsModel, charity, nextPurchaseDate, purchaseDate);
            DreamHome.DeactivateDreamHome(raffleCloseEarlier);
            var raffle = AppDbHelper.DreamHome.GetAciveRaffles().Where(x => x.EndsAt > DateTime.Now).Select(x => x).ToList();

            #endregion

            users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                List<PutsboxEmail>? emailsList = await Elements.GgetAllEmailData(user.Email);
                await EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                                        user.Name,
                                                        charity,
                                                        raffle.Count);
            }


        }



    }


    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    public class Payment : TestBaseWeb
    {
        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task ActivateNewUserFromEmail()
        {
            string? name;
            await Common.CloseCookiesPopUp();
            string email = string.Concat("qatester", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss"), "@putsbox.com");
            await Home.AddTicketsToBasket(0);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Elements.GoToActivationLink(email);
            await Activate.ActivateUser(email);
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);


            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task ActivateNewUserFromEmailAfterThreePayments()
        {
            await Common.CloseCookiesPopUp();
            string email = string.Concat("qatester", DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss"), "@putsbox.com");
            for (int i = 0; i < 5; i++)
            {
                await Home.AddTicketsToBasket(0);
                await Basket.MakeAPurchaseAsUnauthorizedUser(email);
                await ThankYou.VerifyThankYouPageIsDisplayed();
            }

            await Elements.GoToActivationLink(email);
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();


            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task ActivateNewUserAfterPayment()
        {
            await Common.CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            await Browser.Driver.ReloadAsync();
            await Home.AddTicketsToBasket(0);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task ActivateNewUserAfterThreePayments()
        {

            await Common.CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";
            await Home.AddTicketsToBasket(2);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();

            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);


            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.GetUser(tokenAdmin, email);
            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");
            #endregion

        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task MakePurchaseWithDelayAndClosingTab()
        {

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            await Common.CloseCookiesPopUp();
            await WaitUntil.WaitSomeInterval(250);
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Home.OpenHomePage();
            await Home.OpenDreamTicketSelector();
            await Home.SelectFirstBundleBtn();
            await Common.CloseTabAndWait30Seconds();
            await Home.OpenHomePage();
            await Home.OpenDreamTicketSelector();
            await Home.SelectFirstBundleBtn();
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();

            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task PurchaseDreamHome()
        {
            #region Update two active dreamhomes


            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateOneClosedDreamHome(dreamhomeList, -3600, 3600);

            #endregion

            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest
                .DeleteOrders(token, basketOrders);
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Home.AddTicketsToBasket(0);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();

            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task PurchaseTwoActiveDreamHome()
        {
            #region Update two active dreamhomes

            int addFirstStartHours = -3600;
            int addFirstEndHours = 3600;
            int addSecondStartHours = -1740;
            int addSecondEndHours = 80;

            List<DbModels.Raffle> activeDreamhomeList = DreamHome.GetAllRaffles().Where(x => x.Active == true).Select(x => x).ToList();
            List<DbModels.Raffle> dreamhomeList = DreamHome.GetAllRaffles().Distinct(new ItemNameEqualityComparer()).Where(x => x.IsClosed == true).Select(x => x).ToList();
            DreamHome.DeactivateDreamHome(activeDreamhomeList);
            dreamhomeList.Reverse();
            DreamHome.ActivateTwoClosedDreamHome(dreamhomeList, addFirstStartHours, addFirstEndHours, addSecondStartHours, addSecondEndHours);

            #endregion

            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest
                .DeleteOrders(token, basketOrders);
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Home.AddTicketsToBasket(0);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();

            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task SignUpAddTicketsMakePurchase()
        {

            await Common.CloseCookiesPopUp();
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            await WaitUntil.WaitSomeInterval(250);
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            DreamHomeOrderRequestWeb.MultipleAddDreamhomeTickets(token, prizesList.FirstOrDefault(), 15);
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);
            await Basket.ClickCartBtn();
            countOrders = await Basket.GetOrderCount();
            totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task SignUpAddReferralsAndTicketsMakePurchase()
        {

            await Common.CloseCookiesPopUp();
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            await WaitUntil.WaitSomeInterval(250);
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.VerifyAddingTickets(totalOrder, countOrders);
            await HeaderPage.DoLogout();
            for (int i = 0; i < 2; i++)
            {
                var responseReferral = SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
                SignInRequestWeb.MakeSignIn(responseReferral.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? tokenReferral);
                var prizesListReferral = CountdownRequestWeb.GetDreamHomeCountdown(tokenReferral);
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(tokenReferral, prizesListReferral.FirstOrDefault());
                await HeaderPage.OpenSignInPage();
                await SignIn.EnterLoginAndPass(responseReferral.User.Email, Credentials.PASSWORD);
                await SignIn.VerifyIsSignIn();
                await Basket.ClickCartBtn();
                countOrders = await Basket.GetOrderCount();
                double totalOrderReferral = await Basket.GetOrderTotal();
                await Basket.MakeAPurchaseAsAuthorizedUser();
                await ThankYou.VerifyThankYouPageIsDisplayed();
                await Profile.OpenMyTicketsCompetitions();
                await Profile.OpenDreamHomeHistoryList();
                await Profile.VerifyAddingTickets(totalOrderReferral, countOrders);
                await HeaderPage.DoLogout();

                #region Postconditions

                AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

                #endregion
            }
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task GetPurchaseDreamHome()
        {

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < RandomHelper.RandomIntNumber(2); q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                    await WaitUntil.WaitSomeInterval(250);
                }

                await Basket.ClickCartBtn();
                int countOrders = await Basket.GetOrderCount();
                double totalOrder = await Basket.GetOrderTotal();

                await Basket.MakeAPurchaseAsAuthorizedUser();
                await ThankYou.VerifyThankYouPageIsDisplayed();
                await Profile.OpenMyTicketsCompetitions();
                await Profile.OpenDreamHomeHistoryList();
                await Profile.ScrollToEndOfHistoryList(countOrders);
                await Profile.VerifyAddingTickets(totalOrder, countOrders);
            }

            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList(); ;

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test, Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task PurchaseTicketsFromWinAndDiscountPages()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            await Common.CloseCookiesPopUp();
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            await PageDiscountPage.OpenPageDiscount();
            string bunlePrice = await PageDiscountPage.SelectTicketBundle();
            await PageDiscountPage.VerifyPriceOfAddedOrder(bunlePrice);
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await WinRafflePage.OpenWinRaffle();
            string bunleWinPrice = await WinRafflePage.SelectTicketBundle();
            await WinRafflePage.VerifyPriceOfAddedOrder(bunleWinPrice);
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test, Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task PurchaseTicketsWin()
        {

            await Common.CloseCookiesPopUp();
            string email = "qatester" + DateTime.Now.ToString("yyyy-MM-d'-'hh-mm-ss") + "@putsbox.com";

            await WinRafflePage.OpenWinRaffle();
            string bunleWinPrice = await WinRafflePage.SelectTicketBundle();
            await WinRafflePage.VerifyPriceOfAddedOrder(bunleWinPrice);
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();
            await Basket.MakeAPurchaseAsUnauthorizedUser(email);
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickActivateMyAccount();
            await Activate.ActivateUser(email); ;
            await Activate.VerifySuccessfullActivation();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(email, Credentials.PASSWORD); ;
            await SignIn.VerifyIsSignIn();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test, Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task PurchaseTicketsFromPageDiscount()
        {

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            await Common.CloseCookiesPopUp();
            await PageDiscountPage.OpenPageDiscount();
            string bunlePrice = await PageDiscountPage.SelectTicketBundle();
            await PageDiscountPage.VerifyPriceOfAddedOrder(bunlePrice);
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            int countOrders = await Basket.GetOrderCount();
            double totalOrder = await Basket.GetOrderTotal();

            await Basket.MakeAPurchaseAsAuthorizedUser();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions();
            await Profile.OpenDreamHomeHistoryList();
            await Profile.ScrollToEndOfHistoryList(countOrders);
            await Profile.VerifyAddingTickets(totalOrder, countOrders);

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task AddDreamHomeToBasketAndPurchaseSubscription()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < 1; q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                    await WaitUntil.WaitSomeInterval(250);
                }

            }
            await Subscription.OpenSubscriptionPage();
            await Subscription.AddTenSubscriptionToBasket();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtnSub();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await Profile.OpenMyTicketsCompetitions(); ;
            await Profile.OpenDreamHomeHistoryList(); ;
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < 1; q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                    await WaitUntil.WaitSomeInterval(250);
                }

                await Basket.ClickCartBtn();
                await Basket.MakeAPurchaseAsAuthorizedUser();
                await ThankYou.VerifyThankYouPageIsDisplayed();
            }

            await Profile.OpenMyTicketsCompetitions(); ;
            await Profile.OpenDreamHomeHistoryList(); ;

            #region Postconditions

            AppDbHelper.Users.DeleteTestUserData("@putsbox.com");

            #endregion
        }


        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task MakeAPurchaseByPayPalAndBuySub()
        {
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            await Common.CloseCookiesPopUp();
            await SignIn.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Home.OpenHomePage();
            await Home.AddTicketsToBasket(0);
            await Basket.MakeAPurchasePayPal();
            await ThankYou.VerifyThankYouPageIsDisplayed();
            await ThankYou.ClickViewTickets();
            await Profile.OpenSubscriptionsTab();
            await Profile.BuyTenPoundsSub();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtnSub();
            await ThankYou.VerifyThankYouPageIsDisplayed();

        }
    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    public class CheckingTextsOnPages : TestBaseWeb
    {
        [Test, Category("Home")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Home Page")]
        //[Ignore("")]
        public async Task VerifiedHomePage()
        {
            await Common.CloseCookiesPopUp();
            await Home.OpenHomePage(WebEndpoints.WEBSITE_HOST);
            await Home.VerifySecondaryBannerTitle();
            await Home.VerifySecondaryBannerSubtitle();
            await Home.VerifyBottomSliderTitle();
            await Home.VerifyBottomSliderSubitle();
            await Element.Action("End");
            await Home.VerifyInfoBlockTitles();
            await Home.VerifyInfoBlockParagraphs();
            await Home.VerifyHowItWorksTitle();
            await Home.VerifyHowItWorksParagraph();
            await Home.VerifyHowItWorksStepsTitles();
            await Home.VerifyHowItWorksStepsParagraphs();

        }


        [Test, Category("Postal")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Postal Page")]
        public async Task VerifyTextOnPostalPage()
        {
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenPostPage();
            await Postal.VerifyDisplayingParagraphs();
        }

        [Test, Category("Privacy Policy and Terms & Conditions")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Terms&Conditions Page")]
        public async Task VerifyTextOfTermsAndConditions()
        {
            await Common.CloseCookiesPopUp();
            await Footer.OpenTerms();
            var actualTerms = await TermsAndConditions.GetTextTerms();
            await HeaderPage.OpenHomePage(WebEndpoints.WEBSITE_HOST);
            await Footer.OpenPrivacy();
            var actualPrivacy = await TermsAndConditions.GetTextPrivacy();
            await TermsAndConditions.VerifyDisplayingParagraphs(actualTerms, actualPrivacy);
        }

        [Test, Category("Footer")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Home Page")]
        public async Task VerifiedDisplayingFooterElements()
        {
            await Common.CloseCookiesPopUp();
            await Home.OpenHomePage(WebEndpoints.WEBSITE_HOST);
            await Footer.VerifyIsDisplayedFooterTitle();
            await Footer.VerifyIsDisplayedFooterParagraph();
            await Footer.VerifyIsDisplayedContactLinks();
            await Footer.VerifyIsDisplayedSponsorLinks();
            await HeaderPage.OpenWinnersPage();
            await Footer.VerifyIsDisplayedFooterTitle();
            await Footer.VerifyIsDisplayedFooterParagraph();
            await Footer.VerifyIsDisplayedContactLinks();
            await Footer.VerifyIsDisplayedSponsorLinks();
            await HeaderPage.OpenCartPage();
            await Footer.VerifyIsDisplayedFooterTitle();
            await Footer.VerifyIsDisplayedFooterParagraph();
            await Footer.VerifyIsDisplayedContactLinks();
            await Footer.VerifyIsDisplayedSponsorLinks();
            await HeaderPage.OpenPostPage();
            await Footer.VerifyIsDisplayedFooterTitle();
            await Footer.VerifyIsDisplayedFooterParagraph();
            await Footer.VerifyIsDisplayedContactLinks();
            await Footer.VerifyIsDisplayedSponsorLinks();
        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Home Page")]
        public async Task VerifyDisplayedWinners2019()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[0]);
            await HeaderPage.OpenWinnersPage();
            await Common.CloseCookiesPopUp();
            await Winners.FilterWinnersByYear(winners.Years[0]);
            await Winners.ScrollToEndOfList(winners.AllCount);
            await Winners.VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Home Page")]
        public async Task VerifyDisplayedWinners2020()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[1]);
            await HeaderPage.OpenWinnersPage();
            await Common.CloseCookiesPopUp();
            await Winners.FilterWinnersByYear(winners.Years[1]);
            await Winners.ScrollToEndOfList(winners.AllCount);
            await Winners.VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Home Page")]
        public async Task VerifyDisplayedWinners2021()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[2]);
            await HeaderPage.OpenWinnersPage();
            await Common.CloseCookiesPopUp();
            await Winners.FilterWinnersByYear(winners.Years[2]);
            await Winners.ScrollToEndOfList(winners.AllCount);
            await Winners.VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Home Page")]
        public async Task VerifyDisplayedCTACards()
        {
            var winners = WinnersRequest.GetAllWinners();
            await HeaderPage.OpenWinnersPage();
            await Common.CloseCookiesPopUp();
            await Winners.ScrollToEndOfList(winners.AllCount);
            await Winners.VerifyDisplayedCTAButtons(winners.AllCount);

        }
    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    public class ErrorPaymentTests : TestBaseWeb
    {
        #region Test displaying of error messages

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task InsufientFundsError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            DreamHomeRequest
                .GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest
                .EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 151);
            await WaitUntil.WaitSomeInterval(250);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await Basket.VerifyErrorMessageIsDisplayed();
            await Basket.ClickCheckoutNowBtn();
            await Basket.VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.INSUFFICIENT_FUNDS);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task RestrictedCardError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 62);
            await WaitUntil.WaitSomeInterval(250);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await Basket.VerifyErrorMessageIsDisplayed();
            await Basket.ClickCheckoutNowBtn();
            await Basket.VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.RESTRICTED_CARD);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task BadTrackDataError()
        {
            #region Preconditions


            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 154);
            await WaitUntil.WaitSomeInterval(250);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await Basket.VerifyErrorMessageIsDisplayed();
            await Basket.ClickCheckoutNowBtn();
            await Basket.VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.BAD_TRACK_DATA);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
            //var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            //basketOrders = BasketRequest.GetBasketOrders(token);
            //BasketRequest.DeleteOrders(token, basketOrders);
            //UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task SecurityVioLationError()
        {
            #region Preconditions

            SignInResponseModelAdmin tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 163);
            await WaitUntil.WaitSomeInterval(250);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await Basket.VerifyErrorMessageIsDisplayed();
            await Basket.ClickCheckoutNowBtn();
            await Basket.VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.SECURITY_VIOLATION);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("Payment")]
        public async Task InvalidTransactionError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            DreamHomeRequest.GetActiveDreamHome(tokenAdmin, out Raffles? raffleCloseEarlier);
            List<long> bundles = new()
            {
                12,
                62,
                151,
                154,
                163
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 0.16666666, 0.01, bundles);

            SignUpRequest.RegisterNewUser(out SignUpResponse? response);
            SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD, out SignInResponseModelWeb? token);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 12);
            await WaitUntil.WaitSomeInterval(250);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Basket.ClickCartBtn();
            await Basket.ClickCheckoutNowBtn();
            await Basket.EnterCardDetails();
            await Basket.ClickPayNowBtn();
            await Basket.VerifyErrorMessageIsDisplayed();
            await Basket.ClickCheckoutNowBtn();
            await Basket.VerifyErrorMessageOnPaymentPage(Errors.ErrorMessages.INVALID_TRANSACTION);

            #region Postconditions

            bundles = new()
            {
                5,
                15,
                50,
                150
            };
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, raffleCloseEarlier, 1.66666666, 2, bundles);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        #endregion
    }

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    public class Validation : TestBaseWeb
    {
        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("ValidationOnSignInPage")]
        public async Task VerifyValidationOnSignInPage()
        {
            #region Preconditions
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.VerifyValidationOnSignIn(response);
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("ValidationOnSignUpPage")]
        public async Task VerifyFirstnameValidationOnSignUpPage()
        {
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignUpPage();
            await SignUp.VerifyFirstnameValidationOnSignUp();

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("ValidationOnSignUpPage")]
        public async Task VerifyLastnameValidationOnSignUpPage()
        {
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignUpPage();
            await SignUp.VerifyLastnameValidationOnSignUp();

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("ValidationOnSignUpPage")]
        public async Task VerifyEmailValidationOnSignUpPage()
        {
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignUpPage();
            await SignUp.VerifyEmailValidationOnSignUp();

        }

        [Test, Category("Unauthorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("ValidationOnSignUpPage")]
        public async Task VerifyPasswordValidationOnSignUpPage()
        {
            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignUpPage();
            await SignUp.VerifyPasswordValidationOnSignUp();

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("ValidationOnProfilePage")]
        public async Task VerifyValidationPersonalDetailsOnProfilePage()
        {
            #region Preconditions
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Profile.ClickEditPersonalDataBtn();
            await Profile.VerifyValidationOnProfilePersonalDetails();
            await Profile.EditPersonalData();
            await Profile.VerifyDisplayingSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("ValidationOnProfilePage")]
        public async Task VerifyValidationPasswordOnProfilePage()
        {
            #region Preconditions
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Profile.ClickEditPasswordBtn();
            await Profile.VerifyValidationOnProfilePassword();
            await Profile.EditPassword();
            await Profile.VerifyUpdatePasswordSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test, Category("Authorized")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSubSuite("ValidationOnProfilePage")]
        public async Task VerifyValidationAccountDetailsOnProfilePage()
        {
            #region Preconditions
            
            SignUpRequest.RegisterNewUser(out SignUpResponse? response);

            #endregion

            await Common.CloseCookiesPopUp();
            await HeaderPage.OpenSignInPage();
            await SignIn.EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            await SignIn.VerifyIsSignIn();
            await Profile.ClickEditAccountBtn();
            await Profile.VerifyValidationOnProfileAccountDetails();
            await Profile.EditAccountData();
            await Profile.VerifyDisplayingSuccessfullToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }
    }

}