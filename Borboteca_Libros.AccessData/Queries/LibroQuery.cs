using Borboteca_Libros.AccessData.Queries.Repository;
using Borboteca_Libros.Domain.DTO;
using Borboteca_Libros.Domain.Entities;
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
        public Libro GetPathLibro(Guid id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var libro = db.Query("Libro").Select("Id","Titulo","Resenia","Editorial","FechaDePublicacion","Imagen","Pach","Precio").Where("Libro.Id", "=", id).FirstOrDefault<Libro>();
            return libro;
        }

        public List<LibrosMuestra> PedirLibros()
        {
            var db = new QueryFactory(connection, SqlKata);
            var libro = db.Query("Libro");
            var result = libro.Get<LibrosMuestra>();
            return result.ToList();
        }
    }
}
