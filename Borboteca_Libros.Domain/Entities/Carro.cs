using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.Entities
{
    public class Carro
    {
        public int CarroId { get; set; }

        public float Valor { get; set; }

        public string Activo { get; set; }

        public int UsuarioId { get; set; }

        public Usuario UsuarioNavigator { get; set; }

        public ICollection<Ventas> ListaVentas { get; set; }

    }
}
