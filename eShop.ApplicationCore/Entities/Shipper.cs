using System.ComponentModel.DataAnnotations;

namespace eShop.ApplicationCore.Entities;

public class Shipper
{
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; }

    public string ContactNumber { get; set; }
}