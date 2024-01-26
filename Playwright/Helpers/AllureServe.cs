namespace PlaywrightRaffle.Helpers
{
    [AllureSuite("DriverLevel")]
    class AllureServe
    {
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureOwner("Sukharevsky Artem")]
        [AllureSubSuite("GoToAllureResults")]
        [Test]
        public static void GoToAllureResults()
        {
            AllureConfigFilesHelper.OpenAllureReport();
        }

        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureOwner("Sukharevsky Artem")]
        [AllureSubSuite("ForceCloseDriver")]
        [Test]
        public static void ForceClose()
        {
            ForceCloseDriver.ForeseClose();
        }
    }

}
