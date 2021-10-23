using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<LibroGenero> LibroGenero { get; set; }
    }
}
