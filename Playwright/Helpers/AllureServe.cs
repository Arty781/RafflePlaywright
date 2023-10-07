namespace Playwright.Helpers
{
    [AllureSuite("DriverLevel")]
    class AllureServe
    {
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukharevsky Artem")]
        [AllureSubSuite("GoToAllureResults")]
        [Test]
        public static void GoToAllureResults()
        {
            AllureConfigFilesHelper.OpenAllureReport();
        }

        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukharevsky Artem")]
        [AllureSubSuite("ForceCloseDriver")]
        [Test]
        public static void ForceClose()
        {
            ForceCloseDriver.ForeseClose();
        }
    }

}
