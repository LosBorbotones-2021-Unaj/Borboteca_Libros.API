using Borboteca_Libros.AccessData.Queries.Repository;
using Borboteca_Libros.Domain.DTO;
using Borboteca_Libros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Queries
{
    public class LibroQuery : ILibroQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;
        public LibroQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            this.SqlKata = sqlKata;
        }
        public LibroConAutorDTO GetPathLibro(Guid id)
        {
            var db = new QueryFactory(connection, SqlKata);

            var libroConAutor = db.Query("Libro")
                        .Select("Libro.Id", "Libro.Titulo", "Libro.Resenia", "Libro.Editorial", "Libro.FechaDePublicacion", "Libro.Imagen", "Libro.Pach", "Libro.Precio", "Autor.NombreCompleto AS NombreAutor")
                        .Where("Libro.Id", "=", id)
                        .Join("Autor", "Autor.Id", "Libro.AutorId").FirstOrDefault<LibroConAutorDTO>();
                        
            return libroConAutor;
          
        }

        public List<LibrosMuestra> PedirLibros()
        {
            var db = new QueryFactory(connection, SqlKata);
            var libro = db.Query("Libro");
            var result = libro.Get<LibrosMuestra>();
            return result.ToList();
        }

        public List<LibroBusquedaDTO> PedirLibrosPorBusqueda(string busqueda)
        {
            var db = new QueryFactory(connection, SqlKata);
            var result = db.Query("LibroGenero")
                .Join("Genero", "Genero.Id", "LibroGenero.GeneroId")
                .Join("Libro", "Libro.Id", "LibroGenero.LibroId")
                .Join("Autor", "Autor.Id", "Libro.AutorId")
                .Select("Titulo", "Editorial", "Resenia", "Genero.Descripcion AS NombreGenero")
                .WhereContains("Genero.Descripcion", busqueda)
                .OrWhereContains("Libro.Titulo" , busqueda)
                .OrWhereContains("Libro.Editorial", busqueda)
                .OrWhereContains("Autor.NombreCompleto", busqueda)
                .Get<LibroBusquedaDTO>();


            return result.ToList();
        }
    }
}
