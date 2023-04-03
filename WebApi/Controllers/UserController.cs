using Bussiness.Abstract;
using Bussiness.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// CQRS ve MediatR kullanılırsa best practice olur.
        /// </summary>
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// kullanıcı kaydı için kullanılan api metot. validation yazılmadı. 
        /// <param name="createUser"></param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromQuery] CreateUserDTO createUser)
        {
            bool result = await _userService.CreateUserAsync(createUser);

            if (!result)
            {
                return Ok("Başarısız, kullanıcı oluşturulamadı.");
            }

            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }

        /// <summary>
        /// kullanıcı girişi için kullanılan api metot. validation yazılmadı.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("LoginUser")]
        public async Task<IActionResult> LoginUser([FromQuery] string email, string password)
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
