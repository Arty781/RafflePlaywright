namespace PlaywrightRaffle.APIHelpers.Web
{
    #region Dreamhome
    public partial class HomeDataRequestWeb
    {
        public partial class HomeData
        {
            [JsonProperty("home")]
            public Home? Home { get; set; }

            [JsonProperty("countdowns")]
            public List<Countdown>? Countdowns { get; set; }
        }

        public partial class Countdown
        {
            [JsonProperty("_id")]
            public string? Id { get; set; }

            [JsonProperty("stepperCountdown")]
            public StepperCountdown? StepperCountdown { get; set; }

            [JsonProperty("endsAt")]
            public DateTimeOffset? EndsAt { get; set; }

            [JsonProperty("property")]
            public Property? Property { get; set; }

            [JsonProperty("title")]
            public string? Title { get; set; }
        }

        public partial class Property
        {
            [JsonProperty("_id")]
            public string? Id { get; set; }

            [JsonProperty("galleryImages")]
            public string[]? GalleryImages { get; set; }

            [JsonProperty("galleryImagesMobile")]
            public string[]? GalleryImagesMobile { get; set; }

            [JsonProperty("floorPlanImage")]
            public string? FloorPlanImage { get; set; }

            [JsonProperty("locationMapImage")]
            public string? LocationMapImage { get; set; }

            [JsonProperty("cardImage")]
            public string? CardImage { get; set; }

            [JsonProperty("mobileCardImage")]
            public string? MobileCardImage { get; set; }
        }

        public partial class StepperCountdown
        {
            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("title")]
            public string? Title { get; set; }

            [JsonProperty("startAt")]
            public DateTimeOffset? StartAt { get; set; }

            [JsonProperty("endsAt")]
            public DateTimeOffset? EndsAt { get; set; }
        }

        public partial class Home
        {
            [JsonProperty("prizeCountdown")]
            public DateTimeOffset? PrizeCountdown { get; set; }

            [JsonProperty("winners")]
            public List<Winner>? Winners { get; set; }

            [JsonProperty("featured")]
            public List<object>? Featured { get; set; }

            [JsonProperty("popular")]
            public List<Popular>? Popular { get; set; }

            [JsonProperty("statistic")]
            public Statistic? Statistic { get; set; }
        }

        public partial class Popular
        {
            [JsonProperty("_id")]
            public string? Id { get; set; }

            [JsonProperty("prizeId")]
            public string? PrizeId { get; set; }

            [JsonProperty("description")]
            public string? Description { get; set; }

            [JsonProperty("title")]
            public string? Title { get; set; }

            [JsonProperty("competitionType")]
            public string? CompetitionType { get; set; }

            [JsonProperty("totalSpent")]
            public long? TotalSpent { get; set; }

            [JsonProperty("isActiveDiscount")]
            public bool? IsActiveDiscount { get; set; }

            [JsonProperty("discountTicket")]
            public DiscountTicket? DiscountTicket { get; set; }

            [JsonProperty("ticketPrice")]
            public double? TicketPrice { get; set; }

            [JsonProperty("photoUrlKey")]
            public string? PhotoUrlKey { get; set; }
        }

        public partial class DiscountTicket
        {
            [JsonProperty("percent")]
            public long? Percent { get; set; }

            [JsonProperty("newPrice")]
            public double? NewPrice { get; set; }
        }

        public partial class Statistic
        {
            [JsonProperty("totalWon")]
            public string? TotalWon { get; set; }

            [JsonProperty("previousWinner")]
            public long? PreviousWinner { get; set; }

            [JsonProperty("charitableDonation")]
            public string? CharitableDonation { get; set; }

            [JsonProperty("charity")]
            public string? Charity { get; set; }

            [JsonProperty("appDownload")]
            public long? AppDownload { get; set; }
        }

        public partial class Winner
        {
            [JsonProperty("_id")]
            public string? Id { get; set; }

            [JsonProperty("name")]
            public string? Name { get; set; }

            [JsonProperty("description")]
            public string? Description { get; set; }

            [JsonProperty("drawDate")]
            public DateTimeOffset? DrawDate { get; set; }

            [JsonProperty("photoUrl")]
            public Guid? PhotoUrl { get; set; }

            [JsonProperty("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTimeOffset? UpdatedAt { get; set; }

            [JsonProperty("__v")]
            public long? V { get; set; }

            [JsonProperty("videoUrl", NullValueHandling = NullValueHandling.Ignore)]
            public Uri? VideoUrl { get; set; }
        }
    }

    #endregion


}
