using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.ApplicationCore.Entities;

public class Customer
{
    [Key] public int Id { get; set; }

    [Required] public int UserId { get; set; }

    [Required] [StringLength(100)] public string FullName { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    // Navigation property
    public  User User { get; set; }
}