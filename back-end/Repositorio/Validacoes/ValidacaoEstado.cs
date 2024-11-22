using DTO.DTOs;
using Repositorio.Repositorio;
using System;

namespace Repositorio.Validacoes
{
    public class ValidacaoEstado
    {
        private readonly RepositorioEstado _repositorioEstado;

        public ValidacaoEstado()
        {
            _repositorioEstado = new RepositorioEstado();
        }

        public bool Valide(DTOEstado dtoEstado)
        {
            if (dtoEstado == null) return false;

            if (dtoEstado.Codigo <= 0)
            {
                Console.WriteLine("Erro: O código do estado deve ser um número positivo.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoEstado.Nome))
            {
                Console.WriteLine("Erro: O nome do estado é obrigatório.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtoEstado.Uf))
            {
                Console.WriteLine("Erro: A UF é obrigatória.");
                return false;
            }

            if (dtoEstado.ICMSLocal < 0 || dtoEstado.ICMSLocal > 100)
            {
                Console.WriteLine("Erro: O ICMS local deve estar entre 0 e 100.");
                return false;
            }

            if (dtoEstado.ICMSExterno < 0 || dtoEstado.ICMSExterno > 100)
            {
                Console.WriteLine("Erro: O ICMS externo deve estar entre 0 e 100.");
                return false;
            }

            return true;
        }
    }
}
