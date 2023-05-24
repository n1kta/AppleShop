﻿namespace AppleShop.Basket.API.Dtos;

public class ProductDto
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public string CategoryName { get; set; }

    public string ImageUrl { get; set; }
}