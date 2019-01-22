using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Entities
{
    [Table("users")]
    public class User
    {
//        [Required] [Column("id")] [Key] public int UserId { get; set; }
        [Required] [Key] public int Id { get; set; }
        [Required] [StringLength(50)] public string Email { get; set; }
        [Required] [StringLength(50)] public string Password { get; set; }
        [Required] [StringLength(50)] public string Role { get; set; }
//        [Column("last_login_date")][Required] [StringLength(50)] public string LastLoginDate { get; set; }
        [StringLength(50)] public string Token { get; set; }
    }
}