using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.ApplicationCore.Entities;

public class OrderDetail
{
    [Key] public int Id { get; set; }

    [Required] public int OrderId { get; set; }

    [Required] public int ProductId { get; set; }

    [Required] public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    // Navigation properties
    public  Order Order { get; set; }
    public  Product Product { get; set; }
}