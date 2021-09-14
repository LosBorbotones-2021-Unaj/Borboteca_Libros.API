using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.Entities
{
    public class Favoritos
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idLibro { get; set; }
    }
}
