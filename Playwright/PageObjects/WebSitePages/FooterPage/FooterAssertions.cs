namespace Playwright.PageObjects
{
    public partial class Footer
    {
        public static async Task VerifyIsDisplayedFooterTitle()
        {
            await WaitUntil.CustomElementIsVisible(textTitleFooter);
            var title = Browser.Driver.QuerySelectorAsync(textTitleFooter).Result.TextContentAsync().Result;
            Assert.That(title.ToLower() == FooterText.FOOTER_TITLE.ToLower(), Is.True, string.Concat("\"", title, "\"", " not matched with ", FooterText.FOOTER_TITLE));
        }

        public static async Task VerifyIsDisplayedFooterParagraph()
        {
            await WaitUntil.CustomElementIsVisible(textParagraphFooter);
            var paragraph = Browser.Driver.QuerySelectorAsync(textParagraphFooter).Result.TextContentAsync().Result;
            Assert.That(paragraph.ToLower() == FooterText.FOOTER_PARAGRAPH.ToLower(), Is.True, string.Concat("\"", paragraph, "\"", " not matched with ", FooterText.FOOTER_PARAGRAPH));
        }

        public static async Task VerifyIsDisplayedContactLinks()
        {
            await WaitUntil.CustomElementIsVisible(textLinkContactsFooter);
            var links = Browser.Driver.QuerySelectorAllAsync(textLinkContactsFooter).Result.ToList();
            for (int i = 0; i < links.Count; i++)
            {
                string expectedLink = FooterText.FOOTER_CONTACTS_LINKS[i].ToLower();
                string actualLink = links[i].TextContentAsync().Result.ToLower();
                Assert.That(actualLink, Is.EqualTo(expectedLink), $"Not matched. Expected: \"{expectedLink}\". Actual: \"{actualLink}\"");
            }
        }

        public static async Task VerifyIsDisplayedSponsorLinks()
        {
            await WaitUntil.CustomElementIsVisible(textLinkSponsorFooter);
            var links = Browser.Driver.QuerySelectorAllAsync(textLinkSponsorFooter).Result.ToList();
            for (int i = 0; i < links.Count; i++)
            {
                string expectedLink = FooterText.FOOTER_SPONSORS_LINKS[i].ToLower();
                string actualLink = links[i].TextContentAsync().Result.ToLower();
                Assert.That(actualLink, Is.EqualTo(expectedLink), $"Not matched. Expected: \"{expectedLink}\". Actual: \"{actualLink}\"");
            }
        }
    }
}
