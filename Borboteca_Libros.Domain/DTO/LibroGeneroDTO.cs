using Borboteca_Libros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.DTO
{
    public class LibroGeneroDTO
    {
        public int Id { get; set; }
        public Guid LibroId { get; set; }
        public int GeneroId { get; set; }

        public Genero Genero { get; set; }
        public Libro Libro { get; set; }
    }
}
