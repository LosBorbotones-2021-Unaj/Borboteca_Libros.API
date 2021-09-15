using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borboteca_Libros.Domain.Entities
{
    public class Ventas
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Comprobante { get; set; }

        public string estado { get; set; }

        public Carro Carro { get; set; }

    }
}
