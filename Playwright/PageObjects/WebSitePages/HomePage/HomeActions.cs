

namespace PlaywrightRaffle.PageObjects
{
    public partial class Home
    {

        public static async Task OpenHomePage(string url)
        {
            await Browser.Driver.GotoAsync(url);
            await WaitUntil.CustomElementIsVisible(textTitleBannerSecondary);


        }


        public static async Task SwitchingSliderImages()
        {
            for (int i = 0; i < 3; i++)
            {
                await Button.Click(btnNextTopSlider);
            }
            for (int i = 0; i < 5; i++)
            {
                await Button.Click(btnPrevTopSlider);
            }

        }


        public static async Task OpenFloorPlan()
        {
            await Button.ClickOnNthElement(tbsSlider, 1);
            await WaitUntil.CustomElementIsVisible(imgFloorPlan);

        }


        public static async Task OpenMap()
        {

            await Button.ClickOnNthElement(tbsSlider, 2);
            await WaitUntil.CustomElementIsVisible(imgMap);

        }



        public static async Task OpenHomePage()
        {
            await Browser.Driver.GotoAsync(WebEndpoints.WEBSITE_HOST);
            await WaitUntil.WaitSomeInterval(1000);


        }


        public static async Task OpenDreamTicketSelector()
        {
            await Button.Click(btnTicketSelectorInfoBlock);


        }


        public static async Task SelectFirstBundleBtn()
        {
            await WaitUntil.WaitSomeInterval(750);
            await Button.ClickOnNthElement(btnBundles, 0);
            await WaitUntil.WaitSomeInterval(2000);


        }


        public static async Task SelectSecondBundleBtn()
        {
            await WaitUntil.WaitSomeInterval(500);
            await Button.ClickOnNthElement(btnBundles, 1);
            await WaitUntil.WaitSomeInterval(2000);


        }


        public static async Task SelectThirdBundleBtn()
        {
            await WaitUntil.WaitSomeInterval(500);
            await Button.ClickOnNthElement(btnBundles, 2);
            await WaitUntil.WaitSomeInterval(2000);


        }


        public static async Task SelectForthBundleBtn()
        {
            await WaitUntil.WaitSomeInterval(700);
            await Button.ClickOnNthElement(btnBundles, 3);
            await WaitUntil.WaitSomeInterval(2000);


        }


        public static async Task AddTicketsToBasket(int maxIterations)
        {

            for (int i = 0; i <= maxIterations; i++)
            {
                switch (i)
                {
                    case 0:
                        await OpenHomePage();
                        await Element.Action("End");
                        await OpenDreamTicketSelector();
                        await SelectFirstBundleBtn();
                        await WaitUntil.WaitSomeInterval(3000);
                        break;
                    case 1:
                        await OpenHomePage();
                        await Element.Action("End");
                        await OpenDreamTicketSelector();
                        await SelectSecondBundleBtn();
                        await WaitUntil.WaitSomeInterval(3000);
                        break;
                    case 2:
                        await OpenHomePage();
                        await Element.Action("End");
                        await OpenDreamTicketSelector();
                        await SelectForthBundleBtn();
                        await WaitUntil.WaitSomeInterval(3000);
                        break;
                    case 3:
                        await OpenHomePage();
                        await Element.Action("End");
                        await OpenDreamTicketSelector();
                        await SelectThirdBundleBtn();
                        await WaitUntil.WaitSomeInterval(3000);
                        break;
                    default:
                        await OpenHomePage();
                        await Element.Action("End");
                        await OpenDreamTicketSelector();
                        await SelectFirstBundleBtn();
                        await WaitUntil.WaitSomeInterval(3000);
                        break;
                }
            }


        }

        public static async Task<List<string>> SelectParagraphs()
        {
            await WaitUntil.CustomElementIsVisible(textParagraph);
            List<string> paragraphs = new List<string>();
            var actualTitle = Browser.Driver.QuerySelectorAllAsync(textParagraph).Result.ToList();
            foreach (var paragraph in actualTitle)
            {
                var t = paragraph.TextContentAsync();
                paragraphs.Add(t.Result);
            }

            return paragraphs;

        }
    }
}
