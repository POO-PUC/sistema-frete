using Dominio.Objeto;
using System.Collections.Generic;

namespace Repositorio.Repositorio.Interfaces
{
    public interface IRepositorioCliente
    {
        void AdicionarCliente(Cliente cliente);

        void AtualizarCliente(Cliente cliente);

        void DeletarCliente(int id);

        Cliente ObterClientePorId(int id);

        IList<Cliente> ObterTodosClientes();

        bool ClienteExiste(int cod);
    }
}

