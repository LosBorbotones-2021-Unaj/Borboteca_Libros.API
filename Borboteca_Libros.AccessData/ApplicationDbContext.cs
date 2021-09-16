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

            new ConfigFavoritos(modelBuilder.Entity<Favoritos>());
            new ConfigRoll(modelBuilder.Entity<Roll>());
            new ConfigUsuarios(modelBuilder.Entity<Usuarios>());
            new ConfigAutor(modelBuilder.Entity<Autor>());
            new ConfigLibro(modelBuilder.Entity<Libro>());
            new ConfigCarroLibro(modelBuilder.Entity<CarroLibro>());
            new ConfigCarro(modelBuilder.Entity<Carro>());
            new ConfigVentas(modelBuilder.Entity<Ventas>());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CarroLibro> CarroLibro { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Carro> Carro { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roll> Roll { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libro { get; set; }

        
    }
}
