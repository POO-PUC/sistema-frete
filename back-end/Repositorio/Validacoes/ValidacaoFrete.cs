using DTO.DTOs;
using Repositorio.Repositorio;
using System;

namespace Repositorio.Validacoes
{
    public class ValidacaoFrete
    {
        private readonly RepositorioCidade _repositorioCidade;
        private readonly RepositorioFuncionario _repositorioFuncionario;
        private readonly RepositorioCliente _repositorioCliente;

        public ValidacaoFrete()
        {
            _repositorioCidade = new RepositorioCidade();
            _repositorioFuncionario = new RepositorioFuncionario();
            _repositorioCliente = new RepositorioCliente();
        }

        public bool Valide(DTOFrete dtoFrete)
        {
            if (dtoFrete == null) return false;

            if (dtoFrete.Codigo <= 0)
            {
                Console.WriteLine("Erro: O código do frete deve ser um número positivo.");
                return false;
            }

            if (dtoFrete.Peso < 0)
            {
                Console.WriteLine("Erro: O peso não pode ser negativo.");
                return false;
            }

            if (dtoFrete.Valor < 0)
            {
                Console.WriteLine("Erro: O valor não pode ser negativo.");
                return false;
            }

            if (dtoFrete.ICMS < 0)
            {
                Console.WriteLine("Erro: O ICMS não pode ser negativo.");
                return false;
            }

            if (dtoFrete.Pedagio < 0)
            {
                Console.WriteLine("Erro: O pedágio não pode ser negativo.");
                return false;
            }

            if (dtoFrete.DataInicio > DateTime.Now)
            {
                Console.WriteLine("Erro: A data de início não pode estar no futuro.");
                return false;
            }

            if (dtoFrete.CodigoDaCidadeDeOrigem <= 0 || dtoFrete.CodigoDaCidadeDeDestino <= 0)
            {
                Console.WriteLine("Erro: Os códigos das cidades de origem e destino devem ser números positivos.");
                return false;
            }

            //if (_repositorioCidade.ExisteCidade(dtoFrete.CodigoDaCidadeDeOrigem,))
            //{
            //    Console.WriteLine("Erro: A cidade de origem especificada não existe.");
            //    return false;
            //}

            //if (_repositorioCidade.ExisteCidade(dtoFrete.CodigoDaCidadeDeDestino))
            //{
            //    Console.WriteLine("Erro: A cidade de destino especificada não existe.");
            //    return false;
            //}

            if (dtoFrete.CodigoDoCliente <= 0 || dtoFrete.CodigoDoDestinatario <= 0 || dtoFrete.CodigoDoFuncionario <= 0)
            {
                Console.WriteLine("Erro: Os códigos do cliente, destinatário e funcionário devem ser números positivos.");
                return false;
            }

            if (_repositorioCliente.ExisteCliente(dtoFrete.CodigoDoCliente))
            {
                Console.WriteLine("Erro: O cliente especificado não existe.");
                return false;
            }

            if (_repositorioCliente.ExisteCliente(dtoFrete.CodigoDoDestinatario))
            {
                Console.WriteLine("Erro: O destinatário especificado não existe.");
                return false;
            }

            if (_repositorioFuncionario.ExisteFuncionario(dtoFrete.CodigoDoFuncionario))
            {
                Console.WriteLine("Erro: O funcionário especificado não existe.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoFrete.QuemPaga))
            {
                Console.WriteLine("Erro: A informação sobre quem paga é obrigatória.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoFrete.NumeroDeConhecimento))
            {
                Console.WriteLine("Erro: O número do documento do frete é obrigatório.");
                return false;
            }

            return true;
        }
    }
}
