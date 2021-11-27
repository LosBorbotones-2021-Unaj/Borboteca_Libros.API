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
        List<LibrosMuestra> PedirLibros(int Indice);
        LibroDTO2 PedirLibroId(string id);

        List<LibroBusquedaDTO> FiltroLibros(string busqueda);
        List<LibroBusquedaDTO> FiltroLibrosAutor(string busqueda, string titulo);
        int PedirCantidadLibros();
        int PedirGeneroId(Guid Libroid);
    }
    public class LibroService : ILibroService 
    {
        private readonly IGenericRepository _repository;
        private readonly ILibroQuery _query;
        private readonly ILibroGeneroService _libroGenero;
        private readonly IGeneroQuery _queryGenero;
        private readonly ILibroGeneroQuery _libroGeneroQuery;

        public LibroService(IGenericRepository repository, ILibroQuery query, ILibroGeneroService libroGenero, IGeneroQuery queryGenero, ILibroGeneroQuery libroGeneroQuery) 
        {
            this._repository = repository;
            this._query = query;
            this._libroGenero = libroGenero;
            this._queryGenero = queryGenero;
            this._libroGeneroQuery = libroGeneroQuery;
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

        public LibroDTO2 PedirLibroId(string id)
        {
            var libro = _query.GetPathLibro(Guid.Parse(id));

            var entity = new LibroDTO2
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Resenia = libro.Resenia,
                Editorial = libro.Editorial,
                FechaDePublicacion = libro.FechaDePublicacion.ToShortDateString(),
                Imagen = libro.Imagen,
                Pach = libro.Pach,
                Precio = libro.Precio,
                NombreAutor = libro.NombreAutor,
                Generos = libro.Generos
            };

            return entity;
        }

        public List<LibroBusquedaDTO> FiltroLibros(string busqueda)
        {
            return _query.PedirLibrosPorBusqueda(busqueda);
        }
        public List<LibroBusquedaDTO> FiltroLibrosAutor(string busqueda, string titulo)
        {
            List<LibroBusquedaDTO> listaLibros = _query.PedirLibrosPorBusqueda(busqueda);
            List<LibroBusquedaDTO> listaLibrosAutor = new List<LibroBusquedaDTO>();

            foreach (var libro in listaLibros)
            {
                if (libro.Titulo != titulo)
                {
                    listaLibrosAutor.Add(libro);
                    if (listaLibrosAutor.Count == 5)
                    {
                        return listaLibrosAutor;
                    }
                }
            }

            return listaLibrosAutor;
        }
        public List<LibrosMuestra> PedirLibros(int Indice)
        {
            return _query.PedirLibros(Indice);
        }

        public string PedirPathLibro(Guid id)
        {
            LibroConAutorDTO _libro =_query.GetPathLibro(id);
            return _libro.Pach;
        }
        public int PedirCantidadLibros() 
        {
            return _query.ContadorLibros();
        }

        public int PedirGeneroId(Guid Libroid)
        {
            return _libroGeneroQuery.PedirGeneroLibro(Libroid);
        }
    }
}
