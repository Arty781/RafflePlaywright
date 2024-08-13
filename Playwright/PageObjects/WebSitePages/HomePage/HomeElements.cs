namespace PlaywrightRaffle.PageObjects
{
    public partial class Home
    {
        #region Top Slider

        public const string tbsSlider = "//div[contains(@class,'change-button')]/button";
        public const string btnPrevTopSlider = "//div[@class='startpage-slider']//button[@class='slick-arrow slick-prev']";
        public const string btnNextTopSlider = "//div[@class='startpage-slider']//button[@class='slick-arrow slick-next']";
        public const string imgSlider = "div.startpage-slider div.gallery-image";
        public const string imgFloorPlan = "//img[@alt='floorplan']";
        public const string imgMap = "//img[@alt='dreamhome location']";

        #endregion

        #region Banner Secondary Section

        public const string textTitleBannerSecondary = "div h1";
        public const string textSubtitleBannerSecondary = "div.home-page-title-block p";
        public const string btnTicketSelectorDreamCard = "div.dream-home-card button";
        public const string btnTicketSelectorBannerSecondary = "section.banner-secondary button";
        public const string btnTicketSelectorSecondSlider = "div.dream-slider-bg div.container button";

        #endregion

        #region Info blocks
#if CHROME || FIREFOX || DEBUG

        public const string textTitle = "div h3";
        public const string textParagraph = "div p";
        public const string textBottomSliderTitle = "//div[contains(@class,'dream-slider-bg')]//h2";
        public const string textBottomSliderParagraph = "div.dream-slider-bg p";
        public const string btnTicketSelectorInfoBlock = "//div//button[contains(text(),'Enter Now')]";

#endif

#if RELEASE

        public const string textTitle = "//div[@class='info-block']/div[@class='desktop']//h2";
        public const string textParagraph = "//div[@class='info-block']/div[@class='desktop']//p";
        public const string textBottomSliderTitle = "//div[@class='dream-slider-bg']/div[@class='container']//h2";
        public const string textBottomSliderParagraph = "//div[@class='dream-slider-bg']/div[@class='container']//p";
        public const string textCharityTitle = "//section[@class='charitable-home-block']//div[@class='givingAbout']//h2";
        public const string textCharityParagraph = "//section[@class='charitable-home-block']//div[@class='givingAbout']//p";
        public const string textCharityCard = "//section[@class='charitable-home-block']//div[@class='givingAbout']//section//p";
#endif

#if DEBUG_MOBILE || RELEASE_MOBILE

        public const string textTitle = "//div[@class='info-block']/div[@class='mobile']//h2";
        public const string textParagraph = "//div[@class='info-block']/div[@class='mobile']//p[@class='info-block-subtitle-small']";
        public const string textBottomSliderTitle = "//div[@class='dream-slider-bg']/div[@class='container']//h2";
        public const string textBottomSliderParagraph = "//div[@class='dream-slider-bg']/div[@class='container']//p";
        public const string textCharityTitle = "//section[@class='charitable-home-block']//div[@class='givingAboutSlider']//h2";
        public const string textCharityParagraph = "//section[@class='charitable-home-block']//div[@class='givingAboutSlider']//p";
        public const string textCharityCard = "//section[@class='charitable-home-block']//div[@class='givingAboutSlider']//div[@class='cardText']/p";
#endif


        #endregion

        #region How It Works

        public const string textHowItWorksTitle = "section.how-it-works-home h2";
        public const string textHowItWorksParagraph = "section.how-it-works-home div.howMainContent p";
        public const string textHowItWorksStepsTitle = "section.how-it-works-home div.howStepper h3";
        public const string textHowItWorksStepsParagraph = "section.how-it-works-home div.howStepper p";
        public const string btnTicketSelectorHowItWorks = "section.how-it-works-home button";

        #endregion

        #region TicketSelector

        public const string btnPostalBundle = "div.desktop-postal div.postal-card";
        public const string btnBundles = "div.ticket-bundle-card  button";

        #region Tabs

        public const string tabPostal = "#tickets-tab-0";
        public const string tabSinglePurchase = "#tickets-tab-1";
        public const string tabSubscription = "#tickets-tab-2";

        #endregion

        #endregion


    }
}
