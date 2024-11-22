using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class DTOPessoaFisica : DTOCliente
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public int CodigoDoRepresentante { get; set; }
    }
}
