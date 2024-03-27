using System.ComponentModel.DataAnnotations;

namespace eShop.ApplicationCore.Entities;

public class CartItem
{
    [Key] public int Id { get; set; }

    [Required] public int ShoppingCartId { get; set; }

    [Required] public int ProductId { get; set; }

    [Required] public int Quantity { get; set; }
    

    // Navigation properties
    public  ShoppingCart ShoppingCart { get; set; }
    public  Product Product { get; set; }
}