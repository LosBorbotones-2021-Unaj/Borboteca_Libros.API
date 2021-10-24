using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borboteca_Libros.AccessData.Command.Repository;
using Borboteca_Libros.AccessData.Queries.Repository;
using Borboteca_Libros.AccessData.Validations;
using Borboteca_Libros.Domain.DTO;
using Borboteca_Libros.Domain.Entities;

namespace Borboteca_Libros.Application.Services
{
    public interface ILibroService
    {
        LibroDTO CrearLibro(LibroDTO libro);
        string PedirPathLibro(Guid id);
        List<LibrosMuestra> PedirLibros();
        Libro PedirLibroId(Guid id);
    }
    public class LibroService : ILibroService 
    {
        private readonly IGenericRepository _repository;
        private readonly ILibroQuery _query;
        private readonly ILibroGeneroService _libroGenero;
        private readonly IGeneroQuery _queryGenero;

        public LibroService(IGenericRepository repository, ILibroQuery query, ILibroGeneroService libroGenero, IGeneroQuery queryGenero) 
        {
            this._repository = repository;
            this._query = query;
            this._libroGenero = libroGenero;
            this._queryGenero = queryGenero;
        }
        public LibroDTO CrearLibro(LibroDTO libro) 
        {
            var verificar = new ValidarGenero(libro.Generos,_queryGenero);
            var listarGeneros = verificar.Verify();
            var entity = new Libro
            {
                Id = Guid.NewGuid(),
                Titulo = libro.Titulo,
                Resenia = libro.Resenia,
                Editorial = libro.Editorial,
                FechaDePublicacion = libro.FechaDePublicacion,
                Imagen = libro.Imagen,
                Pach = libro.Path,
                Precio = libro.Precio,
                AutorId = libro.IdAutor,
            };
            _repository.Add<Libro>(entity);
            _libroGenero.GenerarGenero(entity, listarGeneros);
            return libro;
        }

        public Libro PedirLibroId(Guid id)
        {
            return _query.GetPathLibro(id);
        }

        public List<LibrosMuestra> PedirLibros()
        {
            return _query.PedirLibros();
        }

        public string PedirPathLibro(Guid id)
        {
            Libro _libro =_query.GetPathLibro(id);
            return _libro.Pach;
        }
    }
}
