namespace LicenseManagementApi.Models.ParameterModels
{
    using Newtonsoft.Json;

    public class CreateUserParameters
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
