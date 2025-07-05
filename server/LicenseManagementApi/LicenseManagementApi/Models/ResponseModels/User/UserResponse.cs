namespace LicenseManagementApi.Models.ResponseModels.User
{
    using Newtonsoft.Json;

    public class UserResponse
    {
        [JsonProperty("data")]
        public UserResponseData Data { get; set; }
    }
}
