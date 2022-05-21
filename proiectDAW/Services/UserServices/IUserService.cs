using proiectDAW.Models.DTOs;
using System.Threading.Tasks;

namespace proiectDAW.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<string> LoginUser(LoginUserDTO loginUserDTO);
    }
}
