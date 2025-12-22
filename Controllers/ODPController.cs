using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class ODPController : ControllerBase
{
    private readonly ReforgedContext _context;

    public ODPController(ReforgedContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/odp/get")]
    [Authorize]
    public IActionResult GetStatus()
    {
        return Ok(new { status = "Server is Working" });
    }
}