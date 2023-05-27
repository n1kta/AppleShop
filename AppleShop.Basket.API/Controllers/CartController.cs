using AppleShop.Basket.API.Dtos;
using AppleShop.Basket.API.Messages;
using AppleShop.Basket.API.MessageSender;
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
    private readonly IMessageSender _messageSender;

    public CartController(ICartRepository cartRepository,
            IMapper mapper,
            IMessageSender messageSender)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _messageSender = messageSender;
    }

    [HttpGet("getCart/{userId}")]
    public async Task<IActionResult> GetCart(string userId)
    {
        var cart = await _cartRepository.GetCartByUserId(userId);

        if (cart is null)
            return Ok(ApiResponse<CartDto>.Success(new CartDto()));

        var dto = _mapper.Map<CartDto>(cart);
        var result = ApiResponse<CartDto?>.Success(dto);

        return Ok(result);
    }

    [HttpPost("addCart")]
    public async Task<IActionResult> AddCart([FromBody] CartDto cartDto)
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

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout(CheckoutHeaderDto checkoutHeader)
    {
        var cart = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);

        if (cart is null)
        {
            return BadRequest();
        }

        var cartDto = _mapper.Map<CartDto>(cart);

        checkoutHeader.CartDetails = cartDto.CartDetails;

        await _messageSender.SendMessage(checkoutHeader, "checkoutqueue");
        await _cartRepository.ClearCart(checkoutHeader.UserId);

        return Ok(ApiResponse<bool>.Success(true));
    }
}