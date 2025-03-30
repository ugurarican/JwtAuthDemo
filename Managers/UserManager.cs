using JwtAuthDemo.Context;
using JwtAuthDemo.Dtos;
using JwtAuthDemo.Entities;
using JwtAuthDemo.Services;
using JwtAuthDemo.Types;

namespace JwtAuthDemo.Managers
{
    public class UserManager : IUserService
    {
        private readonly IdentityDbContext _context;
        public UserManager(IdentityDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var entity = new UserEntity
            {
                Email = user.Email,
                Password = user.Password,
            };
            _context.Users.Add(entity);
            _context.SaveChanges();
            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Kullanıcı oluşturuldu."
            };
        }

        public async Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user)
        {
            var userEntity = _context.Users.Where(x => x.Email.ToLower() == user.Email.ToLower()).FirstOrDefault();
            if(userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı."
                };
            }
            if(userEntity.Password == user.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Message = "Giriş Başarılı.",
                    Data = new UserInfoDto
                    {
                        Email = userEntity.Email,
                        Id = userEntity.Id,
                        UserType = userEntity.UserType
                    }
                };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
            }
        }
    }
}
