using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class MachineController : ControllerBase
{
    private readonly ReforgedContext _context;

    public MachineController(ReforgedContext context)
    {
        _context = context;
    }
}