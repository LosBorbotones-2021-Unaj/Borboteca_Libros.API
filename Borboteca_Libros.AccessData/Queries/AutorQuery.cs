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
    public class AutorQuery : IAutorQuery
    {

        private readonly IDbConnection connection;
        private readonly Compiler SqlKata;
        public AutorQuery(IDbConnection connection, Compiler sqlKata)
        {
            this.connection = connection;
            this.SqlKata = sqlKata;
        }
        public List<Autor> ObtenerListaDeAutores()
        {
            var db = new QueryFactory(connection, SqlKata);
            var autor = db.Query("Autor").Select("NombreAutor", "ApellidoAutor", "Id");
            var retornador = autor.Get<Autor>();
            return retornador.ToList();

        }
        public Autor ObtenerAutorPorid(int id)
        {
            var db = new QueryFactory(connection, SqlKata);
            var autor = db.Query("Autor").Select("NombreAutor", "ApellidoAutor", "Id").Where("Autor.Id", "=", id).FirstOrDefault<Autor>();
            return autor;
        }
        public List<Autor> ObtenerAutorPorNombre(string nombre)
        {
            var db = new QueryFactory(connection, SqlKata);
            var autor = db.Query("Autor").Select("NombreAutor", "ApellidoAutor", "Id").Where("Autor.NombreAutor", "=", nombre);
            var retornador = autor.Get<Autor>();
            return retornador.ToList();
        }
    }
}
