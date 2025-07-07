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
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("hasLicense")]
        public bool HasLicense { get; set; }
    }
}
