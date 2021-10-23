using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }

        public List<Libro> Libro { get; set; }
    }
}
