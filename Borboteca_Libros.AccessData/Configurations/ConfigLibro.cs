using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Borboteca_Libros.Domain.Entities;

namespace Borboteca_Libros.AccessData.Configurations
{
    public class ConfigLibro
    {
        public ConfigLibro(EntityTypeBuilder<Libro> BuilderLibro) 
        {
            BuilderLibro.HasKey(x => x.Id);
            BuilderLibro.Property(x => x.Titulo).IsRequired().HasMaxLength(50);
            BuilderLibro.Property(x => x.Resenia).IsRequired().HasMaxLength(1000);
            BuilderLibro.Property(x => x.Editorial).IsRequired().HasMaxLength(50);
            BuilderLibro.Property(x => x.FechaDePublicacion).IsRequired();
            BuilderLibro.Property(x => x.Imagen).IsRequired();
            BuilderLibro.Property(x => x.Pach).IsRequired().HasMaxLength(120);
            BuilderLibro.Property(x => x.Precio).IsRequired();
            BuilderLibro.HasMany(x => x.LibroGenero).WithOne(x => x.Libro).HasForeignKey(x => x.LibroId);
            BuilderLibro.HasOne(x => x.Autor).WithMany(x => x.Libro).HasForeignKey(x => x.AutorId);
        }
    }
}
