namespace Playwright.PageObjects
{
    public partial class Profile
    {
        public static async Task OpenSubscriptionsTab()
        {
            await Button.Click(tabSubscriptions);
        }

        public static async Task BuyTenPoundsSub()
        {
            await Button.Click(btn10BundleWithoutSub);
        }

        public static async Task BuyTwentyFivePoundsSub()
        {
            await Button.Click(btn25BundleWithSub);
        }


        public static async Task ClickEditPersonalDataBtn()
        {
            await WaitUntil.CustomElementIsVisible(btnEditPersonal);
            await Button.Click(btnEditPersonal);

        }


        public static async Task ClickEditPasswordBtn()
        {
            await Button.Click(btnEditPassword);

        }


        public static async Task ClickEditAccountBtn()
        {
            await Button.Click(btnEditAccount);

        }


        public static async Task EditPersonalData()
        {
            await InputBox.Element(inputFirstName, Name.FirstName());
            await InputBox.Element(inputLastName, Name.LastName());
            await Button.Click(btnSave);

        }


        public static async Task EditPassword(string currentPass = "Qaz11111", string newPass = "Qaz11111!", string confirmPass = "Qaz11111!")
        {
            await InputBox.Element(inputCurrentPassword, currentPass);
            await InputBox.Element(inputNewPassword, newPass);
            await InputBox.Element(inputConfirmPassword, confirmPass);
            await Button.Click(btnSave);

        }


        public static async Task<string> EditAccountData()
        {
            var email = DateTime.Now.ToString("yyyy-MM-dThh-mm-fff") + "@putsbox.com";
            await WaitUntil.CustomElementIsVisible(btnSave);
            await InputBox.Element(inputEmail, email);
            await InputBox.Element(inputPhone, RandomHelper.RandomPhone());
            await Button.Click(btnSave);
            return email;
        }

        public static async Task ClickEmailCommunication()
        {
            await Button.Click(inputEmailCommunication);
            await WaitUntil.WaitSomeInterval(1000);

        }


        public static async Task OpenMyTicketsCompetitions()
        {
            await Browser.Driver.GotoAsync("https://staging.rafflehouse.com/profile/tickets");
            await WaitUntil.CustomElementIsVisible(tabMyTicketsCompetitions);
            await WaitUntil.CustomElementIsVisible(listDreamHomeHistory);

        }

        public static async Task OpenMyDetails()
        {
            await Browser.Driver.GotoAsync("https://staging.rafflehouse.com/profile/user-info");
            await WaitUntil.CustomElementIsVisible(titleProfile);

        }


        public static async Task OpenDreamHomeHistoryList()
        {

            await Button.Click(listDreamHomeHistory);
            await WaitUntil.CustomElementIsVisible(prizeName);
            await WaitUntil.WaitSomeInterval(1000);

        }


        public static async Task ScrollToEndOfHistoryList(int countOrders)
        {
            await WaitUntil.CustomElementIsVisible(prizeName);
            for (int i = 0; i < countOrders; i++)
            {
                await Browser.Driver.QuerySelectorAllAsync(prizeName).Result[Browser.Driver.QuerySelectorAllAsync(prizeName).Result.Count - 1].ScrollIntoViewIfNeededAsync();
                await Browser.Driver.WaitForTimeoutAsync(250);
            }
        }


        public static async Task CloseDreamHomeHistoryList()
        {

            await Button.Click(listDreamHomeHistory);
            await WaitUntil.CustomElementIsInvisible(prizeName);

        }


        public static async Task OpenWeeklyHistoryList()
        {

            await Button.Click(listWeeklyHistory);
            await WaitUntil.CustomElementIsVisible(prizeName);
            await WaitUntil.WaitSomeInterval(1000);

        }


        public static async Task CloseWeeklyHistoryList()
        {

            await Button.Click(listWeeklyHistory);
            await WaitUntil.CustomElementIsInvisible(prizeName);

        }


