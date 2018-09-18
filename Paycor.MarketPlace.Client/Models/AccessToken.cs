using Newtonsoft.Json;
using System;

namespace Paycor.MarketPlace.ApiClient.Models
{
    public class AccessToken
    {
        [JsonProperty(PropertyName ="access_token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime Expires { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
    }
}
