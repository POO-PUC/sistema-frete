using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class DTOCliente
    {
        public int Codigo { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public DateTime DataDeInscricao { get; set; }
    }
}
