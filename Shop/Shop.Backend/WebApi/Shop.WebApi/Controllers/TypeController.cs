using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Interface.Service;

namespace Final.Api.Controllers
{
    [ApiController]
    [Route("/[controller]/")]
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet("get-types")]
        public IActionResult OnGet()
        {
            return Json(_typeService.GetNameTypeAsync().Result);
        }

        [HttpGet("get-type-name/{name}")]
        public IActionResult OnGetOneType([FromRoute] string name)
        {
            return Json(_typeService.SortOneAsync(name).Result);
        }

        [HttpGet("get-count-type/{name}")]
        public IActionResult OnGetCountType([FromRoute] string name)
        {
            return Json(_typeService.GetCountAsync(name).Result);
        }
    }
}
