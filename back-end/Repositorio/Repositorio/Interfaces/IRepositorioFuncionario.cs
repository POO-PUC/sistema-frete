using Dominio.Objeto;
using System.Collections.Generic;

namespace Repositorio.Repositorio.Interfaces
{
    public interface IRepositorioFuncionario
    {
        void AdicionarFuncionario(Funcionario funcionario);

        void AtualizarFuncionario(Funcionario funcionario);

        void DeletarFuncionario(int id);

        Funcionario ObterFuncionarioPorId(int id);

        IList<Funcionario> ObterTodosFuncionarios();
        bool NumeroDeRegistroExiste(int registryNumber);
    }
}
