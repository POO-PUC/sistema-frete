using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Validacoes;
using System;

namespace Repositorio.Conversor
{
    public static class ConversorFuncionario
    {
        public static DTOFuncionario ConverterParaDTO(Funcionario funcionario)
        {
            if (funcionario == null) return null;

            var dtoFuncionario = new DTOFuncionario();

            dtoFuncionario.Codigo = funcionario.Codigo;
            dtoFuncionario.Nome = funcionario.Nome;
            dtoFuncionario.NumeroDeRegistro = funcionario.NumeroDeRegistro;

            return dtoFuncionario;
        }

        public static Funcionario ConverterParaDominio(DTOFuncionario dtoFuncionario)
        {
            if (dtoFuncionario == null) return null;

            var funcionario = new Funcionario();

            var validacaoFuncionario = new ValidacaoFuncionario();

            
                funcionario.Codigo = dtoFuncionario.Codigo;
                funcionario.Nome = dtoFuncionario.Nome;
                funcionario.NumeroDeRegistro = dtoFuncionario.NumeroDeRegistro;
            

            return funcionario;
        }
    }
}
