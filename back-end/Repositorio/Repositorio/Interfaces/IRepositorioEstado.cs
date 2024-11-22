using Dominio.Objeto;
using System.Collections.Generic;

namespace Repositorio.Repositorio.Interfaces
{
    public interface IRepositorioEstado
    {
        void AdicionarEstado(Estado estado);

        void AtualizarEstado(Estado estado);

        void DeletarEstado(int id);

        Estado ObterEstadoPorId(int id);

        IList<Estado> ObterTodosEstados();

        bool EstadoExiste(string nomeEstado, string uf);
    }
}

