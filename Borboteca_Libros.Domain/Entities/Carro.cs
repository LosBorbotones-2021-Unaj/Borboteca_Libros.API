using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.Entities
{
    public class Carro
    {
        public int Id { get; set; }

        public float Valor { get; set; }

        public Boolean Activo { get; set; }

        public int Usuarioid { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public virtual List<Ventas> Ventas { get; set; }
    }
}
