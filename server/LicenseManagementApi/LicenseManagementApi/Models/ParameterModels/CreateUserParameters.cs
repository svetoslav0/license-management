namespace LicenseManagementApi.Models.ParameterModels
{
    using Newtonsoft.Json;

    public class CreateUserParameters
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public void Validate()
        {
            this.ValidateUsername();
            this.ValidateName();
        }

        private void ValidateUsername()
        {
            if (string.IsNullOrEmpty(this.Username))
            {
                throw new BadHttpRequestException("username is required");
            }
        }

        private void ValidateName()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new BadHttpRequestException("name is required");
            }
        }
    }
}
