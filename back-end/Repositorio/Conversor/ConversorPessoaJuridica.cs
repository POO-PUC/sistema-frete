using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Validacoes;
using System;

namespace Repositorio.Conversor
{
    public static class ConversorPessoaJuridica
    {   
        public static DTOPessoaJuridica ConverterParaDTO(PessoaJuridica pessoaJuridica)
        {
            if (pessoaJuridica == null) return null;

            var dtoPessoaJuridica = new DTOPessoaJuridica();    

            dtoPessoaJuridica.CNPJ = pessoaJuridica.CNPJ;
            dtoPessoaJuridica.Codigo = pessoaJuridica.Codigo;
            dtoPessoaJuridica.DataDeInscricao = pessoaJuridica.DataDeInscricao;
            dtoPessoaJuridica.EhRepresentante = pessoaJuridica.EhRepresentante;
            dtoPessoaJuridica.Endereco = pessoaJuridica.Endereco;
            dtoPessoaJuridica.InscricaoEstadual = pessoaJuridica.InscricaoEstadual;
            dtoPessoaJuridica.RazaoSocial = pessoaJuridica.RazaoSocial;
            dtoPessoaJuridica.Telefone = pessoaJuridica.Telefone;
            
            return dtoPessoaJuridica;
        }

        public static PessoaJuridica ConverterParaDominio(DTOPessoaJuridica dtoPessoaJuridica)
        {
            if(dtoPessoaJuridica == null) return null;

            var pessoaJuridica = new PessoaJuridica();

            var validacaoPessoaJuridica = new ValidacaoPessoaJuridica();

           
                pessoaJuridica.CNPJ = dtoPessoaJuridica.CNPJ;
                pessoaJuridica.Codigo = dtoPessoaJuridica.Codigo;
                pessoaJuridica.DataDeInscricao = dtoPessoaJuridica.DataDeInscricao;
                pessoaJuridica.EhRepresentante = dtoPessoaJuridica.EhRepresentante;
                pessoaJuridica.Endereco = dtoPessoaJuridica.Endereco;
                pessoaJuridica.InscricaoEstadual = dtoPessoaJuridica.InscricaoEstadual;
                pessoaJuridica.RazaoSocial = dtoPessoaJuridica.RazaoSocial;
                pessoaJuridica.Telefone = dtoPessoaJuridica.Telefone;
            

            return pessoaJuridica;
        }
    }
}
