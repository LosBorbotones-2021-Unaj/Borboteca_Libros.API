using Borboteca_Libros.AccessData.Queries.Repository;
using Borboteca_Libros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.AccessData.Validations
{
    public class ValidarGenero
    {
        public int[] _listarGeneros;
        private readonly IGeneroQuery _query;
        public ValidarGenero(int[] generos, IGeneroQuery query) 
        {
            this._listarGeneros = generos;
            this._query = query;
        }
        public List<Genero> Verify() 
        {
            List<Genero> genero = new List<Genero>();
            foreach(int objeto in _listarGeneros) 
            {
                var _genero = _query.GetGenerosById(objeto);
                var generoNuevo = new Genero
                {
                    Id = _genero.Id,
                    Descripcion = _genero.Descripcion
                };
                genero.Add(generoNuevo);
            }
            return genero;
        }
    }
}
