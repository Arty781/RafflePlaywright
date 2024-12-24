using Fizzler;

namespace PlaywrightRaffle.PageObjects
{
    public partial class Basket
    {

        public static async Task ClickCartBtn()
        {
            await Browser.Navigate(WebEndpoints.PAYMENT);
            await WaitUntil.WaitSomeInterval();
            await WaitUntil.CustomElementIsVisible(btnPaySub);
        }

        public static async Task ClickCartBtn(IPage page)
        {
            await WaitUntil.WaitSomeInterval(500);
            await page.GotoAsync(WebEndpoints.PAYMENT, new() { WaitUntil = WaitUntilState.DOMContentLoaded, Timeout = 120000 });
            await WaitUntil.WaitSomeInterval();
            await WaitUntil.CustomElementIsVisible(page, btnPaySub);
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

        public static async Task ActivatePrepaid(int index)
        {
            await Button.Click(checkboxPrepaidSubscription.Replace("1", $"{index}"));
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
            await WaitUntil.CustomElementIsVisible("div.checkout-content > h1");
            await Button.Click("div.checkout-content > h1");
            await WaitUntil.CustomElementIsVisible(formPayment);
            var f = await Browser.Driver.QuerySelectorAsync(framePaymentNumber);
            var frame = await f.ContentFrameAsync();
            await frame.QuerySelectorAsync(framePaymentNumber);
            await frame.ContentAsync();
            await frame.TypeAsync(inputCardNumber, CardDetails.CARD_NUMBER[RandomHelper.RandomIntNumber(CardDetails.CARD_NUMBER.Count)]);
            var defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentExpiry).Result.ContentFrameAsync();
            await frame.TypeAsync(inputExpiryDate, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentCvv).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCvv, "100");
            defaultFrame = frame.ParentFrame;
        }

