using Borboteca_Libros.Domain.DTO;
using Borboteca_Libros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Queries.Repository
{
    public interface ILibroQuery
    {
        Libro GetPathLibro(Guid id);
        List<LibrosMuestra> PedirLibros();
    }
}
