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
        public ConfigAutor(EntityTypeBuilder<Autor> BuilderAutor)
        {
            BuilderAutor.HasKey(x => x.Id);
            BuilderAutor.Property(x => x.NombreCompleto).IsRequired().HasMaxLength(50);
        }
    }
}
