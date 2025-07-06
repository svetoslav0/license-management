namespace LicenseManagementApi.Models.ResponseModels
{
    using Newtonsoft.Json;

    public class ResponseMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
