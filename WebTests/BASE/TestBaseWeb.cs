namespace WebsiteTests.BASE
{

    public class TestBaseWeb : PlaywrightTest
    {
        [SetUp]
        public async Task Initialize()
        {
            await Browser.Initialize();
            await Browser.Navigate(WebEndpoints.WEBSITE_HOST);
        }

        [TearDown]
        public static async Task OneTimeTearDown()
        {
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            _ = testStatus == TestStatus.Failed ? TelegramHelper.SendMessage() : null;
            await Browser.Close();
            if (Browser.Driver != null)
            {
                await Browser.Quit();
                ForceCloseDriver.ForeseClose();
            }
        }
    }
}
