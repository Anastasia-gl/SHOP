using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Interface.Service;

namespace Shop.WebApi.Controllers;

[ApiController]
[Route("/[controller]/")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("get-list-product/{pages}/{limit}")]
    public IActionResult OnGet([FromRoute] int pages,[FromRoute] int limit)
    {
        return Json(_productService.GetListAsync(pages, limit).Result);
    }

    [HttpGet("get-by-id/{id}")]
    public IActionResult OnGetId([FromRoute] int id)
    {
        return Json(_productService.GetByIdAsync(id).Result);
    }

    [HttpGet("sort-by-price/{pages}/{limit}")]
    public IActionResult OnGetType([FromRoute] int pages, [FromRoute] int limit)
    {
        return Json(_productService.SortAsync(pages, limit).Result);
    }

    [HttpGet("count-list")]
    public IActionResult OnGetCount()
    {
        return Json(_productService.GetCountAsync().Result);
    }
}
