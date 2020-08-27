using System.Data.Entity;
using Universidad.Data.Models;

namespace Universidad.Data.Services
{
    class MateriaDbContext : DbContext
    {
        
        public DbSet<Materia> subject { get; set; }
    }
}
