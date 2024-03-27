using System.ComponentModel.DataAnnotations;

namespace eShop.ApplicationCore.Entities;

public class User
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(50)] public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    public bool IsAdmin { get; set; }
}