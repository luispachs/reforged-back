using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class ContactController : ControllerBase
{
    private readonly ReforgedContext _context;

    public ContactController(ReforgedContext context)
    {
        _context = context;
    }
}