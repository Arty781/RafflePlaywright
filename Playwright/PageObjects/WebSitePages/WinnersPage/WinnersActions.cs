namespace PlaywrightRaffle.PageObjects
{
    public partial class Winners
    {
        public static async Task ScrollToEndOfList(int winnerCount)
        {
            await WaitUntil.WaitSomeInterval(2000);
            for (int i = 0; i < (winnerCount / 6); i++)
            {
                await Element.Action("End");
            }
        }

        public static async Task FilterWinnersByYear(int yearNum)
        {
            await WaitUntil.CustomElementIsVisible(filterYearSelector);
            foreach (var year in (await Browser.Driver.QuerySelectorAllAsync(filterYearSelector)))
            {
                if (yearNum.ToString() == year.TextContentAsync().Result)
                {
                    await year.ClickAsync();
                }
            }
        }
    }
}
