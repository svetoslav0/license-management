namespace LicenseManagementApi.Models.ResponseModels.User
{
    using Newtonsoft.Json;

    public class UserResponseData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("users")]
        public List<UserResponseItem> Users { get; set; }
    }
}
