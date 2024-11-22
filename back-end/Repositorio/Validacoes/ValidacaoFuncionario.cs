using DTO.DTOs;
using Repositorio.Repositorio;
using System;

namespace Repositorio.Validacoes
{
    public class ValidacaoFuncionario
    {
        private readonly RepositorioFuncionario _repositorioFuncionario;

        public ValidacaoFuncionario()
        {
            _repositorioFuncionario = new RepositorioFuncionario();
        }

        public bool Valide(DTOFuncionario dtoFuncionario)
        {
            if (dtoFuncionario == null) return false;

            if (dtoFuncionario.Codigo <= 0)
            {
                Console.WriteLine("Erro: O código do funcionário deve ser um número positivo.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoFuncionario.Nome))
            {
                Console.WriteLine("Erro: O nome do funcionário é obrigatório.");
                return false;
            }

            if (dtoFuncionario.NumeroDeRegistro <= 0)
            {
                Console.WriteLine("Erro: O número de registro deve ser um número positivo.");
                return false;
            }

            if (_repositorioFuncionario.ExisteFuncionario(dtoFuncionario.Codigo))
            {
                Console.WriteLine("Erro: O Funcionário já existe.");
                return false;
            }

            return true;
        }
    }
}
