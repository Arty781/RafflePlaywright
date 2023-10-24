﻿namespace PlaywrightRaffle.PageObjects
{
    public partial class Home
    {

        public static async Task VerifySecondaryBannerTitle()
        {
            await WaitUntil.CustomElementIsVisible(textTitleBannerSecondary);
            var text = TextBox.GetText(textTitleBannerSecondary).Result;
            Assert.That(text.ToLower(), Is.EqualTo(HomeTexts.SECONDARY_BANNER_TITLE.ToLower()), $"Texts are not matched. Expected \"{HomeTexts.SECONDARY_BANNER_TITLE}\" but was \"{text}\"");

        }


        public static async Task VerifySecondaryBannerSubtitle()
        {
            await WaitUntil.CustomElementIsVisible(textSubtitleBannerSecondary);
            var text = TextBox.GetText(textSubtitleBannerSecondary).Result;
            Assert.That(text.ToLower(), Is.EqualTo(HomeTexts.SECONDARY_BANNER_SUBTITLE.ToLower()), $"Texts are not matched. Expected \"{HomeTexts.SECONDARY_BANNER_SUBTITLE}\" but was \"{text}\"");

        }


        public static async Task VerifyBottomSliderTitle()
        {
            await WaitUntil.CustomElementIsVisible(textBottomSliderTitle);
            var text = TextBox.GetText(textBottomSliderTitle).Result;
            Assert.That(text.ToLower(), Is.EqualTo(HomeTexts.BOTTOM_SLIDER_TITLE.ToLower()), $"Texts are not matched. Expected \"{HomeTexts.BOTTOM_SLIDER_TITLE}\" but was \"{text}\"");

        }


        public static async Task VerifyBottomSliderSubitle()
        {
            await WaitUntil.CustomElementIsVisible(textBottomSliderParagraph);
            var listOfText = TextBox.GetListOfTexts(textBottomSliderParagraph).Result;
            for (int i = 0; i < listOfText.Count; i++)
            {
                Assert.That(listOfText[i].ToLower(), Is.EqualTo(HomeTexts.BOTTOM_SLIDER_SUBTITLE[i].ToLower()), $"Texts are not matched. Expected \"{HomeTexts.BOTTOM_SLIDER_SUBTITLE[i]}\" but was \"{listOfText[i]}\"");
            }

        }


        public static async Task VerifyInfoBlockTitles()
        {
            await WaitUntil.CustomElementIsVisible(textTitle);
            for (int i = 0; i < HomeTexts.TITLES_INFO_BLOCKS.Count; i++)
            {
                string expectedTitle = HomeTexts.TITLES_INFO_BLOCKS[i].ToLower();
                string actualTitle = Browser.Driver.QuerySelectorAllAsync(textTitle).Result[i].TextContentAsync().Result.ToLower();

                Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Not matched. Expected: \"{expectedTitle}\". Actual: \"{actualTitle}\"");
            }


        }


        public static async Task VerifyInfoBlockParagraphs()
        {
            await WaitUntil.CustomElementIsVisible(textParagraph);
            var listOfText = TextBox.GetListOfTexts(textParagraph).Result;
            for (int i = 0; i < listOfText.Count; i++)
            {
                Assert.That(listOfText[i].ToLower(), Is.EqualTo(HomeTexts.PARAGRAPHS_INFO_BLOCKS[i].ToLower()), string.Concat("Not matched ", "\"", listOfText[i], "\"", "\r\nwith ", "\"", HomeTexts.PARAGRAPHS_INFO_BLOCKS[i], "\""));
            }


        }


        public static async Task VerifyHowItWorksTitle()
        {
            await WaitUntil.CustomElementIsVisible(textHowItWorksTitle);
            var text = Browser.Driver.QuerySelectorAsync(textHowItWorksTitle).Result.TextContentAsync().Result;
            Assert.That(text.ToLower(), Is.EqualTo(HomeTexts.HOW_IT_WORKS_TITLE.ToLower()), $"Texts are not matched. Expected \"{HomeTexts.HOW_IT_WORKS_TITLE}\" but was \"{text}\"");

        }


        public static async Task VerifyHowItWorksParagraph()
        {
            await WaitUntil.CustomElementIsVisible(textHowItWorksParagraph);
            var text = Browser.Driver.QuerySelectorAsync(textHowItWorksParagraph).Result.TextContentAsync().Result;
            Assert.That(text.ToLower(), Is.EqualTo(HomeTexts.HOW_IT_WORKS_PARAGRAPH.ToLower()), $"Texts are not matched. Expected \"{HomeTexts.HOW_IT_WORKS_PARAGRAPH}\" but was \"{text}\"");

        }


        public static async Task VerifyHowItWorksStepsTitles()
        {
            await WaitUntil.CustomElementIsVisible(textHowItWorksStepsTitle);
            var text = Browser.Driver.QuerySelectorAllAsync(textHowItWorksStepsTitle).Result.Select(x => x.TextContentAsync()).ToList();
            for (int i = 0; i < 3; i++)
            {

                Assert.That(text[i].Result.ToLower(), Is.EqualTo(HomeTexts.TITLES_STEPS[i].ToLower()), $"Texts are not matched. Expected \"{HomeTexts.TITLES_STEPS[i]}\" but was \"{text[i].Result}\"");
            }

        }


        public static async Task VerifyHowItWorksStepsParagraphs()
        {
            await WaitUntil.CustomElementIsVisible(textHowItWorksStepsTitle);
            for (int i = 0; i < 3; i++)
            {
                string expectedParagraph = HomeTexts.PARAGRAPHS_STEPS[i].ToLower();
                var actualParagraph = TextBox.GetTextForList(textHowItWorksStepsParagraph, i).Result.ToLower();

                Assert.That(actualParagraph, Is.EqualTo(expectedParagraph), $"Not matched. Expected: \"{expectedParagraph}\". Actual: \"{actualParagraph}\"");
            }


        }

    }
}
