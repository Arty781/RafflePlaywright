using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlaywrightRaffle.APIHelpers.Web.PollHome
{
    public partial class PollHome
    {
        public class PollRequest
        {
            [JsonPropertyName("data")]
            public Data data { get; set; }

            [JsonPropertyName("values")]
            public string values { get; set; }
        }

        public class Data
        {
            [JsonPropertyName("value")]
            public string value { get; set; }
        }

        public partial class PollResponse
        {
            [JsonPropertyName("home")]
            public long Home { get; set; }

            [JsonPropertyName("travel")]
            public long Travel { get; set; }

            [JsonPropertyName("share")]
            public long Share { get; set; }
        }
    }
}
