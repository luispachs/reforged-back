using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class WarehouseController : ControllerBase
{
    private readonly ReforgedContext _context;

    public WarehouseController(ReforgedContext context)
    {
        _context = context;
    }
}