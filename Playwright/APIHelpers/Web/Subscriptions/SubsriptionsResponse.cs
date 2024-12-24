namespace PlaywrightRaffle.APIHelpers.Web.Subscriptions
{
    public class SubsriptionsResponse
    {

        public partial class EmailsList
        {
            [JsonProperty("event")]
            public string? Event { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public partial class Data
        {
            [JsonProperty("emails_count")]
            public long EmailsCount { get; set; }

            [JsonProperty("emails")]
            public List<Email>? Emails { get; set; }
        }

        public class Email
        {
            public string? id { get; set; }
            public string? from_email { get; set; }
            public string? from_name { get; set; }
            public List<string>? to { get; set; }
            public string? email { get; set; }
            public string? subject { get; set; }
            public DateTime? created_at { get; set; }
        }


        public class Subscriptions
        {
            [JsonProperty("subscriptionModels")]
            public List<Subscriptionmodel> SubscriptionModels { get; set; }
        }

        public class Subscriptionmodel
        {
            [JsonProperty("totalCost")]
            public int TotalCost { get; set; }
            [JsonProperty("isBonusActive")]
            public bool IsBonusActive { get; set; }
            [JsonProperty("bonusTickets")]
            public int BonusTickets { get; set; }
            [JsonProperty("bonusPeriod")]
            public int BonusPeriod { get; set; }
            [JsonProperty("isActive")]
            public bool IsActive { get; set; }
            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }
            [JsonProperty("_id")]
            public string Id { get; set; }
            [JsonProperty("numOfTickets")]
            public int NumOfTickets { get; set; }
            [JsonProperty("extra")]
            public int Extra { get; set; }
            [JsonProperty("__v")]
            public int V { get; set; }
            [JsonProperty("months")]
            public List<Months> Months { get; set; }
        }

        public class Months
        {
            [JsonProperty("_id")]
            public string Id { get; set; }
            [JsonProperty("month")]
            public int Month { get; set; }
            [JsonProperty("discount")]
            public float Discount { get; set; }
            [JsonProperty("discountActive")]
            public bool DiscountActive { get; set; }
            [JsonProperty("active")]
            public bool Active { get; set; }
            [JsonProperty("discountString")]
            public string DiscountString { get; set; }
        }


        public class SubscriptionsReq
        {
            public Subscription subscription { get; set; }
        }

        public class Subscription
        {
            public string charity { get; set; }
            public int totalCost { get; set; }
            public int numOfTickets { get; set; }
            public int extra { get; set; }
            public string subscriptionModel { get; set; }
            public int count { get; set; }
            public string status { get; set; }
            public string raffle { get; set; }
            public int months { get; set; }
        }


        public class ReqResp
        {
            public string message { get; set; }
            public SubscriptionReqResp subscription { get; set; }
            public Subscriptionmodel subscriptionModel { get; set; }
        }

        public class SubscriptionReqResp
        {
            public int months { get; set; }
            public int monthsTicketsStep { get; set; }
            public string status { get; set; }
            public int count { get; set; }
            public string charity { get; set; }
            public bool isReminderSent { get; set; }
            public DateTime createdAt { get; set; }
            public string _id { get; set; }
            public int totalCost { get; set; }
            public int numOfTickets { get; set; }
            public int extra { get; set; }
            public string subscriptionModel { get; set; }
            public string raffle { get; set; }
            public object[] emails { get; set; }
            public string user { get; set; }
            public int __v { get; set; }
        }



    }
}
