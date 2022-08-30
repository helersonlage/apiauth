using Newtonsoft.Json;

namespace apiauth.Models
{
    public class UserLogin
    {
        [JsonProperty("username")]
        public string? UserName { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}
