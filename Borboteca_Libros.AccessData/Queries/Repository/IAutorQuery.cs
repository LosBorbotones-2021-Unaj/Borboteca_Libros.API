using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borboteca_Libros.Domain.Entities;
using Borboteca_Libros.AccessData;
using Borboteca_Libros.Domain.DTO;

namespace Borboteca_Libros.AccessData.Queries.Repository
{
    public interface IAutorQuery
    {
        public List<Autor> ObtenerListaDeAutores();
        public AutorDTO ObtenerAutorPorid(int id);
        public List<AutorDTO> ObtenerAutorPorNombre(string Nombre);
    }
}
