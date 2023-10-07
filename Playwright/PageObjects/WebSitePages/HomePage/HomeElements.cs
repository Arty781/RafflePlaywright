﻿namespace Playwright.PageObjects
{
    public partial class Home
    {
        #region Top Slider

        public const string tbsSlider = "//div[contains(@class,'change-button')]/button";
        public const string btnPrevTopSlider = "//section[@class='startpage-slider']//button[@class='slick-arrow slick-prev']";
        public const string btnNextTopSlider = "//section[@class='startpage-slider']//button[@class='slick-arrow slick-next']";
        public const string imgFloorPlan = "//img[@alt='floorplan']";
        public const string imgMap = "//img[@alt='dreamhome location']";

        #endregion

        #region Banner Secondary Section

        public const string textTitleBannerSecondary = "//div[@class='home-page-title-block']/h1";
        public const string textSubtitleBannerSecondary = "//h1/parent::div/p";

        #endregion

        #region Info blocks
#if CHROME || FIREFOX || DEBUG

        public const string textTitle = "//div[@class='info-block']/div[@class='desktop']//h2";
        public const string textParagraph = "//div[@class='info-block']/div[@class='desktop']//p";
        public const string textBottomSliderTitle = "//div[@class='dream-slider-bg']/div[@class='container']//h2";
        public const string textBottomSliderParagraph = "//div[@class='dream-slider-bg']/div[@class='container']//p";
        public const string textCharityTitle = "//section[@class='charitable-home-block']//div[@class='givingAbout']//h2";
        public const string textCharityParagraph = "//section[@class='charitable-home-block']//div[@class='givingAbout']//p";
        public const string textCharityCard = "//section[@class='charitable-home-block']//div[@class='givingAbout']//section//p";

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

        public const string textHowItWorksTitle = "//section[@class='how-it-works-home']//h2";
        public const string textHowItWorksParagraph = "//section[@class='how-it-works-home']//div[@class='howMainContent']/p";
        public const string textHowItWorksStepsTitle = "//section[@class='how-it-works-home']//div[@class='howStepper']//h3";
        public const string textHowItWorksStepsParagraph = "//section[@class='how-it-works-home']//div[@class='howStepper']//p";
        public const string btnDreamTicketSelector = "//button[text()='Enter Now']";
        public const string btnPostalBundle = "//div[text()='Postal Entry']/parent::div";
        public const string btnBundles = "//div[@class='ticket-list']//button[text()='Buy Now']";

        #endregion


    }
}
