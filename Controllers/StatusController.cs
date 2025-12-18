using Microsoft.AspNetCore.Mvc;

namespace nago_reforged_api.Controllers;

public class StatusController: ControllerBase
{
    [HttpGet]
    [Route("/api/status")]
    public IActionResult index()
    {
        return Ok(new
        {
            StatusCode = 200,
            message = "Server in working"
        }
                );
    }
}