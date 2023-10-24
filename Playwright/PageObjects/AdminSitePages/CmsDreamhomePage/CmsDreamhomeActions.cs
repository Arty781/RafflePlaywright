namespace PlaywrightRaffle.PageObjects
{
    public partial class CmsDreamhome
    {



        public static async Task OpenDreamhomePage()
        {
            await Browser.Navigate(AdminEndpoints.DREAMHOME_PRIZES);
        }


        public static async Task ClickAddDreamhomeBtn()
        {
            await Button.Click(btnAddDreamHome);
        }

        #region General tab


        public static async Task UploadImages()
        {
            await WaitUntil.WaitSomeInterval(250);
            await InputBox.ElementImage(inputDesktopImage, String.Concat(Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_1 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_2 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_3 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_4 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_5 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_6 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_7 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_8 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_9 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_10 + "\n" +
                                                                      Browser.RootPath() + UploadedImages.RAFFLE_DESKTOP_11));

            await InputBox.ElementImage(inputMobileImage, String.Concat(Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_1 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_2 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_3 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_4 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_5 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_6 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_7 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_8 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_9 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_10 + "\n" +
                                                                     Browser.RootPath() + UploadedImages.RAFFLE_MOBILE_11));
        }


        public static async Task<int> MoveDesktopImages()
        {
            await WaitUntil.CustomElementIsVisible(listImgMobileLast10);
            var sourceElement = await Browser.Driver.QuerySelectorAllAsync(listImgDesktop);
            var targetElement = await Browser.Driver.QuerySelectorAllAsync(listImgDesktop);
            var sourceBoundingBox = await sourceElement[2].BoundingBoxAsync();
            var targetBoundingBox = await targetElement[6].BoundingBoxAsync();
            await Browser.Driver.Mouse.MoveAsync(sourceBoundingBox.X + sourceBoundingBox.Width / 2, sourceBoundingBox.Y + sourceBoundingBox.Height / 2);
            await Browser.Driver.Mouse.DownAsync();
            await Browser.Driver.Mouse.MoveAsync(targetBoundingBox.X + targetBoundingBox.Width / 2, targetBoundingBox.Y + targetBoundingBox.Height / 2);
            await Browser.Driver.Mouse.UpAsync();
            return sourceElement.Count;
        }




        public static async Task RemoveDesktopImages()
        {
            await WaitUntil.WaitSomeInterval(15000);
            await WaitUntil.CustomElementIsVisible(btnDeleteImageDesktop);
            //Element.Action(Keys.End);
            for (int i = 0; i < Browser.Driver.QuerySelectorAllAsync(btnDeleteImageDesktop).Result.Count - 1; i++)
            {
                await Button.Click(btnDeleteImageDesktop);
            }
        }


        public static async Task RemoveMobileImages()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(btnDeleteImageMobile);
            for (int i = 0; i < Browser.Driver.QuerySelectorAllAsync(btnDeleteImageMobile).Result.Count - 1; i++)
            {
                await Button.Click(btnDeleteImageMobile);
            }
        }


        public static async Task AcivateDreamHome()
        {
            await Button.Click(toggleSwitcherStatus);
        }


        public static async Task<string> EnterTitle()
        {
            await InputBox.Element(inputTitle, "Dream New flat " + Company.Name());
            await WaitUntil.CustomElementIsVisible(inputTitle);
            return await Browser.Driver.QuerySelectorAsync(inputTitle).Result.GetAttributeAsync("value");
        }


        public static async Task EnterAddress()
        {
            await InputBox.Element(inputAddress, "42 Broadway London E35 0VE 767 Manor Road");
        }


        public static async Task EnterStartDate()
        {
            var startDate = DateTime.Now.AddMonths(-5).Date;

            for (int i = 0; i < Browser.Driver.QuerySelectorAllAsync(inputStartDate).Result.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        await InputBox.ElementList(inputStartDate, i, startDate.ToString("dd"));
                        break;
                    case 1:
                        await InputBox.ElementList(inputStartDate, i, startDate.ToString("MM"));
                        break;
                    case 2:
                        await InputBox.ElementList(inputStartDate, i, startDate.ToString("yyyy"));
                        break;
                    case 3:
                        await InputBox.ElementList(inputStartDate, i, startDate.ToString("hh"));
                        break;
                    case 4:
                        await InputBox.ElementList(inputStartDate, i, startDate.ToString("mm"));
                        break;
                    case 5:
                        await InputBox.ElementList(inputStartDate, i, startDate.ToString("ss"));
                        break;
                    default:
                        break;
                }
            }

            await Browser.Driver.FocusAsync(inputStartAmPm);
            await Browser.Driver.Keyboard.PressAsync("ArrowDown");
        }


        public static async Task EnterFinishDate()
        {
            var currentDate = DateTime.Now.AddMonths(5).Date;

            for (int i = 0; i < Browser.Driver.QuerySelectorAllAsync(inputFinishDate).Result.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        await InputBox.ElementList(inputFinishDate, i, currentDate.ToString("dd"));
                        break;
                    case 1:
                        await InputBox.ElementList(inputFinishDate, i, currentDate.ToString("MM"));
                        break;
                    case 2:
                        await InputBox.ElementList(inputFinishDate, i, currentDate.ToString("yyyy"));
                        break;
                    case 3:
                        await InputBox.ElementList(inputFinishDate, i, currentDate.ToString("hh"));
                        break;
                    case 4:
                        await InputBox.ElementList(inputFinishDate, i, currentDate.ToString("mm"));
                        break;
                    case 5:
                        await InputBox.ElementList(inputFinishDate, i, currentDate.ToString("ss"));
                        break;
                    default:
                        break;
                }
            }

            await Browser.Driver.FocusAsync(inputFinishAmPm);
            await Browser.Driver.Keyboard.PressAsync("ArrowDown");
            await Browser.Driver.Keyboard.PressAsync("ArrowDown");
        }


        public static async Task EnterMetaTags()
        {
            await InputBox.Element(inputMetaTitle, "Dream home");
            await InputBox.Element(inputMetaDescr, "Dream home description");
        }

        #endregion

        #region Description tab


        public static async Task OpenDescriptionTab()
        {
            await WaitUntil.CustomElementIsVisible(tabDescrDream);
            await Browser.Driver.QuerySelectorAsync(tabDescrDream).Result.ScrollIntoViewIfNeededAsync();
            await Browser.Driver.QuerySelectorAsync(tabDescrDream).Result.ClickAsync();
            await WaitUntil.WaitSomeInterval(1000);
        }


        public static async Task UploadDreamhomeCardImage()
        {
            await WaitUntil.CustomElementIsVisible(imgDesktopSelect);
            await Browser.Driver.QuerySelectorAsync(dreamhomeCardImg).Result.FillAsync(Browser.RootPath() + UploadedImages.RAFFLE_OUTSPACE);
        }


        public static async Task UploadBedroomCardImage()
        {
            await Browser.Driver.QuerySelectorAsync(bedroomCardImg).Result.FillAsync(Browser.RootPath() + UploadedImages.RAFFLE_BEDROOM);
        }


        public static async Task UploadBathroomCardImage()
        {
            await Browser.Driver.QuerySelectorAsync(bathroomCardImg).Result.FillAsync(Browser.RootPath() + UploadedImages.RAFFLE_BATHROOM);
        }


        public static async Task UploadOutspaceCardImage()
        {
            await Browser.Driver.QuerySelectorAsync(outspaceCardImg).Result.FillAsync(Browser.RootPath() + UploadedImages.RAFFLE_OUTSPACE);
        }


        public static async Task UploadFloorPlanCardImage()
        {
            await Browser.Driver.QuerySelectorAsync(floorPlanCardImg).Result.FillAsync(Browser.RootPath() + UploadedImages.RAFFLE_FLOOR_PLAN);
        }


        public static async Task UploadLocationImage()
        {
            await Browser.Driver.QuerySelectorAsync(mapCardImg).Result.FillAsync(Browser.RootPath() + UploadedImages.RAFFLE_LOCATION_MAP);
        }


        public static async Task EnterBedroomText(string bedroomText)
        {
            await InputBox.Element(bedroomsTextArea, bedroomText);
        }


        public static async Task EnterBathroomText(string bathroomText)
        {
            await InputBox.Element(bathroomsTextArea, bathroomText);
        }


        public static async Task EnterOutSpaceText(string outspaceText)
        {
            await InputBox.Element(outspaceTextArea, outspaceText);
        }


        public static async Task EnterAboutText(string aboutText)
        {
            await InputBox.Element(aboutTextArea, aboutText);
        }


        public static async Task EnterProductCTAText(string ctaText)
        {
            await InputBox.Element(productCTATextArea, ctaText);
        }


        public static async Task EnterHeadingText(string headingText)
        {
            await InputBox.Element(headingTextArea, headingText);
        }


        public static async Task EnterTakeTourWithSara(string TakeTourWithSaraLink)
        {
            await InputBox.Element(headingTextArea, TakeTourWithSaraLink);
        }


        public static async Task ClickAddOverviewRowsBtn()
        {
            await WaitUntil.WaitSomeInterval(150);
            for (int i = 0; i < 4; i++)
            {

                await Button.Click(addOverviewBtn);
                await WaitUntil.WaitSomeInterval(450);
                await WaitUntil.CustomElementIsVisible(RowOverviewValue);
                await WaitUntil.WaitSomeInterval(550);
                await InputBox.ElementList(RowOverviewValue, i, RandomHelper.RandomNumber());
                await WaitUntil.WaitSomeInterval(200);
                await WaitUntil.CustomElementIsVisible(RowOverviewTitle);
                await WaitUntil.WaitSomeInterval(250);
                await InputBox.ElementList(RowOverviewTitle, i, Lorem.Characters(25));
            }
        }


        public static async Task EnterOverviewTitle()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(RowOverviewTitle);
            for (int i = 0; i < Browser.Driver.QuerySelectorAllAsync(RowOverviewTitle).Result.Count; i++)
            {
                await WaitUntil.WaitSomeInterval(250);
                await InputBox.ElementList(RowOverviewTitle, i, RandomHelper.RandomNumber());
            }
        }


        public static async Task EnterOverviewValue()
        {
            await WaitUntil.WaitSomeInterval(250);
            await WaitUntil.CustomElementIsVisible(RowOverviewValue);
            for (int i = 0; i < Browser.Driver.QuerySelectorAllAsync(RowOverviewValue).Result.Count; i++)
            {
                await WaitUntil.WaitSomeInterval(250);
                await InputBox.ElementList(RowOverviewValue, i, RandomHelper.RandomNumber());
            }
        }

        #endregion

        #region Discount & Tickets tab


        public static async Task EnterPrice()
        {
            await InputBox.Element(ticketPriceInput, "2");
        }


        public static async Task EnterNumOfTickets()
        {
            await WaitUntil.CustomElementIsVisible(defaultTicketsInput);
            await InputBox.Element(defaultTicketsInput, "10");
        }


        public static async Task SetDiscountThreshold()
        {
            await WaitUntil.CustomElementIsVisible(btnDiscountStepsToggle);
            await Button.Click(btnDiscountStepsToggle);
            await Button.Click(btnDiscountStepsCashRadio);
            await Button.Click(btnAddThresholds);
            await InputBox.ElementList(inputDiscountThreshold, 0, "15");
            await InputBox.ElementList(inputDiscountValue, 0, "1.666666666666");
            await InputBox.ElementList(inputDiscountThreshold, 1, "16");
            await InputBox.ElementList(inputDiscountValue, 1, "2");
        }


        public static async Task AddTicketsBundles()
        {
            await WaitUntil.CustomElementIsVisible(btnAddBundles);
            await Button.Click(btnAddBundles);
            await Button.Click(btnAddBundles);
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        await InputBox.ElementList(inputBundles, i, "5");
                        break;
                    case 1:
                        await InputBox.ElementList(inputBundles, i, "15");
                        break;
                    case 2:
                        await InputBox.ElementList(inputBundles, i, "50");
                        break;
                    case 3:
                        await InputBox.ElementList(inputBundles, i, "150");
                        break;
                    default:
                        break;
                }

            }
        }


        public static async Task SetFreeTickets()
        {
            await WaitUntil.CustomElementIsVisible(btnFreeTicketsToggle);
            await Button.Click(btnFreeTicketsToggle);
            for (int i = 0; i < 3; i++)
            {
                await Button.Click(btnAddFreeTickets);
                await WaitUntil.WaitSomeInterval(250);
            }
            await EnterFreeTicktesData();
        }

        private static async Task EnterFreeTicktesData()
        {
            await WaitUntil.CustomElementIsVisible(inputFreeTickets);
            List<IElementHandle> allElements = Browser.Driver.QuerySelectorAllAsync(inputFreeTickets).Result.ToList(); // your original list of elements

            for (int i = 0; i < allElements.Count; i++)
            {
                if (i % 2 == 0)
                {
                    switch (i)
                    {
                        case 0:
                            await InputBox.ElementList(inputFreeTickets, i, "5");
                            break;
                        case 1:
                            await InputBox.ElementList(inputFreeTickets, i, "15");
                            break;
                        case 2:
                            await InputBox.ElementList(inputFreeTickets, i, "50");
                            break;
                        case 3:
                            await InputBox.ElementList(inputFreeTickets, i, "150");
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            await InputBox.ElementList(inputFreeTickets, i, "10");
                            break;
                        case 1:
                            await InputBox.ElementList(inputFreeTickets, i, "35");
                            break;
                        case 2:
                            await InputBox.ElementList(inputFreeTickets, i, "450");
                            break;
                        case 3:
                            await InputBox.ElementList(inputFreeTickets, i, "1850");
                            break;
                    }
                }


            }
        }

        #endregion

        public static async Task EditDreamHome(string dreamhomeTitle)
        {
            await Element.FindSpecificDreamhome(dreamhomeTitle);
            var btnEditDreamhome = await Browser.Driver.QuerySelectorAsync($"//td[text()='{dreamhomeTitle}']/ancestor::tbody//td//a[@aria-label='Edit']");
            await btnEditDreamhome.ClickAsync();
        }

    }
}