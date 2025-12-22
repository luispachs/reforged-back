using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class DpncController : ControllerBase
{
    private readonly ReforgedContext _context;

    public DpncController(ReforgedContext context)
    {
        _context = context;
    }
}