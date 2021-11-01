using Borboteca_Libros.AccessData.Queries.Repository;
using Borboteca_Libros.Domain.Entities;
using Borboteca_Libros.Domain.DTO;
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
    public class GeneroQuery : IGeneroQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler compiler;

        public GeneroQuery(IDbConnection dbConnection, Compiler sqlKata)
        {
            this.connection = dbConnection;
            this.compiler = sqlKata;
        }

        public Genero GetGenerosById(int id)
        {
            var db = new QueryFactory(connection, compiler);
            var genero = db.Query("Genero")
                .Where("Id", "=", id)
                .First<Genero>();
            return genero;
        }

        public GeneroDTO GetGenerosDTOById(int id)
        {
            Genero genero = GetGenerosById(id);
            GeneroDTO generoDTO = new GeneroDTO() { Descripcion = genero.Descripcion };
            return generoDTO;
        }

        public GeneroDTO GetGenerosDTOByName(string nombre)
        {
            var db = new QueryFactory(connection, compiler);
            var genero = db.Query("Genero")
                .Where("Descripcion", "=", nombre)
                .First<Genero>();
            GeneroDTO generoDTO = new GeneroDTO() { Descripcion = genero.Descripcion };
            return generoDTO;
        }
    }
}
