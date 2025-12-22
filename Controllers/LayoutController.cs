using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class LayoutController : ControllerBase
{
    private readonly ReforgedContext _context;

    public LayoutController(ReforgedContext context)
    {
        _context = context;
    }
}