using System.ComponentModel.DataAnnotations;

namespace AppleShop.Product.API.Models;

public abstract class Entity
{
    [Key]
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }
}