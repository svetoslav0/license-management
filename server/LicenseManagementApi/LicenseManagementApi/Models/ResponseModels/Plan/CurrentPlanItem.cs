namespace LicenseManagementApi.Models.ResponseModels.Plan
{
    using Newtonsoft.Json;

    using System.ComponentModel.DataAnnotations;

    public class CurrentPlanItem
    {
        [Required]
        [JsonProperty("planName")]
        public string PlanName { get; set; }

        [Required]
        [JsonProperty("seatLimit")]
        public int SeatLimit { get; set; }

        [Required]
        [JsonProperty("switchedAt")]
        public DateTime SwitchedAt { get; set; }

        [Required]
        [JsonProperty("currentLicensesCount")]
        public int CurrentLicensesCount { get; set; }
    }
}