        public static async Task OpenFixedOddsList()
        {

            await Button.Click(listWeeklyHistory);
            await WaitUntil.CustomElementIsVisible(prizeName);
            await WaitUntil.WaitSomeInterval(1000);

        }


        public static async Task CloseFixedOddsList()
        {

            await Button.Click(listWeeklyHistory);
            await WaitUntil.CustomElementIsInvisible(prizeName);

        }


        public static async Task OpenSubscriptionInProfile()
        {
            await Browser.Driver.GotoAsync("https://staging.rafflehouse.com/profile/subscription");
            await Browser.Driver.ReloadAsync();
            await WaitUntil.CustomElementIsVisible(titleSubscriptionProfile);

        }


        public static async Task PauseSubscription()
        {
            await Button.Click(btnDetails);
            await Button.Click(inputPause);
            await Button.Click(btnPausePopUp);
            await WaitUntil.WaitSomeInterval();
            await Browser.Driver.QuerySelectorAllAsync(titleSubscriptionStatus).Result.Where(x => x.TextContentAsync().Result == "Paused Subscription").First().WaitForElementStateAsync(ElementState.Visible);

        }


        public static async Task UnpauseSubscription()
        {
            await Button.Click(btnDetails);
            await Button.Click(inputPause);
            await Button.Click(btnUnpausePopUp);
            await WaitUntil.WaitSomeInterval();
            await Browser.Driver.QuerySelectorAllAsync(titleSubscriptionStatus).Result.Where(x => x.TextContentAsync().Result == "Active Subscription").First().WaitForElementStateAsync(ElementState.Visible);

        }


        public static async Task CancelSubscription()
        {
            await Button.Click(btnDetails);
            await Button.Click(btnCancelSubscription);
            await Button.Click(btnCancelPopUp);
            await WaitUntil.WaitSomeInterval();
            await Browser.Driver.QuerySelectorAllAsync(titleSubscriptionStatus).Result.Where(x => x.TextContentAsync().Result == "Cancelled Subscription").First().WaitForElementStateAsync(ElementState.Visible);
        }


        public static async Task ReactivateSubscription()
        {
            await Button.Click(btnDetails);
            await Button.Click(btnReactivateSubscription);
            await Button.Click(btnReactivatePopUp);
            await WaitUntil.WaitSomeInterval();
            await Browser.Driver.QuerySelectorAllAsync(titleSubscriptionStatus).Result.Where(x => x.TextContentAsync().Result == "Active Subscription").First().WaitForElementStateAsync(ElementState.Visible);

        }

        public static async Task VerifyCancelationEmail(string email, string name)
        {
            await EmailVerificator.VerifyCancelationEmail(email, name);


        }

        public static async Task VerifyPauseEmail(string email, string name)
        {
            await EmailVerificator.VerifyPauseEmail(email, name);


        }

        public static async Task VerifyUnpauseEmail(string email, string name, string charity, int activeRaffles)
        {
            await EmailVerificator.VerifyUnpauseEmail(email, name, charity);
        }

        public static async Task VerifyInitialEmailAuth(string email, string name, int quantity, double value, string charity)
        {
            await EmailVerificator.VerifyInitialEmailAuth(email, name, charity);
        }

        public static async Task VerifyInitialEmailUnauth(string email, string name, int quantity, double value, string charity, int activeRaffles)
        {
            await EmailVerificator.VerifyInitialEmailUnauth(email, name, charity, activeRaffles);
        }

        public static async Task WaitUntilScriptRuning(int activeRaffles)
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
                //Assert.That(ordersList.Count >= 1, $"New order is not created, current subscription orders count is \"{ordersList.Count}\"");

                foreach (var subscription in subscriptionList)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(subscription.Refference, Is.Not.Null);
                        Assert.That(subscription.CardSource, Is.Not.Null);
                        Assert.That(subscription.CheckoutId, Is.Not.Null);
                    });
                }

                await EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                    user.Name,
                                    "None Selected",
                                    activeRaffles);
                await EmailVerificator.VerifyUnpauseEmail(user.Email,
                                    user.Name,
                                    "None Selected");
            }


        }

    }
}
