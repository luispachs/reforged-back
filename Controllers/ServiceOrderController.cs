using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class ServiceOrderController : ControllerBase
{
    private readonly ReforgedContext _context;

    public ServiceOrderController(ReforgedContext context)
    {
        _context = context;
    }
}