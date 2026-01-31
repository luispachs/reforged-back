using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nago_reforged_api.Context;
using nago_reforged_api.Models;

namespace nago_reforged_api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly ReforgedContext _context;

    public UserController(ReforgedContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize]
    [Route("api/user/{id:int}")]
    public async Task<IActionResult> getUserById(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync<User>(u=>u.Id == id);
        if(user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}