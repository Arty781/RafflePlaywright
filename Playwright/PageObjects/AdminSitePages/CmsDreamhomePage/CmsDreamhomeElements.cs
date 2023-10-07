namespace Playwright.PageObjects
{
    public partial class CmsDreamhome
    {
        public const string btnAddDreamHome = "//a[@href='#/dreamHome/create']";
        public const string tabGeneralDream = "//a[@href='#/dreamHome/create']";
        public const string tabDescrDream = "//a[@href='#/dreamHome/create/1']";
        public const string tabDiscountTickets = "//a[@href='#/dreamHome/create/3']";
        public const string titleAddedDreamhome = "//h6[text()=' New Dream Home ']/parent::div[@class='active-table-title']/parent::div/following::tbody/tr/td[1]";
        #region General tab        
        public const string btnDeleteImageDesktop = "//div[text()='Add images for desktop *']/parent::div/section[@class='file-list'][1]//div[contains(@class, 'image-actions')]//*[contains(@class,'remove-image-icon')]";
        public const string btnDeleteImageMobile = "//div[text()='Add images for mobile *']/parent::div/section[@class='file-list'][2]//div[contains(@class, 'image-actions')]//*[contains(@class,'remove-image-icon')]";
        public const string fileList = "//section";
        public const string imageContainer = "/div";
        public const string inputDesktopImage = "//div[contains(text(),'desktop *')]/following-sibling::div/input";
        public const string listImgMobileLast10 = "//section[2]/div[./img][10]";
        public const string listImgDesktop = "//section[1]/div[./img]";
        public const string inputMobileImage = "//div[contains(text(),'mobile *')]/following-sibling::div/input";
        public const string dropZone = "//div[@class='dropzone'][2]";
        public const string listImgMobile = "//section[2]/div[./img]";
        public const string inputTitle = "//input[@id='title']";
        public const string inputAddress = "//div[contains(@class, 'coordinates')]//input";
        public const string toggleSwitcherStatus = "//input[@name='active']";
        public const string imgDesktopSelect = "//section[1]//img[@class='file-img']";
        public const string imgMobileSelect = "//section[2]//img[@class='file-img']";
        #region Date picker StartDate        
        public const string inputStartDate = "//p[text()='Start date']/parent::div/div//input[@autocomplete]";
        public const string inputStartAmPm = "//p[contains(text(),'Start date')]/parent::div//select[@name='amPm']";
        #endregion        
        #region Date picker FinishDate        
        public const string inputFinishDate = "//p[text()='Finish date']/parent::div/div//input[@autocomplete]";
        public const string inputFinishAmPm = "//p[contains(text(),'Finish date')]/parent::div//select[@name='amPm']";
        #endregion        
        #region Options        
        public const string inputIsTrending = "#isTrending";
        public const string inputIsPopular = "#isPopular";
        #endregion
        #region Meta Tags        
        public const string inputMetaTitle = "#metaTitle";
        public const string inputMetaDescr = "#metaDescription";
        #endregion
        #endregion
        #region Description tab        
        #region Images        
        public const string dreamhomeCardImg = "//input[@id='property.filesCard']";
        public const string bedroomCardImg = "//input[@id='property.filesBedroom']";
        public const string bathroomCardImg = "//input[@id='property.filesBathroom']";
        public const string outspaceCardImg = "//input[@id='property.filesOutspace']";
        public const string floorPlanCardImg = "//input[@id='property.filesFloorPlan']";
        public const string mapCardImg = "//input[@id='property.filesMapImage']";
        #endregion
        #region Text inputs        
        public const string bedroomsTextArea = "//span[text()='Bedrooms *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']";
        public const string bathroomsTextArea = "//span[text()='Bathrooms *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']";
        public const string outspaceTextArea = "//span[text()='Outspace *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']";
        public const string aboutTextArea = "//span[text()='About *']/ancestor::div[contains(@class,'about-section')]//div[@class='ql-editor ql-blank']";
        public const string productCTATextArea = "//span[text()='Product Page CTA *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']";
        public const string headingTextArea = "//span[text()='Heading 1 *']/ancestor::div[contains(@class,'text-parent')]//div[@class='ql-editor ql-blank']";
        #endregion
        #region Overview section        
        public const string addOverviewBtn = "//div[contains(@class, 'overview')]//*[contains(@class, 'add-discount')]";
        public const string removeOverviewBtn = "//div[contains(@class, 'deletePropertyRowBtn')]";
        #region Overview element rows        
        public const string RowOverviewTitle = "//div[@class='dreamHomeProperty_fieldWrapper']//input[@name='title']";
        public const string RowOverviewValue = "//input[@name='value']";
        #endregion
        #endregion
        #endregion
        #region Discount & Tickets tab        
        public const string ticketPriceInput = "#ticketPrice";
        public const string defaultTicketsInput = "#defaultTickets";
        public const string isActiveDiscountToggle = "#isActiveDiscount";
        public const string btnDiscountStepsToggle = "//h6[contains(text(),'Discount')]/parent::div//input[@type='checkbox']";
        public const string btnFreeTicketsToggle = "//h6[text()='Free Tickets']/parent::div//h6[text()='Status']/parent::div//input";
        public const string btnAddFreeTickets = "//h6[text()='Free Tickets']/parent::div//*[@class='MuiSvgIcon-root add-discount']";
        public const string inputFreeTickets = "//h6[text()='Free Tickets']/parent::div//input[@type='number']";
        public const string btnDiscountStepsCashRadio = "//input[@value='cash']";
        public const string btnDiscountStepsPercentRadio = "//input[@value='percent']";
        public const string inputDiscountThreshold = "//label[contains(text(),'threshold')]/parent::div//input";
        public const string inputDiscountValue = "//label[contains(text(),'£')]/parent::div//input";
        public const string btnAddBundles = "//h6[contains(text(),'Tickets Bundles')]/parent::div//*[@class='MuiSvgIcon-root add-discount']";
        public const string btnAddThresholds = "//h6[contains(text(),'Discount')]/parent::div//*[@class='MuiSvgIcon-root add-discount']";
        public const string inputBundles = "//h6[contains(text(),'Tickets Bundles')]/parent::div//input";
        #endregion
    }
}