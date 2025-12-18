namespace nago_reforged_api.Controllers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nago_reforged_api.Schemes;
using Namotion.Reflection;

public class AuthController : ControllerBase
{
    private IConfiguration _config;
    private string? audience;
    public AuthController(IConfiguration config)
    {
        _config = config;
       
    }

    [HttpPost]
    [Route("api/auth/signin")]
    public IActionResult login([FromBody] LoginScheme loginScheme)
    {
        

        if(loginScheme == null)
        {
            return Unauthorized("Invalid email and/or password.");
        }
        if (loginScheme.Email != "laps1308@gmail.com" || loginScheme.Password != "123456789")
        {
            return Unauthorized("Invalid email and/or password");
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,"Luis Pacheco"),
            new Claim(ClaimTypes.Email,"laps1308@gmail.com"),
            new Claim(ClaimTypes.Role, "ADMIN"),
            new Claim(ClaimTypes.NameIdentifier,"1096217268")

        };


        return Ok(new
        {
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