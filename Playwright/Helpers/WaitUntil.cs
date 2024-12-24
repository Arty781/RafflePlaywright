
namespace PlaywrightRaffle.Helpers
{
    public class WaitUntil
    {
        public static async Task WaitSomeInterval(int ms = 2000)
        {
            await Task.Delay(ms);
        }

        public static async Task CustomElementIsVisible(string selector, int timeoutMilliseconds = 30000)
        {
            await Task.Delay(250);
            var waitOptions = new PageWaitForSelectorOptions()
            {
                Timeout = timeoutMilliseconds,
                State = WaitForSelectorState.Attached
            };
            await Browser.Driver.WaitForSelectorAsync(selector, waitOptions);
        }

        public static async Task CustomElementIsVisible(IPage page, string selector, int timeoutMilliseconds = 30000)
        {
            await Task.Delay(250);
            var waitOptions = new PageWaitForSelectorOptions()
            {
                Timeout = timeoutMilliseconds,
                State = WaitForSelectorState.Attached
            };
            await page.WaitForSelectorAsync(selector, waitOptions);
        }

        public static async Task<bool> CustomElementIsVisible(IFrame frame, int timeout)
        {
            var start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < timeout)
            {
                var isVisible = await frame.QuerySelectorAsync("//iframe[@name='cko-3ds2-iframe']") != null;
                if (isVisible) return true;
                await Task.Delay(100); // Poll every 100ms
            }
            return false;
        }

        public static async Task CustomElementIsInvisible(string selector, int timeoutMilliseconds = 10000)
        {
            await Task.Delay(250);
            var waitOptions = new PageWaitForSelectorOptions()
            {
                Timeout = timeoutMilliseconds,
                State = WaitForSelectorState.Detached
            };
            await Browser.Driver.WaitForSelectorAsync(selector, waitOptions);
        }

        public static async Task CustomElementIsInvisible(IPage page, string selector, int timeoutMilliseconds = 10000)
        {
            await Task.Delay(250);
            var waitOptions = new PageWaitForSelectorOptions()
            {
                Timeout = timeoutMilliseconds,
                State = WaitForSelectorState.Detached
            };
            await page.WaitForSelectorAsync(selector, waitOptions);
        }

        public static async Task CustomCheckoutIsDisplayed(int milliseconds = 30000)
        {
            await Task.Delay(1000);
            await Browser.Driver.WaitForURLAsync((url) => url.Contains("pending/?cko-session-id") || url.Contains("pending?paypal"));
        }

        public static async Task FrameIsVisible(string selector, float milliseconds = 30000)
        {
            await Task.Delay(3250);
            var frame = Browser.Driver.QuerySelectorAsync(selector).Result.ContentFrameAsync().Result;
            var waitForSelectorOptions = new FrameWaitForSelectorOptions { Timeout = milliseconds, State = WaitForSelectorState.Attached };
            await frame.WaitForSelectorAsync(selector, waitForSelectorOptions);
        }

        public static async Task FrameIsInvisible(string selector, float milliseconds = 10000)
        {
            await Task.Delay(250);
            var frame = Browser.Driver.QuerySelectorAsync(selector).Result.ContentFrameAsync().Result;
            var waitForSelectorOptions = new FrameWaitForSelectorOptions { Timeout = milliseconds, State = WaitForSelectorState.Detached };
            await frame.WaitForSelectorAsync(selector, waitForSelectorOptions);
        }


    }
}
