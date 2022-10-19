using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Interface.Service;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]/")]
    public class ProductBasketController : Controller
    {
        private readonly IProductBasketService _productBasketService;

        public ProductBasketController(IProductBasketService productBasketService)
        {
            _productBasketService = productBasketService;
        }

        [HttpPost("add-product-to-basket/{productId}/{basketId}")]
        public IActionResult Add([FromRoute] int productId, [FromRoute] int basketId)
        {
            return Json(_productBasketService.AddAsync(productId, basketId).Result);
        }

        [HttpGet("get-items-from-basket/{basketId}")]
        public IActionResult Get([FromRoute] int basketId)
        {
            return Json(_productBasketService.GetAsync(basketId).Result);
        }

        [HttpDelete("delete-item-from-basket/{productId}/{basketId}")]
        public IActionResult Delete([FromRoute] int productId, [FromRoute] int basketId)
        {
            return Json(_productBasketService.DeleteAsync(productId, basketId));
        }

        [HttpGet("get-list-from-basket/{basketId}")]
        public IActionResult GetList([FromRoute] int basketId)
        {
            return Json(_productBasketService.GetListAsync(basketId).Result);
        }
    }
}
