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
    public interface ILibroGeneroService
    {
        public void GenerarGenero(Libro libro, List<Genero> genero);
    }
    public class LibroGeneroService : ILibroGeneroService
    {
        private readonly IGenericRepository _repository;
        public LibroGeneroService(IGenericRepository repository) 
        {
            _repository = repository;
        }

        public void GenerarGenero(Libro libro, List<Genero> genero)
        {
            foreach (Genero objeto in genero) 
            {
                var GeneroLibros = new LibroGenero
                {
                    LibroId = libro.Id,
                    GeneroId = objeto.Id
                };
                _repository.Add<LibroGenero>(GeneroLibros);
            }
        }
    }
}
