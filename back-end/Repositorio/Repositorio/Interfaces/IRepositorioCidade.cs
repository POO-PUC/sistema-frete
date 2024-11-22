using Dominio.Objeto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio.Interfaces
{
    public interface IRepositorioCidade
    {
        void AdicionarCidade(Cidade cidade);
       
        void AtualizarCidade(Cidade cidade);

        void DeletarCidade(int id);

        Cidade ObterCidadePorId(int id);

        IList<Cidade> ObterTodasCidades();

        bool CidadeExiste(string nomeCidade, int codigoEstado);
    }
}