        public static async Task EnterSubscriptionCardDetails()
        {
            Random random = new Random();
            await WaitUntil.CustomElementIsVisible("div.checkout-content > h1");
            await Button.Click("div.checkout-content > h1");
            await WaitUntil.CustomElementIsVisible(formSubscriptionPayment);
            var f = await Browser.Driver.QuerySelectorAsync(framePaymentNumber);
            var frame = await f.ContentFrameAsync();
            await frame.QuerySelectorAsync(framePaymentNumber);
            await frame.ContentAsync();
            await frame.TypeAsync(inputCardNumber, CardDetails.CARD_NUMBER[random.Next(CardDetails.CARD_NUMBER.Count)]);
            var defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentExpiry).Result.ContentFrameAsync();
            await frame.TypeAsync(inputExpiryDate, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentCvv).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCvv, "100");
            defaultFrame = frame.ParentFrame;
        }

        public static async Task EnterSubscriptionCardDetails(IPage page)
        {
            Random random = new Random();
            await WaitUntil.CustomElementIsVisible(page, "div.checkout-content > h1");
            await Button.Click(page, "div.checkout-content > h1");
            await WaitUntil.CustomElementIsVisible(page, formSubscriptionPayment);
            var f = await page.QuerySelectorAsync(framePaymentNumber);
            var frame = await f.ContentFrameAsync();
            await frame.QuerySelectorAsync(framePaymentNumber);
            await frame.ContentAsync();
            await frame.TypeAsync(inputCardNumber, CardDetails.CARD_NUMBER[random.Next(CardDetails.CARD_NUMBER.Count)]);
            var defaultFrame = frame.ParentFrame;
            frame = await page.QuerySelectorAsync(framePaymentExpiry).Result.ContentFrameAsync();
            await frame.TypeAsync(inputExpiryDate, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            defaultFrame = frame.ParentFrame;
            frame = await page.QuerySelectorAsync(framePaymentCvv).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCvv, "100");
            defaultFrame = frame.ParentFrame;
        }

        public static async Task<string> EnterSubscriptionCardDetailsMultyCards()
        {
            Random random = new Random();
            var cardNumber = CardDetails.CARD_NUMBER[random.Next(CardDetails.CARD_NUMBER.Count)];
            await WaitUntil.CustomElementIsVisible("div.checkout-content > h1");
            await Button.Click("div.checkout-content > h1");
            await WaitUntil.CustomElementIsVisible(formSubscriptionPayment);
            var f = await Browser.Driver.QuerySelectorAsync(framePaymentNumber);
            var frame = await f.ContentFrameAsync();
            await frame.QuerySelectorAsync(framePaymentNumber);
            await frame.ContentAsync();
            await frame.TypeAsync(inputCardNumber, cardNumber);
            var defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentExpiry).Result.ContentFrameAsync();
            await frame.TypeAsync(inputExpiryDate, DateTime.Now.AddYears(2).ToString("MM'/'yy"));
            defaultFrame = frame.ParentFrame;
            frame = await Browser.Driver.QuerySelectorAsync(framePaymentCvv).Result.ContentFrameAsync();
            await frame.TypeAsync(inputCvv, "100");
            defaultFrame = frame.ParentFrame;
            return cardNumber;
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

        public static async Task ClickPayNowBtnSub(IPage page)
        {
            await Button.Click(page, btnPaySub);
        }

        //public static async Task ConfirmPurchaseStage()
        //{
        //    await WaitUntil.CustomElementIsVisible(frameCheckout, 12000);
        //    var f = await Browser.Driver.QuerySelectorAsync(frameCheckout);
        //    var frame = await f.ContentFrameAsync();
        //    await frame.QuerySelectorAsync(frameCheckout);
        //    await frame.ContentAsync();
        //    await frame.FillAsync(inputPasswordCheckout, "Checkout1!");
        //    await frame.ClickAsync(btnContinueCheckout);
        //    await WaitUntil.FrameIsInvisible(frameCheckout, 120000);
        //    var defaultFrame = frame.ParentFrame;
        //}

        public static async Task ConfirmPurchaseStage()
        {
            await WaitUntil.CustomElementIsVisible(frameCheckout, 12000);
            // Wait for the frame to be available
            var elementHandle = await Browser.Driver.QuerySelectorAsync(frameCheckout);
            if (elementHandle == null) throw new Exception("Frame checkout not found");

            var frame = await elementHandle.ContentFrameAsync();
            if (frame == null) throw new Exception("Could not access frame content");

            // Ensure element visibility before proceeding
            await WaitUntil.CustomElementIsVisible(frame, 12000);

            // Perform actions
            await frame.FillAsync(inputPasswordCheckout, "Checkout1!");
            await frame.ClickAsync(btnContinueCheckout);

            // Wait for the frame to be invisible (navigation complete)
            await WaitUntil.FrameIsInvisible(frameCheckout, 120000);
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
            //await ClickCheckoutNowBtn();
            //await SelectedCharity();
            await EnterEmail(email);
            await EnterCardDetails();
            await ClickPayNowBtn();
        }

        public static async Task MakeAPurchaseSubscriptionAsUnauthorizedUser(string email)
        {
            //await ClickCheckoutNowBtn();
            //await SelectedCharity();
            await EnterEmail(email);
            await EnterSubscriptionCardDetails();
            await ClickPayNowBtn();
        }


        public static async Task MakeAPurchaseAsAuthorizedUser()
        {
            //await ClickCheckoutNowBtn();
            await EnterCardDetails();
            await ClickPayNowBtn();
        }

        public static async Task MakeAPurchasePayPal()
        {
            //await ClickCheckoutNowBtn();
            //await ClickPayPalBtn();
            await PayPal.LogInPayPal();


        }

        public static async Task MakeAPurchaseSubscriptionAsUnauthorizedUser(string email, string subscriptionId)
        {
            await GoToBasket(subscriptionId);
            await EnterEmail(email);
            await EnterSubscriptionCardDetails();
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
            var l = Browser.Driver.QuerySelectorAllAsync(listCharities).Result.Select(x=>x.TextContentAsync()).ToList();
            
            
            await DropdownList.SelectDropdownItemByText(listCharities, text);
        }
    }
}
