using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.ApplicationCore.Entities;

public class Promotion
{
    [Key] 
    public int Id { get; set; }

    [Required] 
    public string Name { get; set; }

    public string Description { get; set; }

    [Required] 
    public DateTime StartDate { get; set; }

    [Required] 
    public DateTime EndDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(5, 2)")]
    public decimal Discount { get; set; }
}