using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Configurations
{
    public class ConfigAutor
    {
        public ConfigAutor(EntityTypeBuilder<Autor> BuilderLibro)
        {
            BuilderLibro.HasKey(x => x.Id);
            BuilderLibro.Property(x => x.NombreAutor).IsRequired().HasMaxLength(50);
            BuilderLibro.Property(x => x.ApellidoAutor).IsRequired().HasMaxLength(50);
        }
    }
}
