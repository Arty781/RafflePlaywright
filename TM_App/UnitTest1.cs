using Chilkat;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using PlaywrightRaffle.Helpers;
using PlaywrightRaffle.PageObjects;

namespace TM_App
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Client")]
    [AllureTag("Regression"), AllureOwner("Artem Sukharevskyi"), AllureSeverity(Allure.Net.Commons.SeverityLevel.critical), AllureSubSuite("TMApp")]
    public class SubscriptionsCommon : Base
    {
        [Test, Category("Authorized"), Author("Artem", "qatester91311@gmail.com")]
        //[Repeat(2)]
        public async System.Threading.Tasks.Task EditMembership()
        {
            List<string> membershipIds =
            [
                "342AFE65-4683-49A4-B1F2-D0FDCBD27073",
                "25FE3DB7-4C0A-41D6-96AD-9AD63BF53C55",
                "7116A91C-0D8A-4126-BD58-A7314EE41C0B",
                "3654EA89-7ACB-4E13-9BF2-56B0A16321FE",
                "1D6527BF-3F38-4F93-ADC4-1B637955CEF3",
                "00DAC0CD-EED5-4D51-83C2-3B20A9B622F8",
                "42DEFD99-4146-426E-8A70-A72EC7180E09",
                "BED4E0EA-0AA6-4270-9FF8-2ABB735AB2AB",
                "8F767421-AA8D-4A3E-A1EC-8D61257392D4",
                "4A2E4CF0-DCEF-42DB-A1B6-DC33BBD70985",
                "DC2F6267-53A0-4AB2-8C61-8E3436C16D87",
                "EAAF5F93-BE2E-49FE-8DB0-68DB7563077F",
                "69E6593F-27D7-406A-AA43-2EA9DCF5389E",
                "4A9058B4-64ED-4C7F-BE5E-8A59190DDB66",
                "38224981-BE8E-459B-BB52-1F4BA6B4A34A",
                "6893BB26-6BA8-4F5F-9E3F-EF2688DC2617",
                "59699797-689A-4198-BD3B-8D8967A9224A"
            ];

            List<string> imagePaths =
            [
                @"E:\Users\sucha\Downloads\01_01_Building The Bikini Body Home Part 1.png",
                @"E:\Users\sucha\Downloads\01_Your Glute Coach Part 3.png",
                @"E:\Users\sucha\Downloads\1_01_Building The Bikini Body Part 1.png",
                @"E:\Users\sucha\Downloads\2_01_Building The Bikini Body Part 2.png",
                @"E:\Users\sucha\Downloads\3_01_Building The Bikini Body Part 3.png",
                @"E:\Users\sucha\Downloads\4_01_Building The Bikini Body Part 4.png",
                @"E:\Users\sucha\Downloads\5_01_Home Training.png",
                @"E:\Users\sucha\Downloads\6_01_Postpartum Phase 1.png",
                @"E:\Users\sucha\Downloads\7_01_Postpartum Phase 2.png",
                @"E:\Users\sucha\Downloads\8_01_Pregnancy Program.png",
                @"E:\Users\sucha\Downloads\9_01_strong.png",
                @"E:\Users\sucha\Downloads\91_01_The Art of ‘Gen Pop‘ Transformations - Female.png",
                @"E:\Users\sucha\Downloads\92_01_The Art of ‘Gen Pop‘ Transformations - Male.png",
                @"E:\Users\sucha\Downloads\93_01_The Art of Reverse Dieting.png",
                @"E:\Users\sucha\Downloads\94_01_The Male Method Part 1.png",
                @"E:\Users\sucha\Downloads\95_01_The Male Method Part 2.png",
                @"E:\Users\sucha\Downloads\96_01_Your Glute Coach Part 1.png",
                @"E:\Users\sucha\Downloads\97_01_Your Glute Coach Part 2.png",
            ];

            await TMApp.OpenLogin();
            await TMApp.EnterLoginAndPassword("admin@coachmarkcarroll.com", "Qwerty123!");
            await TMApp.ClickSignInBtn();
            for(int i = 0; i < membershipIds.Count; i++) 
            {
                await TMApp.OpenMembershipEditing(membershipIds[i]);
                //await TMApp.UploadImages(imagePaths[i]);
                await TMApp.ClickSaveButton();
            }
        }
    }
}