using DTO.DTOs;
using Repositorio.Repositorio;
using System;

namespace Repositorio.Validacoes
{
    public class ValidacaoCliente
    {
        private readonly RepositorioCliente _repositorioCliente;

        public ValidacaoCliente()
        {
            _repositorioCliente = new RepositorioCliente();
        }

        public bool Valide(DTOCliente dtoCliente)
        {
            if (dtoCliente == null) return false;

            if (dtoCliente.Codigo <= 0)
            {
                Console.WriteLine("Erro: O código do cliente deve ser um número positivo.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoCliente.Endereco))
            {
                Console.WriteLine("Erro: O endereço é obrigatório.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoCliente.Telefone))
            {
                Console.WriteLine("Erro: O número de telefone é obrigatório.");
                return false;
            }

            if (dtoCliente.DataDeInscricao > DateTime.Now)
            {
                Console.WriteLine("Erro: A data de inscrição não pode estar no futuro.");
                return false;
            }

            if (_repositorioCliente.ExisteCliente(dtoCliente.Codigo))
            {
                Console.WriteLine("Erro: O cliente já existe.");
                return false;
            }

            return true;
        }
    }
}
