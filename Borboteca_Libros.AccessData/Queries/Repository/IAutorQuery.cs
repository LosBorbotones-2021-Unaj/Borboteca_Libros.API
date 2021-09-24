using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borboteca_Libros.Domain.Entities;
using Borboteca_Libros.AccessData;

namespace Borboteca_Libros.AccessData.Queries.Repository
{
    public interface IAutorQuery
    {
        public List<Autor> ObtenerListaDeAutores();
        public Autor ObtenerAutorPorid(int id);
        public List<Autor> ObtenerAutorPorNombre(string Nombre);
    }
}
