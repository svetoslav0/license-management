namespace LicenseManagementApi.Models.ResponseModels.Plan
{
    using Newtonsoft.Json;

    using System.ComponentModel.DataAnnotations;

    public class PlanItem
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("seatLimit")]
        public int SeatLimit { get; set; }
    }
}
