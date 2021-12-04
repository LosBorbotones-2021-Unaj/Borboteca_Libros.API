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

            BuilderLibroGenero.HasData(new LibroGenero {Id=1, LibroId= new Guid("2550E1B1-9E48-43B4-875F-14634D4C07F1"), GeneroId=5});
            BuilderLibroGenero.HasData(new LibroGenero {Id=2, LibroId= new Guid("A76D59D2-3CB0-44B3-9041-4421E14C69C3"), GeneroId=5});
            BuilderLibroGenero.HasData(new LibroGenero {Id=3, LibroId = new Guid("E87266D6-99CB-4AFD-849B-89C49D36C250"), GeneroId = 3 });
            BuilderLibroGenero.HasData(new LibroGenero {Id=4, LibroId = new Guid("E87266D6-99CB-4AFD-849B-89C49D36C250"), GeneroId = 5 });
            BuilderLibroGenero.HasData(new LibroGenero {Id=5, LibroId = new Guid("2650BAA6-334B-4E17-B7D5-9F773F964E37"), GeneroId = 4 });
            BuilderLibroGenero.HasData(new LibroGenero {Id=6, LibroId = new Guid("B8778F7A-15BA-40A0-A66C-A50A7B01F2F3"), GeneroId = 1 });
            BuilderLibroGenero.HasData(new LibroGenero {Id=7, LibroId = new Guid("2DD83FCA-7E9F-45D0-A7DF-A9E734BF1E79"), GeneroId = 1 });
            BuilderLibroGenero.HasData(new LibroGenero {Id=8, LibroId = new Guid("67F3D74E-039E-415C-8F82-BE1A87111B3F"), GeneroId = 4 });
            BuilderLibroGenero.HasData(new LibroGenero {Id=9, LibroId = new Guid("3FE0DEBA-7374-4293-9067-C0EDE9C768FE"), GeneroId = 6 });
            BuilderLibroGenero.HasData(new LibroGenero {Id=10, LibroId = new Guid("93CD1293-5D5E-455E-A2CC-DEAA1ECEB064"), GeneroId = 4 });
            BuilderLibroGenero.HasData(new LibroGenero {Id=11, LibroId = new Guid("EBF123B7-0841-40EA-9546-FF7CCC17835C"), GeneroId = 1 });
            BuilderLibroGenero.HasData(new LibroGenero { Id = 12, LibroId = new Guid("2550E1B1-9E48-43B4-875F-14634D4C07F1"), GeneroId = 4 });
            BuilderLibroGenero.HasData(new LibroGenero { Id = 13, LibroId = new Guid("A76D59D2-3CB0-44B3-9041-4421E14C69C3"), GeneroId = 1 });
            BuilderLibroGenero.HasData(new LibroGenero { Id = 14, LibroId = new Guid("B8778F7A-15BA-40A0-A66C-A50A7B01F2F3"), GeneroId = 4 });

        }
    }
}
