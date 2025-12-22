using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class ProcessController : ControllerBase
{
    private readonly ReforgedContext _context;

    public ProcessController(ReforgedContext context)
    {
        _context = context;
    }
}