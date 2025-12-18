namespace nago_reforged_api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ODPController : ControllerBase
{
    [HttpGet]
    [Route("api/odp/get")]
    [Authorize]
    public IActionResult GetStatus()
    {
        return Ok(new { status = "Server is Working" });
    }
}