namespace nago_reforged_api.Controllers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using nago_reforged_api.Context;
using nago_reforged_api.Models;
using nago_reforged_api.Schemes;
using nago_reforged_api.Security;

[ApiController]
public class AuthController : ControllerBase
{
    private IConfiguration _config;
    private string? audience;
    private ReforgedContext _context;
    public AuthController(IConfiguration config,ReforgedContext context)
    {
        _config = config;
        _context = context;
    }

    [HttpPost]
    [Route("api/auth/signin")]
    public IActionResult login([FromBody] LoginScheme loginScheme)
    {
        

        if(loginScheme == null)
        {
            return Unauthorized("Invalid email and/or password.");
        }

        var user = _context.Users.FirstOrDefault<User>(u=>u.Email == loginScheme.Email);
        if(user == null)
        {
            return Unauthorized("Invalid email and/or password");
        }

        if (!Hash.check(loginScheme.Password,user.PasswordHash))
        {
            return Unauthorized("Invalid email and/or password");
        }

        var permissions = _context.Permissions.Join(
            _context.Profiles,
            p => p.ProfileId,
            pr=>pr.Id,
            (p,pr)=>new {
                RoleId = p.RoleId,
                UserId =pr.UserId
                })
            .FirstOrDefault(p=>p.UserId == user.Id);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, $"{user.Name} {user.Lastname}"),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Role, permissions.RoleId.ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())

        };


        return Ok(new
        {   
            id= user.Id,
            firstname = user.Name,
            lastname = user.Lastname,
            token = GenerateJwtToken(claims),
            expires = DateTime.Now.AddHours(8)
        });
    }


    [HttpGet]
    [Route("api/auth/signout")]
    public IActionResult Logout()
    {
        return Ok("Logout Successfull");
    }


    [HttpGet]
    [Route("api/auth/current")]
    [Authorize]
    public async Task<IActionResult> getCurrentUser()
    {
        ClaimsPrincipal user = this.User;
        var currentUser = await _context.Users.FirstOrDefaultAsync<User>(u=>u.Id == int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value));
        return Ok(new {
            name = currentUser.Name,
            lastname = currentUser.Lastname,
            email = currentUser.Email,
            id = currentUser.Id
        } );
    }
    private string GenerateJwtToken(List<Claim> claims)
    {
        string? secretKey = _config.GetValue<string>("reforgedSecret");
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new Exception("Secret key not found in configuration.");
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: "http://localhost:5181",
            claims: claims,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}