using System.ComponentModel.DataAnnotations;

namespace AppleShop.Product.API.Models;

public class Category : Entity
{
    public Category()
    {
        Products = new HashSet<Product>();
    }

    [Required]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }

    public int ProductQuantity() => Products.Count;
}