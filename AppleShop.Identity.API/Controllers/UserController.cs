using AppleShop.Identity.API.DTOs;
using AppleShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppleShop.Identity.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("getUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = _userManager.Users
            .Where(u => u.Email != "admin@gmail.com")
            .Select(u => new UserDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            })
            .ToList();

        return Ok(ApiResponse<List<UserDto>>.Success(users));
    }
}