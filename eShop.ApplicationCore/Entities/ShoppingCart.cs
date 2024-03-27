using System.ComponentModel.DataAnnotations;

namespace eShop.ApplicationCore.Entities;

public class ShoppingCart
{
    [Key] public int Id { get; set; }

    [Required] public int CustomerId { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation property
    public virtual Customer Customer { get; set; }

    // Collection navigation property
    public ICollection<CartItem> CartItems { get; set; }
}