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
    public interface IAutorService
    {
        public AutorDTO CrearAutor(AutorDTO libro);
    }
    public class AutorService : IAutorService
    {
        private readonly IGenericRepository _repository;
        private readonly IAutorQuery _query;

        public AutorService(IGenericRepository repository, IAutorQuery query)
        {
            this._repository = repository;
            this._query = query;
        }
        public AutorDTO CrearAutor(AutorDTO autor)
        {
            var entity = new Autor
            {
                NombreAutor = autor.NombreAutor,
                ApellidoAutor = autor.ApellidoAutor,
         
            };
            _repository.Add<Autor>(entity);
            return autor;
        }



    }
}
