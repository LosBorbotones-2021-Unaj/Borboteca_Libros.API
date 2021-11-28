using Borboteca_Libros.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Queries.Repository
{
    public interface ILibroGeneroQuery
    {
        int PedirGeneroLibro(Guid libroId);
    }
}
