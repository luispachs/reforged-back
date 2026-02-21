using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nago_reforged_api.Context;
using nago_reforged_api.Models;

namespace nago_reforged_api.Controllers;

public class ProductController : ControllerBase
{
    private readonly ReforgedContext _context;

    public ProductController(ReforgedContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/api/product")]
    [Authorize]
    public ActionResult list()
    {
        var productsList = this._context.Products.ToList();
        return Ok(new {products=productsList});
    }


    public ActionResult create()
    {
        return Ok();
    }
}