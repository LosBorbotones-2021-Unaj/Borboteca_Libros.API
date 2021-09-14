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
            
        }
    }
}
