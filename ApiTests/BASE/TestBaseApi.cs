using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Playwright.Helpers;

namespace ApiTests.BASE
{
    public class TestBaseApi
    {
        [SetUp]

        public async Task SetUp()
        {
            await AllureConfigFilesHelper.CreateJsonConfigFile();
        }


        [TearDown]
        public async Task TearDown()
        {
            await Task.Delay(50);
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _ = TelegramHelper.SendMessage();
            }
        }
    }
}
