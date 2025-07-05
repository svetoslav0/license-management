namespace LicenseManagementApi.Database.EF.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("subscription")]
    public class Subscription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("switched_at")]
        public DateTime SwitchedAt { get; set; } = DateTime.UtcNow;

        [Column("plan_id")]
        public int PlanId { get; set; }

        public SubscriptionPlan Plan { get; set; }
    }
}
