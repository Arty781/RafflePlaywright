namespace PlaywrightRaffle.PageObjects
{
    public partial class Holiday
    {

        public static async Task VerifyTopBannerTitle()
        {
            await WaitUntil.CustomElementIsVisible(textTitleBannerSecondary);
            var text = await Browser.Driver.QuerySelectorAsync(textTitleBannerSecondary).Result.TextContentAsync();
            Assert.That(text.ToLower(), Is.EqualTo(HolidayTexts.TOP_TITLE.ToLower()), $"Texts are not matched. Expected \"{HolidayTexts.TOP_TITLE}\" but was \"{text}\"");

        }


        public static async Task VerifyTopBannerSubtitle()
        {
            await WaitUntil.CustomElementIsVisible(textSubtitleBannerSecondary);
            var text = await Browser.Driver.QuerySelectorAsync(textSubtitleBannerSecondary).Result.TextContentAsync();
            string result = Regex.Replace(text, @"&nbsp;|[\u00A0]", "");
            Assert.That(result.ToLower(), Is.EqualTo(HolidayTexts.TOP_SUBTITLE.ToLower()), $"Texts are not matched. Expected \"{HolidayTexts.TOP_SUBTITLE}\" but was \"{result}\"");

        }


        public static async Task VerifyBottomSliderTitle()
        {
            await WaitUntil.CustomElementIsVisible(textBottomSliderTitle);
            var text = await Browser.Driver.QuerySelectorAsync(textBottomSliderTitle).Result.TextContentAsync();
            Assert.That(text.ToLower(), Is.EqualTo(HolidayTexts.BOTTOM_SLIDER_TITLE.ToLower()), $"Texts are not matched. Expected \"{HolidayTexts.BOTTOM_SLIDER_TITLE}\" but was \"{text}\"");

        }


        public static async Task VerifyBottomSliderSubitle()
        {
            await WaitUntil.CustomElementIsVisible(textBottomSliderParagraph);
            var listOfText = Browser.Driver.QuerySelectorAllAsync(textBottomSliderParagraph).Result.ToList();
            for (int i = 0; i < listOfText.Count; i++)
            {
                Assert.That(listOfText[i].TextContentAsync().Result.ToLower(), Is.EqualTo(HolidayTexts.BOTTOM_SLIDER_SUBTITLE[i].ToLower()), $"Texts are not matched. Expected \"{HolidayTexts.BOTTOM_SLIDER_SUBTITLE[i]}\" but was \"{listOfText[i].TextContentAsync().Result}\"");
            }

        }


        public static async Task VerifyInfoBlockTitles()
        {
            await WaitUntil.CustomElementIsVisible(textTitle);
            for (int i = 0; i < HolidayTexts.TITLES_INFO_BLOCKS.Count; i++)
            {
                string expectedTitle = HolidayTexts.TITLES_INFO_BLOCKS[i].ToLower();
                string actualTitle = Browser.Driver.QuerySelectorAllAsync(textTitle).Result[i].TextContentAsync().Result.ToLower();

                Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Not matched. Expected: \"{expectedTitle}\". Actual: \"{actualTitle}\"");
            }


        }


        public static async Task VerifyInfoBlockParagraphs()
        {
            await WaitUntil.CustomElementIsVisible(textParagraph);
            var listOfText = Browser.Driver.QuerySelectorAllAsync(textParagraph).Result.ToList();
            for (int i = 0; i < 5; i++)
            {
                Assert.That(listOfText[i].TextContentAsync().Result.ToLower(), Is.EqualTo(HolidayTexts.PARAGRAPHS_INFO_BLOCKS[i].ToLower()), string.Concat("Not matched ", "\"", listOfText[i].TextContentAsync(), "\"", "\r\nwith ", "\"", HolidayTexts.PARAGRAPHS_INFO_BLOCKS[i], "\""));
            }


        }


        public static async Task VerifyHowItWorksTitle()
        {
            await WaitUntil.CustomElementIsVisible(textHowItWorksTitle);
            var text = Browser.Driver.QuerySelectorAsync(textHowItWorksTitle).Result.TextContentAsync().Result;
            Assert.That(text.ToLower(), Is.EqualTo(HolidayTexts.HOW_IT_WORKS_TITLE.ToLower()), $"Texts are not matched. Expected \"{HolidayTexts.HOW_IT_WORKS_TITLE}\" but was \"{text}\"");

        }


        public static async Task VerifyHowItWorksParagraph()
        {
            await WaitUntil.CustomElementIsVisible(textHowItWorksParagraph);
            var text = Browser.Driver.QuerySelectorAsync(textHowItWorksParagraph).Result.TextContentAsync().Result;
            Assert.That(text.ToLower(), Is.EqualTo(HolidayTexts.HOW_IT_WORKS_PARAGRAPH.ToLower()), $"Texts are not matched. Expected \"{HolidayTexts.HOW_IT_WORKS_PARAGRAPH}\" but was \"{text}\"");

        }


        public static async Task VerifyHowItWorksStepsTitles()
        {
            await WaitUntil.CustomElementIsVisible(textHowItWorksStepsTitle);
            var text = Browser.Driver.QuerySelectorAllAsync(textHowItWorksStepsTitle).Result.Select(x => x.TextContentAsync()).ToList();
            for (int i = 0; i < 3; i++)
            {

                Assert.That(text[i].Result.ToLower(), Is.EqualTo(HolidayTexts.TITLES_STEPS[i].ToLower()), $"Texts are not matched. Expected \"{HolidayTexts.TITLES_STEPS[i]}\" but was \"{text[i].Result}\"");
            }

        }


        public static async Task VerifyHowItWorksStepsParagraphs()
        {
            await WaitUntil.CustomElementIsVisible(textHowItWorksStepsTitle);
            for (int i = 0; i < 3; i++)
            {
                string expectedParagraph = HolidayTexts.PARAGRAPHS_STEPS[i].ToLower();
                var actualParagraph = TextBox.GetTextForList(textHowItWorksStepsParagraph, i).Result.ToLower();

                Assert.That(actualParagraph, Is.EqualTo(expectedParagraph), $"Not matched. Expected: \"{expectedParagraph}\". Actual: \"{actualParagraph}\"");
            }


        }

    }
}
