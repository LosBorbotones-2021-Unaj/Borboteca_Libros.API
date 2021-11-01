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
        LibroConAutorDTO GetPathLibro(Guid id);
        List<LibrosMuestra> PedirLibros(int Indice);
        int ContadorLibros();
        List<LibroBusquedaDTO> PedirLibrosPorBusqueda(string busqueda);
    }
}
