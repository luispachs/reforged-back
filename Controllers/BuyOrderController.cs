using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class BuyOrderController : ControllerBase
{
    private readonly ReforgedContext _context;

    public BuyOrderController(ReforgedContext context)
    {
        _context = context;
    }
}