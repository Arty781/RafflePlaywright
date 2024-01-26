namespace PlaywrightRaffle.PageObjects
{
    public partial class Basket
    {
        public const string textPrice = "//div[@class='your-basket-ticket-price']";
        public const string addMoreTicketsBtn = "//button[@class='your-basket-ticket-select']";
        public const string removeOrderBtn = "//button[@class='basket-btn']";
        public const string couponInput = "//input[@name='coupon-input']";
        public const string applyCouponBtn = "//button[@class='apply-coupon-btn']";
        public const string checkOutNowBtn = "//div[@class='itemPrice']/button";
        public const string orderTotalVal = "//div[@class='itemPrice total-credit']/div[2]";
        public const string cbbxOrderSummary = "div.checkout-header > div:nth-child(2)";
        public const string cbbxOrderTotal = "#order-total-wrapper > h1 > span";
        public const string cbbxOrderHeader = "div.big-cart-item-header";
        public const string cbbxRemoveOrderBtn = "button.remove-order-button";
        public const string inputCharity = "div.select-wrapper";
        public const string listCharities = "#menu- ul > li";
        public const string dropItemCharities = "#menu- ul > li";
        public const string ageControlSection = "//div[@class='age-control-section']/label//span/input";
        public const string checkboxAgeControl = "//input[@name='checkedB'";
        public const string formPayment = "#payment-form";
        public const string framePaymentNumber = "//iframe[@id='cardNumber']";
        public const string framePaymentExpiry = "#expiryDate";
        public const string framePaymentCvv = "#cvv";
        public const string inputCardNumber = "#checkout-frames-card-number";
        public const string inputExpiryDate = "#checkout-frames-expiry-date";
        public const string inputCvv = "#checkout-frames-cvv";
        public const string btnPay = "#pay-button";
        public const string btnPaySub = "#subscription-pay-button";
        public const string orderSummaryBtn = "div.checkout-header";
        public const string framePayPal = "div.paypal-buttons iframe:nth-child(2)";
        public const string btnPayPal = "#buttons-container div.paypal-button";
        

        #region Checkout Verification page

        public const string frameCheckout = "//iframe[@name='cko-3ds2-iframe']";
        public const string inputPasswordCheckout = "//input[@id='password']";
        public const string btnContinueCheckout = "//input[@value='Continue']";
        public const string btncheckOutNow = "//button[@class='rafflebtn primary full-width']";
        public const string inputEmail = "//input[@name='email']";
        public const string textErrorMessage = "//div[@class='status-payment-container']/span";

        #endregion
    }
}