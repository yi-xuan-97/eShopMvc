using System.ComponentModel.DataAnnotations;

namespace eShop.ApplicationCore.Entities;

public class Category
{
    [Key] 
    public int Id { get; set; }

    [Required] 
    public string Name { get; set; }

    public string Description { get; set; }

    // Collection navigation property
    public  ICollection<Product> Products { get; set; }
}