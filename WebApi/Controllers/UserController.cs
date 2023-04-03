using Bussiness.Abstract;
using Bussiness.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUser)
        {
            bool result = await _userService.CreateUserAsync(createUser);

            if (!result)
            {
                return Ok("Başarısız, kullanıcı oluşturulamadı.");
            }

            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }

        [HttpGet("LoginUser")]
        public async Task<IActionResult> LoginUser(string email, string password)
        {
            bool result = await _userService.LoginUserAsync(email, password);

            if (!result)
            {
                return Ok("Başarısız kullanıcı girişi.");
            }

            return Ok("Kullanıcı başarıyla oturum açtı.");
        }
    }
}
