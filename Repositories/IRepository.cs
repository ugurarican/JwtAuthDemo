using JwtAuthDemo.Entities;

namespace JwtAuthDemo.Repositories
{
    public interface IRepository
    {
        void Add(UserEntity entity);
        void Delete(UserEntity entity);
    }
}
