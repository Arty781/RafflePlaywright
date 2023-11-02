namespace PlaywrightRaffle.PageObjects
{
    public partial class Postal
    {
        public static async Task VerifyDisplayingTitle()
        {
            await WaitUntil.CustomElementIsVisible(textTitlePostPage);
            var title = await Browser.Driver.QuerySelectorAsync(textTitlePostPage).Result.TextContentAsync();
            Assert.That(title.ToLower() == PostText.TITLE_POST.ToLower(), Is.True);
        }
        public static async Task VerifyDisplayingParagraphs()
        {
            await WaitUntil.CustomElementIsVisible(textParagraphsPostPage);
            List<string> expectedText = PostText.PARAGRAPH_POST.Where(x => x.Any()).Select(x => x.Trim().ToLower()).ToList();
            List<string> actualText = TextBox.GetListOfTexts(textParagraphsPostPage).Result.Where(x => x.Any()).Select(x => x.Trim().ToLower()).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(actualText, Is.EqualTo(expectedText), "Texts don't match");
                Assert.That(expectedText.Count, Is.EqualTo(actualText.Count), "Number of elements doesn't match");

                var mismatchedIndices = expectedText.Select((text, index) => new { text, index })
                    .Where(item => !actualText[item.index].Equals(item.text))
                    .Select(item => item.index)
                    .ToList();

                if (mismatchedIndices.Count > 0)
                {
                    string errorMessage = $"Expected text does not match the actual text at index(es): {string.Join(", ", mismatchedIndices)}";
                    Assert.Fail(errorMessage);
                }
            });

        }
        public static async Task VerifyDisplayingLinks()
        {
            await WaitUntil.CustomElementIsVisible(textLinksPostPage);
            var links = Browser.Driver.QuerySelectorAllAsync(textLinksPostPage).Result.ToList();
            for (int i = 0; i < links.Count; i++)
            {
                Assert.That(links[i].TextContentAsync().Result.ToLower() + " " == PostText.PARAGRAPH_LINKS_POST[i].TrimEnd().ToLower(), Is.True, string.Concat("\"", links[i].TextContentAsync().Result, "\"", "\r\nnot matched with ", "\"", PostText.PARAGRAPH_LINKS_POST[i].TrimEnd(' '), "\""));
            }

        }
    }
}
