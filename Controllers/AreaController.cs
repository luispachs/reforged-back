using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class AreaController : ControllerBase
{
    private readonly ReforgedContext _context;

    public AreaController(ReforgedContext context)
    {
        _context = context;
    }
}