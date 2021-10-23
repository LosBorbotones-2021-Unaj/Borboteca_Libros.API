using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borboteca_Libros.AccessData.Command.Repository;
using Borboteca_Libros.AccessData.Queries.Repository;
using Borboteca_Libros.Domain.DTO;
using Borboteca_Libros.Domain.Entities;

namespace Borboteca_Libros.Application.Services
{
    public interface ILibroService
    {
        public LibroDTO CrearLibro(LibroDTO libro);
        string PedirPathLibro(int id);
    }
    public class LibroService : ILibroService 
    {
        private readonly IGenericRepository _repository;
        private readonly ILibroQuery _query;

        public LibroService(IGenericRepository repository, ILibroQuery query) 
        {
            this._repository = repository;
            this._query = query;
        }
        public LibroDTO CrearLibro(LibroDTO libro) 
        {
            var entity = new Libro
            {
                Titulo = libro.Titulo,
                Resenia = libro.Resenia,
                Editorial = libro.Editorial,
                FechaDePublicacion = libro.FechaDePublicacion,
                Imagen = libro.Imagen,
                Pach = libro.Path,
                Precio = libro.Precio,
                AutorId = libro.IdAutor,
                GeneroId = libro.GeneroId
            };
            _repository.Add<Libro>(entity);
            return libro;
        }

        public string PedirPathLibro(int id)
        {
            Libro _libro =_query.GetPathLibro(id);
            return _libro.Pach;
        }
    }
}
