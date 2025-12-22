using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class ServiceController : ControllerBase
{
    private readonly ReforgedContext _context;

    public ServiceController(ReforgedContext context)
    {
        _context = context;
    }
}