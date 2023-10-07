namespace Playwright.PageObjects
{
    public partial class PayPal
    {
        public static async Task LogInPayPal()
        {

            await Basket.ClickPayPalBtn();

            while (Browser.Driver.Context.Pages.Count < 2)
            {
                await Task.Delay(1000);
            }
            var windows = Browser.Driver.Context.Pages;
            var popup = windows[1];
            await popup.WaitForSelectorAsync(inputEmail, new() { Timeout = 10000 });
            await popup.TypeAsync(inputEmail, "testuseroutsite@gmail.com", new() { Timeout = 10000 });
            await popup.WaitForSelectorAsync(btnNext);
            await popup.ClickAsync(btnNext, new() { Timeout = 10000 });
            await popup.WaitForSelectorAsync(inputPassword);
            await popup.TypeAsync(inputPassword, "Zaq1991qaZ", new() { Timeout = 10000 });
            await popup.WaitForSelectorAsync(btnSignIn);
            await popup.ClickAsync(btnSignIn, new() { Timeout = 10000 });

            await popup.WaitForSelectorAsync(btnSubmit);
            await popup.ClickAsync(btnSubmit, new() { Timeout = 10000 });

            Browser.Page = windows[0];


        }

    }
}
