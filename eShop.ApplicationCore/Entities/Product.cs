using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.ApplicationCore.Entities;

public class Product
{
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    [Required] public int StockQuantity { get; set; }

    // Navigation property
    public Category Category { get; set; }
}