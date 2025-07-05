namespace LicenseManagementApi.Database.EF.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("user")]
    public class User
    {
        public User(string username, string name)
        {
            this.Username = username;
            this.Name = name;
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        // TODO: Must replace `username` to `email` to satisfy the requirements!!!
        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("has_license")]
        public bool HasLicense { get; set; } = false;
    }
}
