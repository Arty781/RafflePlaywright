

namespace PlaywrightRaffle.PageObjects
{
    public partial class SensePage
    {

        public static async Task OpenLifePage(string url)
        {
            await Browser.Driver.GotoAsync(url);
            await WaitUntil.CustomElementIsVisible(btnPrevSlider);


        }


        public static async Task SwitchingTopSliderImages()
        {
            for (int i = 0; i < 3; i++)
            {
                await Button.ClickOnNthElement(btnNextSlider, 0);
            }
            for (int i = 0; i < 5; i++)
            {
                await Button.ClickOnNthElement(btnPrevSlider, 0);
            }

        }

        public static async Task SwitchingSecondSliderImages()
        {
            for (int i = 0; i < 3; i++)
            {
                await Button.ClickOnNthElement(btnNextSlider, 1);
            }
            for (int i = 0; i < 5; i++)
            {
                await Button.ClickOnNthElement(btnPrevSlider, 1);
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
            await Button.ClickOnNthElement(btnTicketSelectorInfoBlock, 0);


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
            foreach( var paragraph in actualTitle )
            {
                var t = paragraph.TextContentAsync();
                paragraphs.Add(t.Result);
            }

            return paragraphs;

        }
    }
}
