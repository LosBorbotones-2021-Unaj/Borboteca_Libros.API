using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Configurations
{
    class ConfigVentas
    {
        public ConfigVentas(EntityTypeBuilder<Ventas> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Fecha.ToShortDateString()).IsRequired();
            entityTypeBuilder.Property(x => x.estado).IsRequired();
            entityTypeBuilder.Property(x => x.Comprobante).IsRequired().HasMaxLength(500);
            entityTypeBuilder.Property(x => x.Carro).IsRequired();


        }
    }
}
