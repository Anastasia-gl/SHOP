using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Dtos;
using Shop.Domain.Interface.Service;
using Shop.Identity;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]/")]
    public class AuthController : Controller
    {
        private readonly IUserService _user;
        private readonly IBasketService _basket;
        private readonly JwtToken _service;
        private bool _flag;

        public AuthController(IUserService user, JwtToken service, IBasketService basket)
        {
            _user = user;
            _service = service;
            _basket = basket;
        }

        [HttpPost("register-user")]
        public IActionResult OnPost(RegisterDto user)
        {
            var userRegister = _user.Create(user).Result;
            _basket.CreateNewBasket(userRegister);
            return Json(userRegister);
        }

        [HttpPost("login-user")]
        public IActionResult OnPostLogin([FromBody] LoginDto user)
        {
            var userByEmail = _user.GetByEmail(user.Email).Result;

            if (user == null) return BadRequest(new { massage = "Invalid creadentials" });

            if (!BCrypt.Net.BCrypt.Verify(user.Password, userByEmail.Password))
            {
                return BadRequest(new { massage = "Invalid creadentials" });
            }

            var jwt = _service.Generate(userByEmail.UserId);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });


            return Ok(new
            {
                jwt
            });
        }

        [HttpGet("get-user")]
        public IActionResult OnGet()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _service.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _user.GetById(userId);


                return Json(userId);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("get-jwt")]
        public IActionResult OnGetJwt()
        {
            try {
                var jwt = Request.Cookies["jwt"];
                return Json(jwt);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("check-token/{jwt}")]
        public IActionResult OnGetJwt([FromRoute] string jwt)
        {
            _flag = false;
            if (jwt == Request.Cookies["jwt"])
            {
                _flag = true;
                return Ok(_flag);
            }

            return Unauthorized(_flag);
        }

        [HttpPost("logout-user")]
        public bool OnLogout()
        {
            Response.Cookies.Delete("jwt");
            _flag = false;

            return _flag;
        }
    }
}
