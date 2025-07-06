namespace LicenseManagementApi.Models.ResponseModels.User
{
    using Newtonsoft.Json;

    using System.ComponentModel.DataAnnotations;

    public class UserResponse
    {
        [Required]
        [JsonProperty("data")]
        public UserResponseData Data { get; set; }
    }
}
