using Dominio.Objeto;
using System.Collections.Generic;

namespace Repositorio.Repositorio.Interfaces
{
    public interface IRepositorioPessoaJuridica
    {
        void AdicionarPessoaJuridica(PessoaJuridica pessoaJuridica);

        void AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica);

        void DeletarPessoaJuridica(int id);

        PessoaJuridica ObterPessoaJuridicaPorId(int id);

        IList<PessoaJuridica> ObterTodasPessoasJuridicas();

        bool CNPJExiste(string cnpj);
    }
}
