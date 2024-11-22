using DTO.DTOs;
using Repositorio.Repositorio;
using System;

namespace Repositorio.Validacoes
{
    public class ValidacaoCidade
    {
        private readonly RepositorioCidade _repositorioCidade;
        private readonly RepositorioEstado _repositorioEstado;

        public ValidacaoCidade()
        {
            _repositorioCidade = new RepositorioCidade();
        }

        public bool Valide(DTOCidade dtoCidade)
        {

            if (string.IsNullOrWhiteSpace(dtoCidade.Nome))
            {
                Console.WriteLine("Erro: O nome da cidade é obrigatório.");
                return false;
            }

            if (dtoCidade.PrecoPadrao < 0)
            {
                Console.WriteLine("Erro: O preço padrão não pode ser negativo.");
                return false;
            }

            if (_repositorioEstado.ExisteEstado(dtoCidade.CodigoDoEstado))
            {
                Console.WriteLine("Erro: O Estado da Cidade em questão não existe.");
                return false;
            }

            

            if(dtoCidade.Codigo <=0)
            {
                Console.WriteLine("Erro: O código da Cidade deve ser um número positivo.");
                return false;
            }

            if(dtoCidade.CodigoDoEstado <= 0)
            {
                Console.WriteLine("Erro:O código do Estado deve ser um número positivo.");
                return false;
            }

            return true;
        }
    }
}
