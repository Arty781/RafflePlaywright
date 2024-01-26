using System.Globalization;

namespace PlaywrightRaffle.PageObjects
{
    public partial class Gift
    {
        //public static async Task VerifyDisplayedFilteredWinnersByYear(WinnerResponse listOfWinners)
        //{
        //    await WaitUntil.CustomElementIsVisible(cardWinner);
        //    for (int i = 0; i < (listOfWinners.AllCount / 6); i++)
        //    {
        //        await Element.Action("End");
        //    }
        //    for (int i = 0; i < listOfWinners.Winners.Count; i++)
        //    {
        //        var a = listOfWinners.Winners[i].DrawDate.DateTime;
        //        if (a.Hour >= 21)
        //        {
        //            a = a.AddDays(+1);
        //        }
        //        var expDate = a.ToString("dd' 'MMMM', 'yyyy", new CultureInfo("en-US")).TrimStart('0').TrimEnd();
        //        var actDate = TextBox.GetTextForList(textWinnerDate, i).Result.TrimEnd();
        //        Assert.That(actDate, Is.EqualTo(expDate), actDate + " is not " + expDate);
        //    }
        //}

        //public static async Task VerifyDisplayedCTAButtons(int winnerCount)
        //{
        //    await WaitUntil.CustomElementIsVisible(cardWinner);
        //    for (int i = 0; i < (winnerCount / 6); i++)
        //    {
        //        await Element.Action("End");
        //    }
        //    for (int i = 0; i < winnerCount; i += 4)
        //    {
        //        Assert.That(await TextBox.GetTextForList(textWinnerCardDescription, i) == "Be our next winner. Take a look at what's live now!", Is.True, "Not CTA card");
        //    }
        //}
    }
}
