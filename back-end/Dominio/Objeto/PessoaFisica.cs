using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objeto
{
    public class PessoaFisica : Cliente
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public int? CodigoDoRepresentante { get; set; }
    }
}
