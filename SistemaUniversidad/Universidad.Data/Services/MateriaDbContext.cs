using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;

namespace Universidad.Data.Services
{
    class MateriaDbContext : DbContext
    {
        public DbSet<Materia> subject { get; set; }
    }
}
