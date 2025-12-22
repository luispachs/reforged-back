using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class RoleController : ControllerBase
{
    private readonly ReforgedContext _context;

    public RoleController(ReforgedContext context)
    {
        _context = context;
    }
}