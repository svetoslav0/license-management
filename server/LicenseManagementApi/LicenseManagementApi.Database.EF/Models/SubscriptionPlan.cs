namespace LicenseManagementApi.Database.EF.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("plan")]
    public class SubscriptionPlan
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("limit")]
        public int SeatLimit { get; set; }
    }
}
