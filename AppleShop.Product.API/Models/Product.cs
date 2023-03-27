using AppleShop.Product.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleShop.Product.API.Models;

public class Product : Entity
{
    public Product() { }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public ColorType Color { get; set; }

    public int Memory { get; set; }

    public int AvailableStock { get; set; }

    public string? PictureUri { get; set; }

    public double Price { get; set; }

    public Guid CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; }

    /// <summary>
    /// Check If Product Available.
    /// </summary>
    public bool IsAvailable => AvailableStock > 0;

    /// <summary>
    /// Decrements the quantity of a particular item in inventory.
    /// </summary>
    /// <param name="quantity"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int RemoveStock(int quantity) 
    {
        if (AvailableStock == 0)
            throw new Exception($"Empty stock, product item {Name} is sold out");

        if (quantity <= 0)
            throw new Exception("Item units desired should be greater than zero");

        var removed = Math.Min(quantity, AvailableStock);

        AvailableStock -= removed;

        return removed;
    }

    /// <summary>
    /// Increments the quantity of a particular item in inventory.
    /// </summary>
    /// <param name="quantity"></param>
    /// <returns></returns>
    public int AddStock(int quantity)
    {
        AvailableStock += quantity;

        return AvailableStock - quantity;
    }
}