using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borboteca_Libros.AccessData.Configurations;
using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Borboteca_Libros.AccessData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ConfigFavoritos(modelBuilder.Entity<Favoritos>());
            new ConfigRoll(modelBuilder.Entity<Roll>());
            new ConfigUsuarios(modelBuilder.Entity<Usuarios>());
        }
        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roll> roll { get; set; }

        
    }
}
