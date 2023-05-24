using AppleShop.Basket.API.Dtos;
using AppleShop.Basket.API.Models;
using AppleShop.Basket.API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Basket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : Controller
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CartController(ICartRepository cartRepository,
            IMapper mapper
            )
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    [HttpGet("getCart/{userId}")]
    public async Task<IActionResult> GetCart(string userId)
    {
        var cart = await _cartRepository.GetCartByUserId(userId);
        var dto = _mapper.Map<CartDto>(cart);
        var result = ApiResponse<CartDto>.Success(dto);

        return Ok(result);
    }

    [HttpPost("addCart")]
    public async Task<IActionResult> AddCart(CartDto cartDto)
    {
        var cart = _mapper.Map<Cart>(cartDto);
        var createdCart = await _cartRepository.CreateUpdateCart(cart);

        var dto = _mapper.Map<CartDto>(createdCart);
        var result = ApiResponse<CartDto>.Success(dto);

        return Ok(result);
    }

    [HttpPost("updateCart")]
    public async Task<IActionResult> UpdateCart(CartDto cartDto)
    {
        var cart = _mapper.Map<Cart>(cartDto);
        var updatedCart = await _cartRepository.CreateUpdateCart(cart);

        var dto = _mapper.Map<CartDto>(updatedCart);
        var result = ApiResponse<CartDto>.Success(dto);

        return Ok(result);
    }

    [HttpDelete("removeCart/{cartId}")]
    public async Task<IActionResult> RemoveCart(int cartId)
    {
        var isSuccess = await _cartRepository.RemoveFromCart(cartId);
        var result = ApiResponse<bool>.Success(isSuccess);

        return Ok(result);
    }
}