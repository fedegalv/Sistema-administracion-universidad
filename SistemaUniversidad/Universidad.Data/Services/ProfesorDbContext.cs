using System.Data.Entity;
using Universidad.Data.Models;

namespace Universidad.Data.Services
{
    class ProfesorDbContext : DbContext
    {
        
        public DbSet<Profesor> professor { get; set; }
    }
}
