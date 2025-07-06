namespace LicenseManagementApi.Models.ResponseModels.User
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class UserResponseData
    {
        [Required]
        [JsonProperty("count")]
        public int Count { get; set; }

        [Required]
        [JsonProperty("users")]
        public List<UserResponseItem> Users { get; set; }
    }
}
