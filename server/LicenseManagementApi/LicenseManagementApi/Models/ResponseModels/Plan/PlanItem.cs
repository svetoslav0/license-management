namespace LicenseManagementApi.Models.ResponseModels.Plan
{
    using Newtonsoft.Json;

    public class PlanItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("seatLimit")]
        public int SeatLimit { get; set; }
    }
}
