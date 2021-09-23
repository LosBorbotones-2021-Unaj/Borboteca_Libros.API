using System;
using System.Collections.Generic;

namespace Borboteca_Libros.Domain.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resenia { get; set; }
        public string Editorial { get; set; }
        public DateTime FechaDePublicacion { get; set; }
        public string Imagen { get; set; }
        public string Pach { get; set; }
        public int Precio { get; set; }
        public Autor Autor { get; set; }
    }
}