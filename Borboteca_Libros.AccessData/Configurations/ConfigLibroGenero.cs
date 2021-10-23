using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Configurations
{
    public class ConfigLibroGenero
    {
        public ConfigLibroGenero(EntityTypeBuilder<LibroGenero> BuilderLibroGenero)
        {
            BuilderLibroGenero.HasKey(x => x.Id);
            BuilderLibroGenero.Property(x => x.GeneroId);
            BuilderLibroGenero.Property(x => x.LibroId);

        }
    }
}
