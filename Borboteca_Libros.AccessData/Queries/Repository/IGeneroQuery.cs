using Borboteca_Libros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borboteca_Libros.Domain.DTO;

namespace Borboteca_Libros.AccessData.Queries.Repository
{
    public interface IGeneroQuery
    {
        public Genero GetGenerosById(int id);
        public GeneroDTO GetGenerosDTOById(int id);
        public GeneroDTO GetGenerosDTOByName(string nombre);
        public List<GeneroDTO> GetGenero();
    }
}
