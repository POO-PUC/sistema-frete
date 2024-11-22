using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objeto
{
    public class Cidade
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public int CodigoDoEstado { get; set; }

        public float PrecoPadrao { get; set; }

    }
}