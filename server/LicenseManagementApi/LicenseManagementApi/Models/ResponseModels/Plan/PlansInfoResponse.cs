namespace LicenseManagementApi.Models.ResponseModels.Plan
{
    using Newtonsoft.Json;

    using System.ComponentModel.DataAnnotations;

    public class PlansInfoResponse
    {
        [Required]
        [JsonProperty("currentPlan")]
        public CurrentPlanItem CurrentPlan { get; set; } = new CurrentPlanItem();

        [Required]
        [JsonProperty("plans")]
        public List<PlanItem> Plans { get; set; } = new List<PlanItem>();
    }
}
