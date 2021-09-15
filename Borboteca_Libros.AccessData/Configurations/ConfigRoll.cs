using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Borboteca_Libros.AccessData.Configurations
{
    class ConfigRoll
    {
        public ConfigRoll(EntityTypeBuilder<Roll> BuilderRoll) {
            BuilderRoll.HasKey(x => x.Id);
            BuilderRoll.Property(x => x.Descripcion).HasMaxLength(200);
        }
    }
}
