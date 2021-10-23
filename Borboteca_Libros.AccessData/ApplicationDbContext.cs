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
            new ConfigAutor(modelBuilder.Entity<Autor>());
            new ConfigLibro(modelBuilder.Entity<Libro>());
            new ConfigGenero(modelBuilder.Entity<Genero>());
            new ConfigLibroGenero(modelBuilder.Entity<LibroGenero>());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<LibroGenero> LibroGenero { get; set; }

        
    }
}
