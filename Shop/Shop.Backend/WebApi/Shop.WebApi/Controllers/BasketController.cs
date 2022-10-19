using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Interface.Service;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]/")]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("get-basket-by-user/{id}")]
        public IActionResult OnGet([FromRoute] int id)
        {
            return Json(_basketService.GetByUserIdAsync(id).Result);
        }
    }
}
