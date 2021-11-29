using Borboteca_Libros.AccessData.Command.Repository;
using Borboteca_Libros.AccessData.Queries.Repository;
using Borboteca_Libros.Domain.DTO;
using Borboteca_Libros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Application.Services
{
    public interface IGeneroService
    {
        public GeneroDTO PedirGeneroPorId(int id);
        public GeneroDTO PedirGeneroPorNombre(string nombre);
        List<GeneroDTO> GetGeneros();
    }
    public class GeneroService : IGeneroService
    {
        private readonly IGenericRepository _repository;
        private readonly IGeneroQuery _query;

        public GeneroService(IGenericRepository repository, IGeneroQuery query)
        {
            this._repository = repository;
            this._query = query;
        }

        public List<GeneroDTO> GetGeneros()
        {
            return _query.GetGenero();
        }

        public GeneroDTO PedirGeneroPorId(int id)
        {
            return _query.GetGenerosDTOById(id);
        }
        public GeneroDTO PedirGeneroPorNombre(string nombre)
        {
            return _query.GetGenerosDTOByName(nombre);
        }
    }
}
