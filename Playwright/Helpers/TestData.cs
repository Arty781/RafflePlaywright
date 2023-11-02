using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlaywrightRaffle.Helpers
{

#if DEBUG || CHROME || FIREFOX || DEBUG_MOBILE
    public class AdminEndpoints
    {
        public const string ADMIN_HOST = "https://admin-staging.rafflehouse.com";
        public const string DREAMHOME_PRIZES = "https://admin-staging.rafflehouse.com/#/dreamHome";
        public const string LIFESTYLE_PRIZES = "https://admin-staging.rafflehouse.com/#/prizes";
        public const string FIXEDODDS_PRIZES = "https://admin-staging.rafflehouse.com/#/fixedOdds";
        public const string USER_MANAGEMENT = "https://admin-staging.rafflehouse.com/#/users";
        public const string STAFF_MANAGEMENT = "https://admin-staging.rafflehouse.com/#/staffUsers";
        public const string SETTINGS_GENERAL = "https://admin-staging.rafflehouse.com/#/general";
        public const string SETTING_WINNERS = "https://admin-staging.rafflehouse.com/#/winners";
        public const string SETTINGS_REFERRALS = "https://admin-staging.rafflehouse.com/#/referrals";
        public const string COMPETITIONS = "https://admin-staging.rafflehouse.com/#/competitions";
    }

    public class WebEndpoints
    {
        public const string WEBSITE_HOST = "https://staging.rafflehouse.com";
        public const string SIGN_IN = "https://staging.rafflehouse.com/sign-in";
        public const string SIGN_UP = "https://staging.rafflehouse.com/sign-up";
        public const string DREAMHOME = "https://staging.rafflehouse.com/dreamhome";
        public const string LIFESTYLE_PRIZE = "https://staging.rafflehouse.com/lifestyleprizes";
        public const string FIXEDODDS = "https://staging.rafflehouse.com/fixedodds";
        public const string WINNERS = "https://staging.rafflehouse.com/winners";
        public const string ABOUT = "https://staging.rafflehouse.com/about-us";
        public const string PROFILE = "https://staging.rafflehouse.com/profile";
        public const string FREE_ENTRY = "https://staging.rafflehouse.com/post";
        public const string BASKET = "https://staging.rafflehouse.com/basket";
        public const string PAGE_DISCOUNT = "https://pagediscount-staging.rafflehouse.com/";
        public const string WIN_RAFFLE = "https://win-staging.rafflehouse.com/";
        public const string THESUN_RAFFLE = "https://thesun-staging.rafflehouse.com/";
        public const string LIFESTYLE = "https://staging.rafflehouse.com/lifestyle";
        public const string WIN_YOUR_COUNTRYSIDE_DREAMHOME = "https://staging.rafflehouse.com/win-your-countryside-dream-home";
        public const string CITY = "https://staging.rafflehouse.com/city";
        public const string HOLIDAY_HOME = "https://staging.rafflehouse.com/holiday-home";
    }

    public class ApiEndpoints
    {
        public const string API = "https://staging-api.rafflehouse.com";
        public const string API_CHIL = "staging-api.rafflehouse.com";
    }

    public class DbConnection
    {
        public const string DB_STAGING = "rafflehousedb_staging";
        public const string DB_STAGING_CONNECTION_STRING = "mongodb+srv://root:2312Hanford2312!@rafflehousestaging1.jahzn.mongodb.net/rafflehousedb_staging";

    }
#endif
#if RELEASE || RELEASE_MOBILE

    public class AdminEndpoints
    {
        public const string ADMIN_HOST = "https://admin.rafflehouse.com";
        public const string DREAMHOME_PRIZES = "https://admin.rafflehouse.com/#/dreamHome";
        public const string LIFESTYLE_PRIZES = "https://admin.rafflehouse.com/#/prizes";
        public const string FIXEDODDS_PRIZES = "https://admin.rafflehouse.com/#/fixedOdds";
    }
    public class WebEndpoints
    {
        public const string WEBSITE_HOST = "https://rafflehouse.com";
        public const string SIGN_IN = "https://rafflehouse.com/sign-in";
        public const string SIGN_UP = "https://rafflehouse.com/sign-up";
        public const string DREAMHOME = "https://rafflehouse.com/dreamhome";
        public const string LIFESTYLE = "https://rafflehouse.com/lifestyleprizes";
        public const string FIXEDODDS = "https://rafflehouse.com/fixedodds";
        public const string WINNERS = "https://rafflehouse.com/winners";
        public const string ABOUT = "https://rafflehouse.com/about-us";
        public const string PROFILE = "https://rafflehouse.com/profile";
        public const string FREE_ENTRY = "https://rafflehouse.com/post";
        public const string BASKET = "https://rafflehouse.com/basket";
        public const string PAGE_DISCOUNT = "https://discount.rafflehouse.com/";
        public const string WIN_RAFFLE = "https://win.rafflehouse.com/";
    }

        public class ApiEndpoints
    {
        public const string API = "https://backend.rafflehouse.com";
        public const string API_CHIL = "backend.rafflehouse.com";
    }
#endif

    public class Credentials
    {
        public const string LOGIN = "qatester91311@gmail.com";
        public const string PASSWORD = "Qaz11111";
        public const string NEW_PASWORD = "Qaz11111!";

        public const string LOGIN_ADMIN = "bennospencer@gmail.com";
        public const string PASSWORD_ADMIN = "1289Raffle@!CMS";
    }

    public class Categories
    {
        public const string TECH = "Tech";
        public const string HOLIDAYS_EXPIRIENCES = "Holidays & Experiences";
        public const string LUXURY = "Luxury";
        public const string MOTORS = "Motors";
        public const string LIVING = "Living";
        public const string WORKING_FROM_HOME = "Working From Home";
    }

    public class SubCategoriesD
    {
        public const string PHONES_TABLETS = "Phones & Tablets";
    }

    public class UploadedImages
    {
        public const string RAFFLE_BATHROOM = @"UploadImages\RaffleBathroom.jpg";
        public const string RAFFLE_BEDROOM = @"UploadImages\RaffleBedroom.jpg";
        public const string RAFFLE_FLOOR_PLAN = @"UploadImages\RaffleFloorPlan.jpg";
        public const string RAFFLE_LOCATION_MAP = @"UploadImages\RaffleLocationMap.jpg";
        public const string RAFFLE_OUTSPACE = @"UploadImages\RaffleOutspace.jpg";
        public const string RAFFLE_DESKTOP_1 = @"UploadImages\Desktop\DreamHomeImage01.jpg";
        public const string RAFFLE_DESKTOP_2 = @"UploadImages\Desktop\DreamHomeImage02.jpg";
        public const string RAFFLE_DESKTOP_3 = @"UploadImages\Desktop\DreamHomeImage03.jpg";
        public const string RAFFLE_DESKTOP_4 = @"UploadImages\Desktop\DreamHomeImage04.jpg";
        public const string RAFFLE_DESKTOP_5 = @"UploadImages\Desktop\DreamHomeImage05.jpg";
        public const string RAFFLE_DESKTOP_6 = @"UploadImages\Desktop\DreamHomeImage06.jpg";
        public const string RAFFLE_DESKTOP_7 = @"UploadImages\Desktop\DreamHomeImage07.jpg";
        public const string RAFFLE_DESKTOP_8 = @"UploadImages\Desktop\DreamHomeImage08.jpg";
        public const string RAFFLE_DESKTOP_9 = @"UploadImages\Desktop\DreamHomeImage09.jpg";
        public const string RAFFLE_DESKTOP_10 = @"UploadImages\Desktop\DreamHomeImage10.jpg";
        public const string RAFFLE_DESKTOP_11 = @"UploadImages\Desktop\DreamHomeImage11.jpg";
        public const string RAFFLE_MOBILE_1 = @"UploadImages\Mobile\DreamHomeImage01.jpg";
        public const string RAFFLE_MOBILE_2 = @"UploadImages\Mobile\DreamHomeImage02.jpg";
        public const string RAFFLE_MOBILE_3 = @"UploadImages\Mobile\DreamHomeImage03.jpg";
        public const string RAFFLE_MOBILE_4 = @"UploadImages\Mobile\DreamHomeImage04.jpg";
        public const string RAFFLE_MOBILE_5 = @"UploadImages\Mobile\DreamHomeImage05.jpg";
        public const string RAFFLE_MOBILE_6 = @"UploadImages\Mobile\DreamHomeImage06.jpg";
        public const string RAFFLE_MOBILE_7 = @"UploadImages\Mobile\DreamHomeImage07.jpg";
        public const string RAFFLE_MOBILE_8 = @"UploadImages\Mobile\DreamHomeImage08.jpg";
        public const string RAFFLE_MOBILE_9 = @"UploadImages\Mobile\DreamHomeImage09.jpg";
        public const string RAFFLE_MOBILE_10 = @"UploadImages\Mobile\DreamHomeImage10.jpg";
        public const string RAFFLE_MOBILE_11 = @"UploadImages\Mobile\DreamHomeImage11.jpg";
    }

    public class TakeTourWithSaraLink
    {
        public const string TAKE_TOUR = "https://www.youtube.com/embed/hMvXYHRvN-I";
    }

    public class CardDetails
    {
        public static readonly List<string> CARD_NUMBER = new()
        {
            "4242424242424242",
            "4485040371536584",
            "5588686116426417"
        };
    }

    public class DreamHomeTexts
    {
        public const string BEDROOMS = "A spacious primary bedroom with lots of natural light and LED lighting throughout for energy saving light at night. Electric radiator heating system, and Drayton Wiser smart heating system. USB outlets throughout and a video entry-phone system.";
        public const string BATHROOMS = "Contemporary white sanitary-ware with Grohe chrome taps. Fully tiled walls and floor. Overhead Rain shower. Chrome heated towel rail, and modern monochromatic vibes throughout.";
        public const string OUTSPACE = "West Drayton offers a range of parks which are all home to excellent scenery and wildlife. One of these, Bunny Park, is a perfect destination for a family day out as it not only has a fantastic play areas for kids of all ages, but there is also a maze and an animal park that houses birds, goats, sheep and peacocks. ";
        public const string ABOUT = "On October 30, live your dream and win the £250,000 West Drayton flat for just £2 \n"
                                    + "Will you live in it, rent it out or sell up? Or you can choose to take a £200,000 cash alternative \n"
                                    + "The new development is being offered exclusively to Raffle House in partnership with the Black Property Network \n"
                                    + "Plus, we’re throwing in £3,000 to help you settle in and cover any bills \n"
                                    + "What’s more, we’ll match any ticket bought for the London flat with tickets for the Copperworks flat! That's £500,000 up for grabs for just £2! \n"
                                    + "That’s more chances to win and support for Centrepoint and Housing for Women, our chosen charities.More on them in our About page.";
        public const string PRODUCT_CTA_BTN = "London Dream Home or £200,000 cash";
        public const string HEADING = "The London \n WIN this stunning property for just £2. Or, if you don't fancy being a homeowner, you can elect to take £200,000 tax-free!";
    }

    public class HomeTexts
    {
        public class OneActive
        {
            public const string STEPPER_TITLE = "Win a £250,000 Early Bird Prize!";
            public static readonly string SECONDARY_BANNER_TITLE = "Win YOUR Dream Home";
            public static readonly string SECONDARY_BANNER_SUBTITLE = "Everybody’s dream home is different. By winning our new Dream Home competition, we’ll furnish you with £3,000,000 to achieve your own property dreams.";

            public static readonly string BOTTOM_SLIDER_TITLE = "Win £3,000,000 To Spend On Your Property Dreams.";
            public static readonly List<string> BOTTOM_SLIDER_SUBTITLE = new()
        {
            "Built to the highest standard and nestled in Ovingdean, a stone’s throw from Brighton and the South Downs National Park, this luxury and bespoke Dream Home boasts a private courtyard and woodland to enjoy those lazy days in." ,
            "It’s time to quit the rat race and put your feet up."
        };

            public static readonly List<string> TITLES_INFO_BLOCKS = new()
        {
            "Picture Your Dream Home. What Do You See?",
            "Everybody’s Dream Home Is Different",
            "Win Your Dream Car",
            "Dream Big. Do Good."
        };
            public static readonly List<string> PARAGRAPHS_INFO_BLOCKS = new()
        {
            "Is it a country manor with open fires and flagstone floors?",
            "Perhaps it’s a contemporary penthouse apartment, overlooking the city skyline below?",
            "A coastal bolthole, far from the madding crowd with beach frontage for daily dips?",
            "Maybe you've already found your dream home, but want it renovated, modernised, and extended with a cinema room and a couple of extra bedrooms. Or maybe your dream home is abroad?",
            "A single ticket can unlock your dreams.",
            "Every Dream Home ticket you buy before midnight on November 19 will also be entered into our Early Bird Draw, where you can win your dream car.",
            "What would you buy with £70,000? A new 4x4 to make your neighbours envious? Or something more environmentally friendly?",
            "Or, will you pocket the cash for a rainy day? Unlock your dreams today.",
            "Every time you enter, you’ll be able to choose from one of over 15 charities to donate to.",
            "Everyone has a cause that is near and dear to their hearts, and so we want you to be able to choose where 10% of your purchase goes to.",
            "It’s time to dream big and do good."

        };

        }
        
        public class TwoActive
        {
            public const string STEPPER_TITLE = "Win a £250,000 Early Bird Prize!";
            public static readonly string SECONDARY_BANNER_TITLE = "Two Dream Home Draws For The Price Of One";
            public static readonly string SECONDARY_BANNER_SUBTITLE = "Everybody’s dream home is different. By winning our new Dream Home competition, we’ll furnish you with £2,000,000 to achieve your own property dreams.";

            public static readonly string BOTTOM_SLIDER_TITLE = "Win £2,000,000 To Spend On Your Property Dreams.";
            public static readonly List<string> BOTTOM_SLIDER_SUBTITLE = new()
            {
                "Built to the highest standard and nestled in Ovingdean, a stone’s throw from Brighton and the South Downs National Park, this luxury and bespoke Dream Home boasts a private courtyard and woodland to enjoy those lazy days in." ,
                "It’s time to quit the rat race and put your feet up."
            };
            
            public static readonly List<string> TITLES_INFO_BLOCKS = new()
            {
                "Picture Your Dream Home. What Do You See?",
                "Everybody’s Dream Home Is Different",
                "Claim 2-For-1 Entries At No Extra Cost",
                "Dream Big. Do Good."
            };
            public static readonly List<string> PARAGRAPHS_INFO_BLOCKS = new()
            {
                "Is it a country manor with open fires and flagstone floors?",
                "Perhaps it’s a contemporary penthouse apartment, overlooking the city skyline below?",
                "A coastal bolthole, far from the madding crowd with beach frontage for daily dips?",
                "Maybe you've already found your dream home, but want it renovated, modernised, and extended with a cinema room and a couple of extra bedrooms. Or maybe your dream home is abroad?",
                "A single ticket can unlock your dreams.",
                "What's better than the chance to win £2 million to buy your Dream Home?",
                "Free tickets to win our next Dream Home competition worth £3million.",
                "Every ticket you buy to our current competition will be matched by us with tickets into our £3million competition at no extra cost.",
                "Every time you enter, you’ll be able to choose from one of over 15 charities to donate to.",
                "Everyone has a cause that is near and dear to their hearts, and so we want you to be able to choose where 10% of your purchase goes to.",
                "It’s time to dream big and do good."

            };
            
        }

        public static readonly string HOW_IT_WORKS_TITLE = "How It Works";
        public static readonly string HOW_IT_WORKS_PARAGRAPH = "Entering any of our competitions is quick and easy.";

        public static readonly string[] TITLES_STEPS =
        {
            "Choose your ticket bundle",
            "Unlock your dreams",
            "More than just a ticket"
        };
        public static readonly string[] PARAGRAPHS_STEPS =
        {
            "Select which ticket bundle you want to buy to win your Dream Home.",
            "We'll then email you a receipt with your ticket numbers in. Your tickets will also be available in your online account.",
            "We'll make a donation to our charity partner and you can sit back and start dreaming! We always contact our winners by email & phone."
        };
    }

    public class LifestyleTexts
    {
        public const string STEPPER_TITLE = "Win a £250,000 Early Bird Prize!";
        public static readonly string TOP_TITLE = "Win £3 million to unlock YOUR dreams";
        public static readonly string TOP_SUBTITLE = "What would you do with £3,000,000? Win our latest competition and we’ll furnish you with a truly life changing sum of money to spend as you see fit.";

        public static readonly string BOTTOM_SLIDER_TITLE = "Win £3,000,000 To Spend On Your Dreams.";
        public static readonly List<string> BOTTOM_SLIDER_SUBTITLE = new()
        {
            "Built to the highest standard and nestled in Ovingdean, a stone’s throw from Brighton and the South Downs National Park, this luxury and bespoke Dream Home boasts a private courtyard and woodland to enjoy those lazy days in." ,
            "It’s time to quit the rat race and put your feet up."
        };

        public static readonly List<string> TITLES_INFO_BLOCKS = new()
        {
            "Everybody’s Dreams Are Different.",
            "Indulge. Adventure. Enjoy.",
            "Win Your Dream Car",
            "Dream Big. Do Good."
        };
        public static readonly List<string> PARAGRAPHS_INFO_BLOCKS = new()
        {
            "Our £3 Million prize pot is a truly life changing sum of money.",
            "What would you do if you won?",
            "Would it pay off the mortgage?",
            "Open up the world for some far-flung adventures?",
            "Or perhaps present the opportunity to buy that vintage car you’ve been picturing yourself behind the driving wheel of?",
            "Unlock the best that your world has to offer by winning our £3 Million competition.",
            "A truly life changing amount of money to spend as you as please.",
            "Every Dream Home ticket you buy before midnight on November 19 will also be entered into our Early Bird Draw, where you can win your dream car.",
            "What would you buy with £70,000? A new 4x4 to make your neighbours envious? Or something more environmentally friendly?",
            "Or, will you pocket the cash for a rainy day? Unlock your dreams today.",
            "Every time you enter, you’ll be able to choose from one of over 15 charities to donate to.",
            "Everyone has a cause that is near and dear to their hearts, and so we want you to be able to choose where 10% of your purchase goes to.",
            "It’s time to dream big and do good."

        };

        public static readonly string HOW_IT_WORKS_TITLE = "How It Works";
        public static readonly string HOW_IT_WORKS_PARAGRAPH = "Entering any of our competitions is quick and easy.";

        public static readonly string[] TITLES_STEPS =
        {
            "Choose your ticket bundle",
            "Unlock your dreams",
            "More than just a ticket"
        };
        public static readonly string[] PARAGRAPHS_STEPS =
        {
            "Select which ticket bundle you want to buy to win your Dream Home.",
            "We'll then email you a receipt with your ticket numbers in. Your tickets will also be available in your online account.",
            "We'll make a donation to our charity partner and you can sit back and start dreaming! We always contact our winners by email & phone."
        };

    }

    public class CityTexts
    {
        public const string STEPPER_TITLE = "Win a £250,000 Early Bird Prize!";
        public static readonly string TOP_TITLE = "Win YOUR £3 million Dream City Home";
        public static readonly string TOP_SUBTITLE = "Win £3,000,000 to live the city dream. Penthouse apartments, beautiful Georgian terraces, or contemporary homes filled with glass.";

        public static readonly string BOTTOM_SLIDER_TITLE = "Win £3,000,000 To Spend On Your Property Dreams.";
        public static readonly List<string> BOTTOM_SLIDER_SUBTITLE = new()
        {
            "Built to the highest standard and nestled in Ovingdean, a stone’s throw from Brighton and the South Downs National Park, this luxury and bespoke Dream Home boasts a private courtyard and woodland to enjoy those lazy days in." ,
            "It’s time to quit the rat race and put your feet up."
        };

        public static readonly List<string> TITLES_INFO_BLOCKS = new()
        {
            "Live Mortgage Free In The Big City",
            "Win £3,000,000 To Own Your City Dream Home.",
            "Win Your Dream Car",
            "Dream Big. Do Good."
        };
        public static readonly List<string> PARAGRAPHS_INFO_BLOCKS = new()
        {
            "Living mortgage free is aspiration enough, but doing so in your home city really would be the dream.",
            "Would you choose that penthouse suite, overlooking the city lights below?",
            "Or perhaps your dream home is on a classical.",
            "Georgian terrace, with a cinema room and space for all the family?",
            "Unlock the very best that your city has to offer, by winning our £3 Million prize pot and own YOUR dream city home.",
            "Every Dream Home ticket you buy before midnight on November 19 will also be entered into our Early Bird Draw, where you can win your dream car.",
            "What would you buy with £70,000? A new 4x4 to make your neighbours envious? Or something more environmentally friendly?",
            "Or, will you pocket the cash for a rainy day? Unlock your dreams today.",
            "Every time you enter, you’ll be able to choose from one of over 15 charities to donate to.",
            "Everyone has a cause that is near and dear to their hearts, and so we want you to be able to choose where 10% of your purchase goes to.",
            "It’s time to dream big and do good."


        };

        public static readonly string HOW_IT_WORKS_TITLE = "How It Works";
        public static readonly string HOW_IT_WORKS_PARAGRAPH = "Entering any of our competitions is quick and easy.";

        public static readonly string[] TITLES_STEPS =
        {
            "Choose your ticket bundle",
            "Unlock your dreams",
            "More than just a ticket"
        };
        public static readonly string[] PARAGRAPHS_STEPS =
        {
            "Select which ticket bundle you want to buy to win your Dream Home.",
            "We'll then email you a receipt with your ticket numbers in. Your tickets will also be available in your online account.",
            "We'll make a donation to our charity partner and you can sit back and start dreaming! We always contact our winners by email & phone."
        };

    }

    public class CountrysideTexts
    {
        public const string STEPPER_TITLE = "Win a £250,000 Early Bird Prize!";
        public static readonly string TOP_TITLE = "Win YOUR £3 million Dream Countryside Home";
        public static readonly string TOP_SUBTITLE = "Dreaming of the good life? Win our latest competition and we’ll furnish you with £3 Million to spend on YOUR Country House Dream.";

        public static readonly string BOTTOM_SLIDER_TITLE = "Win £3,000,000 To Spend On Your Property Dreams.";
        public static readonly List<string> BOTTOM_SLIDER_SUBTITLE = new()
        {
            "Built to the highest standard and nestled in Ovingdean, a stone’s throw from Brighton and the South Downs National Park, this luxury and bespoke Dream Home boasts a private courtyard and woodland to enjoy those lazy days in." ,
            "It’s time to quit the rat race and put your feet up."
        };

        public static readonly List<string> TITLES_INFO_BLOCKS = new()
        {
            "A Magical Move To The Countryside",
            "Everybody’s Dream Home Is Different",
            "Win Your Dream Car",
            "Dream Big. Do Good."
        };
        public static readonly List<string> PARAGRAPHS_INFO_BLOCKS = new()
        {
            "What does your rural idyll look like?",
            "Is it a beautiful Georgian fronted manor, with a creeping wisteria?",
            "Or a cosy cottage with exposed timber beams and a roaring open fire?",
            "Or perhaps it’s that coastal bolthole with beachfront access for daily dips in the open water?",
            "This is your opportunity to live that bucolic life.",
            "Open skies, forested-hills and nature await you at your doorstep.",
            "Every Dream Home ticket you buy before midnight on November 19 will also be entered into our Early Bird Draw, where you can win your dream car.",
            "What would you buy with £70,000? A new 4x4 to make your neighbours envious? Or something more environmentally friendly?",
            "Or, will you pocket the cash for a rainy day? Unlock your dreams today.",
            "Every time you enter, you’ll be able to choose from one of over 15 charities to donate to.",
            "Everyone has a cause that is near and dear to their hearts, and so we want you to be able to choose where 10% of your purchase goes to.",
            "It’s time to dream big and do good."


        };

        public static readonly string HOW_IT_WORKS_TITLE = "How It Works";
        public static readonly string HOW_IT_WORKS_PARAGRAPH = "Entering any of our competitions is quick and easy.";

        public static readonly string[] TITLES_STEPS =
        {
            "Choose your ticket bundle",
            "Unlock your dreams",
            "More than just a ticket"
        };
        public static readonly string[] PARAGRAPHS_STEPS =
        {
            "Select which ticket bundle you want to buy to win your Dream Home.",
            "We'll then email you a receipt with your ticket numbers in. Your tickets will also be available in your online account.",
            "We'll make a donation to our charity partner and you can sit back and start dreaming! We always contact our winners by email & phone."
        };

    }

    public class HolidayTexts
    {
        public const string STEPPER_TITLE = "Win a £250,000 Early Bird Prize!";
        public static readonly string TOP_TITLE = "Win YOUR £3 million Dream Holiday Home";
        public static readonly string TOP_SUBTITLE = "A life in the sun or the snow? By the beach or atop a mountain? Win our competition and we’ll furnish you with £3,000,000 to buy YOUR Dream Holiday Home.";

        public static readonly string BOTTOM_SLIDER_TITLE = "Win £3,000,000 To Spend On Your Property Dreams.";
        public static readonly List<string> BOTTOM_SLIDER_SUBTITLE = new()
        {
            "Built to the highest standard and nestled in Ovingdean, a stone’s throw from Brighton and the South Downs National Park, this luxury and bespoke Dream Home boasts a private courtyard and woodland to enjoy those lazy days in." ,
            "It’s time to quit the rat race and put your feet up."
        };

        public static readonly List<string> TITLES_INFO_BLOCKS = new()
        {
            "Your Dream. Your Holiday Home.",
            "A Holiday Home Changes Everything",
            "Win Your Dream Car",
            "Dream Big. Do Good."
        };
        public static readonly List<string> PARAGRAPHS_INFO_BLOCKS = new()
        {
            "We Brits love to get away, and what better than to do so to a holiday home of your very own.",
            "The only question is where you’d choose to go. Would it be the glamorous French Riviera?",
            "An historic Tuscan hilltop?",
            "Or a bolthole in the Swiss Alps?",
            "A single ticket into our competition could furnish you with £3,000,000 to spend on your holiday Dream Home. As the sun sets on the first day of your holiday, you’ll think of the moment your entered, glass in hand.",
            "Every Dream Home ticket you buy before midnight on November 19 will also be entered into our Early Bird Draw, where you can win your dream car.",
            "What would you buy with £70,000? A new 4x4 to make your neighbours envious? Or something more environmentally friendly?",
            "Or, will you pocket the cash for a rainy day? Unlock your dreams today.",
            "Every time you enter, you’ll be able to choose from one of over 15 charities to donate to.",
            "Everyone has a cause that is near and dear to their hearts, and so we want you to be able to choose where 10% of your purchase goes to.",
            "It’s time to dream big and do good."


        };

        public static readonly string HOW_IT_WORKS_TITLE = "How It Works";
        public static readonly string HOW_IT_WORKS_PARAGRAPH = "Entering any of our competitions is quick and easy.";

        public static readonly string[] TITLES_STEPS =
        {
            "Choose your ticket bundle",
            "Unlock your dreams",
            "More than just a ticket"
        };
        public static readonly string[] PARAGRAPHS_STEPS =
        {
            "Select which ticket bundle you want to buy to win your Dream Home.",
            "We'll then email you a receipt with your ticket numbers in. Your tickets will also be available in your online account.",
            "We'll make a donation to our charity partner and you can sit back and start dreaming! We always contact our winners by email & phone."
        };

    }

    public class SubscriptionTexts
    {
        public static readonly string TITLE_H1 = "Never Miss Your Chance To Dream Big And Do Good";
        public static readonly List<string> TITLES_H2 = new()
        {
            "Subscription Benefits",
            "How it Works",
            "Frequently Asked Questions",
            "Dream Big. Do Good",
            "As Seen In",
            "Got A Question?"
        };
        public static readonly List<string> TITLES_H3 = new()
        {
            "Subscribe at any time",
            "You’re all set",
            "Peace of mind",
            "Choose your charity every month",
            "About Raffle House"
        };
        public static readonly List<string> PARAGRAPHS = new()
        {
            "Get triple the entries to all our Early Bird and multi-million pound Dream Home draws every single month. ",
            "Dream Big and Do Good Every Single Month with a Raffle House Subscription",
            "If you want the peace of mind that you’ve always got your tickets to win our Early Bird Prizes or Dream Homes, our subscription options are the perfect solution. ",
            "Subscribing to our competitions is quick and easy.",
            "Get triple the usual entries into every single upcoming Early Bird and Dream Home draw",
            "You’ll receive your subscription tickets at the beginning of every month.",
            "Whenever a new Dream Home is announced, even if two are live at the same time, you’ll be automatically entered into both without having to make a new purchase.",
            "Every month, you can choose to change where you want 10% of your payment to be donated to or keep your preferred charity. You can cancel at any time or even skip a month or two.",
            "What’s the benefit of subscribing?",
            "Not only will you always guarantee yourself tickets to win our Early Bird and Dream Home Prizes, but you’ll be also doing so with three times more tickets than a one-off purchase.",
            "Where will I see my tickets?",
            "We’ll email you your tickets when you first activate your subscription, and then at the beginning of every month we’ll confirm your new ticket numbers on your renewed subscription. You’ll also be able to find these in your account.",
            "Can I choose a different charity each month?",
            "Yes. In that same email you’ll receive at the beginning of the month, you can decide to switch your charitable giving or do nothing to keep it the same.",
            "Are my tickets entered into all prize pools?",
            "Yes. Your tickets will be entered into every single Early Bird Prize draw, as well as all Dream Home draws, as well as any other prize pools yet to be announced.",
            "Can I cancel whenever I like?",
            "Absolutely. Your tickets will remain valid for all upcoming Early Bird Prizes and the next Dream Home draw and you can choose to use the Free Entry option at any time. You can manage your subscription from your account or our customer support team can help you.",
            "I won’t lose any tickets even if I cancel my subscription?",
            "That’s right. You’ll keep all of the tickets from the beginning of your subscription period to its end, and they’ll all remain valid for any upcoming Early Bird or Dream Home draws.",
            "If I subscribe, can I still buy regular ticket bundles?",
            "Yes. You’ll still have the option of buying regular ticket bundles or using the Free Entry option, as well as taking advantage of any discounts or deals that we offer from time-to-time.",
            "Every month, you’ll be able to choose from one of over 20 charities to donate to or keep your donation where it is.",
            "Everyone has a cause that is near and dear to their hearts, and so we want you to be able to choose where 10% of your purchase goes to.",
            "It’s time to dream big and do good.",
            "",
            "",
            "",
            "Contact Us"

        };
    }

    public class Headers
    {
        public static Dictionary<string, string> COMMON = new Dictionary<string, string>()
        {
            {"accept", "application/json, text/plain, */*" },
            {"accept-encoding", "gzip, deflate, br"},
            {"content-type", "application/json" }
        };

    }

    public class Keyss
    {
        public static string Control()
        {
            string control = String.Empty;
            if (OperatingSystem.IsWindows())
            {
                control = "Control";
            }
            else if (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux())
            {
                control = "Command";
            }
            return control;
        }
    }

    public class Country
    {
        public static List<string> COUNTRY_CODES = new()
        {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Angola",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Bermuda",
            "Bhutan",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cayman Islands",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Costa Rica",
            "Czech Republic",
            "DR Congo",
            "Denmark",
            "Dominican Republic",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Estonia",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hong Kong",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Israel",
            "Italy",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Libya",
            "Lithuania",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Moldova",
            "Mongolia",
            "Morocco",
            "Mozambique",
            "Myanmar",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Caledonia",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "North Macedonia",
            "Oman",
            "Pakistan",
            "Palestinian Territories",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Republic of Korea",
            "Romania",
            "Russia",
            "Rwanda",
            "Saint Lucia",
            "Saint Vincent and the Grenadines",
            "Samoa",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Singapore",
            "Solomon Islands",
            "South Africa",
            "Spain",
            "Sri Lanka",
            "Suriname",
            "Sweden",
            "Switzerland",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Tonga",
            "Trinidad & Tobago",
            "Tunisia",
            "Turkey",
            "UAE",
            "UK",
            "USA",
            "Uganda",
            "Ukraine",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Venezuela",
            "Vietnam",
            "Zambia",
            "Zimbabwe"
        };
    }

    public class FooterText
    {
        public const string FOOTER_TITLE = "About Raffle House";
        public const string FOOTER_PARAGRAPH = "We offer you the chance to win your Dream Home or multi-million pound cash-prize while donating to worthwhile causes. Every Dream Home entry is automatically added to the bonus prize pools and will be drawn for each consecutive competition. Our paid competitions to win a Dream Home and bonus prizes also include a postal entry method. It’s time to dream big and do good.";
        public static readonly List<string> FOOTER_CONTACTS_LINKS = new()
        {
            "Home",
            "Winners",
            "Subscription",
            "Login / Register",
            "Terms & Conditions",
            "Privacy Policy",
            "Contact"
        };
        public static readonly List<string> FOOTER_SPONSORS_LINKS = new()
        {
            "GambleAware",
            "Copyright 2017-2023 - Raffle House Ltd.",
            "Company Reg. No. 10928240 - All Rights Reserved"
        };
    }

    public class PostText
    {
        public const string TITLE_POST = "How To Enter For Free By Post";
        public static readonly List<string> PARAGRAPH_POST = new()
        {
            "Raffle House offers a postal entry for its competitions. Just like the paid method of entering its competitions, the postal method requires that you create an online account and accept our T&Cs. This is so that we can verify your entry details and provide you with an electronic record of your entry.",
            "Click the button below to create an account.",
            "On a blank sheet of paper write your full name, date of birth, telephone number, email address, and the title of the competition you are submitting an entry for. Please refer to the individual product pages for competition titles. Examples of these can be found in our T&Cs. This information must match the information that you use to create your online account and needs to be written legibly otherwise the entry may be deemed invalid.",
            "We have appointed Civica Election Services, formerly known as Electoral Reform Services (ERS),as our independent scrutineers to administer this competition. They have over 100 years’ experience in administering elections, ballots and competitions for a wide range of clients including TV programmes and various lottery projects. Please send the sheet of paper in an envelope to the following address via first- or second-class post to:",
            "A maximum of one entry can be made per envelope received.",
            "Postal entries are treated in exactly the same way as paid entries for the purposes of determining a winner. However, there is a difference in the deadlines for postal entries for the property competition. Our property draw closes at midnight on its final day; the corresponding cut-off for postal entries will be that they are received and processed before 5pm four business days later.",
            "One postal entry has an equal chance of winning as any one paid entry. If a postal entry wins a prize there will be no further purchase or payment necessary to be notified of the win or to receive the prize. If the above steps are not followed as described, then a postal entry will be invalid.",
            "You will not be notified if your entry is invalid and only valid entries will appear on your online account."

        };
        public static readonly List<string> PARAGRAPH_LINKS_POST = new()
        {
            "Raffle House Postal Entry​",
            "Civica Election Services​",
            "33 Clarendon Road​",
            "London",
            "N8 0NW​"
        };
    }

    public class TermsConditions
    {
        public const string TERMS = "Last Update: April\n            5, 2021Subject to the Terms and Conditions detailed in full below:\n        No purchase, payment or other financial contribution is necessary to enter or win any Competition and Raffle House’s Postal Entry is available for all Competitions.\n    \n        Raffle House Ltd. gives its customers the chance to win Jackpot Property, Weekly Lifestyle, Fixed Odds, and Cash Prizes through Competitions it displays on its Website.\n    \n        Every week, at least one Winner of the Weekly Cash Prize Competition of £1,000 will be Drawn, one winner of the Weekly Lifestyle Prize Competition will be Drawn, and if applicable, one winner of any Closed/completed Fixed Odds Competition will be Drawn.\n    \n        The Jackpot Property Competition Closing Date is 30 June, 2021. The Weekly Lifestyle and Cash Prize Competitions reset every Sunday at midnight. Fixed Odds Competitions have bespoke dates reflected by their specific Competition product page on the Site.\n    \n        For the Property to be awarded, the Minimum Number of Jackpot Property Entries to be sold is 650,000, and more information on this threshold can be found in our Help Centre (click FAQ in the menu and search for “threshold”).\n    \n        In the event that the Jackpot Property Competition threshold is not met, full details regarding the 90% cash-prize can be found below.\n    \n        The Promoter offers an automatic charitable donation option at checkout and we urge you to select a charity at checkout.\n    \n        Customers that pay the Entry Fee will be emailed their receipt and Ticket(s) and find their Ticket(s) in their Account.\n    \n        Customers that choose the Postal Entry will find their Ticket(s) in their Account following an administration period but cannot be emailed a receipt.\n    Terms & Conditions\n        The following Terms & Conditions apply to all Entries submitted to the Competition for which is set out in these Terms.\n    \n        In entering the Competition, Entrants will be required to tick on the Website that they are over the age of 18, and have read and accepted these Terms and Conditions and agreed to be bound by them.\n    The Promoters\n        The Competition is operated by the Promoter. The Promoter is authorised by the owner of the Property to offer the Property as a prize in this Competition. The Promoters are members of the Property Redress Scheme, more information about which can be found here: www.theprs.co.uk. How to enter\n        By submitting an Entry, Entrants agree to be bound by these Terms and Conditions. If you do not so agree, do not submit an Entry.\n     \n        No purchase, payment or other financial contribution is necessary to enter or win any Competition and Raffle House’s Postal Entry is available for all Competitions. To validly enter the Competition Entrants must:\n        \n                First, create a free Account; and then either:\n                        pay the Entry Fee. The entry will qualify for the Jackpot Competition and the Weekly Lifestyle, Fixed Odds, and Cash Prize Competitions as per their Definitions; or\n                    \n                        Print your full name, phone number, email address, and which competition you are submitting a ticket request for (Dream Home, Lifestyle Prize “xx” (for example: Lifestyle Prize “£5,000 Fast Cash”), Fixed Odds “xx” (for example: Fixed Odds “£1,000 A Week For A Year”) on a piece of paper and enclose in an envelope. This information must match with the information provided when creating a free account or your Postal Entry will be deemed invalid. With a first-class stamp, post the completed entry to: Raffle House Postal Entry, Civica Election Services, 33 Clarendon Road, London N80NW. There is a limit of one entry per outer stamped, mailing envelope. Each valid entry made via the Postal Entry will automatically qualify for the Jackpot Competition and, if the requirements are met, the Weekly Lifestyle, Fixed Odds and Cash Prize Competition with effect from the date that an entry is received and processed. No mechanically reproduced entries are permitted. Illegible entries are void. Raffle House is not responsible for lost, late, mutilated, delayed, inaccurate, incomplete, postage due, misdirected entries or entries not received by the last day of the applicable entry period. Each Postal Entry will be equivalent to a single entry into the relevant Competition that may be awarded via paying an Entry Fee. You must provide all required information to be eligible to enter and win. Automated entries will be disqualified. Postal Entries must be submitted by the Raffle House account holder. No copies, facsimiles, or mechanical reproductions of entries will be accepted. Postal Entries shall have the same status as Entries paid in cash, except they shall not count towards the calculation of the Minimum Number of Jackpot Property Entries. Civica Election Services are a third-party entity that provide the Promoter with an independent postal and submission verification service only, with no recourse or liability with regards to providing prizes to entrants as advertised by the Promoter.\n                     \n        At the Promoter’s sole discretion, the requirement to pay the Entry Fee may be satisfied by redeeming a voucher code or credit provided to the Entrant under one of its promotional schemes. Entries so credited as paid shall have the same status as Entries paid in cash excepting that they shall not count towards the calculation of the Minimum Number of Jackpot Property Entries.\n    \n        Payment of the Entry Fee shall be processed by Checkout.com. Card payments shall be subject to Checkout.com’s terms and conditions, which shall be available to view by following the link:http://checkout.com/.The Entry Fee must be received by the Promoter in pounds sterling only and if you make payment in a different currency, the amount you pay in that currency may have currency exchange and international transfer charges added.\n    \n        Entrants will be asked to provide their contact details, including e-mail address and phone number. This information will be processed in accordance with the provisions below and the Promoter’s Data Protection and Privacy Policy. The Promoter’s card service provider, Checkout.com, will require the Entrant’s card payment details. Once the Entry is submitted, the Entrant’s card payment will be electronically approved and the Promoter will not retain any records of the Entrant’s card details. Raffle House never sees or stores any card payment details.\n    \n        The Promoter will store and process the Entrant’s name and personal information (which must include details of at least one form of contact) which will be used for the following purposes:\n        \n                to notify any Winner or Runner(s) Up that they that they have won a prize in the Competitions;\n            \n                to administer the Website and conduct the Competitions; and\n            \n                after a Draw, to post the Winner and any Runner(s) Up's name and town of residence on the Website and in publicity about the Competitions.\n            \n        All Entrants are solely and completely responsible for providing the Promoters with accurate and current personal and contact details.\n    \n        The Promoters will be in no way liable for any failure or inability to make contact with any Entrant due to any errors, omissions or inaccuracies in the contact details provided by the Entrants or otherwise.\n    \n        The Promoters will not accept:\n                responsibility for Entries that are lost, mislaid, damaged or delayed in transit, regardless of cause including, for example, equipment failure, technical malfunction, systems, satellite, network, server, computer hardware or software failure of any kind; or\n            \n                any other purported proof of entry to the Competitions other than as recorded by the Website’s systems.\n            \n        An Entry shall be declared void (without any refund being given) if the Entrant engages in: (a) any form of fraud (actual or apparent); (b) fraudulent misrepresentation; (c) fraudulent concealment; (d) hacking or interference with the proper functioning of the Website; or (e) amending, or unauthorised use of, any of the code that constitutes the Website.\n    \n        Each individual Entrant may submit up to 5,000 (five thousand) paid Entries to the Jackpot Property competition, and the Entry Fee must be paid on each purchase. If using the Postal Entry, each individual Entrant may submit up to 5,000 (five thousand) valid Entries, but there is a limit of one entry per outer stamped, mailing envelope (pursuant to term 3). Any “Fast Cash” Lifestyle or Fixed Odds Competition will have a limit of £1,000 per individual Entrant, and the equivalent number of Postal Entries.\n    \n        All entries will be electronically recorded by the Promoter and accessible via the Entrant’s Account. Valid Postal Entry submissions will take a processing time before being visible via the Entrant’s account.\n    \n        All Postal Entries will become the property of the Promoters on receipt and will not be returned. Entrants via this method will not receive notification of their Ticket; instead, it is incumbent on the individual to check their account online.\n    \n        All Entries to the Competition are final and no refunds shall be made at any time or for any reason, except in the case of Entries submitted after the Closing Date for which payment has been taken and pursuant with terms 46 and 47. In the case of Postal Entries, all those entries posted on the last business day of the Competition will be included, based on typical postal service delivery times.\n    \n        For help with Entries, please visit the Website.\n    Eligibility\n        The Competitions are open for entry only to private individuals (i.e., not companies or businesses) aged 18 or over, excluding:\n        \n                the Promoter, their immediate family, agents, or employees; or\n            \n                anyone else connected with the development or operation of the Website or the conduct or administration of the Competition in any way, shape or form; or\n            \n                the members of the immediate families or households of the above.\n            \n        In entering any Competition, all Entrants confirm that they are eligible to do so and eligible to claim any prize awarded in any Competition. The Promoters may require any Entrant to provide evidence that they are eligible to enter any Competition.\n    \n        The Promoter will not accept Postal Entries that are:\n        \n                from countries outside of the UK\n            \n                automatically generated by computer;\n            \n                illegible, have been altered, reconstructed, forged, tampered with or incomplete\n            \n        The Promoters reserve all rights to disqualify Entrants if their conduct is contrary to the spirit or intention of any Competition.\n    \n        Entries on behalf of another person can be accepted and joint submissions are allowed. However, a single Account holder and person will be required to take ownership of any Prize and be the Ticket holder.\n    \n        Credit can be earned by any Account holder and Referrals can be made by any Account holder. Any consumed Credit granted to the Account holder and transferred to Entries will be treated in exactly the same way as any paid or Postal Entries for any Competition and its corresponding Draw.\n    \n        If any Entrant, at any time prior to the end of any Competition, deletes their Account, any Entries held by that Account will also be removed from any future Draw. Deleting Accounts is different from logging out, which will not remove any Entries. Deleting Accounts requires 2-step verification for safety. Any Entries removed from any Draw due to Account deletion will not be re-instated and refunds will not be awarded (pursuant to term 15).\n    \n        By entering any Competition, all Entrants warrant that all information which they submit is accurate, true, current and complete. The Promoter reserves the right to disqualify any Entrant (entirely at their own discretion) if there are reasonable grounds to believe the Entrant has acted in breach of any of these Terms and Conditions.\n    The Jack Property Prize and its Draw\n        The title of the Jackpot Property Competition is “A £2 ticket to your dream home”.\n    \n        The Winner and Referral Prize Winner will be determined and awarded the Prizes so specified on the Website and in accordance with these Terms and Conditions.\n    \n        The Draw to determine the Winner, the Referral Prize Winner and any Runner(s) Up will be made on the Draw Date (subject to term 28).\n    \n        The Promoter may, at its sole discretion, and at any time during the Competition up to the end of the Closing Date, bring forward the Closing Date to a new Closing Date, to be before and no later than the specified Closing Date. Also, the Promoter may, at its sole discretion, and at any time during the Competition up to the end of the Closing Date, extend the Competition Closing Date.\n    \n        If by the Closing Date (subject to term 28), at least the Minimum Number of Jackpot Property Entries has been received, the Competition will close and on the Draw Date:\n        \n                there will be a Draw to determine the Winner (and Runner(s) Up in the event that the winner cannot be contacted within the time allocated in term 31), and the prize shall be the Property, plus the payment of Stamp Duty (as set out in term 37) and the Bonus Prize;\n            \n                there will be an evaluation to determine the Winner of the Referral Prize, who shall be awarded the Referral Prize.\n            \n        If by the Closing Date (subject to term 28), the actual number of Entries received is less than the Minimum Number of Jackpot Property Entries, the Competition will close and on the Draw Date there will be a Draw, at the sole discretion of the Promoter, by reference to the proceeds received from the Entries to:\n        \n                award to the Winner the Cash Prize and;\n            \n                There will be an evaluation to determine the Winner of the Referral Bonus Prize, who shall be awarded the Referral Bonus Prize.\n            \n        If any Jackpot Prize Winner or Runner(s) Up cannot be contacted by the Promoter within 21 days of being notified of their status as the Winner by e-mail and/or, telephone to the contact details submitted in their Entry, the Promoter shall be entitled to award their prize to the Entrant next Drawn, with the effect that the first Runner Up (as applicable) would become the Winner, and so on. At the Draw, there shall be such number of additional / reserve Entries Drawn but not actioned or disclosed until required to permit the operation of this alternate Winner / Runner Up arrangement. Any alternate Jackpot Prize Winner or Runner Up shall likewise comply with the above 21-day contact requirement.\n    \n        The Promoter shall take all reasonable steps to ensure and preserve the random nature of all Draws but shall not be required to comply with any particular regulatory or other standards in this respect. The Jackpot Prize Competition Draw shall be managed and verified by Sterling Lotteries who are independent of the Promoter and licensed and regulated by the Gambling Commission (More information about them can be found here:https://sterlinglotteries.co.uk/. The Weekly Lifestyle and Cash Prize Draws shall be made using random number generating software and independently verified. The result(s) of any Draw are final.\n    \n        On the Jackpot Property Draw Date, the Promoter shall calculate the Charity Donation and apportion the same on a pro-rata basis between the Charities in accordance with the aggregated preferences specified by the Entrants at the time of Entry. The Promoter shall publish the details of the Charity Donation made on the Website. The Promoter’s calculations of the Charity Donation apportionment are final.\n    \n        The Winner and any Runner(s) Up will be required to forward a copy of their passport or driving licence together with two utility bills or bank statements (or a combination of the two) dated within the previous three months to the Promoters to prove their identity and, in the event of an online Entry, that their Entry was made using a valid debit/credit card belonging to the Entrant or used with the express authorisation of the card holder and that there is no lawful impediment (subject to any applicable UK or international law) to Winner or any Runner(s) Up being awarded any prize in the Competition.In the event that Promoter reasonably believes that there may be a lawful impediment to awarding a prize to a Winner or any Runner(s) Up, the Promoter may suspend making such award until the legal issue is resolved, or if, in the reasonable opinion of the Promoter such issue cannot be resolved, to award that prize in a like manner as set out in term 31 above.\n    \n        If the prize comprises the Property, the Promoter will arrange for the Property to be transferred by (or on behalf of) the legal owner(s)/proprietor(s) of the Property to the Winner subject to the terms of a separate sale contract and instrument of transfer to be entered into between the owner(s) of the Property and the Winner, free from any charges, mortgages or other encumbrances to its legal or equitable title and subject always to compliance with all applicable law. The Promoter shall not be responsible or liable for any matters arising out of the conduct of the transfer of the Property including without limitation any negligence of any conveyancers.\n    \n        The Promoters take care to only offer properties in good repair though do not in any way guarantee or give any warranties as to the value of the Property, its condition, history or any other matters associated with the Property.\n    \n        Any Stamp Duty Land Tax (SDLT) and contribution to SDLT will only be paid to the extent that SDLT is actually payable. The maximum SDLT that could be payable (if the winner already owns a home) is £35,000. The Winner will be responsible for all other taxes or charges incurred arising out of the transfer to and ownership or occupation of the Property, including council taxes, grounds rents and service charges which are not covered by the Bonus Prize.\n    \n        The Winner shall execute all documents required for the transfer of the Property and take all steps they can to ensure transfer and registration of the Property at the Land Registry within 4 months of the Draw Date.\n    \n        The Promoter shall only deal with any Winner or, as applicable, Runner(s) Up or their estate (in the case of their prior death) and no prize in the Competition is transferable.\n    Fixed Odds Competitions and its Draws\n        The Winners will be determined and awarded the Prizes so specified on the Website and in accordance with these Terms and Conditions.\n    \n        The Draw to determine the Winners and any Runner(s) Up will be made on the Draw Date (subject to term 42).\n    \n        The Promoter may, at its sole discretion, and at any time during the Fixed Odds Competitions up to the end of the Closing Date, bring forward the Closing Date to a new Closing Date, to be before and no later than the specified Closing Date in the event that the Stated Number of Fixed Odds Entries have been sold. Also, the Promoter may, at its sole discretion, and at any time during the Competition up to the end of the Closing Date, extend the Competition Closing Date in the event that the Stated Number of Fixed Odds Entries has not been met a maximum of 4 times and extend no more than 30 days at each individual extension.\n    \n        If by the Closing Date (subject to term 42), the Stated Number of Fixed Odds Entries has been received, the Competition will close and on the Draw Date: there will be a Draw to determine the Winner (and Runner(s) Up in the event that the winner cannot be contacted within the time allocated in term 45), and the Prize shall be awarded.\n    \n        For Fixed Odds Competitions, if by the Closing Date (subject to term 42), the actual number of Entries received is less than the Stated Number of Fixed Odds Entries, the Competition will close and on the Draw Date there will be a Draw, at the sole discretion of the Promoter, by reference to the proceeds received from the Entries to: award to the Winner the Cash Prize (For Fixed Odds Competitions).\n    \n        If any Fixed Odds Winner cannot be contacted by the Promoter within 7-days of being notified of their status as the Winner by e-mail and/or, telephone to the contact details submitted in their Entry, the Promoter shall be entitled to award their prize to the Entrant next Drawn, with the effect that the first Runner Up (as applicable) would become the Winner, and so on. At the Draw, there shall be such number of additional / reserve Entries Drawn but not actioned or disclosed until required to permit the operation of this alternate Winner / Runner Up arrangement. Any alternate Prize Winner or Runner Up shall likewise comply with the above 7-day contact requirement.\n    \n        The Promoter shall take all reasonable steps to ensure and preserve the random nature of all Draws but shall not be required to comply with any particular regulatory or other standards in this respect. Fixed Odds Prize Draws shall be made using random number generating software and independently verified. The result(s) of any Draw are final.\n    \n        On the Jackpot Property Draw Date, (or within the financial year if there are no properties offered), the Promoter shall calculate the Charity Donation and apportion the same on a pro-rata basis between the Charities in accordance with the aggregated preferences specified by the Entrants at the time of Entry. The Promoter shall publish the details of the Charity Donation made on the Website. The Promoter’s calculations of the Charity Donation apportionment are final.\n    \n        The Winner may be required to forward a copy of their passport or driving to the Promoters to prove their identity and, in the event of an online Entry, that their Entry was made using a valid debit/credit card belonging to the Entrant or used with the express authorisation of the card holder and that there is no lawful impediment (subject to any applicable UK or international law) to Winner or any Runner(s) Up being awarded any prize in the Competition.In the event that Promoter reasonably believes that there may be a lawful impediment to awarding a prize to a Winner or any Runner(s) Up, the Promoter may suspend making such award until the legal issue is resolved, or if, in the reasonable opinion of the Promoter such issue cannot be resolved, to award that prize in a like manner as set out in term 45 above.\n    \n        The Promoter will arrange for any Prizes to be delivered or transferred to the Winners to the free from any charges or other encumbrances to its legal or equitable title and subject always to compliance with all applicable law. The Promoter shall not be responsible or liable for any costs associated with the ownership of any Prize once transferred to the Winners.\n    \n        The Promoter shall only deal with any Winner or, as applicable, Runner(s) Up or their estate (in the case of their prior death) and no prize in the Competition is transferable.\n    Weekly Lifestyle, and Weekly Cash Prize Competitions and their Draws\n        The Winners will be determined and awarded the Prizes so specified on the Website and in accordance with these Terms and Conditions.\n    \n        The Draw to determine the Winners and any Runner(s) Up will be made the day after the Competitions’ Closing Date.\n    \n        On every Closing Date there will be a Draw to determine the Winner (and Runner(s) Up in the event that the winner cannot be contacted within the time allocated in term 54), and the prize shall be awarded.\n    \n        If any Lifestyle Prize or Weekly Cash Prize Winner cannot be contacted by the Promoter within 7-days of being notified of their status as the Winner by e-mail and/or, telephone to the contact details submitted in their Entry, the Promoter shall be entitled to award their prize to the Entrant next Drawn, with the effect that the first Runner Up (as applicable) would become the Winner, and so on. At the Draw, there shall be such number of additional / reserve Entries Drawn but not actioned or disclosed until required to permit the operation of this alternate Winner / Runner Up arrangement. Any alternate Prize Winner or Runner Up shall likewise comply with the above 7-day contact requirement.\n    \n        The Promoter shall take all reasonable steps to ensure and preserve the random nature of all Draws but shall not be required to comply with any particular regulatory or other standards in this respect. Weekly Lifestyle and Weekly Cash Prize Draws shall be made using random number generating software and independently verified. The result(s) of any Draw are final.\n    \n        On the Jackpot Property Draw (or within the financial year if there are no properties offered), the Promoter shall calculate the Charity Donation and apportion the same on a pro-rata basis between the Charities in accordance with the aggregated preferences specified by the Entrants at the time of Entry. The Promoter shall publish the details of the Charity Donation made on the Website. The Promoter’s calculations of the Charity Donation apportionment are final.\n    \n        The Winner may be required to forward a copy of their passport or driving to the Promoters to prove their identity and, in the event of an online Entry, that their Entry was made using a valid debit/credit card belonging to the Entrant or used with the express authorisation of the card holder and that there is no lawful impediment (subject to any applicable UK or international law) to Winner or any Runner(s) Up being awarded any prize in the Competition.In the event that Promoter reasonably believes that there may be a lawful impediment to awarding a prize to a Winner or any Runner(s) Up, the Promoter may suspend making such award until the legal issue is resolved, or if, in the reasonable opinion of the Promoter such issue cannot be resolved, to award that prize in a like manner as set out in term 54 above.\n    \n        The Promoter will arrange for any Prizes to be delivered or transferred to the Winners free from any charges or other encumbrances to its legal or equitable title and subject always to compliance with all applicable law. The Promoter shall not be responsible or liable for any costs associated with the ownership of any Prize once transferred to the Winners.\n    \n        The Promoter shall only deal with any Winner or, as applicable, Runner(s) Up or their estate (in the case of their prior death) and no prize in the Competition is transferable.\n    Winner Announcement\n        The Winner(s) and any Runner(s) Up shall be announced and publicised on the Website and via email campaigns, as well as on Raffle House’s associated social media pages/sites, such as Facebook, Instagram and Twitter. Any Winner and Runner(s) Up shall cooperate with and participate in the Promoter’s reasonable publicity requests.\n    Limitation of Liability\n        Insofar as is permitted by law, the Promoter, their agents or distributors will not in any circumstances be responsible or liable to compensate any Entrant or accept any liability for any loss, damage, personal injury or death occurring as a result of submitting and Entry or in relation to the Property except where it caused by the negligence or fraud of the Promoter, their agents or distributors, or that of their employees. The Winner’s(`) statutory rights are not affected.\n    \n        The liability of the Promoter to each Entrant is limited to the aggregate value of the Entry Fees paid by that Entrant.\n    \n        The Promoters accept no liability for errors or omissions contained within the description of the Property or the Property Value or for any other description or specification or any other part of the Website. It is the responsibility of each Entrant (and in particular the Winner) to satisfy him/herself as to the accuracy of any such details and/or any content of the Website.\n    \n        Each Entrant agrees that the usual requirement under the Consumer Protection (Distance Selling) Regulations 2000 for any goods and services ordered online to be supplied within 30 days will not apply to the Competition.\n    General\n        The Promoter shall not be a trustee of any Entry Fees received.\n    \n        The Promoter reserves the right to suspend or cancel any Competition at any time either before or after Entries have been received. If the Competition is cancelled, the Promoter will return the Entry Fees to each Entrant by bank card refund or by cheque (at the Promoter’s sole discretion). Any refund of the Entry Fee may be subject to deduction of any irrecoverable acquiring bank service charge fees. Where the Entry Fee is returned, the Promoter shall have no further liability to the Entrant or to any other person.\n    \n        Without prejudice to the operation of term 57 above, the Promoters reserve the right to cancel any Competition in the event that an order is made or a resolution is passed for the winding up of the Promoter, or an order is made for the appointment of an administrator to manage the affairs of the Promoter, or circumstances arise which entitle a court or creditor to appoint a receiver or manager or which entitle a court to make a winding up order, or the Promoter takes or suffers any analogous action in consequence of debt or an application to court for protection from its creditors is made by the Promoter.\n    \n        The Promoters reserve the right to make reasonable amendments to these Terms and Conditions at any time, with immediate effect upon publishing such amendments on the Website. Any such amendments shall not prejudice any Entries received prior to the time of such changes.\n    \n        These Terms and Conditions shall not create or be construed as creating any form of contract, joint venture or other agreement between any Entrant and the Promoters.\n    \n        The Competition, its administration and all associated activities shall be governed by the laws of England and Wales and the parties submit to the exclusive jurisdiction of the courts of England and Wales.\n    \n        Each Entrant should retain a copy of these Terms and Conditions as at the date of their Entry for their future reference.\n    Definitions The following definitions apply in these Terms and\n        Conditions:ACCOUNT: means a\n        free-to-create online Raffle House account, created using personal information,\n        such as name, email address and telephone number or by using a Facebook or\n        Google login, as set out in term 6 and processed in accordance with the\n        Promoter’s Data Protection and Privacy Policy. The Account will display\n        information pertinent to the Dream Home Prize Competition, Weekly Lifestyle,\n        Fixed Odds and Weekly Cash Prize Competitions, such as Tickets, Referral links,\n        account information and management tools.\n        BONUS PRIZE: is a sum payable to the Winner (subject to term 29) of up to\n        £3,000 to cover council tax and reasonable utilities for a period of 12 months;\n        and reasonable solicitors’ fees (to include disbursements) incurred in\n        connection with the transfer of the Property to the Winner, capped at £1,500\n        inclusive of VAT.CASH PRIZE (FOR THE DREAM HOME PROPERTY\n        COMPETITION): in the event of a Draw under term\n            30, a cash prize payable to the Winner being calculated as (1) 90% of the total\n            value of the total Entry Fees received up to the Closing Date net the\n            Promoter’s costs and overheads; less (2) the amount of the Charity Donation;\n            and less (3) the payment processor and acquiring bank fees. CASH PRIZE (FOR FIXED ODDS COMPETITIONS): unless\n        the prize is stated as guaranteed on the website and in the event of a Draw\n        under term 44, a cash prize payable to the Winner being calculated as 70% of\n        the total value of the total Entry Fees received up to the final Closing Date\n        less (1) the amount of the Charity Donation; and less (2) the payment processor\n        and acquiring bank fees. CHARITY(IES): means the\n        charities or charitable causes specified on the Website to whom the Charitable\n        Donation will be paid after the Dream Home Property Competition Draw. CHARITY DONATION: means 2.5%\n        of the total value of Entry Fees received to be payable to the Charity(ies)\n        after the Dream Home Property Competition Draw (or within the financial year if\n        there are no properties offered) - where there is more than one Charity, in\n        proportion to the preferences stated by all the Entrants at the time of submitting\n        their Entry. CLOSING DATE(s): for the Dream\n        Home Property Competition: means 30 June, 2021, subject to term 28. For Weekly\n        Cash and Lifestyle Competitions: means every Sunday at midnight (00:00:00:000\n        UK time). Fixed Odds Competitions close when stated on their unique product\n        page, subject to term 42. CREDIT: Credit can be earned\n        for any purchase, awarded separately, or via making a valid Referral. Credit\n        can be spent on any Competition and, if not used, will expire 30-days after\n        first being awarded. Once expired, Credit cannot be used or redeemed. The\n        amount of credit earned in any way is subject to change and customers will be\n        notified at the point of purchase, and referrers at point of action of what\n        credit they are going to be awarded.  DRAW or DRAWN: means the\n        choice of an Entry or Entries, made at random, which may be made by Postal\n        Entry or by way of a computer function (at the Promoter’s sole discretion) on\n        any Draw Date (for the Weekly Lifestyle, Fixed Odds, and Cash Prize\n        Competitions or Dream Home Prize Competition) to determine a Winner and, where\n        applicable, any Runner(s) Up. DRAW DATE: The Dream Home\n        Property Competition will be Drawn up to but no later than 21 days after the\n        Closing Date of any Competition and at the sole discretion of the promoter\n        (subject to term 28). Fixed Odds Competitions will be Drawn up to but no later\n        than 7 days after the Closing Date of any Competition and at the sole\n        discretion of the promoter (subject to term 44). The Weekly Lifestyle and Cash\n        Prize Draws will be held the first working day following the closure of the\n        previous Sunday’s weekly competition.  ENTRANT: any natural person\n        (not including a limited company, partnership or limited liability partnership)\n        who validly submits an Entry to the Competition, in accordance with these Terms\n        and Conditions. ENTRY: means a validly\n        submitted and completed entry by the Entrant through the Website or Postal\n        Entry in order to obtain an opportunity to win any of the Prizes (and ENTRIES\n        means more than one Entry). ENTRY FEE: the entry fee\n        payable as a condition of submitting a single valid Entry online only. FIXED ODDS PRIZE: means the\n        Prize as advertised on the Website as detailed in the specific Fixed Odds\n        product page awarded to the Winner subject to a Draw under term 43 or the Cash\n        Prize (for Fixed Odds Competitions) subject to a Draw under term 44. DREAM HOME PRIZE: means the\n        Property to be awarded to the Winner subject to a Draw under term 29 or the\n        Cash Prize (for the Dream Home Property Competition) subject to a Draw under\n        term 30. DREAM HOME PROPERTY COMPETITION:\n        means the Dream Home Property Competition operated by the Promoters to which\n        these Terms and Conditions apply, wherein the Entrants submit Entries via the\n        Website or via Postal Entry to win the Dream Home Property Prize (subject to\n        term 30). \n        MINIMUM NUMBER OF DREAM HOME PROPERTY ENTRIES: means 650,000 Entries where the\n        Entry Fee has been paid in cash and exempting any Entries credited as paid by\n        the utilisation of a promotional voucher, Postal Entry or credit offered by the\n        Promoter under term 4. OPENING DATE (only applicable\n        to the Dream Home Property Competition): means August 1, 2020 POSTAL ENTRY: the means of\n        entering by post rather than paying online. Like an online entry, a free\n        account must be created in order for a free entry to be applied. A full\n        explanation of the Postal Entry requirements can be found in term 3 and on the\n        Website at https://rafflehouse.com/post PROPERTY: means 1A, Eastlake\n        Road, London, SE5 9QJ, as shown on the Promoters’ Website, in the 3D tour,\n        floorplan and photos and other media. PROPERTY VALUE: £750,000 being\n        the amount so specified as an asking price by the owner of the Property for the\n        purposes of offering it as a prize in this Dream Home Prize Competition and\n        verified by an independent agent, which is accessible on the Website. PROMOTER: means Raffle House\n        Ltd, company number 10928240, whose registered office address is 1B Ashmere\n        Grove, London, SW2 5UH\n        REFERRAL: means any successful Entrant recorded through any account holders’\n        unique referral link, which can be found and accessed in every Account.REFERRAL PRIZE: means a cash\n        prize of £5,000 payable to the Referral Winner following the closure of the Dream\n        Home Prize Competition (subject to term 28).\n        REFERRAL WINNER: means the Winner of the Referral Bonus Prize, as defined by\n        the highest total number of Referrals recorded by the Website for that Account\n        Holder. The Promoter’s decision is final and all referral counts will be available\n        for review on the Website following the closure of the Dream Home Prize\n        Competition.RUNNER(S) UP: The Entrant(s)\n        corresponding to the next reasonable number of Tickets Drawn after the Winner\n        on the Draw Date and handled in chronological order reflected in their Draw\n        positions. STATED NUMBER OF FIXED ODDS\n        ENTRIES: means the fixed and total number of Entries as detailed on the\n        competitions’ unique product pages. TICKET(S): means a unique\n        identifier used for the purposes of determining a Winner or Runner(s) Up during\n        any Draw. Tickets are Universally Unique Identifiers comprised of 32 letters\n        and numbers conforming to this logic: 32 hexadecimal (base-16)\n        digits, displayed in five groups separated by hyphens, in the form 8-4-4-4-12\n        for a total of 36 characters (32 hexadecimal characters and 4 hyphens). It\n        should be noted that they are unique identifiers rather than numbers drawn via\n        a lottery style mechanic.WEBSITE:\n        https://www.rafflehouse.comWEEKLY CASH PRIZE COMPETITION:\n        means the weekly £1,000 giveaway that runs from Monday (00:00:00:000) through\n        Sunday (23:59:59:999). Any Ticket purchases with an aggregate transaction value\n        of £20 or more will be entered into that week’s Weekly Cash Prize Competition.\n        Weekly Cash Prize draws will be secondary to Weekly Lifestyle Prize Draws, and\n        the winner of the Weekly Lifestyle Prize cannot win the Weekly Cash Prize. If a\n        corresponding number of Postal Entries to the aggregate value of £20 for any\n        Competition are received and processed before close of business Friday, they\n        will also be entered into the corresponding Weekly Cash Prize Draw. Any Postal\n        entries received after the corresponding weekly cut-off will be counted towards\n        the next weekly draw should a total corresponding number of Postal Entries to\n        the aggregate value of £20 be received the following week. There will be no\n        Weekly Cash Prize Competition Draw or Winner for paid or Postal Entries in the\n        final full week of the Dream Home Prize Competition. WEEKLY LIFESTYLE PRIZE\n        COMPETITION: means the weekly Lifestyle Prize Competition that runs from Monday\n        (00:00:00:000) through Sunday (23:59:59:999). All Entries for all Lifestyle\n        Prize Competitions will be entered into a single Draw and one Winner will be\n        Drawn every week. The winning Entry, associated with a specific prize at time\n        of purchase or defined in a Postal Entry, will define the Prize to be awarded.  WINNER: The Entrant corresponding to the first Correct Entry Drawn on\n        the Draw Date and in accordance with these Terms and Conditions!";
        public const string POLICY = "Last Update: April 5, 2021\n        Raffle House recognises the importance of honest and responsible use of your\n        personal information. We will never share or sell your personal data to other\n        companies or third parties; we treat personal data with extreme sensitivity and\n        in accordance with all applicable GDPR laws. Site usage information (non-personally\n        identifiable data) provided to us through usage of the Site may be shared with\n        other companies. This Privacy and Cookies Policy (\"Policy\") explains\n        how and why we collect, and use personal and non-personally identifiable information\n        about you when you visit this Site and when you contact us, whether by e-mail,\n        post, or telephone using the contact options on this Site.\n        It is important to us that you feel comfortable in visiting the Site. For any\n        questions regarding this Policy, data removal and/or deletion requests, or\n        other questions, please email info@rafflehouse.com.This Privacy and Cookies\n        Policy applies to the website https://www.rafflehouse.com (\"the\n        Site\") which is run by Raffle House Ltd. (\"the Company\")\n        (company number 10928240) whose registered office address is 1 Ashmere Grove,\n        London, SW2 5UH. Our collection of website use\n        information may involve the use of cookies and Web beacons. Please see the\n        \"Cookies\" section below for more information.DATA PROTECTION\n    For the purposes of the Data Protection Act 1998 (the Act) and the General Data\n    Protection Regulation, the data controller is the Company. LEGAL BASIS FOR THE USE OF PERSONAL DATA\n    The legal basis on which we rely to process your personal information includes:\n\n        On some occasions, we process your data with your consent (for example, when you agree that we may place cookies or process information that you input into our website).\n    \n        On other occasions, we process your data when we need to do this to fulfil a contract with you (for example, if you win a prize in the competitions we promoted or where we are required to do this by law (for example, to comply with record keeping obligations).\n    \n        We also process your data when it is in our legitimate interests to do this and when these interests are not overridden by your data protection rights (including for example, when we share data with our affiliates).\n    In most cases, the information\n        the Company processes about you is required to deal with your request or\n        registration, or required by law, or is necessary for the exercise of the\n        Company’s legitimate business interests and needs, in which case special care\n        is taken to safeguard your rights and to ensure any such use is proportionate.\n        The Company may also convert personal information into anonymous data and use\n        it (normally on an aggregated statistical basis) for research and analysis to\n        improve Company performance.PERSONAL INFORMATION WE COLLECT FROM YOU\n    If you want to use certain facilities we provide on this Site, you will need to\n    provide us with some additional personal information so that we can liaise with\n    you and deal with your request, query or application. If you do choose to\n    provide us with your personal information, we will collect that information for\n    our own use and for the purposes described in this Policy.\n    Where you choose to provide personal details to us, we may collect, store and\n    process the following personal information from you. We do so largely so that\n    in the event of a win, we can contact you and ask for you by name and begin any\n    verification process that may need to occur in order to transfer winnings,\n    Prize or Property:\nyour full\n            name; your\n            contact details e.g. phone number and e-mail address;the\n            reason for your contact, which may be an enquiry, a request or enquiry on\n            behalf of someone else, providing a comment, or details in relation to a\n            possible or existing competition;if you\n            create an account - your password, e-mail address and your full name;if you\n            enter competitions on the Site - full name, email address;your\n            contact and marketing preferences;if you\n            take a survey or interact with us in various other ways - demographics\n            information and information about subjects that may interest you;standard\n            internet and website log information and details of patterns about how\n            website visitors behave on our Site. The information we may collect\n            includes information about your Internet service provider, your operating\n            system, browser type, domain name, the Internet protocol (IP) address of\n            your computer (or other electronic Internet-enabled device), your access\n            times, the website that referred you to us, the Web pages you request and\n            the date and time of those requests.where you\n            \"like\" us or make posts on our pages on social networking\n            websites.This information will be\n        collected primarily from you as information voluntarily provided to us, but we\n        may also collect it where lawful to do so from (and combine it with information\n        from) public sources, third party service providers, individuals whom you have\n        indicated have agreed for you to provide their personal information,\n        government, tax or law enforcement agencies, and other third parties. We may\n        also collect personal information about you from your use of other company\n        services.USES MADE OF YOUR PERSONAL INFORMATION\n    \n    The Company may use information about you for purposes described in this Policy\n    or disclosed to you on our Site or with our services. For example, we may use\n    information about you for the following purposes, all of which we believe to be\n    in our legitimate business interests:\nto\n            operate competitions promoted on the Siteto\n            respond and/or deal with any request or enquiry you may raise;to\n            improve our products and services and to ensure that content from the Site\n            is presented in the most effective manner for you and for your computer\n            (or other electronic Internet-enabled device);to\n            administer the Site;for\n            internal record keeping;to\n            contact you (directly, either by the Company or through a relevant partner\n            or agent) by e-mail or phone for the above reasons;subject\n            to your consent where required under applicable laws, to carry out direct\n            marketing and/or e-mail marketing that you have requested;to\n            perform any contract the Company has with you; andfor\n            compliance with legal, regulatory and other good governance obligations.DISCLOSURE OF YOUR PERSONAL\n            INFORMATION\n        Your personal information will be made available for the purposes mentioned\n        above (or as otherwise notified to you from time to time), on a ‘need-to-know’\n        basis and only to responsible management, human resources, accounting, legal,\n        audit, compliance, information technology and other Company staff who properly\n        need to know these details for their functions within the Company and our\n        parent and subsidiary companies (“Group”). Please note that certain individuals\n        who will see your personal information may not be based at the Company or in\n        your country (please see below).\n        We may share personal information within the Company as needed for reasonable\n        management, analysis, planning and decision making, including in relation to\n        taking decisions regarding the expansion and promotion of our service offering\n        and for use by the Company for the other purposes described in this Policy.\n        Your personal information may also be made available to third parties (within\n        or outside the Company) providing relevant services under contract to the\n        Company, (see below for further details), such as credit card processors,\n        auditors and compliance managers, provider or call centres and IT hosting and\n        IT maintenance providers. These companies may use information about you to\n        perform their functions on our behalf. The Company has put in place various\n        security and data privacy measures, including with such third parties, in order\n        to protect personal information and shall seek to comply with applicable legal\n        requirements.\n        The data that we collect from you may be transferred to, and stored at, a\n        destination outside the European Economic Area (\"EEA\"). It may also\n        be processed by staff operating outside the EEA who work for us or for one of\n        our providers. This may include staff engaged in, among other things, the\n        fulfilment of any contract with you, the processing of your payment details and\n        the provision of support services. By submitting your personal data, you agree\n        to this transfer, storing or processing. We will take all steps reasonably\n        necessary to ensure that your data is treated securely and in accordance with\n        this privacy policy.\n        We may disclose specific information upon lawful request by government\n        authorities, law enforcement and regulatory authorities where required or\n        permitted by law and for tax or other purposes. Personal information may also\n        be released to external parties in response to legal process, and when required\n        to comply with laws, or to enforce our agreements, corporate policies, and\n        terms of use, or to protect the rights, property or safety of the Company, our\n        employees, agents, customers, and others, as well as to parties to whom you\n        authorise the Company to release your personal information.\n        We will not sell your personal information to any third party other than as\n        part of any restructuring of the Company or sale of the business.WHAT CHOICES DOES THE COMPANY OFFER YOU WITH REGARD TO DIRECT MARKETING?\n    The Company may wish to provide you with information about new products,\n    services, promotions and offers, which may be of interest to you and may invite\n    you to take part in market research or request feedback on our products and\n    services. This communication may occur by e-mail, telephone, post, social media\n    or SMS. We will obtain your consent and advise you of how to opt-out of\n    receiving such communications where we are required to do so in accordance with\n    applicable law.WHAT SAFEGUARDS ARE IN PLACE TO PROTECT YOUR PERSONAL INFORMATION?\n    The Company takes reasonable steps to maintain appropriate physical, technical\n    and administrative security to help prevent loss, misuse, unauthorised access,\n    disclosure or modification of personal information. While we take these\n    reasonable efforts to safeguard your personal information, we cannot guarantee\n    the security of any personal information you disclose online. You accept the\n    inherent security implications of dealing online and will not hold us\n    responsible for any breach of security unless such breach has been caused by\n    the specific negligence of the Company, or their agents.WHAT RIGHTS DO YOU HAVE TO REVIEW AND AMEND PERSONAL INFORMATION?\n    You have the right to review and access your personal information held by the\n    Company.\n    You also have the right to ask us to rectify, block, complete and delete your\n    personal information, to restrict its use, and to ‘port’ your personal\n    information (that is, to ask us to provide it to you in a structured, commonly\n    used and machine readable format and to transmit it directly to another\n    organisation).\n    In addition, you have the right to request further information about the\n    handling of your personal information.\n    If you wish to do so, or to notify the Company of a change in your details,\n    please contact info@rafflehouse.com and/or post to Raffle House Ltd, 1 Ashmere\n    Grove, London, SW2 5UH.\n    There are exceptions to these rights, however. For example, access to personal\n    information may be denied in some circumstances if making the information\n    available would reveal personal information about another person or if we are\n    legally prevented from disclosing such information. In addition, we may be able\n    to retain data even if you withdraw your consent, where we can demonstrate that\n    we have a legal requirement to process your data.\n    If you have a question about the use of your personal information, or wish to\n    file a complaint about it, please contact us using the contact details set out\n    above.\n    Finally, if you have unresolved concerns, you also have the right to complain\n    to data protection authoritiesKEEPING YOU INFORMED\n    When we store your information, we do so for as long as necessary to (i) fulfil\n    the specific purposes for which your personal information was collected to\n    perform the services set out in this notice and (ii) to comply with our legal\n    obligations or enforce our legal rights.INFORMATION ABOUT OUR USE OF COOKIES\n    We use cookies for certain areas of our Site. Cookies are small data files\n    stored on your hard drive by a website. Cookies help us improve our Site and\n    your experience. We use cookies to see which areas and features are popular and\n    to count visits to our websites, to recognise you as a returning visitor and to\n    tailor your experience of the Site according to your preferences. Overall,\n    cookies help us provide you with better websites, by enabling us to monitor\n    which pages you find useful and which you do not. We may also use cookies for\n    targeting or advertising purposes. We may use Web beacons on our Site or in our\n    e-mails. Web beacons are electronic images that may be used to deliver cookies,\n    count visits, understand usage of group websites and to tell if an e-mail has\n    been opened and acted upon. Further details about cookie purposes and types are\n    below. To delete or block cookies by browser settings at any time and for more\n    general information about cookies including the difference between session and\n    persistent cookies, visit www.allaboutcookies.org.\n    We also use Google Analytics on our Site to collect information about your\n    online activity on the Site, such as the Web pages you visit and the links you\n    click on the Site. We use the information to compile reports and to help us\n    improve the Site. The cookies collect information in an anonymous form,\n    including the number of visitors to the Site, where visitors have come to the\n    Site from and the pages they visited.\n    For more information about the information gathered using Google Analytics\n    please visit http://www.google.com/intl/en/analytics/privacyoverview.html. You\n    can prevent these cookies by selecting the appropriate settings on your\n    browser. If you do this you may not be able to use the full functionality of\n    this Site. You may download and install the Google Analytics Opt-out Browser\n    Add-on available here: http://tools.google.com/dlpage/gaoptout.\n    The cookies used on our Site are categorised in accordance with the\n    International Chamber of Commerce United Kingdom Cookie Guide as follows:\nCookies\n            which are \"strictly necessary\" for\n            functionality of the Site’s platforms. These cookies are essential in\n            order to enable users to move around the Site and use its features.\"Performance\" cookies which collect information about how\n            users navigate the Site, for example, which pages users access most\n            frequently. They identify how users interact with our Site, any errors\n            that occur, which pages are not used often, which pages take a long time\n            to load, which pages users tend to visit and in what order. These cookies\n            do not collect any information which could identify you and are only used\n            to help us improve how our Site works and understand what interests our\n            Site’s users.\"Functionality\" cookies which allow the Site to remember\n            choices you make and your preferences as a logged in user (based on e.g.\n            your user name).\"Targeting\n                or advertising\" cookies used to deliver adverts relevant to an identified machine\n            or other device (not a named or otherwise identifiable person) which are\n            tailored to interests associated with the website activity tied to that\n            machine or device. For example, if a cookie on a third party website\n            recognises that a particular product was purchased from a particular\n            device, that cookie may “talk to” marketing cookies on the Site to ensure\n            advertisements about similar products displayed on the Site are accessed\n            from that device. These cookies are also used to limit the number of times\n            a user sees an advertisement as well as to help measure the effectiveness\n            of an advertising campaign. They may also remember that the Site has been\n            visited from a device and share that information with marketing\n            organisations. The marketing cookies on our Site are operated by third\n            parties with our permission. Marketing cookies are used to monitor from\n            which advertising source a user was directed towards our Site so that we\n            know whether it is worth us investing in that particular advertising\n            source. Cookie\n                            name/typeExpiration\n                            PeriodPurposeCategory of\n                            cookie as defined in the ICC Cookie GuideASP.NET_SessionIdSession\n                        (these cookies typically expire at the end of your session or at the latest\n                        within one week)Authentication session to prevent having to login multiple times in \n                        one browser session. A unique ID that ties the current session to a database\n                        settings table.A. Strictly necessary\n                        C. FunctionalityVSI Cookie Status12 months from set/updateEnables us to remember if you have seen the cookie information panel\n                        and accept cookies from this website.A. Strictly necessary\n                        C. FunctionalityGoogle Analytics\n                        utma2 years from set/updateProvides a unique ID for each Web browser that visits this site.D. Targeting/advertisingGoogle Analytics\n                        utmbSession\n                        30 minutes from set/updateUsed to establish and continue a user session with this website.D. Targeting/advertisingGoogle Analytics\n                        utmcSession\n                        (these cookies typically expire at the end of your session ie when you close\n                        your browser)Used to establish and continue a user session with this website.D. Targeting/advertisingTwitter eu_cnSession\n                        1 year from set/updateUsed to collect information  about users browsing behaviour for\n                        marketing purposes including digital display and social media advertisingD. Targeting/advertisingTwitter _gaSession\n                        2 years from set/updateD. Targeting/advertisingTwitter guest_id\n                        Twitter\n                        personalization_idSession\n                        2 years from set/updateUsed to collect information about users browsing behaviour for  marketing purposes including digital display and social media advertisingD. Targeting/advertisingYouTube CookiesSession\n                        2 years from set/updateWe embed videos from YouTube using YouTube’s privacy-enhanced mode.\n                        This mode may set cookies  on your computer once you click on the YouTube\n                        video playerC. Functionality\n                        D. TargetingCOOKIE SETTINGS\n        We will ask for your consent to the use of cookies set out in this Privacy and\n        Cookies Policy when you first access the Site and if we introduce any new\n        cookies to the Site. When you first visit the Site, a box/banner will appear\n        asking you to agree to the cookies that we set on the Site.\n        You can usually choose to set your browser to warn you when a cookie is being\n        sent or to remove or reject cookies. Each browser is a little different, so\n        look at your browser Help menu to learn the correct way to modify your cookie\n        settings. If you choose to remove or reject cookies, it will affect many\n        features or services on our Site.If you agree to cookies from our Site by clicking on the \"I\n        agree\" button, we will set cookies from categories A, B, C and D on your\n        device. If you wish to delete the cookies we have set on your device, please\n        refer to your browser Help menu.If you do nothing to indicate your cookie preference for our Site\n        (i.e. if you do not click on \"I agree\"), we will treat this as\n        acceptance and set category A, B and C cookies (which are, in our reasonable\n        view, not ‘intrusive’ of your privacy) on your device. By default, category D\n        cookies will not be set on your device. To modify your cookie settings, please\n        refer to the Help menu of your browser.If you say no to cookies on our Site we will not set category A, B\n        C, or D cookies on your device. Please note that if you do this you may not be\n        able to use the full functionality of our Site.CHANGES TO THIS PRIVACY AND COOKIES POLICY\n    We keep this Policy under regular review. We may change this Policy from time\n    to time by updating this page in order to reflect changes in the law and/or our\n    privacy practices. The date at the top of this Policy will be updated\n    accordingly.\n    We encourage you to check the date of this Policy when you visit this Site for\n    any updates or changes. We will notify you of any modified versions of this\n    Policy that might materially affect the way we use or disclose your personal\n    information.\n    Contact/address details\n    If you have any questions about this Privacy Policy, please contact us at:\n    info@rafflehouse.com.\n";
    }

    public class Competitions
    {
        public const string DREAMHOME = "Dream home";
        public const string WEEKLY = "Lifestyle";
        public const string FIXED_ODDS = "Fixed Odds";
    }

    public class DbModels
    {
        #region Users Collection

        [BsonIgnoreExtraElements]
        public class UserRequest
        {
            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("isAdmin")]
            public bool? IsAdmin { get; set; }

            [BsonElement("isManager")]
            public bool? IsManager { get; set; }

            [BsonElement("isVerified")]
            public bool? IsVerified { get; set; }

            [BsonElement("freeEntries")]
            public int? FreeEntries { get; set; }

            [BsonElement("successfullReferralCount")]
            public int? SuccessfullReferralCount { get; set; }

            [BsonElement("totalTicketsBought")]
            public int? TotalTicketsBought { get; set; }

            [BsonElement("emailCommunication")]
            public bool? EmailCommunication { get; set; }

            [BsonElement("registerReferrals")]
            public List<object>? RegisterReferrals { get; set; }

            [BsonElement("freeTickets")]
            public int? FreeTickets { get; set; }

            [BsonElement("isSocialRegistration")]
            public bool? IsSocialRegistration { get; set; }

            [BsonElement("isBlocked")]
            public bool? IsBlocked { get; set; }

            [BsonElement("notifications")]
            public Notification? Notifications { get; set; }

            [BsonElement("spentMoney")]
            public int? SpentMoney { get; set; }

            [BsonElement("name")]
            public string? Name { get; set; }

            [BsonElement("surname")]
            public string? Surname { get; set; }

            [BsonElement("email")]
            public string? Email { get; set; }

            [BsonElement("password")]
            public string? Password { get; set; }

            [BsonElement("phone")]
            public string? Phone { get; set; }

            [BsonElement("country")]
            public string? Country { get; set; }

            [BsonElement("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [BsonElement("registerRaffle")]
            public ObjectId? RegisterRaffle { get; set; }

            [BsonElement("referralKey")]
            public string? ReferralKey { get; set; }

            [BsonElement("neededSpend")]
            public int? NeededSpend { get; set; }

            [BsonElement("referralCredits")]
            public int? ReferralCredits { get; set; }

            [BsonElement("isEmailValid")]
            public bool IsEmailValid { get; set; }

            [BsonElement("updatedAt")]
            public DateTime? UpdatedAt { get; set; }

            [BsonElement("corporateNotification")]
            public bool? CorporateNotification { get; set; }

        }
        public class Notification
        {

            public bool? dreamHome { get; set; }
            public bool? lifestyle { get; set; }
            public bool? fixedOdds { get; set; }
            public bool? myCompetitions { get; set; }
            public bool? newPrizes { get; set; }
            public bool? all { get; set; }
        }
        public class Memberships
        {
            public int? active { get; set; }
            public int? count { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class UserResponse
        {
            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("isAdmin")]
            public bool? IsAdmin { get; set; }

            [BsonElement("isManager")]
            public bool? IsManager { get; set; }

            [BsonElement("isVerified")]
            public bool? IsVerified { get; set; }

            [BsonElement("freeEntries")]
            public int? FreeEntries { get; set; }

            [BsonElement("successfullReferralCount")]
            public int? SuccessfullReferralCount { get; set; }

            [BsonElement("totalTicketsBought")]
            public int? TotalTicketsBought { get; set; }

            [BsonElement("emailCommunication")]
            public bool? EmailCommunication { get; set; }

            [BsonElement("registerReferrals")]
            public List<object>? RegisterReferrals { get; set; }

            [BsonElement("freeTickets")]
            public int? FreeTickets { get; set; }

            [BsonElement("isSocialRegistration")]
            public bool? IsSocialRegistration { get; set; }

            [BsonElement("isBlocked")]
            public bool? IsBlocked { get; set; }

            [BsonElement("notifications")]
            public Notification? Notifications { get; set; }

            [BsonElement("membership")]
            public Memberships? Membership { get; set; }

            [BsonElement("spentMoney")]
            public int? SpentMoney { get; set; }

            [BsonElement("name")]
            public string? Name { get; set; }

            [BsonElement("surname")]
            public string? Surname { get; set; }

            [BsonElement("email")]
            public string? Email { get; set; }

            [BsonElement("password")]
            public string? Password { get; set; }

            [BsonElement("phone")]
            public string? Phone { get; set; }

            [BsonElement("country")]
            public string? Country { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("registerRaffle")]
            public ObjectId? RegisterRaffle { get; set; }

            [BsonElement("referralKey")]
            public string? ReferralKey { get; set; }

            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("googleAccountId")]
            public string? GoogleAccountId { get; set; }

            [BsonElement("facebookAccountId")]
            public string? FacebookAccountId { get; set; }

            [BsonElement("neededSpend")]
            public int? NeededSpend { get; set; }

            [BsonElement("referralCredits")]
            public int? ReferralCredits { get; set; }

            [BsonElement("referredBy")]
            public ObjectId? ReferredBy { get; set; }

            [BsonElement("emailMarketingSentDate")]
            public DateTimeOffset? EmailMarketingSentDate { get; set; }

            [BsonElement("isEmailValid")]
            public bool IsEmailValid { get; set; }

            [BsonElement("boughtDHafterMailing")]
            public bool? BoughtDHafterMailing { get; set; }

            [BsonElement("updatedAt")]
            public DateTimeOffset? UpdatedAt { get; set; }

            [BsonElement("corporateNotification")]
            public bool? CorporateNotification { get; set; }

            [BsonElement("mobileEntry")]
            public bool? MobileEntry { get; set; }

            [BsonElement("spentMobile")]
            public int? SpentMobile { get; set; }

            [BsonElement("klaviyoId")]
            public string? KlaviyoId { get; set; }
        }

        #endregion

        #region Raffles Collection

        [BsonIgnoreExtraElements]
        public class Raffle
        {
            [BsonElement("__v")]
            public int V { get; set; }

            [BsonElement("_id")]
            public ObjectId Id { get; set; }

            [BsonElement("active")]
            public bool Active { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset CreatedAt { get; set; }

            [BsonElement("creditsRates")]
            public List<Object>? CreditsRates { get; set; }

            [BsonElement("defaultTickets")]
            public int DefaultTickets { get; set; }

            [BsonElement("discountCategory")]
            public string? DiscountCategory { get; set; }

            [BsonElement("discountRates")]
            public List<DiscountRate> DiscountRates { get; set; }

            [BsonElement("discountTicket")]
            public DiscountTicket DiscountTicket { get; set; }

            [BsonElement("endsAt")]
            public DateTime? EndsAt { get; set; }

            [BsonElement("freeTicketsRates")]
            public List<FreeTicketsRates> FreeTicketsRates { get; set; }

            [BsonElement("isActiveDiscount")]
            public bool IsActiveDiscount { get; set; }

            [BsonElement("isClosed")]
            public bool IsClosed { get; set; }

            [BsonElement("isCreditsActive")]
            public bool IsCreditsActive { get; set; }

            [BsonElement("isDeleted")]
            public bool IsDeleted { get; set; }

            [BsonElement("isDiscountRates")]
            public bool IsDiscountRates { get; set; }

            [BsonElement("isFreeTicketsRates")]
            public bool IsFreeTicketsRates { get; set; }

            [BsonElement("isPopular")]
            public bool IsPopular { get; set; }

            [BsonElement("isRemoved")]
            public bool IsRemoved { get; set; }

            [BsonElement("isTrending")]
            public bool IsTrending { get; set; }

            [BsonElement("metaDescription")]
            public string? MetaDescription { get; set; }

            [BsonElement("metaTitle")]
            public string? MetaTitle { get; set; }

            [BsonElement("property")]
            public ObjectId? Property { get; set; }

            [BsonElement("startAt")]
            public DateTime? StartAt { get; set; }

            [BsonElement("ticketPrice")]
            public double TicketPrice { get; set; }

            [BsonElement("ticketsBundles")]
            public List<int> TicketsBundles { get; set; }

            [BsonElement("title")]
            public string? Title { get; set; }

            [BsonElement("updatedAt")]
            public DateTimeOffset UpdatedAt { get; set; }

            [BsonElement("name")]
            public string? Name { get; set; }

            [BsonElement("creditsEndDate")]
            public DateTimeOffset? CreditsEndDate { get; set; }

            [BsonElement("creditsStartDate")]
            public DateTimeOffset? CreditsStartDate { get; set; }

            [BsonElement("isCreditsPermanent")]
            public bool? IsCreditsPermanent { get; set; }

            [BsonElement("location")]
            public string? Location { get; set; }

            [BsonElement("completedAt")]
            public string? CompletedAt { get; set; }

            [BsonElement("quizType")]
            public string? QuizType { get; set; }

            [BsonElement("stepperCountdown")]
            public StepperCountDown? StepperCountdown { get; set; }

        }

        public class CreditRate
        {
            [BsonElement("count")]
            public double? Count { get; set; }

            [BsonElement("percent")]
            public int? Percent { get; set; }

            [BsonElement("id")]
            public string? Id { get; set; }
        }

        public class DiscountRate
        {
            [BsonElement("newPrice")]
            public double? NewPrice { get; set; }

            [BsonElement("percent")]
            public double? Percent { get; set; }

            [BsonElement("amountTickets")]
            public int? AmountTickets { get; set; }
        }

        public class DiscountTicket
        {
            [BsonElement("newPrice")]
            public double? NewPrice { get; set; }

            [BsonElement("percent")]
            public double? Percent { get; set; }
        }

        public class StepperCountDown
        {
            [BsonElement("isActive")]
            public bool? IsActive { get; set; }

            [BsonElement("title")]
            public string? Title { get; set; }

            [BsonElement("startAt")]
            public DateTimeOffset? StartAt { get; set; }

            [BsonElement("endsAt")]
            public DateTimeOffset? EndsAt { get; set; }

        }

        public class FreeTicketsRates
        {
            [BsonElement("tickets")]
            public int? Tickets { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("isShow")]
            public bool? IsShow { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class Property
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId Id { get; set; }

            [BsonElement("badroomImage")]
            public string? BadroomImage { get; set; }

            [BsonElement("bathroomImage")]
            public string? BathroomImage { get; set; }

            [BsonElement("bathroomText")]
            public string? BathroomText { get; set; }

            [BsonElement("bedroomText")]
            public string? BedroomText { get; set; }

            [BsonElement("cardImage")]
            public string? CardImage { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("description")]
            public string? Description { get; set; }

            [BsonElement("floorPlanImage")]
            public string? FloorPlanImage { get; set; }

            [BsonElement("galleryImages")]
            public List<string>? GalleryImages { get; set; }

            [BsonElement("galleryImagesMobile")]
            public List<string>? GalleryImagesMobile { get; set; }

            //[BsonElement("generalText")]
            //public string? GeneralText { get; set; }

            [BsonElement("heading")]
            public string? Heading { get; set; }

            [BsonElement("latitude")]
            public double? Latitude { get; set; }

            [BsonElement("location")]
            public string? Location { get; set; }

            [BsonElement("locationMapImage")]
            public string? LocationMapImage { get; set; }

            [BsonElement("longitude")]
            public double? Longitude { get; set; }

            [BsonElement("outspaceImage")]
            public string? OutspaceImage { get; set; }

            [BsonElement("ooutspaceText")]
            public string? OoutspaceText { get; set; }

            [BsonElement("overview")]
            public List<Overview> Overview { get; set; }

            [BsonElement("pixangleSource")]
            public string? PixangleSource { get; set; }

            [BsonElement("tourLink")]
            public string? TourLink { get; set; }

            [BsonElement("updatedAt")]
            public DateTimeOffset? UpdatedAt { get; set; }

            [BsonElement("address")]
            public string? Address { get; set; }

            [BsonElement("area")]
            public string? Area { get; set; }

            [BsonElement("bedroomCount")]
            public dynamic? BedroomCount { get; set; }

            [BsonElement("bathroomCount")]
            public dynamic? BathroomCount { get; set; }

            [BsonElement("outspaceCount")]
            public dynamic? OutspaceCount { get; set; }

            [BsonElement("outspaceText")]
            public string? OutspaceText { get; set; }

            [BsonElement("floorPlanText")]
            public string? FloorPlanText { get; set; }

            [BsonElement("threeDTourText")]
            public string? ThreeDTourText { get; set; }

            [BsonElement("areaText")]
            public string? AreaText { get; set; }

            [BsonElement("transportText")]
            public string? TransportText { get; set; }

            [BsonElement("amenitiesText")]
            public string? AmenitiesText { get; set; }

            [BsonElement("metroStations")]
            public List<MetroStations>? MetroStations { get; set; }

            [BsonElement("adress")]
            public string? Adress { get; set; }

            [BsonElement("propertyPrice")]
            public dynamic? PropertyPrice { get; set; }

            [BsonElement("tax")]
            public dynamic? Tax { get; set; }

            [BsonElement("freehold")]
            public string? Freehold { get; set; }

            [BsonElement("garden")]
            public string? Garden { get; set; }

            [BsonElement("energy")]
            public string? Energy { get; set; }


            [BsonElement("GeneralText")]
            public string? GeneralText { get; set; }

        }

        public class Overview
        {
            [BsonElement("title")]
            public string? Title { get; set; }

            [BsonElement("value")]
            public string? Value { get; set; }

            [BsonElement("icon")]
            public string? Icon { get; set; }

        }

        public class MetroStations
        {
            [BsonElement("text")]
            public string? Text { get; set; }

            [BsonElement("title")]
            public string? Title { get; set; }
        }

        #endregion

        #region Competitions

        [BsonIgnoreExtraElements]
        public class Competitions
        {
            public class PrizesLF
            {
                [BsonElement("__v")]
                public int? V { get; set; }

                [BsonElement("_id")]
                public ObjectId Id { get; set; }

                [BsonElement("competitionId")]
                public string? CompetitionId { get; set; }

                [BsonElement("competitionType")]
                public string? CompetitionType { get; set; }

                [BsonElement("endsAt")]
                public DateTimeOffset EndsAt { get; set; }

                [BsonElement("fixedOdds")]
                public dynamic? FixedOdds { get; set; }

                [BsonElement("isActive")]
                public bool? IsActive { get; set; }

                [BsonElement("prizes")]
                public List<ObjectId>? Prizes { get; set; }

                [BsonElement("startAt")]
                public DateTimeOffset StartAt { get; set; }
            }

            public class Raffle
            {
                [BsonElement("_id")]
                public ObjectId Id { get; set; }

                [BsonElement("isActive")]
                public bool? IsActive { get; set; }

                [BsonElement("startAt")]
                public DateTime? StartAt { get; set; }

                [BsonElement("endsAt")]
                public DateTime? EndsAt { get; set; }

                [BsonElement("competitionType")]
                public string? CompetitionType { get; set; }

                [BsonElement("dreamHome")]
                public ObjectId? DreamHome { get; set; }

                [BsonElement("competitionId")]
                public string? CompetitionId { get; set; }

                [BsonElement("createdAt")]
                public DateTime? CreatedAt { get; set; }

                [BsonElement("updatedAt")]
                public DateTime? UpdatedAt { get; set; }

                [BsonElement("__v")]
                public int? V { get; set; }

                [BsonElement("fixedOdds")]
                public dynamic? FixedOdds { get; set; }

                [BsonElement("prizes")]
                public dynamic? Prizes { get; set; }
            }
        }

        [BsonIgnoreExtraElements]
        public class CompetitionsR
        {

            [BsonElement("_id")]
            public ObjectId Id { get; set; }

            [BsonElement("isActive")]
            public bool? IsActive { get; set; }

            [BsonElement("startAt")]
            public DateTime? StartAt { get; set; }

            [BsonElement("endsAt")]
            public DateTime? EndsAt { get; set; }

            [BsonElement("competitionType")]
            public string? CompetitionType { get; set; }

            [BsonElement("dreamHome")]
            public ObjectId DreamHome { get; set; }

            [BsonElement("competitionId")]
            public string? CompetitionId { get; set; }

            [BsonElement("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [BsonElement("updatedAt")]
            public DateTime? UpdatedAt { get; set; }

            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("fixedOdds")]
            public dynamic? FixedOdds { get; set; }

            [BsonElement("prizes")]
            public dynamic? Prizes { get; set; }
        }




        #endregion

        #region Subscriptions

        [BsonIgnoreExtraElements]
        public class Subscriptions
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("charity")]
            public string? Charity { get; set; }

            [BsonElement("checkoutId")]
            public string? CheckoutId { get; set; }

            [BsonElement("count")]
            public int? Count { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("purchaseDate")]
            public DateTimeOffset? PurchaseDate { get; set; }

            [BsonElement("refference")]
            public string? Refference { get; set; }

            [BsonElement("status")]
            public string? Status { get; set; }

            [BsonElement("totalCost")]
            public double? TotalCost { get; set; }

            [BsonElement("user")]
            public ObjectId? User { get; set; }

            [BsonElement("pausedAt")]
            public DateTime? PausedAt { get; set; }

            [BsonElement("pauseEnd")]
            public DateTime? PauseEnd { get; set; }

            [BsonElement("UpdatedAt")]
            public DateTimeOffset? UpdatedAt { get; set; }

            [BsonElement("cardSource")]
            public string? CardSource { get; set; }

            [BsonElement("nextPurchaseDate")]
            public DateTime? NextPurchaseDate { get; set; }

            [BsonElement("subscriptionModel")]
            public ObjectId SubscriptionModel { get; set; }

            [BsonElement("isReminderSent")]
            public bool IsReminderSent { get; set; }

            [BsonElement("emails")]
            public List<Emails>? Emails { get; set; }

            [BsonElement("raffle")]
            public ObjectId Raffle { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class SubscriptionsModels
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("totalCost")]
            public int? TotalCost { get; set; }

            [BsonElement("isActive")]
            public bool? IsActive { get; set; }

            [BsonElement("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

        }

        [BsonIgnoreExtraElements]
        public class SubscriptionsInsert
        {

            [BsonElement("charity")]
            public string? Charity { get; set; }

            [BsonElement("checkoutId")]
            public string? CheckoutId { get; set; }

            [BsonElement("count")]
            public int? Count { get; set; }

            [BsonElement("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("purchaseDate")]
            public DateTime? PurchaseDate { get; set; }

            [BsonElement("refference")]
            public string? Refference { get; set; }

            [BsonElement("status")]
            public string? Status { get; set; }

            [BsonElement("totalCost")]
            public double? TotalCost { get; set; }

            [BsonElement("user")]
            public ObjectId? User { get; set; }

            [BsonElement("pausedAt")]
            public DateTime? PausedAt { get; set; }

            [BsonElement("pauseEnd")]
            public DateTime? PauseEnd { get; set; }

            [BsonElement("UpdatedAt")]
            public DateTime? UpdatedAt { get; set; }

            [BsonElement("cardSource")]
            public string? CardSource { get; set; }

            [BsonElement("nextPurchaseDate")]
            public DateTime? NextPurchaseDate { get; set; }

            [BsonElement("subscriptionModel")]
            public ObjectId SubscriptionModel { get; set; }

            [BsonElement("isReminderSent")]
            public bool IsReminderSent { get; set; }

            [BsonElement("emails")]
            public List<string>? Emails { get; set; }

            [BsonElement("raffle")]
            public ObjectId Raffle { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class SubscriptionsActiveInsert
        {

            [BsonElement("charity")]
            public string? Charity { get; set; }

            [BsonElement("checkoutId")]
            public string? CheckoutId { get; set; }

            [BsonElement("count")]
            public int? Count { get; set; }

            [BsonElement("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("purchaseDate")]
            public DateTime? PurchaseDate { get; set; }

            [BsonElement("refference")]
            public string? Refference { get; set; }

            [BsonElement("status")]
            public string? Status { get; set; }

            [BsonElement("totalCost")]
            public double? TotalCost { get; set; }

            [BsonElement("user")]
            public ObjectId? User { get; set; }

            [BsonElement("updatedAt")]
            public DateTime? UpdatedAt { get; set; }

            [BsonElement("cardSource")]
            public string? CardSource { get; set; }

            [BsonElement("nextPurchaseDate")]
            public DateTime? NextPurchaseDate { get; set; }

            [BsonElement("subscriptionModel")]
            public ObjectId SubscriptionModel { get; set; }

            [BsonElement("isReminderSent")]
            public bool IsReminderSent { get; set; }

            [BsonElement("emails")]
            public List<string>? Emails { get; set; }

            [BsonElement("raffle")]
            public ObjectId Raffle { get; set; }
        }

        [BsonIgnoreExtraElements]
        public class Emails
        {
            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("type")]
            public string? Type { get; set; }

            [BsonElement("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [BsonElement("extra")]
            public int? Extra { get; set; }

            [BsonElement("totalCost")]
            public int? TotalCost { get; set; }

            [BsonElement("charity")]
            public string? Charity { get; set; }

            [BsonElement("raffle")]
            public ObjectId? Raffle { get; set; }


        }

        #endregion

        #region Orders

        [BsonIgnoreExtraElements]
        public class Orders
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("appliedCredits")]
            public List<AppliedCredits> AppliedCredits { get; set; }

            [BsonElement("checkoutId")]
            public string? CheckoutId { get; set; }

            [BsonElement("competitionId")]
            public ObjectId? CompetitionId { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("fixedOdds")]
            public ObjectId? FixedOdds { get; set; }

            [BsonElement("groupId")]
            public string? GroupId { get; set; }

            [BsonElement("isArchive")]
            public bool IsArchive { get; set; }

            [BsonElement("paymentStatus")]
            public string? PaymentStatus { get; set; }

            [BsonElement("selectedCharity")]
            public string? SelectedCharity { get; set; }

            [BsonElement("spentCredits")]
            public int? SpentCredits { get; set; }

            [BsonElement("tickets")]
            public List<Tickets> Tickets { get; set; }

            [BsonElement("totalCost")]
            public int? TotalCost { get; set; }

            [BsonElement("user")]
            public ObjectId? User { get; set; }

            [BsonElement("orderType")]
            public string? OrderType { get; set; }

            [BsonElement("raffle")]
            public ObjectId? Raffle { get; set; }

            [BsonElement("purchaseDate")]
            public DateTime? PurchaseDate { get; set; }
        }

        public class AppliedCredits
        {
            [BsonElement("creditId")]
            public ObjectId? CreditId { get; set; }

            [BsonElement("spentAmount")]
            public double? SpentAmount { get; set; }
        }

        public class Tickets
        {
            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("code")]
            public string? Code { get; set; }

            [BsonElement("bonus")]
            public bool? Bonus { get; set; }
        }

        #endregion

        #region ArchiveOrders

        [BsonIgnoreExtraElements]
        public class ArchiveOrders
        {
            [BsonElement("__v")]
            public int? V { get; set; }

            [BsonElement("_id")]
            public ObjectId? Id { get; set; }

            [BsonElement("appliedCredits")]
            public List<AppliedCredits> AppliedCredits { get; set; }

            [BsonElement("checkoutId")]
            public string? CheckoutId { get; set; }

            [BsonElement("competitionId")]
            public ObjectId? CompetitionId { get; set; }

            [BsonElement("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [BsonElement("fixedOdds")]
            public ObjectId? FixedOdds { get; set; }

            [BsonElement("groupId")]
            public string? GroupId { get; set; }

            [BsonElement("isArchive")]
            public bool IsArchive { get; set; }

            [BsonElement("paymentStatus")]
            public string? PaymentStatus { get; set; }

            [BsonElement("selectedCharity")]
            public string? SelectedCharity { get; set; }

            [BsonElement("spentCredits")]
            public int? SpentCredits { get; set; }

            [BsonElement("tickets")]
            public List<Tickets> Tickets { get; set; }

            [BsonElement("totalCost")]
            public int? TotalCost { get; set; }

            [BsonElement("user")]
            public ObjectId? User { get; set; }

            [BsonElement("orderType")]
            public string? OrderType { get; set; }

            [BsonElement("raffle")]
            public ObjectId? Raffle { get; set; }

            [BsonElement("purchaseDate")]
            public DateTime? PurchaseDate { get; set; }
        }

        #endregion
    }

    public class SubscriptionStatuses
    {
        public const string PAUSED = "PAUSED";
        public const string CANCELLED = "CANCELLED";
        public const string IN_PAYMENT_PROCESS = "IN_PAYMENT_PROCESS";
        public const string ACTIVE = "ACTIVE";
    }

    public class SubscriptionEmailsTemplate
    {
        public static string InitialUnauth(string name, int? quantity, double? value, string charity)
        {
            return $"<html><head><style>@media screen and (max-width: 480px) {{\n    .wrap-btn {{\n        text-align: center;\n    }}\n}}\n\n.im {{\n    color: #31323C !important;\n}}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi {name},</strong></p>\n<img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body><p style=\"color:#31323C;font:HK Grotesk;\">Welcome to the Raffle House subscription service. You're now doing good every single month! So sit back, and start dreaming big.\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p>\n<table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td>{quantity}</td></tr><tr><td style=\"font-weight:bold;\">Value</td><td>£{value}</td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td>{charity}</td></tr><tr><td></td><td></td></tr></table>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Activate account</button></a></div>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p></html>\n";
        }
        public static string InitialAuth(string name, int? quantity, double? value, string charity)
        {
            return $"<html><head><style>@media screen and (max-width: 480px) {{\n    .wrap-btn {{\n        text-align: center;\n    }}\n}}\n\n.im {{\n    color: #31323C !important;\n}}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi {name},</strong></p>\n<img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body><p style=\"color:#31323C;font:HK Grotesk;\">Welcome to the Raffle House subscription service. You're now doing good every single month! So sit back, and start dreaming big.\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p>\n<table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td>{quantity}</td></tr><tr><td style=\"font-weight:bold;\">Value</td><td>£{value}</td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td>{charity}</td></tr><tr><td></td><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p></html>\n";
        }
        public static string MonthlyAuth(string name, int? quantity, double? value, string charity)
        {
            return $"<html><head><style>@media screen and (max-width: 480px) {{\n    .wrap-btn {{\n        text-align: center;\n    }}\n}}\n\n.im {{\n    color: #31323C !important;\n}}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi {name},</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p><table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td>{quantity}</td></tr><tr><td style=\"font-weight:bold;\">Value</td><td>£{value}</td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td>{charity}</td></tr><tr><td></td><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        }
        public static string Pause(string name)
        {
            return $"<html><head><style>@media screen and (max-width: 480px) {{\n    .wrap-btn {{\n        text-align: center;\n    }}\n}}\n\n.im {{\n    color: #31323C !important;\n}}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi {name},</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">You have successfully paused your Raffle House subscription. Your subscription will automatically reactivate on the 1st of the next month, following a full month’s pause.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">All tickets credited before the pause are still active for all draws in the current competition cycle and are securely saved to your account. You can view your tickets and manage your subscription from your account. </p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">You can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        }
        public static string Unpause(string name, int? quantity, double? value, string charity)
        {
            return $"<html><head><style>@media screen and (max-width: 480px) {{\n    .wrap-btn {{\n        text-align: center;\n    }}\n}}\n\n.im {{\n    color: #31323C !important;\n}}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi {name},</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription has been reactivated following your pause!</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p><table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td>{quantity}</td></tr><tr><td style=\"font-weight:bold;\">Value</td><td>£{value}</td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td>{charity}</td></tr><tr><td></td><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><p style=\"color:#31323C;font:HK Grotesk;\">You can manage your subscription and view your active tickets in your account at any time!</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        }
        public static string Cancel(string name)
        {
            return $"<html><head><style>@media screen and (max-width: 480px) {{\n    .wrap-btn {{\n        text-align: center;\n    }}\n}}\n\n.im {{\n    color: #31323C !important;\n}}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi {name},</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">You have successfully cancelled your Raffle House subscription. Any tickets that you had prior to the cancellation will remain active for any upcoming draw in the current competition cycle.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you want to renew your subscription or view your active tickets, head to your account at any time.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">If you want to increase your chances to win, just hit the button below to buy more tickets.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        }
        public static string SevenDaysBeforeUnpause(string name)
        {
            return $"<html><head><style>@media screen and (max-width: 480px) {{\n    .wrap-btn {{\n        text-align: center;\n    }}\n}}\n\n.im {{\n    color: #31323C !important;\n}}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi {name},</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription will automatically reactivate in 7 days, on the 1st of the next month, following your full month’s pause. You do not need to take any action to start dreaming big and doing good once more!</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">All tickets credited before the pause are still active for all draws in the current competition cycle and are securely saved to your account, as will all future tickets yet to be awarded. You can view your tickets and manage your subscription from your account. </p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">You can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        }
        public static string PurchaseFailed(string name)
        {
            return $"<html><head><style>@media screen and (max-width: 480px) {{\n    .wrap-btn {{\n        text-align: center;\n    }}\n}}\n\n.im {{\n    color: #31323C !important;\n}}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi {name},</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription payment has failed. This may be due to insufficient funds or your card’s expiry date. As a result, your tickets for this month have not been credited and your subscription has been cancelled.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you wish to purchase tickets this month, you can do so manually.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you wish to continue to benefit from a Raffle House subscription, you’ll need to purchase a new one.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;margin-bottom:20px;height:auto;border:none;\">Purchase a Subscription</button>\n</a></div><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a></div>\n<p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        }

        //public const string INITIAL_UNAUTH = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body><p style=\"color:#31323C;font:HK Grotesk;\">Welcome to the Raffle House subscription service. You're now doing good every single month! So sit back, and start dreaming big.\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p>\n<table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td></td></tr><tr><td style=\"font-weight:bold;\">Value</td><td></td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td></td></tr><tr><td></td></tr></table>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Activate account</button></a></div>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p></html>\n";
        //public const string INITIAL_AUTH = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body><p style=\"color:#31323C;font:HK Grotesk;\">Welcome to the Raffle House subscription service. You're now doing good every single month! So sit back, and start dreaming big.\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p>\n<table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td></td></tr><tr><td style=\"font-weight:bold;\">Value</td><td></td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td></td></tr><tr><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p></html>\n";
        //public const string MONTHLY_AUTH = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p><table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td></td></tr><tr><td style=\"font-weight:bold;\">Value</td><td></td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td></td></tr><tr><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">View tickets</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        //public const string PAUSE = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">You have successfully paused your Raffle House subscription. Your subscription will automatically reactivate on the 1st of the next month, following a full month’s pause.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">All tickets credited before the pause are still active for all draws in the current competition cycle and are securely saved to your account. You can view your tickets and manage your subscription from your account. </p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">You can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        //public const string UNPAUSE = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription has been reactivated following your pause!</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Please see your Raffle House subscription receipt below. You will next be billed and issued tickets on the 1st of every month. You’ll also receive confirmation of your new tickets then.</p><table style=\"color:#31323C;border-spacing:10px;\"><tr><td style=\"font-weight:bold;\">Ticket Quantity</td><td></td></tr><tr><td style=\"font-weight:bold;\">Value</td><td></td></tr><tr><td style=\"font-weight:bold;\">Charitable Donation</td><td></td></tr><tr><td></td></tr></table>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your tickets have been securely saved to your account</p><p style=\"color:#31323C;font:HK Grotesk;\">You can manage your subscription and view your active tickets in your account at any time!</p><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">As a subscriber, you can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        //public const string CANCEL = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">You have successfully cancelled your Raffle House subscription. Any tickets that you had prior to the cancellation will remain active for any upcoming draw in the current competition cycle.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you want to renew your subscription or view your active tickets, head to your account at any time.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">If you want to increase your chances to win, just hit the button below to buy more tickets.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        //public const string SEVEN_DAYS_BEFORE_UNPAUSE = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription will automatically reactivate in 7 days, on the 1st of the next month, following your full month’s pause. You do not need to take any action to start dreaming big and doing good once more!</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">All tickets credited before the pause are still active for all draws in the current competition cycle and are securely saved to your account, as will all future tickets yet to be awarded. You can view your tickets and manage your subscription from your account. </p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">My Account</button></a></div><p style=\"color:#31323C;font:HK Grotesk;\">You can still buy one-off bundles if you want to increase your chances to win. If you want to buy more tickets, just hit the button below.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a>\n</div><p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
        //public const string PURCHASE_FAILED = "<html><head><style>@media screen and (max-width: 480px) {\n    .wrap-btn {\n        text-align: center;\n    }\n}\n\n.im {\n    color: #31323C !important;\n}</style></head><body style=\"color:#31323C;font:HK Grotesk;\"><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>Hi \"Name\",</strong></p>\n<p style=\"color:#31323C;font:HK Grotesk;\">Your Raffle House subscription payment has failed. This may be due to insufficient funds or your card’s expiry date. As a result, your tickets for this month have not been credited and your subscription has been cancelled.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you wish to purchase tickets this month, you can do so manually.</p>\n<p style=\"color:#31323C;font:HK Grotesk;\">If you wish to continue to benefit from a Raffle House subscription, you’ll need to purchase a new one.</p>\n<div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;margin-bottom:20px;height:auto;border:none;\">Purchase a Subscription</button>\n</a></div><div class=\"wrap-btn\"><a href=\"link with token\"><button type=\"button\" style=\"color:white;background:#f48202;border-radius:10px;padding:5px 25px;width:184px;height:36px;border:none;\">Buy more tickets</button></a></div>\n<p style=\"color:#31323C;font:HK Grotesk;\">Good luck!</p><p style=\"color:#31323C;font:HK Grotesk;font-size:15px;\"><strong>RAFFLE HOUSE</strong></p><p style=\"color:#31323C;font:HK Grotesk;\">You can view our subscription<a href=\"link with token\"> T&Cs here.</a></p><img width=\"1px\" height=\"1px\" alt=\"\" src=\"link with token\"></body></html>\n";
    }

    public class SubscriptionsCardDetails
    {
        public static readonly List<string> CHECKOUT_ID = new List<string>
        {
            "pay_es22m5rqbad2fcdmqzu662tjs4",
            "pay_aaktyrmqggzklkxi4qnur7jkb4",
            "pay_cb4bvpbepjn2hccwhywi6gfcge",
            "pay_nypnbbwcr272njdn64f2vz5y6a",
            "pay_zoauvhsyf7g27pqkx6csrbwjiy",
            "pay_5xamkreqnwrkfeuvv4zjz7bkou",
            "pay_gxrqpmxhvte2hawpgbtovjobia",
            "pay_fhvkjvaixtn2rof7vi4z6h7vde",
            "pay_2h6il5eqe5mkjfoowxe4er6hfa",
            "pay_k4jv56ptcd425iwvohftmttn6u",
            "pay_ocx44gdai6d2dp7lkzb4jv3qgy"

        };
        public static readonly List<string> REFFERENCE = new List<string>()
        {
              "ae00ad26-f68e-4a46-8a7a-c25ac9996323",
              "121c887f-7165-4e78-9014-e44e4747aaf3",
              "9283fa3a-31be-4093-8a50-554350555a83",
              "99536535-d22a-4635-bd58-bdb22e664cae",
              "22b64379-1115-4dea-b172-625839efda4d",
              "b26545c3-d598-4c43-ba3a-db997e2e9b7b",
              "c21346a1-4e08-454f-9322-c372b175a91a",
              "ee45c42a-7660-4220-a867-2ea2ee02c408",
              "0304abed-0a4e-4a10-859a-0cb2e50bd14f",
              "b785b852-f101-4e73-9e71-3515687506e0",
              "2e93be22-71e5-4675-842e-671f3f7e62db"
        };
        public static readonly List<string> CARD_SOURCE = new List<string>()
        {
            "src_coanebipcc3vuca37p7e4lw7tu",
            "src_oxc6nndbqfxfmcepog7unzj244",
            "src_g3mzrzdzserfych2jdvbhwrkoi",
            "src_kecpx6dydmrfqcfn37hdsgnzue",
            "src_j4myhz44vvkvgcb45d2k3so6ca",
            "src_pfu6iu2llwbfocbcrwrhm66k6m",
            "src_qzxgozn72hlvucbdaejox2qwpa",
            "src_5z6nrihqalof6cbawhmuen5qea",
            "src_nzkvxi7oywyfycc7jegmas55ma",
            "src_imdxoy5nhrrfocajkueikmwm5i",
            "src_dfxpo5lo4dpfucfkkwmkbqhvj4"
        };
    }

    public class Charities
    {
        public static readonly List<string> CHARITY = new()
        {
            "No charity selected",
            "British Heart Foundation",
            "Marie Curie",
            "St. John Ambulance",
            "Alzheimer's Research UK",
            "Alzheimer's Society",
            "British Red Cross",
            "WWF",
            "Duke of Edinburgh Awards",
            "The Flying Seagull Project",
            "Save the Children",
            "National Trust",
            "Royal British Legion",
            "Dementia UK",
            "NSPCC",
            "Prostate Cancer UK",
            "Keep Britain Tidy",
            "Children in Need",
            "Parkinson's UK",
            "Barnardo's",
            "War Paws"

        };
    }

    public class Errors
    {
        public class ErrorTotalCost
        {
            public const int ERROR_BAD_TRACK_DATA = 154;
            public const int ERROR_SECURITY_VIOLATION = 163;
            public const int ERROR_INVALID_TRANSACTION = 12;
            public const int ERROR_RESTRICTED_CARD = 62;
            public const int ERROR_INSUFIENT_FUNDS = 151;
        }

        public class ErrorMessages
        {
            public const string BAD_TRACK_DATA = "Bad Track Data (invalid CVV and/or expiry date)";
            public const string INSUFFICIENT_FUNDS = "Insufficient Funds";
            public const string INVALID_TRANSACTION = "Invalid Transaction";
            public const string RESTRICTED_CARD = "Restricted Card";
            public const string SECURITY_VIOLATION = "Security Violation";
        }
    }


    public class PutsboxEmail
    {
        public string? id { get; set; }
        public string? headers { get; set; }
        public string? from_email { get; set; }
        public string? from_name { get; set; }
        public List<string> to { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? text { get; set; }
        public string? html { get; set; }
        public object attachments { get; set; }
        public string? created_at { get; set; }

    }

    public class WebMOdels
    {
        public class Profile
        {
            public class OrderHistory
            {
                public string? PRIZE { get; set; }
                public string? PURCHASE_DATE { get; set; }
                public int NUM_TICKETS { get; set; }
                public int PRICE { get; set; }
            }
        }

        public class Basket
        {
            public class Order
            {
                public string? PRIZE { get; set; }
                public int NUM_TICKETS { get; set; }
                public double PRICE { get; set; }
            }
        }
    }


}
