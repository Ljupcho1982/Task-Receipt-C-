using Newtonsoft.Json;

namespace Receipt
{
    public class Root
    {

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("domestic")]
        public bool domestic { get; set; }

        [JsonProperty("price")]
        public double price { get; set; }

        [JsonProperty("weight")]
        public int weight { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

    }
}
