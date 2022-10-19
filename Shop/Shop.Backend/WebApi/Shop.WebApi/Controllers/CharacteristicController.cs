using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Interface.Service;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]/")]
    public class CharacteristicController : Controller
    {
        private readonly ICharacteristicService _characteristicService;

        public CharacteristicController(ICharacteristicService characteristicService)
        {
            _characteristicService = characteristicService;
        }

        [HttpGet("get-characteristic/{id}")]
        public IActionResult OnGet([FromRoute] int id)
        {
            return Json(_characteristicService.GetAsync(id).Result);
        }
    }
}
