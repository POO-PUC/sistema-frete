using Dominio.Objeto;
using System.Collections.Generic;

namespace Repositorio.Repositorio.Interfaces
{
    public interface IRepositorioFrete
    {
        void AdicionarFrete(Frete frete);

        void AtualizarFrete(Frete frete);

        void DeletarFrete(int id);

        Frete ObterFretePorId(int id);

        IList<Frete> ObterTodosFretes();
    }
}
