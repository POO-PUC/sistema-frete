using Dominio.Objeto;
using System.Collections.Generic;

namespace Repositorio.Repositorio.Interfaces
{
    public interface IRepositorioPessoaFisica
    {
        void AdicionarPessoaFisica(PessoaFisica pessoaFisica);

        void AtualizarPessoaFisica(PessoaFisica pessoaFisica);

        void DeletarPessoaFisica(int id);

        PessoaFisica ObterPessoaFisicaPorId(int id);

        IList<PessoaFisica> ObterTodasPessoasFisicas();
        
        bool CPFExiste(string cpf);
    }
}
