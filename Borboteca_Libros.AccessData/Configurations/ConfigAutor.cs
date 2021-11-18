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

            BuilderAutor.HasData(
                new Autor
                {
                    Id = 1,
                    NombreCompleto = "Antoine de Saint-Exupéry"
                });
            BuilderAutor.HasData(
                new Autor
                {
                    Id = 2,
                    NombreCompleto = "Javier Alexis Villa"
                });
            BuilderAutor.HasData(
                new Autor
                {
                    Id = 3,
                    NombreCompleto = "Carlos Javier Suarez"
                });
            BuilderAutor.HasData(
                new Autor
                {
                    Id = 4,
                    NombreCompleto = "Tomas Rojas"
                });
            BuilderAutor.HasData(
                new Autor
                {
                    Id = 5,
                    NombreCompleto = "Anonimo"
                });
            BuilderAutor.HasData(
                new Autor
                {
                    Id = 6,
                    NombreCompleto = "Vicente Blasco Ibañez"
                });

        }
    }
}
