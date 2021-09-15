using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.Entities
{
    public class CarroLibro
    {
        public int Id { get; set; }
        public int LibroId { get; set; }

        public int CarroId { get; set; }

        public Libro Libro { get; set; }

        public Carro Carro { get; set; }
    }
}
