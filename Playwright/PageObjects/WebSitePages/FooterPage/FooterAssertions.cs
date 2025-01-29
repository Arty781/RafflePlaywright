namespace PlaywrightRaffle.PageObjects
{
    public partial class Footer
    {
        public static async Task VerifyIsDisplayedFooterTitle()
        {
            await WaitUntil.CustomElementIsVisible(textTitleFooter);

            var title = await Browser.Driver.QuerySelectorAsync(textTitleFooter)
                                            .ContinueWith(t => t.Result.TextContentAsync())
                                            .Unwrap();

            Assert.That(
                title.Trim().Equals(FooterText.FOOTER_TITLE.Trim(), StringComparison.CurrentCultureIgnoreCase),
                Is.True,
                $"\"{title}\" not matched with \"{FooterText.FOOTER_TITLE}\""
            );
        }

        public static async Task VerifyIsDisplayedFooterParagraph()
        {
            await WaitUntil.CustomElementIsVisible(textParagraphFooter);

            var paragraph = await Browser.Driver.QuerySelectorAsync(textParagraphFooter)
                                                .ContinueWith(t => t.Result.TextContentAsync())
                                                .Unwrap();

            Assert.That(
                paragraph.Trim().Equals(FooterText.FOOTER_PARAGRAPH.Trim(), StringComparison.CurrentCultureIgnoreCase),
                Is.True,
                $"\"{paragraph}\" not matched with \"{FooterText.FOOTER_PARAGRAPH}\""
            );
        }

        public static async Task VerifyIsDisplayedContactLinks()
        {
            await WaitUntil.CustomElementIsVisible(textLinkContactsFooter);

            var links = await Browser.Driver.QuerySelectorAllAsync(textLinkContactsFooter);
            var actualLinks = await Task.WhenAll(links.Select(async link => (await link.TextContentAsync()).Trim()));
            actualLinks = await Task.WhenAll(links.Select(async link => (await link.TextContentAsync()).Trim()));

            Assert.That(
                actualLinks.Length,
                Is.EqualTo(FooterText.FOOTER_CONTACTS_LINKS.Count),
                $"Expected {FooterText.FOOTER_CONTACTS_LINKS.Count} links but found {actualLinks.Length}."
            );

            for (int i = 0; i < actualLinks.Length; i++)
            {
                Assert.That(
                    actualLinks[i].Equals(FooterText.FOOTER_CONTACTS_LINKS[i], StringComparison.CurrentCultureIgnoreCase),
                    Is.True,
                    $"Not matched. Expected: \"{FooterText.FOOTER_CONTACTS_LINKS[i]}\". Actual: \"{actualLinks[i]}\""
                );
            }
        }


        public static async Task VerifyIsDisplayedSponsorLinks()
        {
            await WaitUntil.CustomElementIsVisible(textLinkSponsorFooter);
            var links = await Browser.Driver.QuerySelectorAllAsync(textLinkSponsorFooter);
            var actualLinks = await Task.WhenAll(links.Select(async link => (await link.TextContentAsync()).Trim()));
            Assert.That(
                actualLinks.Length,
                Is.EqualTo(FooterText.FOOTER_SPONSORS_LINKS.Count),
                $"Expected {FooterText.FOOTER_SPONSORS_LINKS.Count} links but found {actualLinks.Length}."
            );
            for (int i = 0; i < actualLinks.Length; i++)
            {
                Assert.That(
                    actualLinks[i].Equals(FooterText.FOOTER_SPONSORS_LINKS[i], StringComparison.CurrentCultureIgnoreCase),
                    Is.True,
                    $"Not matched. Expected: \"{FooterText.FOOTER_SPONSORS_LINKS[i]}\". Actual: \"{actualLinks[i]}\""
                );
            }

        }
    }
}
