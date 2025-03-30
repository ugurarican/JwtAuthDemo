using JwtAuthDemo.Dtos;
using JwtAuthDemo.Types;

namespace JwtAuthDemo.Services
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user);
        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user);
    }
}
