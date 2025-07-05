namespace LicenseManagementApi.Models.ResponseModels.User
{
    using Newtonsoft.Json;

    public class UserResponseItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("hasLicense")]
        public bool HasLicense { get; set; }
    }
}
