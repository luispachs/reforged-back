using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class PaymentController : ControllerBase
{
    private readonly ReforgedContext _context;

    public PaymentController(ReforgedContext context)
    {
        _context = context;
    }
}