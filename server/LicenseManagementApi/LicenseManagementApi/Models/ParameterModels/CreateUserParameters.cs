namespace LicenseManagementApi.Models.ParameterModels
{
    using Newtonsoft.Json;

    using System.ComponentModel.DataAnnotations;

    public class CreateUserParameters
    {
        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
