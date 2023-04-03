using Bussiness.DTOs;

namespace Bussiness.Abstract
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserDTO createUser);
        Task<bool> LoginUserAsync(string email, string password);
    }
}
