using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Configurations
{
    public class ConfigGenero
    {
        public ConfigGenero(EntityTypeBuilder<Genero> BuilderGenero)
        {
            BuilderGenero.HasKey(x => x.Id);
            BuilderGenero.Property(x => x.Descripcion).IsRequired();
            BuilderGenero.HasMany(x => x.LibroGenero).WithOne(x => x.Genero).HasForeignKey(x => x.GeneroId);

            BuilderGenero.HasData(new Genero { Id = 1, Descripcion = "Novela" });
            BuilderGenero.HasData(new Genero { Id = 2, Descripcion = "Terror" });
            BuilderGenero.HasData(new Genero { Id = 3, Descripcion = "Comedia" });
            BuilderGenero.HasData(new Genero { Id = 4, Descripcion = "Ficción" });
            BuilderGenero.HasData(new Genero { Id = 5, Descripcion = "Aventura" });
            BuilderGenero.HasData(new Genero { Id = 6, Descripcion = "Suspenso" });


        }
    }
}
