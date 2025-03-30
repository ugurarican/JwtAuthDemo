using JwtAuthDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Context
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options): base(options)
        {

        }
        public DbSet<UserEntity> Users => Set<UserEntity>();
    }
}
