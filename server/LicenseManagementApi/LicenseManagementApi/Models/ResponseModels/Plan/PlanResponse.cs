namespace LicenseManagementApi.Models.ResponseModels.Plan
{
    using Newtonsoft.Json;

    public class PlanResponse
    {
        [JsonProperty("planName")]
        public string PlanName { get; set; }

        [JsonProperty("seatLimit")]
        public int SeatLimit { get; set; }

        [JsonProperty("switchedAt")]
        public DateTime SwitchedAt { get; set; }

        [JsonProperty("currentLicensesCount")]
        public int CurrentLicensesCount { get; set; }
    }
}
