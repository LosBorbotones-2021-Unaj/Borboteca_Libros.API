using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Configurations
{
    public class ConfigUsuarios
    {
        public ConfigUsuarios(EntityTypeBuilder<Usuarios> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.id);
            entityTypeBuilder.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Apellido).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Contraceña).HasMaxLength(50).IsRequired().IsRequired();//Esto de aca no se si podemos hacer q no este en texto plano en la base de datos
            entityTypeBuilder.Property(x => x.rolid).IsRequired();
        }
    }
}
