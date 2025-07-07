namespace LicenseManagementApi.Database.EF.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("user")]
    public class User
    {
        public User(string email, string name)
        {
            this.Email = email;
            this.Name = name;
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("has_license")]
        public bool HasLicense { get; set; } = false;
    }
}
