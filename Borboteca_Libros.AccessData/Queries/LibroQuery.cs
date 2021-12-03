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
                        .Join("Autor", "Autor.Id", "Libro.AutorId")
                        .Select("Libro.Id", "Libro.Titulo", "Libro.Resenia", "Libro.Editorial", "Libro.FechaDePublicacion", "Libro.Imagen", "Libro.Pach", "Libro.Precio", "Autor.NombreCompleto AS NombreAutor")
                        .Where("Libro.Id", "=", id)
                        .FirstOrDefault<LibroConAutorDTO>();
            var fecha = libroConAutor.FechaDePublicacion.ToShortDateString();
            DateTime fechaCorta = Convert.ToDateTime(fecha);
            var retornador = new LibroConAutorDTO() {
                Id = libroConAutor.Id,
                Titulo = libroConAutor.Titulo,
                Resenia = libroConAutor.Resenia,
                Editorial = libroConAutor.Editorial,
                FechaDePublicacion = fechaCorta,
                Imagen = libroConAutor.Imagen,
                Pach = libroConAutor.Pach,
                Precio = libroConAutor.Precio,
                NombreAutor = libroConAutor.NombreAutor
            };
            return retornador;
          
        }

        public List<LibrosMuestra> PedirLibros(int Indice)
        {
            int index = ((Indice - 1) * 8);
            var db = new QueryFactory(connection, SqlKata);
            var libro = db.Query("Libro").Limit(8).Offset(index);
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
                .Select("Titulo", "Editorial", "Resenia", "Genero.Descripcion AS NombreGenero", "Imagen", "Libro.Id", "Precio", "Autor.NombreCompleto")
                .WhereContains("Genero.Descripcion", busqueda)
                .OrWhereContains("Libro.Titulo" , busqueda)
                .OrWhereContains("Libro.Editorial", busqueda)
                .OrWhereContains("Autor.NombreCompleto", busqueda)
                .Get<LibroBusquedaDTO>();

            return result.ToList();
        }
        public List<LibroBusquedaDTO> BuscarLibros (string nombre)
        {
            var db = new QueryFactory(connection, SqlKata);
            var result = db.Query("Libro")
                .Select("Titulo", "Imagen", "Id")
                .WhereContains("Libro.Titulo", nombre)
                .Get<LibroBusquedaDTO>();
            return result.ToList();
        }

        public int ContadorLibros() 
        {
            var db = new QueryFactory(connection, SqlKata);
            var libro = db.Query("Libro").Select();
            var result = libro.Get<LibrosMuestra>().Count();
            return result;

        }
    }
}
