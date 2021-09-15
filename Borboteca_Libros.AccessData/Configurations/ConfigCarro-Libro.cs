using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Configurations
{
    class ConfigCarroLibro
    {
        public ConfigCarroLibro(EntityTypeBuilder<CarroLibro> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.LibroId).IsRequired();
            entityTypeBuilder.Property(x => x.CarroId).IsRequired();


        }
    }
}
