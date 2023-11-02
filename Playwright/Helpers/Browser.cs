namespace PlaywrightRaffle.Helpers
{
    public class Browser
    {
        public static IPage Driver { get; set; }
        public static IBrowser BrowserSet { get; set; }

        public static async Task Initialize()
        {
            await AllureConfigFilesHelper.CreateJsonConfigFile();
        }


        public static string RootPath() => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
        public static string RootPathReport() => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));

        public static async Task Close() => await Driver.CloseAsync();
        public static async Task Quit() => await BrowserSet.CloseAsync();
        public static async Task Navigate(string url)
        {
            await Driver.GotoAsync(url, new() { WaitUntil = WaitUntilState.DOMContentLoaded});
        }


    }

    public class Base : Browser
    {
        
        [OneTimeSetUp]
        public static async Task OneTimeSetUp()
        {
            await Browser.Initialize();
            var pl = await Playwright.CreateAsync();
            var launch = new BrowserTypeLaunchOptions
            {
                Headless = true,
                Devtools = false,
                Timeout = 15000
            };
            BrowserSet = await pl.Chromium.LaunchAsync(launch);
        }

        [SetUp]
        public static async Task SetUp()
        {
            var context = await BrowserSet.NewContextAsync();
            Driver = await context.NewPageAsync();
            await Driver.SetViewportSizeAsync(width: 1900, height: 980);
            await Browser.Navigate(WebEndpoints.WEBSITE_HOST);
        }

        [TearDown]
        public static async Task TearDown()
        {
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            _ = testStatus == TestStatus.Failed ? TelegramHelper.SendMessage() : null;
            await Browser.Close();
            

        }

        [OneTimeTearDown]
        public static async Task OneTimeTearDown()
        {
            if (Browser.Driver != null)
            {
                await Browser.Quit();
                ForceCloseDriver.ForeseClose();
            }
        }

    }

    public class ForceCloseDriver
    {
        public static string CreateBatFile()
        {
            string path = Browser.RootPathReport() + "_!CloseOpenWith.bat";
            string forceCloseAppList = string.Format("echo off" +
                "TASKKILL /F /IM \"OpenWith.exe\"\r\n" +
                "TASKKILL /F /IM \"chromedriver.exe\"\r\n" +
                "TASKKILL /F /IM \"java.exe\"\r\n" +
                "TASKKILL /F /IM \"node.exe\"\r\n" +
                "TASKKILL /F /IM \"AppleMobileDeviceService.exe\"\r\n" +
                "TASKKILL /F /IM \"APSDaemon.exe\"\r\n" +
                "TASKKILL /F /IM \"ICloudServices.exe\"\r\n" +
                "TASKKILL /F /IM \"mDNSResponder.exe\"\r\n" +
                "TASKKILL /F /IM \"altserver.exe\"\r\n" +
                "TASKKILL /F /IM \"Screencast-O-Matic.exe\"" +
                "pause"
                );
            FileInfo fileInf = new(path);
            if (fileInf.Exists == true)
            {
                fileInf.Delete();
            }
            using StreamWriter writer = new(path, false, Encoding.UTF8);
            writer.Write(forceCloseAppList);

            return path;
        }

        public static void ForeseClose()
        {
            string path = CreateBatFile();
            Process process = new();
            process.StartInfo.FileName = path;
            process.Start();
            process.Close();
            Thread.Sleep(1000);
            FileInfo fileInf = new(path);
            if (fileInf.Exists == true)
            {
                fileInf.Delete();
            }
        }
    }

}
