using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Dtos;
using Shop.Domain.Interface.Service;

namespace Final.Api.Controllers
{
    [ApiController]
    [Route("/[controller]/")]
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpPost("add-from-basket-to-history/{basketId}")]
        public IActionResult OnPost([FromRoute] int basketId, [FromBody] HistoryDto history)
        {
            return Json(_historyService.AddAsync(basketId, history).Result);
        }

        [HttpGet("get-basket-history/{basketId}")]
        public IActionResult OnGet(int basketId)
        {
            return Json(_historyService.GetAsync(basketId).Result);
        }
    }
}
