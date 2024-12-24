namespace PlaywrightRaffle.APIHelpers.Web
{

    public class DreamHomeOrderRequestModel
    {
        [JsonProperty("numOfTickets")]
        public string? NumOfTickets { get; set; }

        [JsonProperty("prizeType")]
        public string? PrizeType { get; set; }

        [JsonProperty("prizeId")]
        public string? PrizeId { get; set; }
    }

    public class GeneratedSubscriptions
    {
        public List<Subscription> Subscriptions { get; private set; } = new();

        public GeneratedSubscriptions()
        {
            Subscriptions.Add(new Subscription
            {
                charity = "",
                totalCost = 3000,
                numOfTickets = 15,
                extra = 165,
                subscriptionModel = "667946903b19fe0033a827d2",
                count = 0,
                status = "PENDING_BASKET",
                raffle = "66ffa2e08cacb0003d92eaf4",
                months = 1
            });
            Subscriptions.Add(new Subscription
            {
                charity = "",
                totalCost = 3000,
                numOfTickets = 15,
                extra = 165,
                subscriptionModel = "667946903b19fe0033a827d2",
                count = 0,
                status = "PENDING_BASKET",
                raffle = "66ffa2e08cacb0003d92eaf4",
                months = 1
            });
        }
    }

    public class SubscriptionRequestModel
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


    public class DreamHomeOrderResponseModelWeb
    {

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("orderId")]
        public string? OrderId { get; set; }
    }
}

