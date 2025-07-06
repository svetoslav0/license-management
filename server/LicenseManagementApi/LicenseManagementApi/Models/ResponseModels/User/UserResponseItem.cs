namespace LicenseManagementApi.Models.ResponseModels.User
{
    using Newtonsoft.Json;

    using System.ComponentModel.DataAnnotations;

    public class UserResponseItem
    {
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("hasLicense")]
        public bool HasLicense { get; set; }
    }
}
