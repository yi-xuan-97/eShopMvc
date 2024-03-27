using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.ApplicationCore.Entities;

public class Order
{
    [Key] public int Id { get; set; }

    [Required] public int CustomerId { get; set; }

    [Required] public int ShipperId { get; set; }

    public DateTime OrderDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal TotalAmount { get; set; }

    // Navigation properties
    public virtual Customer Customer { get; set; }
    public virtual Shipper Shipper { get; set; }

    // Collection navigation property
    public  ICollection<OrderDetail> OrderIteDetails { get; set; }
}