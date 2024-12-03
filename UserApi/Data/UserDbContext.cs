using Microsoft.EntityFrameworkCore;
using UserApi.Model;

namespace UserApi.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
    }
}
