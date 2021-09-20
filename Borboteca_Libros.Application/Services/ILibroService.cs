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
            Autor _autor = new Autor()
            {
                NombreAutor = "Marcos",
                ApellidoAutor = "Garcia"
            };
            var entity = new Libro
            {
                Titulo = libro.Titulo,
                Recenia = libro.Receña,
                Editorial = libro.Editorial,
                FechaDePublicacion = libro.FechaDePublicacion,
                Imagen = libro.Imagen,
                Pach = libro.Pach,
                Precio = libro.Precio,
                Autor = _autor,
            };
            _repository.Add<Libro>(entity);

            return libro;
        }
    }
}
