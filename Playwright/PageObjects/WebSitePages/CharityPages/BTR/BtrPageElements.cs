﻿namespace PlaywrightRaffle.PageObjects
{
    public partial class BtrPage
    {
        #region Top Slider

        public const string tbsSlider = "//div[contains(@class,'change-button')]/button";
        public const string btnPrevSlider = "//div[@class='startpage-slider']//button[@class='slick-arrow slick-prev']";
        public const string btnNextSlider = "//div[@class='startpage-slider']//button[@class='slick-arrow slick-next']";
        public const string imgFloorPlan = "//img[@alt='floorplan']";
        public const string imgMap = "//img[@alt='dreamhome location']";

        #endregion

        #region Banner Secondary Section

        public const string textMainTitle = "div.video-block-heading p";
        public const string textSecondTitle= "div.charity-block-wrap h2";
        public const string textSubtitle = "div.charity-block-wrap p";
        public const string btnTicketSelectorBannerSecondary = "section.banner-secondary button";
        public const string btnTicketSelectorSecondSlider = "div.dream-slider-bg div.container button";

        #endregion

        #region Key highlights

        public const string textKeyHighlights = "div.dream-draw__items span";
        public const string titleKeyHighlights = "div.dream-draw__items h1";
        public const string titleKeyHighlightsCards = "div.dream-draw-item__title";
        public const string textKeyHighlightsDesc = "div.dream-draw-description";
        public const string textKeyHighlightsValues = "section.bg-1 div.faq-questions-container > div.wrapper div.answer-container li";





        #endregion

        #region Info blocks

        public const string textTitle = "div.info-block > div.desktop h2";
        public const string textParagraph = "div.info-block > div.desktop p";
        public const string textBottomSliderTitle = "//div[contains(@class,'dream-slider-bg')]//h2";
        public const string textBottomSliderParagraph = "div.dream-slider-bg p";
        public const string btnTicketSelectorInfoBlock = "div.info-block div.desktop button";

        #endregion

        #region How It Works

        public const string textHowItWorksTitle = "section.how-it-works-home h2";
        public const string textHowItWorksParagraph = "section.how-it-works-home div.howMainContent p";
        public const string textHowItWorksStepsTitle = "section.how-it-works-home h3";
        public const string textHowItWorksStepsParagraph = "section.how-it-works-home div.howStepper p";
        public const string btnTicketSelectorHowItWorks = "section.how-it-works-home button";

        #endregion

        #region TicketSelector

        public const string btnPostalBundle = "div.desktop-postal div.postal-card";
        public const string btnBundles = "div.ticket-card button";

        #endregion


    }
}
