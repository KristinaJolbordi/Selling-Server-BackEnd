using System;
using System.Collections.Generic;
using FinalProjectWebAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWebAPI.Model;

public class Product : IComparable<Product>
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(10)]
    public string Code { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
    [Required]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public ProductCategory Category { get; set; }
    [Required]
    [Range(0, 100)]
    public int AgeRecommendation { get; set; }
    public int CompareTo(Product? other)
    {
        if (other == null) return 1;
        return this.Name.CompareTo(other.Name);
    }
}