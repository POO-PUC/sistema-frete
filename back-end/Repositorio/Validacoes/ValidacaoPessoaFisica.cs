using DTO.DTOs;
using Repositorio.Repositorio;
using System;
using System.Text.RegularExpressions;

namespace Repositorio.Validacoes
{
    public class ValidacaoPessoaFisica
    {
        private readonly RepositorioPessoaFisica _repositorioPessoaFisica;

        public ValidacaoPessoaFisica()
        {
            _repositorioPessoaFisica = new RepositorioPessoaFisica();
        }

        public bool Valide(DTOPessoaFisica dtoPessoaFisica)
        {
            if (dtoPessoaFisica == null) return false;

            if (dtoPessoaFisica.Codigo <= 0)
            {
                Console.WriteLine("Erro: O código do cliente deve ser um número positivo.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoPessoaFisica.Nome))
            {
                Console.WriteLine("Erro: O nome é obrigatório.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoPessoaFisica.CPF))
            {
                Console.WriteLine("Erro: Formato de CPF inválido.");
                return false;
            }
            else if (_repositorioPessoaFisica.ExistePessoaFisica(dtoPessoaFisica.CPF))
            {
                Console.WriteLine("Erro: O número de CPF já existe.");
                return false;
            }

            if (dtoPessoaFisica.CodigoDoRepresentante <= 0)
            {
                Console.WriteLine("Erro: O código do representante deve ser um número positivo.");
                return false;
            }

            return true;
        }
    }
}
