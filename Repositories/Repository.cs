using JwtAuthDemo.Context;
using JwtAuthDemo.Entities;

namespace JwtAuthDemo.Repositories
{
    public class Repository : IRepository
    {
        private readonly IdentityDbContext _context;
        public Repository(IdentityDbContext context)
        {
            _context = context;
        }
        public void Add(UserEntity entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(UserEntity entity)
        {
            entity.isDeleted = true;
            _context.SaveChanges();
        }
    }
}
