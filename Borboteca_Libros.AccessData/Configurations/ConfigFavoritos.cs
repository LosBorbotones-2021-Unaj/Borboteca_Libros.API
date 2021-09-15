using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Borboteca_Libros.Domain.Entities;

namespace Borboteca_Libros.AccessData.Configurations
{
    class ConfigFavoritos
    {
        public ConfigFavoritos(EntityTypeBuilder<Favoritos> BuilderFavorito) {
            BuilderFavorito.HasKey(x => x.id);
            BuilderFavorito.Property(x => x.idLibro).IsRequired();
            BuilderFavorito.Property(x => x.idUsuario).IsRequired();
        }
    }
}
