using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.Entities
{
    public class Carro_Libro
    {
        public int Id { get; set; }

        public Libro Libro { get; set; }

        public Carro Carro { get; set; }

        //public ICollection<Libro> ListaLibros { get; set; }
        //public ICollection<Carro> ListaCarro { get; set; }
    }
}
