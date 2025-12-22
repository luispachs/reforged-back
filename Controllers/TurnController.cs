using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class TurnController : ControllerBase
{
    private readonly ReforgedContext _context;

    public TurnController(ReforgedContext context)
    {
        _context = context;
    }
}