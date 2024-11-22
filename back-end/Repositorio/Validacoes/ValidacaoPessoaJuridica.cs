using DTO.DTOs;
using Repositorio.Repositorio;
using System;
using System.Text.RegularExpressions;

namespace Repositorio.Validacoes
{
    public class ValidacaoPessoaJuridica
    {
        private readonly RepositorioPessoaJuridica _repositorioPessoaJuridica;

        public ValidacaoPessoaJuridica()
        {
            _repositorioPessoaJuridica = new RepositorioPessoaJuridica();
        }

        public bool Valide(DTOPessoaJuridica dtoPessoaJuridica)
        {
            if (dtoPessoaJuridica == null) return false;

            if (dtoPessoaJuridica.Codigo <= 0)
            {
                Console.WriteLine("Erro: O código do cliente deve ser um número positivo.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoPessoaJuridica.RazaoSocial))
            {
                Console.WriteLine("Erro: A razão social é obrigatória.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoPessoaJuridica.CNPJ))
            {
                Console.WriteLine("Erro: Formato de CNPJ inválido.");
                return false;
            }
            else if (_repositorioPessoaJuridica.ExistePessoaJuridica(dtoPessoaJuridica.CNPJ))
            {
                Console.WriteLine("Erro: O CNPJ já existe.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoPessoaJuridica.InscricaoEstadual))
            {
                Console.WriteLine("Erro: A inscrição estadual é obrigatória.");
                return false;
            }

            return true;
        }
    }
}
