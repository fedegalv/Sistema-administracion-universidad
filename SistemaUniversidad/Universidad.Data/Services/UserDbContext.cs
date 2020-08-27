using System.Data.Entity;
using Universidad.Data.Models;

namespace Universidad.Data.Services
{
    public class UserDbContext : DbContext
    {
      
        public DbSet<User> user { get; set; }
    }
}
