namespace Playwright.PageObjects
{
    public partial class Basket
    {

        public static async Task ClickCartBtn()
        {
            await Browser.Navigate(WebEndpoints.BASKET);
            await WaitUntil.CustomElementIsVisible(btncheckOutNow);
        }

        public static async Task ClickPayPalBtn()
        {
            await WaitUntil.CustomElementIsVisible(framePayPal);
            var frame = await Browser.Driver.QuerySelectorAsync(framePayPal).Result.ContentFrameAsync();
            await Browser.Driver.QuerySelectorAsync(framePayPal).Result.ScrollIntoViewIfNeededAsync();
            await frame.ClickAsync(btnPayPal);
            var defaultFrame = frame.ParentFrame;
        }

        public static async Task<int> GetOrderCount()
        {
            await WaitUntil.CustomElementIsVisible(orderTotalVal);
            await WaitUntil.WaitSomeInterval(500);
            return Browser.Driver.QuerySelectorAllAsync(textPrice).Result.Count;
        }


        public static async Task<double> GetOrderTotal()
        {
            await WaitUntil.CustomElementIsVisible(orderTotalVal);
            await WaitUntil.WaitSomeInterval(500);
            return double.Parse((await Browser.Driver.QuerySelectorAsync(orderTotalVal))?.TextContentAsync().Result?[1..] ?? throw new Exception("Value is Null"));
        }


        public static async Task ClickAddMoreBtn()
        {
            await Button.Click(addMoreTicketsBtn);
        }


        public static async Task ApplyCouponCode(string coupon)
        {
            await InputBox.Element(couponInput, coupon);
            await Button.Click(applyCouponBtn);
            await WaitUntil.WaitSomeInterval(1500);
        }


        public static async Task ClickCheckoutNowBtn()
        {
            await Button.Click(checkOutNowBtn);
        }


        public static async Task OpenOrderSummary()
        {
            await Button.Click(orderSummaryBtn);
        }


        public static async Task EnterCardDetails()
        {
            await WaitUntil.CustomElementIsVisible(framePaymentNumber);
            IFrame frame = await Browser.Driver.QuerySelectorAsync(framePaymentNumber).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCardNumber, CardDetails.CARD_NUMBER[RandomHelper.RandomIntNumber(CardDetails.CARD_NUMBER.Count)]);
            var defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentExpiry).Result.ContentFrameAsync();
            await frame.TypeAsync(inputExpiryDate, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentCvv).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCvv, "100");
            defaultFrame = frame.ParentFrame;
        }


        public static async Task EnterCardDetails(string cvv)
        {
            await WaitUntil.CustomElementIsVisible(btnPay);
            var frame = await Browser.Driver.QuerySelectorAsync(framePaymentNumber).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCardNumber, "372688581899681");
            var defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentExpiry).Result.ContentFrameAsync();
            await frame.TypeAsync(inputExpiryDate, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentCvv).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCvv, cvv);
            defaultFrame = frame.ParentFrame;
            await WaitUntil.CustomElementIsVisible(btnPay);
        }



        public static async Task ClickPayNowBtn()
        {
            await Button.Click(btnPay);
        }


        public static async Task ClickPayNowBtnSub()
        {
            await Button.Click(btnPaySub);
        }


        public static async Task ConfirmPurchaseStage()
        {
            var frame = await Browser.Driver.QuerySelectorAsync(frameCheckout).Result.ContentFrameAsync();
            await frame.TypeAsync(inputPasswordCheckout, "Checkout1!");
            await frame.ClickAsync(btnContinueCheckout);
            await WaitUntil.FrameIsInvisible(frameCheckout, 120000);
            var defaultFrame = frame.ParentFrame;
        }


        public static async Task ConfirmPurchaseLive()
        {
            await WaitUntil.FrameIsVisible(frameCheckout);
            await WaitUntil.CustomElementIsInvisible(frameCheckout, 120000);
        }


        public static async Task WaitForTimeout()
        {
            var frame = await Browser.Driver.QuerySelectorAsync(frameCheckout).Result.ContentFrameAsync();
            await frame.TypeAsync(inputPasswordCheckout, "Checkout1!");
            await WaitUntil.FrameIsInvisible(frameCheckout, 720000);
            var defaultFrame = frame.ParentFrame;
            await WaitUntil.CustomElementIsVisible(btncheckOutNow);
        }

        public static async Task EnterEmail(string email)
        {
            await WaitUntil.CustomElementIsVisible(inputEmail);
            await InputBox.Element(inputEmail, email);
        }


        public static async Task MakeAPurchaseAsUnauthorizedUser(string email)
        {
            await ClickCheckoutNowBtn();
            await SelectedCharity();
            await EnterEmail(email);
            await EnterCardDetails();
            await ClickPayNowBtn();
        }


        public static async Task MakeAPurchaseAsAuthorizedUser()
        {
            await ClickCheckoutNowBtn();
            await EnterCardDetails();
            await ClickPayNowBtn();
        }

        public static async Task MakeAPurchasePayPal()
        {
            await ClickCheckoutNowBtn();
            //await ClickPayPalBtn();
            await PayPal.LogInPayPal();


        }

        public static async Task MakeAPurchaseSubscriptionAsUnauthorizedUser(string email, string subscriptionId)
        {
            await GoToBasket(subscriptionId);
            await EnterEmail(email);
            await EnterCardDetails();
            await ClickPayNowBtnSub();
        }


        public static async Task MakeAPurchaseSubscriptionAsAuthorizedUser(string subscriptionId)
        {
            await GoToBasket(subscriptionId);
            await EnterCardDetails();
            await ClickPayNowBtnSub();
        }


        private static async Task GoToBasket(string subscriptionId)
        {
            await Browser.Navigate(WebEndpoints.WEBSITE_HOST + $"/subscriptions/{subscriptionId}/payment");
            await WaitUntil.WaitSomeInterval(1000);
            await Browser.Driver.ReloadAsync();
        }

        public static async Task SelectedCharity()
        {
            await Button.Click(inputCharity);
            await SelectCharity();
        }

        private static async Task SelectCharity()
        {
            string text = Charities.CHARITY[RandomHelper.RandomCharityNumber(10)];
            await DropdownList.SelectDropdownItemByText(listCharities, text);
        }
    }
}
