using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Validacoes;
using System;

namespace Repositorio.Conversor
{
    public static class ConversorPessoaFisica
    {
        public static DTOPessoaFisica ConverterParaDTO(PessoaFisica pessoaJuridica)
        {
            if (pessoaJuridica == null) return null;

            var dtoPessoaFisica = new DTOPessoaFisica();

            dtoPessoaFisica.CPF = pessoaJuridica.CPF;
            dtoPessoaFisica.Codigo = pessoaJuridica.Codigo;
            dtoPessoaFisica.DataDeInscricao = pessoaJuridica.DataDeInscricao;
            dtoPessoaFisica.Endereco = pessoaJuridica.Endereco;
            dtoPessoaFisica.Telefone = pessoaJuridica.Telefone;
            dtoPessoaFisica.Nome = pessoaJuridica.Nome;

            return dtoPessoaFisica;
        }

        public static PessoaFisica ConverterParaDominio(DTOPessoaFisica dtoPessoaFisica)
        {
            if (dtoPessoaFisica == null) return null;

            var pessoaFisica = new PessoaFisica();

            var validacaoPessoaFisica = new ValidacaoPessoaFisica();

           
                pessoaFisica.CPF = dtoPessoaFisica.CPF;
                pessoaFisica.Codigo = dtoPessoaFisica.Codigo;
                pessoaFisica.DataDeInscricao = dtoPessoaFisica.DataDeInscricao;
                pessoaFisica.Endereco = dtoPessoaFisica.Endereco;
                pessoaFisica.Telefone = dtoPessoaFisica.Telefone;
                pessoaFisica.Nome = dtoPessoaFisica.Nome;
           

            return pessoaFisica;
        }
    }
}
