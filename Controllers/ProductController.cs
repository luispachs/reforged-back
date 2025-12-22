using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;

namespace nago_reforged_api.Controllers;

public class ProductController : ControllerBase
{
    private readonly ReforgedContext _context;

    public ProductController(ReforgedContext context)
    {
        _context = context;
    }
}