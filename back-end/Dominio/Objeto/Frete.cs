using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objeto
{
    public class Frete
    {
        public int Codigo { get; set; }

        public float Peso { get; set; }

        public float Valor { get; set; }

        public float ICMS { get; set; }

        public float Pedagio { get; set; }

        public DateTime DataInicio { get; set; }

        public int CodigoDaCidadeDeOrigem { get; set; }

        public int CodigoDaCidadeDeDestino { get; set; }

        public int CodigoDoCliente { get; set; }

        public int CodigoDoDestinatario { get; set; }

        public int CodigoDoFuncionario { get; set; }

        public string QuemPaga { get; set; }

        public string NumeroDeConhecimento { get; set; }
    }
}
